using Business;
using Entities;
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
        private readonly ProductoBusiness productoBusiness = new ProductoBusiness();
        private const int EM_SETCUEBANNER = 0x1501;
        
        // Variables de Paginación
        private int paginaActual = 1;
        private int totalPaginas = 1;

        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(FLPCards);
            ConfigurarColumnasGrid();
            CargarProductos();

            //placeholder buscador ventas
            SendMessage(TBBuscar.Handle, EM_SETCUEBANNER, 0, "Buscar por nombre o código  ...");

        }

        /// <summary>
        /// Configura las columnas del DataGridView para mostrar los productos, incluyendo botones de acción para ver detalles y editar.
        /// </summary>
        private void ConfigurarColumnasGrid()
        {
            Diseno.FormatearGrilla(DGVProductos);

            DGVProductos.Columns.Clear();
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Código", Name = "colCodigo", Width = 120 });
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre", Name = "colNombre", Width = 250 });
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CategoriaNombre", HeaderText = "Categoría", Name = "colCategoria", Width = 150 });
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Precio", HeaderText = "Precio", Name = "colPrecio", Width = 120, DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Stock", HeaderText = "Stock", Name = "colStock", Width = 100, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } });

            DGVProductos.Columns.Add(new DataGridViewButtonColumn { HeaderText = "Estado", Text = "Estado", Name = "btnEstado", UseColumnTextForButtonValue = true, Width = 100 });
            DGVProductos.Columns.Add(new DataGridViewButtonColumn { HeaderText = "Editar", Text = "Editar", Name = "btnEditarFila", UseColumnTextForButtonValue = true, Width = 90 });
            DGVProductos.Columns.Add(new DataGridViewButtonColumn { HeaderText = "Eliminar", Text = "Eliminar", Name = "btnEliminarFila", UseColumnTextForButtonValue = true, Width = 100 });
        }

        /// <summary>
        /// Carga los productos activos con stock disponible en el DataGridView.
        /// </summary>
        private void CargarProductos()
        {
            string busqueda = TBBuscar.Text.Trim();

            var lista = productoBusiness.ObtenerProductosPaginados(busqueda, paginaActual, out totalPaginas, out string mensajeError);

            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DGVProductos.DataSource = null;
            DGVProductos.DataSource = lista;

            ActualizarControlesPaginacion();
        }

        #region Filtros y Paginación
        private void BBuscar_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            CargarProductos();
        }
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


        private void DGVProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Producto productoSeleccionado = DGVProductos.Rows[e.RowIndex].DataBoundItem as Producto;
            if (productoSeleccionado == null) return;

            if (DGVProductos.Columns[e.ColumnIndex].Name == "btnVerDetalleFila")
            {
                MessageBox.Show($"Producto: {productoSeleccionado.Nombre}\nCódigo: {productoSeleccionado.Codigo}\nStock: {productoSeleccionado.Stock}\nPrecio: {productoSeleccionado.Precio:C2}", "Detalle de Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (DGVProductos.Columns[e.ColumnIndex].Name == "btnEditarFila")
            {
                MessageBox.Show($"Abrir edición para {productoSeleccionado.Nombre} (ID: {productoSeleccionado.Id})", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
