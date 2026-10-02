using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Business;
using Entities;

namespace Presentation.GestionAdministrador
{
    public partial class FormNuevoProducto : Form
    {
        public FormNuevoProducto()
        {
            InitializeComponent();
        }

        private void FormNuevoProducto_Load(object sender, EventArgs e)
        {
            this.ActiveControl = TBCodProduc;
        }

        /// <summary>
        /// Verifica si el DNI ingresado ya pertenece a un cliente existente y carga sus datos si es así.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            if (CBcategoriaProduc.SelectedIndex == -1)
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

            //
            // llamada a  registrar en capa de negocio
            /*
            var nuevoProducto = new Producto
            {
                Codigo = codigo,
                Nombre = nombre,
                Descripcion = TBDescripcion.Text.Trim(),
                IdCategoria = (int)CBCategoria.SelectedValue,
                Precio = precio,
                Stock = stock,
                Activo = true
            };

            if (productoBusiness.RegistrarProducto(nuevoProducto, Sesion.UsuarioId, out string mensaje))
            {
                MessageBox.Show("Producto registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            */

        }
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
        private void LCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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

        private TextBox TBNombreProduc;
        private Label LNombreProduc;
        private ComboBox CBcategoriaProduc;
    }
}