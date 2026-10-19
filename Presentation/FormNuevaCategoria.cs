using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Business;
using Entities;

namespace Presentation
{
    public partial class FormNuevaCategoria : Form
    {
        private readonly CategoriaBusiness _categoriaBusiness = new CategoriaBusiness();

        public FormNuevaCategoria()
        {
            InitializeComponent();
            Diseno.FormatearModal(this);
        }

        private void FormNuevaCategoria_Load(object sender, EventArgs e)
        {
            this.ActiveControl = TBCodCategoria;
            Diseno.HabilitarMovimiento(this, panel1);
            Diseno.FormatearBotonPrimario(BGuardar);
            Diseno.FormatearBotonSecundario(BCancelar);
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
        /// Valida el código de la categoría (obligatorio, hasta 4 caracteres alfanuméricos y único).
        /// </summary>
        private bool ValidarCodigo()
        {
            string codigo = TBCodCategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MostrarError(LErrorCodigo, TBCodCategoria, "El código es obligatorio.");
                return false;
            }

            if (codigo.Length > 4)
            {
                MostrarError(LErrorCodigo, TBCodCategoria, "Permite hasta 4 caracteres.");
                return false;
            }

            if (_categoriaBusiness.ExisteCodigo(codigo))
            {
                MostrarError(LErrorCodigo, TBCodCategoria, "El código ya está registrado.");
                return false;
            }

            LimpiarError(LErrorCodigo, TBCodCategoria);
            return true;
        }

        /// <summary>
        /// Valida el nombre de la categoría (máximo 100 caracteres).
        /// </summary>
        private bool ValidarNombre()
        {
            string nombre = TBNombreCategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MostrarError(LErrorNombre, TBNombreCategoria, "El nombre es obligatorio.");
                return false;
            }

            if (nombre.Length > 100)
            {
                MostrarError(LErrorNombre, TBNombreCategoria, "Máximo 100 caracteres.");
                return false;
            }

            LimpiarError(LErrorNombre, TBNombreCategoria);
            return true;
        }

        /// <summary>
        /// Valida todos los campos antes de guardar.
        /// </summary>
        private bool ValidarFormulario()
        {
            bool esValido = true;
            Control primerInvalido = null;

            if (!ValidarCodigo())
            {
                esValido = false;
                if (primerInvalido == null) primerInvalido = TBCodCategoria;
            }

            if (!ValidarNombre())
            {
                esValido = false;
                if (primerInvalido == null) primerInvalido = TBNombreCategoria;
            }

            primerInvalido?.Focus();
            return esValido;
        }

        #endregion

        #region Eventos de Controles

        private void TBCodCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TBCodCategoria_TextChanged(object sender, EventArgs e)
        {
            ValidarCodigo();
        }

        private void TBCodCategoria_Leave(object sender, EventArgs e)
        {
            ValidarCodigo();
        }

        private void TBNombreCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TBNombreCategoria_TextChanged(object sender, EventArgs e)
        {
            ValidarNombre();
        }

        private void TBNombreCategoria_Leave(object sender, EventArgs e)
        {
            ValidarNombre();
        }

        #endregion

        /// <summary>
        /// Valida los datos y registra la nueva categoría en el sistema.
        /// </summary>
        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            string codigo = TBCodCategoria.Text.Trim().ToUpper();
            string nombre = TBNombreCategoria.Text.Trim();
            string descripcion = TBDescripcion.Text.Trim();

            if (_categoriaBusiness.RegistrarCategoria(codigo, nombre, descripcion, out string mensaje))
            {
                MessageBox.Show("Categoría registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (mensaje.IndexOf("código", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    MostrarError(LErrorCodigo, TBCodCategoria, mensaje);
                    TBCodCategoria.Focus();
                }
            }
        }

        /// <summary>
        /// Cierra el formulario modal cancelando la operación.
        /// </summary>
        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}