using Business;
using Entities;
using Presentation.GestionVentas;
using Presentation.GestionAdministrador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Presentation
{
    public partial class FormProductos : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
        private readonly ProductoBusiness productoBusiness = new ProductoBusiness();
        private readonly CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        // Variables de Paginación
        private int paginaActual = 1;
        private int totalPaginas = 1;
        private int filaEnEdicionIndex = -1;
        // Filtros avanzados
        private int? filtroCategoriaId = null;
        private FormFiltrosProductos.FiltroEstado filtroEstado = FormFiltrosProductos.FiltroEstado.Todos;
        private FormFiltrosProductos.FiltroStock filtroStock = FormFiltrosProductos.FiltroStock.Todos;

        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(TLPCards);
            Diseno.FormatearBotonPrimario(BAnterior);
            Diseno.FormatearBotonPrimario(BSiguiente);
            Diseno.FormatearBotonFiltro(BFiltros);
            ConfigurarColumnasGrid();
            CargarProductos();
            CargarIndicadoresCards();
            SendMessage(TBBuscar.Handle, EM_SETCUEBANNER, 0, "Buscar por nombre o código  ...");

        }

        #region Configuración de grilla y carga de cards
        /// <summary>
        /// Configura las columnas del DataGridView para mostrar los productos, incluyendo botones de acción para ver detalles y editar.
        /// </summary>
        private void ConfigurarColumnasGrid()
        {
            Diseno.FormatearGrilla(DGVProductos, soloLectura: false);
            DGVProductos.EditMode = DataGridViewEditMode.EditProgrammatically;

            DGVProductos.AutoGenerateColumns = false;
            DGVProductos.AllowUserToAddRows = false;
            DGVProductos.Columns.Clear();

            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", Visible = false });
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Código", Name = "colCodigo", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 100, ReadOnly = true });
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre", Name = "colNombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 220, ReadOnly = true });
            var colCategoria = new DataGridViewComboBoxColumn
            {
                Name = "colCategoria",
                HeaderText = "Categoría",
                DataPropertyName = "CategoriaId",
                DataSource = categoriaBusiness.ObtenerCategoriasActivas(),
                DisplayMember = "Nombre",
                ValueMember = "Id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 150,
                ReadOnly = true
            };
            DGVProductos.Columns.Add(colCategoria);
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Precio", HeaderText = "Precio", Name = "colPrecio", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 100, ReadOnly = true, DefaultCellStyle = { Format = "C2"} });
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = "Stock", Name = "colStock", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 70, ReadOnly = true });
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StockMinimo", HeaderText = "Stock Mín.", Name = "colStockMinimo", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 70, ReadOnly = true});
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EstadoTexto", HeaderText = "Estado", Name = "colEstado", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 90, ReadOnly = true});
            DGVProductos.Columns.Add(new DataGridViewImageColumn { Name = "colAccionEditar", HeaderText = "Editar", ImageLayout = DataGridViewImageCellLayout.Normal, FillWeight = 80 });
            DGVProductos.Columns.Add(new DataGridViewImageColumn { Name = "colAccionEstado", HeaderText = "Eliminar", ImageLayout = DataGridViewImageCellLayout.Normal, FillWeight = 90 });
            DGVProductos.CellFormatting += DGVProductos_CellFormatting;
        }

        /// <summary>
        /// Carga los valores de las 4 tarjetas KPI.
        /// </summary>
        private void CargarIndicadoresCards()
        {
            string busqueda = TBBuscar.Text.Trim();
            bool? soloActivos = ObtenerFiltroSoloActivos();

            LTotalProductos.Text = productoBusiness.ContarProductosActivos(busqueda, filtroCategoriaId, soloActivos).ToString();
            LProdSinStock.Text = productoBusiness.ContarProductosSinStock(busqueda, filtroCategoriaId, soloActivos).ToString();
            LProdStockCritico.Text = productoBusiness.ContarProductosStockCritico(busqueda, filtroCategoriaId, soloActivos).ToString();
            LProdValorInventario.Text = productoBusiness.ObtenerValorInventario(busqueda, filtroCategoriaId, soloActivos).ToString("C2");
        }

        #endregion

        #region Carga y filtros
        /// <summary>
        /// Carga los productos activos con stock disponible.
        /// </summary>
        private void CargarProductos()
        {
            string busqueda = TBBuscar.Text.Trim();
            bool? soloActivos = ObtenerFiltroSoloActivos();
            string filtroStockTexto = filtroStock == FormFiltrosProductos.FiltroStock.Todos ? null : filtroStock.ToString();

            var lista = productoBusiness.ObtenerProductosPaginadosAdmin(
                busqueda, filtroCategoriaId, soloActivos, filtroStockTexto,
                paginaActual, out totalPaginas, out string mensajeError);

            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DGVProductos.DataSource = null;
            DGVProductos.DataSource = lista;

            filaEnEdicionIndex = -1;
            ActualizarControlesPaginacion();
        }

        /// <summary>
        /// Calcula icono del botón Eliminar/Activar y Editar/Guardar en cada repintado.
        /// </summary>
        private void DGVProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = DGVProductos.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "colAccionEditar")
            {
                bool estaEnEdicion = e.RowIndex == filaEnEdicionIndex;
                e.Value = estaEnEdicion ? Properties.Resources.guardar : Properties.Resources.editar;
                e.FormattingApplied = true;
            }
            else if (nombreColumna == "colAccionEstado")
            {
                if (!(DGVProductos.Rows[e.RowIndex].DataBoundItem is Producto producto)) return;

                e.Value = producto.Activo ? Properties.Resources.eliminar : Properties.Resources.activar;
                e.FormattingApplied = true;
            }
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            CargarProductos();
            CargarIndicadoresCards();
        }

        /// <summary>
        /// Actualiza la etiqueta de paginación y habilita/deshabilita los botones de navegación según la página actual y el total de páginas.
        /// </summary>
        private void ActualizarControlesPaginacion()
        {
            LPaginas.Text = $"Página {paginaActual} de {totalPaginas}";
            BAnterior.Enabled = paginaActual > 1;
            BSiguiente.Enabled = paginaActual < totalPaginas;
        }
        private void BAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                CargarProductos();
            }
        }
        private void BSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                CargarProductos();
            }
        }
        #endregion

        #region Edición in-place y baja/alta
        /// <summary>
        /// Determina si se hizo clic en los botones de acción "Editar/Guardar" o "Eliminar/Activar".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = DGVProductos.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "colAccionEditar")
            {
                ManejarClickEditarGuardar(e.RowIndex);
            }
            else if (nombreColumna == "colAccionEstado")
            {
                ManejarClickEstado(e.RowIndex);
            }
        }
        /// <summary>
        /// Cambia entre los modos de edición y guardado según corresponda.
        /// </summary>
        /// <param name="filaIndex"></param>
        private void ManejarClickEditarGuardar(int filaIndex)
        {
            bool estaEnEdicion = filaIndex == filaEnEdicionIndex;

            if (!estaEnEdicion)
            {
                if (filaEnEdicionIndex != -1)
                {
                    MessageBox.Show("Termine de editar la fila actual antes de editar otra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                HabilitarEdicionFila(filaIndex);
            }
            else
            {
                GuardarFila(filaIndex);
            }
        }

        /// <summary>
        /// Maneja el clic en el botón de la columna "Eliminar/Activar". 
        /// Cambia el estado del producto según corresponda, mostrando mensajes de confirmación y error según sea necesario.
        /// </summary>
        /// <param name="filaIndex"></param>
        private void ManejarClickEstado(int filaIndex)
        {
            if (filaEnEdicionIndex != -1)
            {
                MessageBox.Show("Termine de editar la fila actual antes de cambiar el estado de otro producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var producto = DGVProductos.Rows[filaIndex].DataBoundItem as Producto;
            if (producto == null) return;

            if (producto.Activo)
            {
                var respuesta = MessageBox.Show(
                    $"¿Eliminar el producto \"{producto.Nombre}\"? Podrá reactivarlo más adelante si tiene stock disponible.",
                    "Confirmar baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta != DialogResult.Yes) return;

                if (!productoBusiness.DesactivarProducto(producto.Id, out string mensaje))
                {
                    MessageBox.Show(mensaje, "No se pudo desactivar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (!productoBusiness.ReactivarProducto(producto.Id, out string mensaje))
                {
                    MessageBox.Show(mensaje, "No se pudo activar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            CargarProductos();
            CargarIndicadoresCards();
        }

        /// <summary>
        /// Habilita la edición de las celdas de la fila especificada y cambia el icono del botón a "Guardar". 
        /// Deshabilita la edición de otras filas si es necesario.
        /// </summary>
        /// <param name="filaIndex"></param>
        private void HabilitarEdicionFila(int filaIndex)
        {
            var fila = DGVProductos.Rows[filaIndex];

            fila.Cells["colNombre"].ReadOnly = false;
            fila.Cells["colCategoria"].ReadOnly = false;
            fila.Cells["colPrecio"].ReadOnly = false;
            fila.Cells["colStock"].ReadOnly = false;
            fila.Cells["colStockMinimo"].ReadOnly = false;

            fila.DefaultCellStyle.BackColor = Color.LightYellow;

            filaEnEdicionIndex = filaIndex;

            DGVProductos.CurrentCell = fila.Cells["colNombre"];
            DGVProductos.BeginEdit(true);
            DGVProductos.InvalidateColumn(DGVProductos.Columns["colAccionEditar"].Index);
        }

        /// <summary>
        /// Valida y guarda los cambios realizados en la fila especificada.
        /// </summary>
        /// <param name="filaIndex"></param>
        private void GuardarFila(int filaIndex)
        {
            DGVProductos.EndEdit();

            var fila = DGVProductos.Rows[filaIndex];
            var productoOriginal = fila.DataBoundItem as Producto;
            if (productoOriginal == null) return;

            string nuevoNombre = fila.Cells["colNombre"].Value?.ToString().Trim();
            string textoPrecio = fila.Cells["colPrecio"].Value?.ToString();
            string textoStock = fila.Cells["colStock"].Value?.ToString();
            string textoStockMinimo = fila.Cells["colStockMinimo"].Value?.ToString();
            object valorCategoria = fila.Cells["colCategoria"].Value;

            if (!decimal.TryParse(textoPrecio, out decimal nuevoPrecio))
            {
                MessageBox.Show("El precio ingresado no es válido.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textoStock, out int nuevoStock))
            {
                MessageBox.Show("El stock ingresado no es válido.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textoStockMinimo, out int nuevoStockMinimo))
            {
                MessageBox.Show("El stock mínimo ingresado no es válido.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (valorCategoria == null || !int.TryParse(valorCategoria.ToString(), out int nuevaCategoriaId))
            {
                MessageBox.Show("Debe seleccionar una categoría válida.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productoActualizado = new Producto
            {
                Id = productoOriginal.Id,
                Nombre = nuevoNombre,
                Precio = nuevoPrecio,
                Stock = nuevoStock,
                StockMinimo = nuevoStockMinimo,
                CategoriaId = nuevaCategoriaId
            };

            if (!productoBusiness.ActualizarProducto(productoActualizado, out string mensaje))
            {
                MessageBox.Show(mensaje, "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (mensaje.Contains("desactivó"))
            {
                MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            fila.DefaultCellStyle.BackColor = Color.White;
            filaEnEdicionIndex = -1;
            CargarProductos();
            CargarIndicadoresCards();
        }

        /// <summary>
        /// Muestra el formulario de filtros en un modal, aplica los filtros seleccionados, restablece la página a la
        /// primera y recarga los productos e indicadores.
        /// <param name="sender">Objeto que originó el evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void BFiltros_Click(object sender, EventArgs e)
        {
            var formFiltros = new FormFiltrosProductos(filtroCategoriaId, filtroEstado, filtroStock);

            Diseno.MostrarModal(this, formFiltros, () =>
            {

                filtroCategoriaId = formFiltros.CategoriaIdSeleccionada;
                filtroEstado = formFiltros.EstadoSeleccionado;
                filtroStock = formFiltros.StockSeleccionado;

                ActualizarTextoBotonFiltros();
                paginaActual = 1;
                CargarProductos();
                CargarIndicadoresCards();

            });
        }

        /// <summary>
        /// Actualiza el estado visual del botón de filtros con el indicador / redondito rojo.
        /// </summary>
        private void ActualizarTextoBotonFiltros()
        {
            int cantidadActivos = 0;
            if (filtroCategoriaId.HasValue) cantidadActivos++;
            if (filtroEstado != FormFiltrosProductos.FiltroEstado.Todos) cantidadActivos++;
            if (filtroStock != FormFiltrosProductos.FiltroStock.Todos) cantidadActivos++;

            Diseno.ActualizarEstadoFiltro(BFiltros, cantidadActivos > 0, cantidadActivos);
        }

        private void BLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            TBBuscar.Clear();

            filtroCategoriaId = null;
            filtroEstado = FormFiltrosProductos.FiltroEstado.Todos;
            filtroStock = FormFiltrosProductos.FiltroStock.Todos;
            ActualizarTextoBotonFiltros();

            paginaActual = 1;
            CargarProductos();
            CargarIndicadoresCards();
        }

        /// <summary>Traduce el filtro de estado (enum de UI) al bool? que usa la capa de datos.</summary>
        private bool? ObtenerFiltroSoloActivos()
        {
            switch (filtroEstado)
            {
                case FormFiltrosProductos.FiltroEstado.Activo:
                    return true;
                case FormFiltrosProductos.FiltroEstado.Inactivo:
                    return false;
                default:
                    return null;
            }
        }

        private void BNuevoProduc_Click(object sender, EventArgs e)
        {
            FormNuevoProducto modalNuevo = new FormNuevoProducto();
            Diseno.MostrarModal(this, modalNuevo, () =>
            {
                CargarProductos();
                CargarIndicadoresCards();
            });
        }





        #endregion

        private void TBBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                BBuscar.PerformClick();
            }
        }

        private void LProdValorInventario_Click(object sender, EventArgs e)
        {

        }
    }
}
