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
            if (e.RowIndex < 0) return;

            if (DGVUsuarios.Columns[e.ColumnIndex].Name == "btnEditarFila")
            {
                DataGridViewRow fila = DGVUsuarios.Rows[e.RowIndex];

                // Pasamos los valores de la fila a los TextBox/ComboBox correspondientes
                TBDni.Text = fila.Cells["colDni"].Value?.ToString();
                TBNombre.Text = fila.Cells["colNombre"].Value?.ToString();
                TBApellido.Text = fila.Cells["colApellido"].Value?.ToString();
                TBCorreo.Text = fila.Cells["colEmail"].Value?.ToString();
                TBTelefono.Text = fila.Cells["colTelefono"].Value?.ToString();
                CBRolAsignado.Text = fila.Cells["colRol"].Value?.ToString();

                TBNombre.Focus();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
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
        private void ConfigurarGrid()
        {
            DGVUsuarios.AutoGenerateColumns = false; // Evita que SQL duplique columnas
            DGVUsuarios.Columns.Clear();

            // 1. Columna ID 
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id", 
                HeaderText = "ID",
                Name = "colId",
                Width = 50
            });

            // 2. Columna DNI
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "dni",
                HeaderText = "DNI",
                Name = "colDni",
                Width = 100
            });

            // 3. Columna Nombre
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "first_name",
                HeaderText = "Nombre",
                Name = "colNombre",
                Width = 120
            });

            // 4. Columna Apellido
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "last_name",
                HeaderText = "Apellido",
                Name = "colApellido",
                Width = 120
            });

            // 5. Columna Email
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "email",
                HeaderText = "Correo Electrónico",
                Name = "colEmail",
                Width = 160
            });

            // 6. Columna Teléfono
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "phone",
                HeaderText = "Teléfono",
                Name = "colTelefono",
                Width = 110
            });

            // 7. Columna Rol (Nombre del rol traído desde role.name)
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "role_name",
                HeaderText = "Rol",
                Name = "colRol",
                Width = 110
            });

            // 8. Columna Estado
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "status",
                HeaderText = "Estado",
                Name = "colEstado",
                Width = 110
            });

            // 9. Columna de botón Editar
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Editar",
                Name = "btnEditarFila",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            DGVUsuarios.Columns.Add(btnEditar);

            // 10. Columna botón eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Eliminar",
                Name = "btnEliminarFila",
                UseColumnTextForButtonValue = true, 
                Width = 80
            };
            DGVUsuarios.Columns.Add(btnEliminar);

            // Ajustes visuales generales
            DGVUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVUsuarios.AllowUserToAddRows = false;
            DGVUsuarios.ReadOnly = true;


        }

        private void CargarDatosPrueba()
        {
            DGVUsuarios.Rows.Add("1", "40123456", "Alice", "Perez" ,  "alice@test.com", "3456", "Administrador", "Activo");
            DGVUsuarios.Rows.Add("2", "38987654", "Bob", "Lopez", "bob@test.com", "1245", "Moderador", "Activo");
            DGVUsuarios.Rows.Add("3", "42555666", "Candice", "Smith", "candice@test.com", "987" , "Miembro", "Inactivo");
            DGVUsuarios.Rows.Add("4", "39111222", "David", "Johnson", "david@test.com", " 09876", "Miembro", "Activo");
        }

        private void PPanelDivisorio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BGuardar_Click(object sender, EventArgs e)
        {

        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            //Vacio los textboxes
            TBNombre.Clear();
            TBApellido.Clear();
            TBDni.Clear();
            TBCorreo.Clear();
            TBTelefono.Clear();
            TBContraseña.Clear();

            //vacio el combobox
            CBRolAsignado.SelectedIndex = -1;

            //vuelvo al primer textbox
            TBNombre.Focus();


        }

        private void BDesactivar_Click(object sender, EventArgs e)
        {

        }
    }
}
