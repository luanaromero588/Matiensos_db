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
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private Form formularioActivo = null;

        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // 1. Si ya hay un formulario abierto en el panel, lo cerramos
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formularioHijo;

            // 2. Configuramos el formulario hijo para que actúe como un control dentro del panel
            formularioHijo.TopLevel = false;                  // No es una ventana independiente
            formularioHijo.FormBorderStyle = FormBorderStyle.None; // Quitamos bordes y barra de título
            formularioHijo.Dock = DockStyle.Fill;             // Que ocupe todo el panel central

            // 3. Lo incrustamos en el panel contenedor
            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();                            // Mostramos el formulario
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
    }
}
