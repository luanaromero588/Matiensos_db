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
using Business;  // referencia al proyecto Business 
using Entities;

namespace Presentation
{
    public partial class FormUsuario : Form
    {
        // Instancias de las capas de negocio
        private UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        private RolBusiness rolBusiness = new RolBusiness();

        // Variables de estado: si son null es un Alta; si tienen valor es una Edición
        private int? usuarioIdSeleccionado = null;
        private int? personaIdSeleccionado = null;

        // API de Windows para mostrar texto de ayuda gris (placeholder) en los TextBox
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public FormUsuario()
        {
            InitializeComponent();

        }

        private void DGVUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = DGVUsuarios.Columns[e.ColumnIndex].Name;
            var fila = DGVUsuarios.Rows[e.RowIndex];
            string rol = fila.Cells["colRol"].Value?.ToString();

            // Regla de seguridad el SuperAdmin no se toca desde la grilla
            if (rol != null && rol.Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase)) return;
            
            int usuarioId = Convert.ToInt32(fila.Cells["colId"].Value);

            // Acción: Eliminar usuario
            if (colName == "btnEliminarFila")
            {
                DialogResult confirm = MessageBox.Show(
                    "¿Seguro que deseas eliminar este usuario?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        usuarioBusiness.EliminarUsuario(usuarioId, rol, Entities.Sesion.UsuarioId);
                        MessageBox.Show("Usuario eliminado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Acción: Editar usuario (carga los datos de la fila en los inputs)
            if (colName == "btnEditarFila")
            {
                usuarioIdSeleccionado = usuarioId;
                personaIdSeleccionado = Convert.ToInt32(fila.Cells["colPersonId"].Value);

                TBNombre.Text = fila.Cells["colNombre"].Value?.ToString();
                TBApellido.Text = fila.Cells["colApellido"].Value?.ToString();
                TBDni.Text = fila.Cells["colDni"].Value?.ToString();
                TBCorreo.Text = fila.Cells["colEmail"].Value?.ToString();
                TBTelefono.Text = fila.Cells["colTelefono"].Value?.ToString();
                CBRolAsignado.SelectedValue = Convert.ToInt32(fila.Cells["colRoleId"].Value);
                TBContraseña.Clear();
            }
        }

        // Se ejecuta al abrir la pantalla
        private void FormUsuario_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarRoles();
            CargarUsuarios();

            // Textos de ayuda en las cajas de texto
            SendMessage(TBNombre.Handle, EM_SETCUEBANNER, 0, "Ej: María José");
            SendMessage(TBApellido.Handle, EM_SETCUEBANNER, 0, "Ej: Granatto");
            SendMessage(TBDni.Handle, EM_SETCUEBANNER, 0, "Número de documento");
            SendMessage(TBCorreo.Handle, EM_SETCUEBANNER, 0, "correo@ejemplo.com");
            SendMessage(TBTelefono.Handle, EM_SETCUEBANNER, 0, "Teléfono de contacto");
            SendMessage(TBBuscar.Handle, EM_SETCUEBANNER, 0, "Buscar por DNI ...");

            DGVUsuarios.ClearSelection();

        }

        // Define las columnas del DataGridView y las enlaza a los campos del DataTable
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
                Width = 25,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }

            });
            // 1. Columna ID de Persona (oculto)
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
            // 7. Columna Rol
            DGVUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "role_name",
                HeaderText = "Rol",
                Name = "colRol"
            });
            // 8. ID Rol (oculto)
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
            // 10. Columna de Botón Editar
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Editar",
                Name = "btnEditarFila",
                UseColumnTextForButtonValue = true,
                Width = 70,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            };
            DGVUsuarios.Columns.Add(btnEditar);

            // 11. Columna Botón Eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Eliminar",
                Name = "btnEliminarFila",
                UseColumnTextForButtonValue = true,
                Width = 75,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            };
            DGVUsuarios.Columns.Add(btnEliminar);

            // Ajustes visuales generales
            DGVUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVUsuarios.AllowUserToAddRows = false;
            DGVUsuarios.ReadOnly = true;
            DGVUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // El resto de columnas (DNI, Nombre, Apellido, Email, Rol) se acomodan solas
            DGVUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Centro texto de la cabecera
            DGVUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            

        }

        // Consulta a Business para rellenar las opciones del desplegable de roles
        private void CargarRoles()
        {
            try
            {
                var listaRoles = rolBusiness.ObtenerRoles();

                CBRolAsignado.DataSource = listaRoles;
                CBRolAsignado.DisplayMember = "Nombre"; // Lo que el usuario ve escrito
                CBRolAsignado.ValueMember = "Id"; // El valor numérico interno
                CBRolAsignado.SelectedIndex = -1; // Inicia deseleccionado
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga o filtra la grilla con usuarios activos
        private void CargarUsuarios(string filtroDni = null)
        {
            try
            {
              
                DGVUsuarios.AutoGenerateColumns = false;

                DataTable dt = usuarioBusiness.BuscarUsuariosPorDni(filtroDni);
                DGVUsuarios.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Guardar sirve tanto para Insertar como para Actualizar
        private void BGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int? rolId = (CBRolAsignado.SelectedValue != null)
                    ? (int?)Convert.ToInt32(CBRolAsignado.SelectedValue)
                    : null;

                //  Delegar la validación y el guardado a Business

                usuarioBusiness.GuardarUsuario(
                    TBNombre.Text,
                    TBApellido.Text,
                    TBDni.Text,
                    TBCorreo.Text,
                    TBTelefono.Text,
                    rolId,
                    TBContraseña.Text,
                    personaIdSeleccionado,
                    usuarioIdSeleccionado,
                    Entities.Sesion.UsuarioId // <-- ID del usuario logueado
                );
                MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BLimpiar_Click(null, null);
                CargarUsuarios();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Aviso de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Limpia el formulario y resetea las variables de selección
        private void BLimpiar_Click(object sender, EventArgs e)
        {
            TBNombre.Clear();
            TBApellido.Clear();
            TBDni.Clear();
            TBCorreo.Clear();
            TBTelefono.Clear();
            TBContraseña.Clear();
            TBBuscar.Clear();

            CBRolAsignado.SelectedIndex = -1;
            usuarioIdSeleccionado = null;
            personaIdSeleccionado = null;

            CargarUsuarios();

            TBNombre.Focus();
        }

        // Filtro de teclado solo permite números en el DNI
        private void TBDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Filtro de teclado solo permite letras en el Nombre
        private void TBNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        // Filtro de teclado solo permite letras en el Apellido
        private void TBApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        // Filtro de teclado teléfono con números, espacios y guiones
        private void TBTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != ' ' && e.KeyChar != '-')
                e.Handled = true;
        }

        // Filtro de teclado en el buscador
        private void TBBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Búsqueda por clic
        private void BBuscar_Click(object sender, EventArgs e)
        {
            string texto = TBBuscar.Text.Trim();
            CargarUsuarios(string.IsNullOrWhiteSpace(texto) || texto == "Buscar por DNI ..." ? null : texto);
        }

        // Búsqueda al presionar Enter en el buscador
        private void BBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarUsuarios(TBBuscar.Text.Trim());
                e.Handled = true;
                e.SuppressKeyPress = true; 
            }
        }

        // Captura los clics en los botones dentro de la grilla (Editar / Eliminar)
        private void DGVUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= DGVUsuarios.Rows.Count) return;

            string colName = DGVUsuarios.Columns[e.ColumnIndex].Name;

            if (colName == "btnEditarFila" || colName == "btnEliminarFila")
            {
                var rol = DGVUsuarios.Rows[e.RowIndex].Cells["colRol"].Value?.ToString();

                if (rol != null && rol.Equals("SuperAdmin", StringComparison.OrdinalIgnoreCase))
                {
                    e.PaintBackground(e.CellBounds, true);
                    TextRenderer.DrawText(
                        e.Graphics,
                        "—",
                        e.CellStyle.Font,
                        e.CellBounds,
                        e.CellStyle.ForeColor,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );
                    e.Handled = true;
                }
            }
        }

        private void PCard1_Paint(object sender, PaintEventArgs e)
        {
            // Dibuja una franja verde de 4px pegada a la izquierda
            using (Brush brocha = new SolidBrush(Color.FromArgb(56, 97, 80)))
            {
                e.Graphics.FillRectangle(brocha, 0, 0, 4, PCard1.Height);
            }
        }

        private void PCard2_Paint(object sender, PaintEventArgs e)
        {
            using (Brush brocha = new SolidBrush(Color.FromArgb(56, 97, 80)))
            {
                e.Graphics.FillRectangle(brocha, 0, 0, 4, PCard1.Height);
            }
        }

        private void PCard3_Paint(object sender, PaintEventArgs e)
        {
            using (Brush brocha = new SolidBrush(Color.FromArgb(56, 97, 80)))
            {
                e.Graphics.FillRectangle(brocha, 0, 0, 4, PCard1.Height);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LTitleGestionUsuarios_Click(object sender, EventArgs e)
        {

        }
    } 
}
