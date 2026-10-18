using Entities;
using Presentation.GestionVentas;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation.GestionAdministrador
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
            LInfoSesion.Text = $"Operador: {Sesion.Nombre}";
            AbrirFormularioHijo(new FormProductos());
            
        }

        /// <summary>
        /// Abre un formulario hijo dentro del panel contenedor del formulario principal.
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

            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Productos" para abrir el formulario de productos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BProductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormProductos());
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Categorias" para abrir el formulario de categorías.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormCategorias());
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Métodos de Pago" para abrir el formulario de métodos de pago.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BMetodosPago_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormMetodosPago());
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Ventas" para abrir el formulario de ventas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormHistorialVentas());
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Auditoría" para abrir el formulario de auditoría.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Maneja el evento de clic del botón "Cerrar Sesión" para cerrar la sesión actual.
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

        
    }
}