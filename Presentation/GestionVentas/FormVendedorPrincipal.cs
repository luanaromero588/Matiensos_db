using Business;
using System;
using System.Drawing;
using System.Windows.Forms;
using Entities;

namespace Presentation.GestionVentas
{
    /// <summary>
    /// Ventana principal del panel de vendedor para operaciones de venta y catálogo.
    /// </summary>
    public partial class FormVendedorPrincipal : Form
    {
        private Form formularioActivo = null;

        /// <summary>
        /// Inicializa una nueva instancia del panel principal de vendedor.
        /// </summary>
        public FormVendedorPrincipal()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Configura el usuario activo, la barra de estado y abre el módulo de nueva venta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVendedorPrincipal_Load(object sender, EventArgs e)
        {
            LInfoSesion.Text = $"Operador: {Sesion.Nombre}";
            Diseno.AgregarBarraEstado(this, Sesion.Rol);
            AbrirFormularioHijo(new FormVenta());
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

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        /// <summary>
        /// Dibuja la línea decorativa inferior de la barra de navegación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelNavbar_Paint(object sender, PaintEventArgs e)
        {
            using (Pen lapiz = new Pen(Color.FromArgb(56, 97, 80), 2))
            {
                int y = panelNavbar.Height - 1;
                e.Graphics.DrawLine(lapiz, 0, y, panelNavbar.Width, y);
            }
        }

        /// <summary>
        /// Abre el catálogo de productos y consulta de stock.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BProductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormProductos());
        }

        /// <summary>
        /// Abre el historial de ventas del vendedor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BHistorial_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormHistorialVentas());
        }

        /// <summary>
        /// Solicita confirmación y cierra la sesión del usuario actual.
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
                UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
                usuarioBusiness.CerrarSesion();

                this.Close();
            }
        }

        /// <summary>
        /// Abre el formulario para registrar una nueva venta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BNuevaVenta_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormVenta());
        }
    }
}