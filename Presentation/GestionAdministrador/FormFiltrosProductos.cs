using Business;
using Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Presentation
{
    /// <summary>
    /// Ventana modal de filtros avanzados para el listado de productos.
    /// Devuelve los filtros elegidos vía propiedades públicas cuando el
    /// resultado es DialogResult.OK.
    /// </summary>
    public partial class FormFiltrosProductos : Form
    {
        private readonly CategoriaBusiness categoriaBusiness = new CategoriaBusiness();

        // Valores sentinela para la opción "Todos/Todas" de cada combo.
        private const int FILTRO_TODAS_CATEGORIAS = 0;

        public enum FiltroEstado { Todos, Activo, Inactivo }
        public enum FiltroStock { Todos, SinStock, Critico }

        /// <summary>
        /// Id de categoría elegida, o null si se eligió "Todas".
        /// </summary>
        public int? CategoriaIdSeleccionada { get; private set; }
        public FiltroEstado EstadoSeleccionado { get; private set; } = FiltroEstado.Todos;
        public FiltroStock StockSeleccionado { get; private set; } = FiltroStock.Todos;

        public FormFiltrosProductos(int? categoriaActual, FiltroEstado estadoActual, FiltroStock stockActual)
        {
            InitializeComponent();
            Diseno.FormatearModal(this);

            CategoriaIdSeleccionada = categoriaActual;
            EstadoSeleccionado = estadoActual;
            StockSeleccionado = stockActual;
        }

        private void FormFiltrosProductos_Load(object sender, EventArgs e)
        {
            CargarCombos();
            PreseleccionarValoresActuales();
        }

        private void CargarCombos()
        {
            var categorias = categoriaBusiness.ObtenerCategoriasActivas().ToList();
            categorias.Insert(0, new Categoria { Id = FILTRO_TODAS_CATEGORIAS, Nombre = "Todas" });
            CBCategoriaFiltro.DataSource = categorias;
            CBCategoriaFiltro.DisplayMember = "Nombre";
            CBCategoriaFiltro.ValueMember = "Id";

            CBEstadoFiltro.DataSource = Enum.GetValues(typeof(FiltroEstado));
            CBStockFiltro.DataSource = Enum.GetValues(typeof(FiltroStock));
        }

        private void PreseleccionarValoresActuales()
        {
            CBCategoriaFiltro.SelectedValue = CategoriaIdSeleccionada ?? FILTRO_TODAS_CATEGORIAS;
            CBEstadoFiltro.SelectedItem = EstadoSeleccionado;
            CBStockFiltro.SelectedItem = StockSeleccionado;
        }

        private void BAplicarFiltros_Click(object sender, EventArgs e)
        {
            int categoriaElegida = (int)CBCategoriaFiltro.SelectedValue;
            CategoriaIdSeleccionada = categoriaElegida == FILTRO_TODAS_CATEGORIAS ? (int?)null : categoriaElegida;

            EstadoSeleccionado = (FiltroEstado)CBEstadoFiltro.SelectedItem;
            StockSeleccionado = (FiltroStock)CBStockFiltro.SelectedItem;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BLimpiarFiltros_Click(object sender, EventArgs e)
        {
            CBCategoriaFiltro.SelectedValue = FILTRO_TODAS_CATEGORIAS;
            CBEstadoFiltro.SelectedItem = FiltroEstado.Todos;
            CBStockFiltro.SelectedItem = FiltroStock.Todos;
        }

        private void BCancelarFiltros_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LCruzFiltros_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}