using System;
using System.Windows.Forms;
using Business;
using Entities;

namespace Presentation.GestionVentas
{
    public partial class FormNuevoCliente : Form
    {
        private readonly ClienteBusiness clienteBusiness = new ClienteBusiness();
        public Cliente ClienteCreado { get; private set; }

        // Constructor por defecto
        public FormNuevoCliente()
        {
            InitializeComponent();
        }
        // Sobrecarga de constructor que recibe el DNI escrito previamente
        public FormNuevoCliente(string dniInicial) : this()
        {
            TBDni.Text = dniInicial;
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// // Evento KeyPress para DNI y Teléfono (Solo dígitos)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Evento KeyPress para Nombre y Apellido (Solo letras y espacios)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TBApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TBTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}