using System;
using System.Drawing;
using System.Windows.Forms;
using Entities;

namespace Presentation.GestionVentas
{
    public partial class FormVendedorPrincipal : Form
    {
        // Almacena la referencia del formulario que está visible en el panel central
        private Form formularioActivo = null;

        public FormVendedorPrincipal()
        {
            InitializeComponent();
        }

        private void FormVendedorPrincipal_Load(object sender, EventArgs e)
        {
            // Muestra los datos del operador logueado en la esquina superior derecha
            LInfoSesion.Text = $"Operador: (ID: {Sesion.UsuarioId})";

            // Abre la pantalla de Nueva Venta al iniciar
            //AbrirFormularioHijo(new FormVenta());
        }

        /// <summary>
        /// Abre un formulario hijo dentro del panel central, cerrando el formulario activo si existe.
        /// </summary>
        /// <param name="formularioHijo"></param>
        private void AbrirFormularioHijo(Form formularioHijo)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formularioHijo;

            // Se configura como control secundario dentro del panel
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        // Botón 1: Nueva de Venta
        private void BNuevaVenta_Click(object sender, EventArgs e)
        {
            //AbrirFormularioHijo(new FormVenta());
        }

        // Botón 2: Consulta de Catálogo y Stock
        private void BProductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormProductos());
        }

        // Botón 3: Historial y Métricas del Vendedor
        private void BHistorial_Click(object sender, EventArgs e)
        {
            //AbrirFormularioHijo(new FormMisVentas());
        }

        // Botón inferior: Salir de la sesión actual
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

        // Dibuja la línea divisoria inferior de la barra superior (mismo estilo que Form1)
        private void panelNavbar_Paint(object sender, PaintEventArgs e)
        {
            using (Pen lapiz = new Pen(Color.FromArgb(56, 97, 80), 2))
            {
                int y = panelNavbar.Height - 1;
                e.Graphics.DrawLine(lapiz, 0, y, panelNavbar.Width, y);
            }
        }
    }
}