using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FormPanelSuperAdmin : Form
    {
        private Form formularioActivo = null;

        public FormPanelSuperAdmin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormProductos());
                      
            LInfoSesion.Text = $"Operador: {Entities.Sesion.Nombre}";

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

        private void BUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormUsuario());
        }

        private void BProductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormProductos());
        }

        private void BCategorias_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormCategorias());
        }

        private void BClientes_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormCliente());
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
            // Dibuja una línea de 2 píxeles de grosor en el borde inferior
            using (Pen lapiz = new Pen(Color.FromArgb(56, 97, 80), 2))
            {
                // Desde x=0 (izquierda total) hasta el ancho total del panel
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

        private void BMetodosPago_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormMetodosPago());
        }
    }
}