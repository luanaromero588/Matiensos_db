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
        private readonly ProductoBusiness productoBusiness = new ProductoBusiness();

        private const int EM_SETCUEBANNER = 0x1501;
        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(FLPCards);
            Diseno.FormatearGrilla(DGVProductos);
            ConfigurarColumnasGrid();
            CargarProductos();

            //placeholder buscador ventas
            SendMessage(TBBuscar.Handle, EM_SETCUEBANNER, 0, "Buscar por nombre o código  ...");

        }

        private void ConfigurarColumnasGrid()
        {
            DGVProductos.AutoGenerateColumns = false;
            DGVProductos.Columns.Clear();

            // 1.Código de producto
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Codigo",
                HeaderText = "Código",
                Name = "colCodigo",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 2. Nombre
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "colNombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // 3. Categoría
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CategoriaNombre",
                HeaderText = "Categoría",
                Name = "colCategoria",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });
            // 4. Precio
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "precio",
                HeaderText = "Precio",
                Name = "colPrecio",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "C2" }
            });

            // 5. Stock
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "stock",
                HeaderText = "Stock",
                Name = "colStock",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 6. Ver detalle
            DGVProductos.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Ver detalle",
                Name = "btnVerDetalleFila",
                UseColumnTextForButtonValue = true,
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });
            // 7. editar estado
            DGVProductos.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Editar",
                Name = "btnEditarFila",
                UseColumnTextForButtonValue = true,
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });


        }

        /// <summary>
        /// Carga los productos activos con stock disponible en el DataGridView.
        /// </summary>
        private void CargarProductos()
        {
            try
            {
                List<Producto> lista = productoBusiness.ObtenerProductosConStock();
                DGVProductos.DataSource = null;
                DGVProductos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos desde la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex < 0) return;

            // Obtener el producto seleccionado en la fila actual
            Producto productoSeleccionado = DGVProductos.Rows[e.RowIndex].DataBoundItem as Producto;
            if (productoSeleccionado == null) return;

            // Clic en "Ver detalle"
            if (DGVProductos.Columns[e.ColumnIndex].Name == "btnVerDetalleFila")
            {
                MessageBox.Show($"Producto: {productoSeleccionado.Nombre}\nCódigo: {productoSeleccionado.Codigo}\nStock: {productoSeleccionado.Stock}\nPrecio: {productoSeleccionado.Precio:C2}", "Detalle de Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Clic en "Editar"
            if (DGVProductos.Columns[e.ColumnIndex].Name == "btnEditarFila")
            {
                MessageBox.Show($"Abrir edición para {productoSeleccionado.Nombre} (ID: {productoSeleccionado.Id})", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BNuevoProduc_Click(object sender, EventArgs e)
        {
            Diseno.MostrarModal(this, new FormNuevoProducto());
        }
    }
}
