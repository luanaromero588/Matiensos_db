using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Business;
using Entities;

namespace Presentation
{
    public partial class FormNuevaCategoria : Form
    {
        private readonly CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        public FormNuevaCategoria()
        {
            InitializeComponent();
        }

        private void FormNuevaCategoria_Load(object sender, EventArgs e)
        {
            // El foco va directo al nombre de la categoría
            this.ActiveControl = TBNombreCategoria;
        }

     
        private void BGuardar_Click(object sender, EventArgs e)
        {
            string nombre = TBNombreCategoria.Text.Trim();
            string descripcion = TBDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre de la categoría es obligatorio.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBNombreCategoria.Focus();
                return;
            }
            if (!categoriaBusiness.RegistrarCategoria(nombre, descripcion, out string mensaje))
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }   

        private void LCerrar_Click(object sender, EventArgs e)
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

        private Label LNombreCategoria;
    }
}