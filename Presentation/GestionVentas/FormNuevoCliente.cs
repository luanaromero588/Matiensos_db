using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
        }

        public FormNuevoCliente(string dniInicial) : this()
        {
            TBDni.Text = dniInicial;
        }

        private void FormNuevoCliente_Load(object sender, EventArgs e)
        {
            Diseno.FormatearModal(this);
            Diseno.HabilitarMovimiento(this, PHeader);
            Diseno.FormatearBotonPrimario(BGuardar);
            Diseno.FormatearBotonSecundario(BCancelar);

            ConfigurarAutocompletadoDni();

            if (!string.IsNullOrWhiteSpace(TBDni.Text))
            {
                VerificarDocumento(TBDni.Text.Trim());
            }

            this.ActiveControl = TBDni;
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (clienteExistenteCargado != null)
            {
                this.ClienteCreado = clienteExistenteCargado;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

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

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

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
        /// Carga los DNI de clientes activos para autocompletado en el cuadro de texto.
        /// </summary>
        private void ConfigurarAutocompletadoDni()
        {
            try
            {
                var clientes = clienteBusiness.ObtenerClientesActivos();
                var coleccionDni = new AutoCompleteStringCollection();
                if (clientes != null)
                {
                    foreach (var cli in clientes)
                    {
                        if (!string.IsNullOrEmpty(cli.Dni))
                        {
                            coleccionDni.Add(cli.Dni);
                        }
                    }
                }

                TBDni.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                TBDni.AutoCompleteSource = AutoCompleteSource.CustomSource;
                TBDni.AutoCompleteCustomSource = coleccionDni;
            }
            catch
            {
            }
        }

        /// <summary>
        /// Valida y carga el cliente automáticamente al ingresar un DNI completo de 7 u 8 dígitos.
        /// </summary>
        private void TBDni_TextChanged(object sender, EventArgs e)
        {
            string dni = TBDni.Text.Trim();
            if (Regex.IsMatch(dni, @"^\d{7,8}$"))
            {
                VerificarDocumento(dni);
            }
            else if (clienteExistenteCargado != null)
            {
                RestablecerFormularioParaNuevo();
            }
        }

        private void TBDni_Leave(object sender, EventArgs e)
        {
            if (this.ActiveControl == BCancelar || this.ActiveControl == LCerrar)
            {
                return;
            }

            VerificarDocumento(TBDni.Text.Trim());
        }

        /// <summary>
        /// Verifica si el DNI ingresado ya pertenece a un cliente existente y carga sus datos si es así.
        /// </summary>
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
                clienteExistenteCargado = existente;
                TBNombre.Text = existente.Nombre;
                TBApellido.Text = existente.Apellido;
                TBTelefono.Text = existente.Telefono;
                TBEmail.Text = existente.Email;

                SetCamposSoloLectura(true);

                BGuardar.Text = "Seleccionar";
                BGuardar.BackColor = Color.FromArgb(70, 130, 180);
            }
            else
            {
                if (clienteExistenteCargado != null)
                {
                    RestablecerFormularioParaNuevo();
                }
            }
        }

        /// <summary>
        /// Establece los campos de entrada como solo lectura o editables según el parámetro proporcionado.
        /// </summary>
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

        private void LCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}