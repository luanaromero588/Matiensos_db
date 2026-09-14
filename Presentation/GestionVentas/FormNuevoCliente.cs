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
            // 1. Validar campos obligatorios en la interfaz
            if (string.IsNullOrWhiteSpace(TBDni.Text) ||
                string.IsNullOrWhiteSpace(TBNombre.Text) ||
                string.IsNullOrWhiteSpace(TBApellido.Text))
            {
                MessageBox.Show("DNI, Nombre y Apellido son datos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Mapear los controles a la entidad Cliente
            var nuevoCliente = new Cliente
            {
                Dni = TBDni.Text.Trim(),
                Nombre = TBNombre.Text.Trim(),
                Apellido = TBApellido.Text.Trim(),
                Telefono = TBTelefono.Text.Trim(),
                Email = TBEmail.Text.Trim(),
                Direccion = TBDireccion.Text.Trim(),
                Activo = true
            };

            // 3. Delegar la transacción atómica a la capa Business
            if (clienteBusiness.RegistrarCliente(nuevoCliente, Sesion.UsuarioId, out int idGenerado, out string mensaje))
            {
                nuevoCliente.Id = idGenerado;
                this.ClienteCreado = nuevoCliente;

                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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