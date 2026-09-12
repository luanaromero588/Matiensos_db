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
            //Validaciones básicas de interfaz
            if (string.IsNullOrWhiteSpace(TBDni.Text) ||
                string.IsNullOrWhiteSpace(TBNombre.Text) ||
                string.IsNullOrWhiteSpace(TBApellido.Text))
            {
                MessageBox.Show("DNI, Nombre y Apellido son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //Construcción de la entidad
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

            // Pasa el ID del usuario logueado en Sesion para cumplir con created_by
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
                MessageBox.Show(mensaje, "Aviso de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}