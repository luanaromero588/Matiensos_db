using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Business;
using Entities;

namespace Presentation.GestionVentas
{
    public partial class FormNuevoCliente : Form
    {
        private readonly ClienteBusiness clienteBusiness = new ClienteBusiness();
        public Cliente ClienteCreado { get; private set; }
        private Cliente clienteExistenteCargado = null;

        public FormNuevoCliente()
        {
            InitializeComponent();
            Diseno.FormatearModal(this);
            Diseno.FormatearBotonPrimario(BGuardar);
            Diseno.FormatearBotonSecundario(BCancelar);
        }
        public FormNuevoCliente(string dniInicial) : this()
        {
            TBDni.Text = dniInicial;
        }

        private void FormNuevoCliente_Load(object sender, EventArgs e)
        {
            // Si vino con DNI precargado desde la venta, verificar existencia
            if (!string.IsNullOrWhiteSpace(TBDni.Text))
            {
                VerificarDocumento(TBDni.Text.Trim());
            }
            this.ActiveControl = TBDni;
        }

        /// <summary>
        /// Verifica si el DNI ingresado ya pertenece a un cliente existente y carga sus datos si es así.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BGuardar_Click(object sender, EventArgs e)
        {
            // El cliente ya existía en la base de datos
            if (clienteExistenteCargado != null)
            {
                this.ClienteCreado = clienteExistenteCargado;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // Registro de nuevo cliente
            string dni = TBDni.Text.Trim();
            string nombre = TBNombre.Text.Trim();
            string apellido = TBApellido.Text.Trim();

            if (string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("DNI, Nombre y Apellido son datos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevoCliente = new Cliente
            {
                Dni = dni,
                Nombre = nombre,
                Apellido = apellido,
                Telefono = TBTelefono.Text.Trim(),
                Email = TBEmail.Text.Trim(),
                Activo = true
            };

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

        /// <summary>
        /// Cancela la operación y cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Evento KeyPress para DNI, Nombre, Apellido y Telefono
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBDni_Leave(object sender, EventArgs e)
        {
            // Evitar validación si el usuario presiona Cancelar
            if (this.ActiveControl == BCancelar)
            {
                return;
            }

            VerificarDocumento(TBDni.Text.Trim());
        }

        /// <summary>
        /// Verifica si el DNI ingresado ya pertenece a un cliente existente y carga sus datos si es así.
        /// </summary>
        /// <param name="dni"></param>
        private void VerificarDocumento(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                RestablecerFormularioParaNuevo();
                return;
            }

            if (!Regex.IsMatch(dni, @"^\d{7,8}$"))
            {
                return;
            }

            var existente = clienteBusiness.BuscarPorDni(dni);

            if (existente != null)
            {
                // Precarga de datos encontrados
                clienteExistenteCargado = existente;
                TBNombre.Text = existente.Nombre;
                TBApellido.Text = existente.Apellido;
                TBTelefono.Text = existente.Telefono;
                TBEmail.Text = existente.Email;

                // Bloqueo de campos para lectura
                SetCamposSoloLectura(true);

                // Adaptación del botón de acción
                BGuardar.Text = "Seleccionar";
                BGuardar.BackColor = Color.FromArgb(70, 130, 180);
            }
            else
            {
                // Habilitación para nuevo registro
                if (clienteExistenteCargado != null)
                {
                    RestablecerFormularioParaNuevo();
                }
            }
        }

        /// <summary>
        /// Establece los campos de entrada como solo lectura o editables según el parámetro proporcionado.
        /// </summary>
        /// <param name="soloLectura"></param>
        private void SetCamposSoloLectura(bool soloLectura)
        {
            TBNombre.ReadOnly = soloLectura;
            TBApellido.ReadOnly = soloLectura;
            TBTelefono.ReadOnly = soloLectura;
            TBEmail.ReadOnly = soloLectura;

            Color backColor = soloLectura ? Color.FromArgb(240, 240, 240) : Color.White;
            TBNombre.BackColor = backColor;
            TBApellido.BackColor = backColor;
            TBTelefono.BackColor = backColor;
            TBEmail.BackColor = backColor;
        }

        /// <summary>
        /// Restablece el formulario para permitir el ingreso de un nuevo cliente, limpiando los campos y habilitándolos para edición.
        /// </summary>
        private void RestablecerFormularioParaNuevo()
        {
            clienteExistenteCargado = null;
            SetCamposSoloLectura(false);

            TBNombre.Clear();
            TBApellido.Clear();
            TBTelefono.Clear();
            TBEmail.Clear();

            BGuardar.Text = "Guardar";
            Diseno.FormatearBotonPrimario(BGuardar);
        }

        private void LDatosPersonales_Click(object sender, EventArgs e)
        {

        }

        private void TBEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void LTelefono_Click(object sender, EventArgs e)
        {

        }

        private void TBTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void LCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}