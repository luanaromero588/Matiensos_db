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

        private void FormPanelSuperAdmin_Load(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormProductos());
                      
            LInfoSesion.Text = $"Operador: {Entities.Sesion.Nombre}";

        }

        /// <summary>
        /// Abre un formulario hijo dentro del panel contenedor, cerrando cualquier formulario activo previamente.
        /// </summary>
        /// <param name="formularioHijo"></param>
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

            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Usuarios" y abre el formulario correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormUsuario());
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Productos" y abre el formulario correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BProductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormProductos());
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Categorías" y abre el formulario correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCategorias_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormCategorias());
        }
        
        /// <summary>
        /// Maneja el evento de clic del botón "Clientes" y abre el formulario correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BClientes_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormCliente());
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Ventas" y abre el formulario correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormVentas()); 
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Auditoría" y abre el formulario correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Maneja el evento de clic del botón "Cerrar Sesión" y solicita confirmación antes de cerrar la sesión actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Maneja el evento de clic del botón "Métodos de Pago" y abre el formulario correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BMetodosPago_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormMetodosPago());
        }
    }
}