using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Business;
using Entities;

namespace Presentation
{
    public partial class FormNuevoMetodoPago : Form
    {
        public FormNuevoMetodoPago()
        {
            InitializeComponent();
        }

        private void FormNuevaCategoria_Load(object sender, EventArgs e)
        {

            this.ActiveControl = TBNombreMP;
        }

     
        private void BGuardar_Click(object sender, EventArgs e)
        {
            string nombre = TBNombreMP.Text.Trim();
            string descripcion = TBDescripcionMP.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre de la categoría es obligatorio.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBNombreMP.Focus();
                return;
            }
            //  Mock de guardado para la maqueta
            // (Cuando haga el backend, aca llamo a CategoriaBusiness.RegistrarCategoria(...))
            /*
            var nuevaCategoria = new Categoria
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Activo = true
            };
            */

            MessageBox.Show("Categoría registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private Label LNombre;
        private Label label2;
        private TextBox TBDescripcionMP;
    }
}