using System;
using System.Drawing;
using System.Windows.Forms;
using Business;

namespace Presentation
{
    public partial class FormNuevoMetodoPago : Form
    {
        private readonly MetodoPagoBusiness metodoPagoBusiness = new MetodoPagoBusiness();
        private bool _inicializado = false;
        private bool _usuarioModifico = false;

        public FormNuevoMetodoPago()
        {
            InitializeComponent();
        }

        private void FormNuevaCategoria_Load(object sender, EventArgs e)
        {
            this.ActiveControl = TBNombreMP;
            Diseno.FormatearModal(this);
            Diseno.FormatearBotonPrimario(BGuardar);
            Diseno.FormatearBotonSecundario(BCancelar);
            Diseno.HabilitarMovimiento(this, panel1);
            BCancelar.Click += (s, ev) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            LimpiarError(LErrorNombre, TBNombreMP);
            _inicializado = true;
            _usuarioModifico = false;
        }

        #region Validación e Indicadores de Error

        /// <summary>
        /// Muestra el mensaje de error debajo del control y resalta su fondo.
        /// </summary>
        private void MostrarError(Label lbl, Control control, string mensaje)
        {
            lbl.Text = mensaje;
            lbl.Visible = true;
            control.BackColor = Color.MistyRose;
        }

        /// <summary>
        /// Oculta el mensaje de error y restablece el fondo original del control.
        /// </summary>
        private void LimpiarError(Label lbl, Control control)
        {
            lbl.Text = string.Empty;
            lbl.Visible = false;
            control.BackColor = Color.White;
        }

        /// <summary>
        /// Valida el nombre del método de pago (obligatorio, máximo 50 caracteres y único).
        /// </summary>
        private bool ValidarNombre(bool forzarValidacionVacio = false)
        {
            string nombre = TBNombreMP.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                if (forzarValidacionVacio || _usuarioModifico)
                {
                    MostrarError(LErrorNombre, TBNombreMP, "El nombre es obligatorio.");
                }
                else
                {
                    LimpiarError(LErrorNombre, TBNombreMP);
                }
                return false;
            }

            if (nombre.Length > 50)
            {
                MostrarError(LErrorNombre, TBNombreMP, "Máximo 50 caracteres.");
                return false;
            }

            if (metodoPagoBusiness.ExisteNombre(nombre))
            {
                MostrarError(LErrorNombre, TBNombreMP, "El método de pago ya está registrado.");
                return false;
            }

            LimpiarError(LErrorNombre, TBNombreMP);
            return true;
        }

        /// <summary>
        /// Valida todos los campos antes de registrar el método de pago.
        /// </summary>
        private bool ValidarFormulario()
        {
            bool esValido = true;
            Control primerInvalido = null;

            if (!ValidarNombre(forzarValidacionVacio: true))
            {
                esValido = false;
                if (primerInvalido == null) primerInvalido = TBNombreMP;
            }

            primerInvalido?.Focus();
            return esValido;
        }

        #endregion

        #region Eventos de Controles

        private void TBNombreMP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TBNombreMP_TextChanged(object sender, EventArgs e)
        {
            if (!_inicializado) return;
            _usuarioModifico = true;
            ValidarNombre(forzarValidacionVacio: false);
        }
        private void TBNombreMP_Leave(object sender, EventArgs e)
        {
            if (!_inicializado) return;
            if (_usuarioModifico || !string.IsNullOrWhiteSpace(TBNombreMP.Text))
            {
                ValidarNombre(forzarValidacionVacio: true);
            }
        }

        #endregion

        /// <summary>
        /// Valida los datos y registra el nuevo método de pago en el sistema.
        /// </summary>
        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            string nombre = TBNombreMP.Text.Trim();
            string descripcion = TBDescripcionMP.Text.Trim();

            if (metodoPagoBusiness.RegistrarMetodoPago(nombre, descripcion, out string mensaje))
            {
                MessageBox.Show("Método de pago registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (mensaje.IndexOf("nombre", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    mensaje.IndexOf("registrado", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    MostrarError(LErrorNombre, TBNombreMP, mensaje);
                    TBNombreMP.Focus();
                }
            }
        }

        private void LCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}