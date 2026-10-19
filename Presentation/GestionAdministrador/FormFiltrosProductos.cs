using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentation
{
    /// <summary>
    /// Ventana modal de filtros avanzados para el catálogo de productos (Categoría, Estado y Stock).
    /// </summary>
    public partial class FormFiltrosProductos : Form
    {
        #region Constantes y Servicios
        private readonly CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        private const int FILTRO_TODAS_CATEGORIAS = 0; // Valor sentinela para representar la opción "Todas" en el ComboBox de categorías.

        // Enumeraciones de Filtro
        public enum FiltroEstado {Todos, Activo, Inactivo} // Opciones de filtrado por estado
        public enum FiltroStock {Todos, SinStock, Critico} // Opciones de filtrado por stock

        //Propiedades de Filtro Seleccionado
        public int? CategoriaIdSeleccionada { get; private set; } // Identificador de la categoría seleccionada
        public FiltroEstado EstadoSeleccionado { get; private set; } = FiltroEstado.Todos; // Estado de actividad seleccionado en el filtro.
        public FiltroStock StockSeleccionado { get; private set; } = FiltroStock.Todos; // Condición de stock seleccionada en el filtro.
        #endregion

        public FormFiltrosProductos(int? categoriaActual, FiltroEstado estadoActual, FiltroStock stockActual)
        {
            InitializeComponent();
            Diseno.FormatearModal(this);
            Diseno.FormatearBotonPrimario(BAplicarFiltros);
            Diseno.FormatearBotonSecundario(BLimpiarFiltros);

            CategoriaIdSeleccionada = categoriaActual;
            EstadoSeleccionado = estadoActual;
            StockSeleccionado = stockActual;
        }

        #region Ciclo de Vida del Formulario

        /// <summary>
        /// Llena los desplegables con datos, restaura los valores vigentes y
        /// enfoca el primer control para evitar resaltados múltiples simultáneos.
        /// </summary>
        private void FormFiltrosProductos_Load(object sender, EventArgs e)
        {
            CargarCombos();
            PreseleccionarValoresActuales();
            this.ActiveControl = CBCategoriaFiltro;
        }

        #endregion

        #region Carga y Preselección de Datos

        /// <summary>
        /// Obtiene las categorías e inicializa los orígenes de datos de cada ComboBox.
        /// </summary>
        private void CargarCombos()
        {
            try
            {
                var categoriasActivas = categoriaBusiness.ObtenerCategoriasActivas() ?? new List<Categoria>();
                var listaCategorias = new List<Categoria>
                {
                    new Categoria 
                    { 
                        Id = FILTRO_TODAS_CATEGORIAS, 
                        Nombre = "Todas", 
                        Codigo = "TODAS", 
                        Descripcion = string.Empty,
                        Activo = true 
                    }
                };
                listaCategorias.AddRange(categoriasActivas);

                CBCategoriaFiltro.DisplayMember = "Nombre";
                CBCategoriaFiltro.ValueMember = "Id";
                CBCategoriaFiltro.DataSource = listaCategorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al cargar las categorías disponibles: " + ex.Message,
                    "Error al cargar filtros",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            CBEstadoFiltro.DataSource = Enum.GetValues(typeof(FiltroEstado));
            CBStockFiltro.DataSource = Enum.GetValues(typeof(FiltroStock));
        }

        /// <summary>
        /// Establece la selección de cada ComboBox.
        /// </summary>
        private void PreseleccionarValoresActuales()
        {
            CBCategoriaFiltro.SelectedValue = CategoriaIdSeleccionada ?? FILTRO_TODAS_CATEGORIAS;
            CBEstadoFiltro.SelectedItem = EstadoSeleccionado;
            CBStockFiltro.SelectedItem = StockSeleccionado;
        }

        #endregion

        #region Eventos de Botones

        /// <summary>
        /// Guarda las opciones seleccionadas en las propiedades públicas y cierra el modal con OK.
        /// </summary>
        private void BAplicarFiltros_Click(object sender, EventArgs e)
        {
            if (CBCategoriaFiltro.SelectedValue is int categoriaElegida && categoriaElegida != FILTRO_TODAS_CATEGORIAS)
            {
                CategoriaIdSeleccionada = categoriaElegida;
            }
            else
            {
                CategoriaIdSeleccionada = null;
            }

            if (CBEstadoFiltro.SelectedItem is FiltroEstado estado)
            {
                EstadoSeleccionado = estado;
            }

            if (CBStockFiltro.SelectedItem is FiltroStock stock)
            {
                StockSeleccionado = stock;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Restablece todos los desplegables al valor por defecto ("Todas" / "Todos").
        /// </summary>
        private void BLimpiarFiltros_Click(object sender, EventArgs e)
        {
            CBCategoriaFiltro.SelectedValue = FILTRO_TODAS_CATEGORIAS;
            CBEstadoFiltro.SelectedItem = FiltroEstado.Todos;
            CBStockFiltro.SelectedItem = FiltroStock.Todos;
        }

        /// <summary>
        /// Cancela la operación sin aplicar cambios y cierra el modal.
        /// </summary>
        private void BCancelarFiltros_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Cierra el formulario modal al hacer clic en la cruz superior derecha ('X').
        /// </summary>
        private void LCruzFiltros_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}