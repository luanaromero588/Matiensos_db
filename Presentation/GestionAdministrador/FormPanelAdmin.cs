using Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FormPanelAdmin : Form
    {
        private Form formularioActivo = null;

        public FormPanelAdmin()
        {
            InitializeComponent();
        }

        private void FormPanelAdmin_Load(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormProductos());
            LInfoSesion.Text = $"Operador: {Sesion.Nombre}";
        }

        private void AbrirFormularioHijo(Form formularioHijo)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formularioHijo;

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void BProductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormProductos());
        }

        private void BCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormCategorias());
        }

        private void BVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormVentas());
        }

        private void BAuditoria_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormAuditoria());
        }

        private void panelNavbar_Paint(object sender, PaintEventArgs e)
        {
            using (Pen lapiz = new Pen(Color.FromArgb(56, 97, 80), 2))
            {
                int y = panelNavbar.Height - 1;
                e.Graphics.DrawLine(lapiz, 0, y, panelNavbar.Width, y);
            }
        }

        private void BCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea cerrar la sesión actual?",
                "Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}