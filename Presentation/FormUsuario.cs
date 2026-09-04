using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices; //placeholder
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Presentation
{
    public partial class FormUsuario : Form
    {
        private int? usuarioIdSeleccionado = null;
        private int? personaIdSeleccionado = null;
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

            DataGridViewRow fila = DGVUsuarios.Rows[e.RowIndex];
            string rol = fila.Cells["colRol"].Value?.ToString();

            // Si es Superadmin, ignoramos cualquier clic en esa fila
            if (rol == "Superadmin")
            {
                return;
            }

            if (DGVUsuarios.Columns[e.ColumnIndex].Name == "btnEditarFila")
            {
               
                usuarioIdSeleccionado = Convert.ToInt32(fila.Cells["colId"].Value);
                personaIdSeleccionado = Convert.ToInt32(fila.Cells["colPersonId"].Value);

                // Pasamos los valores de la fila a los TextBox/ComboBox correspondientes
                TBDni.Text = fila.Cells["colDni"].Value?.ToString();
                TBNombre.Text = fila.Cells["colNombre"].Value?.ToString();
                TBApellido.Text = fila.Cells["colApellido"].Value?.ToString();
                TBCorreo.Text = fila.Cells["colEmail"].Value?.ToString();
                TBTelefono.Text = fila.Cells["colTelefono"].Value?.ToString();
                CBRolAsignado.Text = fila.Cells["colRol"].Value?.ToString();

                TBContraseña.Text = "";
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
            CargarRoles();
            CargarUsuarios();

            // Placeholder de textboxes 
            SendMessage(TBNombre.Handle, EM_SETCUEBANNER, 0, "Ej: María José");
            SendMessage(TBApellido.Handle, EM_SETCUEBANNER, 0, "Ej: Granatto");
            SendMessage(TBDni.Handle, EM_SETCUEBANNER, 0, "Número de documento");
            SendMessage(TBCorreo.Handle, EM_SETCUEBANNER, 0, "correo@ejemplo.com");
            SendMessage(TBTelefono.Handle, EM_SETCUEBANNER, 0, "Teléfono de contacto");
            SendMessage(TBBuscar.Handle, EM_SETCUEBANNER, 0, "Buscar por DNI ...");

            DGVUsuarios.ClearSelection();

        }
        private void ConfigurarGrid()
        {
            DGVUsuarios.AutoGenerateColumns = false; // Evita que SQL duplique columnas
            DGVUsuarios.Columns.Clear();

           

            // 0. Columna ID 
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id", 
                HeaderText = "ID",
                Name = "colId",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }

            });

            // 1. id de persona oculto
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "person_id", 
                HeaderText = "PersonId",
                Name = "colPersonId",           
                Visible = false                
            });
            // 2. Columna DNI
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "dni",
                HeaderText = "DNI",
                Name = "colDni"
                
            });

            // 3. Columna Nombre
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "first_name",
                HeaderText = "Nombre",
                Name = "colNombre"
                
                
            });

            // 4. Columna Apellido
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "last_name",
                HeaderText = "Apellido",
                Name = "colApellido"
                
            });

            // 5. Columna Email
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "email",
                HeaderText = "Correo",
                Name = "colEmail"
             
            });

            // 6. Columna Teléfono
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "phone",
                HeaderText = "Teléfono",
                Name = "colTelefono"
            });

            // 7. Columna Rol (Nombre del rol traído desde role.name)
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "role_name",
                HeaderText = "Rol",
                Name = "colRol"
            });

            // 8. ID de rol oculto
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "role_id",
                HeaderText = "RoleId",
                Name = "colRoleId",
                Visible = false
            });

            // 9. Columna Estado
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "status_text",
                HeaderText = "Estado",
                Name = "colEstado",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }

            });

            // 10. Columna de botón Editar
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Editar",
                Name = "btnEditarFila",
                UseColumnTextForButtonValue = true
                
            };
            DGVUsuarios.Columns.Add(btnEditar);

            // 11. Columna botón eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Eliminar",
                Name = "btnEliminarFila",
                UseColumnTextForButtonValue = true
                
            };
            DGVUsuarios.Columns.Add(btnEliminar);

            // Ajustes visuales generales
            DGVUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVUsuarios.AllowUserToAddRows = false;
            DGVUsuarios.ReadOnly = true;
            DGVUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //DGVUsuarios.Columns["colId"].Visible = false;

            // Fijar columnas cortas
            DGVUsuarios.Columns["colId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DGVUsuarios.Columns["colId"].Width = 25;

            DGVUsuarios.Columns["btnEditarFila"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DGVUsuarios.Columns["btnEditarFila"].Width = 70;

            DGVUsuarios.Columns["btnEliminarFila"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DGVUsuarios.Columns["btnEliminarFila"].Width = 75;

           // DGVUsuarios.Columns["colEstado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //DGVUsuarios.Columns["colEstado"].Width = 80;

            // El resto de columnas (DNI, Nombre, Apellido, Email, Rol) se acomodan solas
            DGVUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Centro texto de la cabecera
            DGVUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }
 
        private string connectionString = "Server=localhost,1433;Database=Matiensos_db;User Id=sa;Password=Matiensos123!;TrustServerCertificate=True;";

        private void CargarRoles()
        {
            try
            {
                    string query = @"
            SELECT id, name 
            FROM [role] 
            WHERE is_active = 1 
              AND name != 'Superadmin' 
            ORDER BY name ASC";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        CBRolAsignado.DataSource = dt;
                        CBRolAsignado.DisplayMember = "name";
                        CBRolAsignado.ValueMember = "id";
                        CBRolAsignado.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar roles: " + ex.Message);
                }
            }

        private void CargarUsuarios()
        {
            try
            {
                string query = @"
            SELECT 
                u.id,
                p.id AS person_id,
                u.role_id,
                p.dni,
                p.first_name,
                p.last_name,
                p.email,
                p.phone,
                r.name AS role_name,
                CASE WHEN p.is_active = 1 THEN 'Activo' ELSE 'Inactivo' END AS status_text
            FROM [user] u
            INNER JOIN [person] p ON u.person_id = p.id
            INNER JOIN [role] r ON u.role_id = r.id
            WHERE p.is_active = 1";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DGVUsuarios.DataSource = dt;
     
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void PPanelDivisorio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas
            if (string.IsNullOrWhiteSpace(TBNombre.Text) ||
                string.IsNullOrWhiteSpace(TBApellido.Text) ||
                string.IsNullOrWhiteSpace(TBDni.Text) ||
                CBRolAsignado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor complete los campos obligatorios (Nombre, Apellido, DNI y Rol).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usuarioIdSeleccionado == null && string.IsNullOrWhiteSpace(TBContraseña.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña para el nuevo usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    if (usuarioIdSeleccionado == null)
                    {
                        // alta nueva
                        string queryPersona = @"
                    INSERT INTO [person] (first_name, last_name, dni, email, phone, is_active)
                    VALUES (@Nombre, @Apellido, @Dni, @Email, @Telefono, 1);
                    SELECT SCOPE_IDENTITY();";

                        SqlCommand cmdPersona = new SqlCommand(queryPersona, conn, trans);
                        cmdPersona.Parameters.AddWithValue("@Nombre", TBNombre.Text.Trim());
                        cmdPersona.Parameters.AddWithValue("@Apellido", TBApellido.Text.Trim());
                        cmdPersona.Parameters.AddWithValue("@Dni", TBDni.Text.Trim());
                        cmdPersona.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(TBCorreo.Text) ? (object)DBNull.Value : TBCorreo.Text.Trim());
                        cmdPersona.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(TBTelefono.Text) ? (object)DBNull.Value : TBTelefono.Text.Trim());

                        int nuevaPersonaId = Convert.ToInt32(cmdPersona.ExecuteScalar());

                        string queryUsuario = @"
                    INSERT INTO [user] (password, role_id, person_id)
                    VALUES (@Password, @RoleId, @PersonId);";

                        SqlCommand cmdUsuario = new SqlCommand(queryUsuario, conn, trans);
                        cmdUsuario.Parameters.AddWithValue("@Password", TBContraseña.Text.Trim());
                        cmdUsuario.Parameters.AddWithValue("@RoleId", CBRolAsignado.SelectedValue);
                        cmdUsuario.Parameters.AddWithValue("@PersonId", nuevaPersonaId);
                        cmdUsuario.ExecuteNonQuery();
                    }
                    else
                    {
                        // editar usuario existente
                        string queryUpdatePersona = @"
                    UPDATE [person] 
                    SET first_name = @Nombre, last_name = @Apellido, dni = @Dni, 
                        email = @Email, phone = @Telefono, updated_at = GETDATE()
                    WHERE id = @PersonaId";

                        SqlCommand cmdPersona = new SqlCommand(queryUpdatePersona, conn, trans);
                        cmdPersona.Parameters.AddWithValue("@Nombre", TBNombre.Text.Trim());
                        cmdPersona.Parameters.AddWithValue("@Apellido", TBApellido.Text.Trim());
                        cmdPersona.Parameters.AddWithValue("@Dni", TBDni.Text.Trim());
                        cmdPersona.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(TBCorreo.Text) ? (object)DBNull.Value : TBCorreo.Text.Trim());
                        cmdPersona.Parameters.AddWithValue("@Telefono", string.IsNullOrWhiteSpace(TBTelefono.Text) ? (object)DBNull.Value : TBTelefono.Text.Trim());
                        cmdPersona.Parameters.AddWithValue("@PersonaId", personaIdSeleccionado.Value);
                        cmdPersona.ExecuteNonQuery();

                        // Si escribió algo en TBContraseña, actualizamos la clave; si lo dejó vacío, mantenemos la anterior
                        string queryUpdateUsuario = string.IsNullOrWhiteSpace(TBContraseña.Text)
                            ? "UPDATE [user] SET role_id = @RoleId WHERE id = @UsuarioId"
                            : "UPDATE [user] SET role_id = @RoleId, password = @Password WHERE id = @UsuarioId";

                        SqlCommand cmdUsuario = new SqlCommand(queryUpdateUsuario, conn, trans);
                        cmdUsuario.Parameters.AddWithValue("@RoleId", CBRolAsignado.SelectedValue);
                        cmdUsuario.Parameters.AddWithValue("@UsuarioId", usuarioIdSeleccionado.Value);
                        if (!string.IsNullOrWhiteSpace(TBContraseña.Text))
                        {
                            cmdUsuario.Parameters.AddWithValue("@Password", TBContraseña    .Text.Trim());
                        }
                        cmdUsuario.ExecuteNonQuery();
                    }

                    trans.Commit();
                    MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpieza
                    BLimpiar_Click(null, null);
                    usuarioIdSeleccionado = null;
                    personaIdSeleccionado = null;

                    // Recargar grilla
                    CargarUsuarios();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Error al guardar: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void DGVUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //bloquear el boton editar y eliminar para el superadmin
            if (e.RowIndex >= 0)
            {
                string nombreColumna = DGVUsuarios.Columns[e.ColumnIndex].Name;

                
                if (nombreColumna == "btnEditarFila" || nombreColumna == "btnEliminarFila")
                {
                    string rol = DGVUsuarios.Rows[e.RowIndex].Cells["colRol"].Value?.ToString();

                    
                    if (rol == "Superadmin")
                    {
                        e.Handled = true; 

                        
                        e.PaintBackground(e.CellBounds, true);


                        TextRenderer.DrawText(
                             e.Graphics,
                             "—",
                            e.CellStyle.Font,
                            e.CellBounds,
                            Color.Black,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                        );
                    }
                }
            }
        }
    }
}
