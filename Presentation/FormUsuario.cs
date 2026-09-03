using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; //placeholder

namespace Presentation
{
    public partial class FormUsuario : Form
    {

        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public FormUsuario()
        {
            InitializeComponent();
        }
        private void LApellido_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LRolAsignado_Click(object sender, EventArgs e)
        {

        }

        private void DGVUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            ConfigurarColumnasTemporales();
            CargarDatosPrueba();

            // Placeholder de textboxes 
            SendMessage(TBNombre.Handle, EM_SETCUEBANNER, 0, "Ej: María José");
            SendMessage(TBApellido.Handle, EM_SETCUEBANNER, 0, "Ej: Granatto");
            SendMessage(TBDni.Handle, EM_SETCUEBANNER, 0, "Número de documento");
            SendMessage(TBCorreo.Handle, EM_SETCUEBANNER, 0, "correo@ejemplo.com");
            SendMessage(TBTelefono.Handle, EM_SETCUEBANNER, 0, "Teléfono de contacto");
            SendMessage(TBBuscar.Handle, EM_SETCUEBANNER, 0, "Buscar por DNI o Apellido...");

            DGVUsuarios.ClearSelection();

        }
        private void ConfigurarColumnasTemporales()
        {
            DGVUsuarios.Columns.Clear();

            DGVUsuarios.Columns.Add("id", "ID");
            DGVUsuarios.Columns.Add("dni", "DNI");
            DGVUsuarios.Columns.Add("nombre", "Nombre");
            DGVUsuarios.Columns.Add("apellido", "Apellido");
            DGVUsuarios.Columns.Add("correo", "Correo");
            DGVUsuarios.Columns.Add("rol", "Rol");
            DGVUsuarios.Columns.Add("estado", "Estado");

            DGVUsuarios.Columns["id"].FillWeight = 40;

            
        }

        private void CargarDatosPrueba()
        {
            DGVUsuarios.Rows.Add("1", "40123456", "Alice", "Admin", "alice@test.com", "Administrador", "Activo");
            DGVUsuarios.Rows.Add("2", "38987654", "Bob", "Moderator", "bob@test.com", "Moderador", "Activo");
            DGVUsuarios.Rows.Add("3", "42555666", "Candice", "Member", "candice@test.com", "Miembro", "Inactivo");
            DGVUsuarios.Rows.Add("4", "39111222", "David", "Member", "david@test.com", "Miembro", "Activo");
        }
    }
}
