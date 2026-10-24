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
        public string ClavePropia => TBContraseñaAdmin.Text.Trim();
        public string ClaveSuperAdmin => TBContraseñaSuper.Text.Trim();

        public FormModalBackup(bool esAdmin = false)
        {
            InitializeComponent();
            Diseno.FormatearModal(this);

            ConfigurarModo(esAdmin);


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
            // Validar primer campo 
            if (string.IsNullOrWhiteSpace(TBContraseñaAdmin.Text))
            {
                MessageBox.Show("Debe ingresar su contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBContraseñaAdmin.Focus();
                return;
            }

            // Si el campo de SuperAdmin está visible, también debe validarse que no esté vacío
            if (TBContraseñaSuper.Visible && string.IsNullOrWhiteSpace(TBContraseñaSuper.Text))
            {
                MessageBox.Show("Debe ingresar la contraseña de SuperAdmin para autorizar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBContraseñaSuper.Focus();
                return;
            }

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
            if (TBContraseñaAdmin.UseSystemPasswordChar || TBContraseñaSuper.UseSystemPasswordChar)
            {
                // Mostrar contraseña
                TBContraseñaAdmin.UseSystemPasswordChar = false;
                TBContraseñaSuper.UseSystemPasswordChar = false;
                PBOcultar.Image = Properties.Resources.ojoabierto;
            }
            else
            {
                // Ocultar contraseña
                TBContraseñaAdmin.UseSystemPasswordChar = true;
                TBContraseñaSuper.UseSystemPasswordChar = true;
                PBOcultar.Image = Properties.Resources.esconder;
            }

            // Mantener el foco y el cursor al final del texto
            TBContraseñaAdmin.Focus();
            TBContraseñaAdmin.SelectionStart = TBContraseñaAdmin.Text.Length;
        }
    }
}