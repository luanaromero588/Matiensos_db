using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Business;
using Entities;

namespace Presentation.GestionAdministrador
{
    public partial class FormNuevoProducto : Form
    {
        private readonly CategoriaBusiness _categoriaBusiness = new CategoriaBusiness();
        private readonly ProductoBusiness _productoBusiness = new ProductoBusiness();

        public FormNuevoProducto()
        {
            InitializeComponent();
            Diseno.FormatearModal(this);
        }

        private void FormNuevoProducto_Load(object sender, EventArgs e)
        {
            this.ActiveControl = TBCodProduc;
            Diseno.HabilitarMovimiento(this, panel1);
            Diseno.FormatearBotonPrimario(BGuardar);
            Diseno.FormatearBotonSecundario(BCancelar);
            CargarComboCategorias();
        }

        /// <summary>
        /// Carga las categorías activas.
        /// </summary>
        private void CargarComboCategorias()
        {
            try
            {
                var categoriasActivas = _categoriaBusiness.ObtenerCategoriasActivas();

                CBcategoriaProduc.DataSource = null;
                CBcategoriaProduc.DataSource = categoriasActivas;
                CBcategoriaProduc.DisplayMember = "Nombre";
                CBcategoriaProduc.ValueMember = "Id";
                CBcategoriaProduc.DropDownStyle = ComboBoxStyle.DropDownList;
                CBcategoriaProduc.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Valida los datos ingresados y registra un nuevo producto en el catálogo.
        /// </summary>
        private void BGuardar_Click(object sender, EventArgs e)
        {
            string codigo = TBCodProduc.Text.Trim();
            string nombre = TBNombreProduc.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo) || string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El código y el nombre del producto son obligatorios.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CBcategoriaProduc.SelectedIndex == -1 || CBcategoriaProduc.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una categoría.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(TBPrecio.Text.Trim(), out decimal precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un precio válido mayor o igual a 0.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(TBStock.Text.Trim(), out int stock) || stock < 0)
            {
                MessageBox.Show("Ingrese una cantidad de stock válida.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(TBStockMinimo.Text.Trim(), out int stockMinimo) || stockMinimo < 0)
            {
                MessageBox.Show("Ingrese una cantidad de stock mínimo válida.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevoProducto = new Producto
            {
                Codigo = codigo,
                Nombre = nombre,
                Descripcion = TBDescripcion.Text.Trim(),
                CategoriaId = Convert.ToInt32(CBcategoriaProduc.SelectedValue),
                Precio = precio,
                Stock = stock,
                StockMinimo = stockMinimo,
                Activo = true
            };

            if (_productoBusiness.RegistrarProducto(nuevoProducto, out string mensaje))
            {
                MessageBox.Show("Producto registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Boton Cancelar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TBNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TBPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void TBStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}