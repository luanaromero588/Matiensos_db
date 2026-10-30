using Business;
using Entities;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{

    public partial class FormModalBackup : Form
    {
        private readonly UsuarioBusiness _usuarioBusiness = new UsuarioBusiness();
        private bool _pasoSuperAdmin = false;
        public string ClavePropia => TBContraseñaAdmin.Text.Trim();
        public string ClaveSuperAdmin => TBContraseñaSuper.Text.Trim();

        public FormModalBackup(bool esAdmin = false)
        {
            InitializeComponent();
            Diseno.FormatearModal(this);
            TBContraseñaAdmin.UseSystemPasswordChar = true;
            PBOcultar.Image = Properties.Resources.esconder;

            this.AcceptButton = BAceptar;

            ConfigurarModo(esAdmin: false);
            LAdmin.Text = "Contraseña del Administrador:";
            BAceptar.Text = "Continuar";

        }

        private void ConfigurarModo(bool esAdmin)
        {
            // Si es Admin muestra el campo del super; si ya es SuperAdmin lo oculta
            LSuper.Visible = esAdmin;
            TBContraseñaSuper.Visible = esAdmin;
            PBOjoSuper.Visible = esAdmin;

            if (esAdmin)
            {
                LAdmin.Text = "Contraseña del Administrador:";
            }
            else
            {
                LAdmin.Text = "Contraseña del SuperAdmin:";

                // Achica la ventana para que no quede el hueco del segundo campo
                this.ClientSize = new Size(this.ClientSize.Width, TBContraseñaAdmin.Bottom + BAceptar.Height + 50);
                BAceptar.Top = TBContraseñaAdmin.Bottom + 25;
                BCancelar.Top = TBContraseñaAdmin.Bottom + 25;
            }
        }
        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            //Validar contraseña de cualquier Administrador
            if (!_pasoSuperAdmin)
            {
                if (string.IsNullOrWhiteSpace(TBContraseñaAdmin.Text))
                {
                    MessageBox.Show("Debe ingresar la contraseña de un Administrador.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBContraseñaAdmin.Focus();
                    return;
                }

                bool adminValido = _usuarioBusiness.ValidarClaveCualquierAdmin(TBContraseñaAdmin.Text.Trim());
                if (!adminValido)
                {
                    MessageBox.Show("La contraseña ingresada no corresponde a ningún Administrador activo.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TBContraseñaAdmin.SelectAll();
                    TBContraseñaAdmin.Focus();
                    return;
                }

                // Clave válida: preparamos el campo para el SuperAdmin
                _pasoSuperAdmin = true;
                LAdmin.Text = "Contraseña del SuperAdmin:";
                TBContraseñaAdmin.Clear();
                TBContraseñaAdmin.UseSystemPasswordChar = true;
                PBOcultar.Image = Properties.Resources.esconder;
                PBOcultar.Refresh();
                BAceptar.Text = "Aceptar";
                TBContraseñaAdmin.Focus();
                return;
            }

            //Validar contraseña del SuperAdmin
            if (string.IsNullOrWhiteSpace(TBContraseñaAdmin.Text))
            {
                MessageBox.Show("Debe ingresar la contraseña de SuperAdmin para autorizar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBContraseñaAdmin.Focus();
                return;
            }

            bool superValido = _usuarioBusiness.ValidarClaveSuperAdmin(TBContraseñaAdmin.Text.Trim());
            if (!superValido)
            {
                MessageBox.Show("La contraseña de SuperAdmin es incorrecta. Operación cancelada.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                TBContraseñaAdmin.SelectAll();
                TBContraseñaAdmin.Focus();
                return;
            }

            // Si ambas fueron correctas, cierra con OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LCruzFiltros_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PBOcultar_Click(object sender, EventArgs e)
        {
            if (TBContraseñaAdmin.UseSystemPasswordChar)
            {
                // Mostrar contraseña
                TBContraseñaAdmin.UseSystemPasswordChar = false;
                PBOcultar.Image = Properties.Resources.ojoabierto;
            }
            else
            {
                // Ocultar contraseña
                TBContraseñaAdmin.UseSystemPasswordChar = true;
                PBOcultar.Image = Properties.Resources.esconder;
            }

            PBOcultar.Refresh();
            // Mantener el foco y el cursor al final del texto
            TBContraseñaAdmin.Focus();
            TBContraseñaAdmin.SelectionStart = TBContraseñaAdmin.Text.Length;
        }
    }
}