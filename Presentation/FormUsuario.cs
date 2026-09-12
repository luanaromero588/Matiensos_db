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

            // Limpieza de todos los mensajes de error
            LimpiarError(LErrorDni, TBDni);
            LimpiarError(LErrorNombre, TBNombre);
            LimpiarError(LErrorApellido, TBApellido);
            LimpiarError(LErrorCorreo, TBCorreo);
            LimpiarError(LErrorTelefono, TBTelefono);
            LimpiarError(LErrorContraseña, TBContraseña);
            LimpiarError(LErrorRol, CBRolAsignado);

            BloquearCamposSiguientes(true);
            TBDni.Focus();
        }

        // Filtro de teclado solo permite números en el DNI
        private void TBDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        //Verifica en tiempo real campos del formulario y muestra errores si es necesario

        //  Se ejecuta automáticamente cuando el usuario sale del TextBox (hace clic afuera o pulsa Tab)
        private void TBDni_Leave(object sender, EventArgs e)
        {
            string dni = TBDni.Text.Trim(); //Trim() quita cualquier espacio en blanco

            if (string.IsNullOrEmpty(dni))
            {
                MostrarError(LErrorDni, TBDni, "El DNI es obligatorio.");
                BloquearCamposSiguientes(false);
                return;
            }

            if (dni.Length < 7 || dni.Length > 8)
            {
                MostrarError(LErrorDni, TBDni, "El DNI debe contener 7 u 8 números.");
                BloquearCamposSiguientes(false);
                return;
            }

            bool yaExiste = usuarioBusiness.ExisteDni(dni, personaIdSeleccionado, out string mensaje);

            if (yaExiste || !string.IsNullOrEmpty(mensaje))
            {
                MostrarError(LErrorDni, TBDni, mensaje);
                BloquearCamposSiguientes(false);
            }
            else
            {
                LimpiarError(LErrorDni, TBDni);
                bool estabanBloqueados = !TBNombre.Enabled;
                BloquearCamposSiguientes(true);
            }
        }
        
        //validacion mientras escribe
        private void TBDni_TextChanged(object sender, EventArgs e)
        {
            string dni = TBDni.Text.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                MostrarError(LErrorDni, TBDni, "El DNI es obligatorio.");
                BloquearCamposSiguientes(false);
                return;
            }

            if (dni.Length < 7 || dni.Length > 8)
            {
                MostrarError(LErrorDni, TBDni, "El DNI debe contener 7 u 8 números.");
                BloquearCamposSiguientes(false);
                return;
            }

            bool yaExiste = usuarioBusiness.ExisteDni(dni, personaIdSeleccionado, out string mensaje);

            if (yaExiste || !string.IsNullOrEmpty(mensaje))
            {
                MostrarError(LErrorDni, TBDni, mensaje);
                BloquearCamposSiguientes(false);
            }
            else
            {
                LimpiarError(LErrorDni, TBDni);
                BloquearCamposSiguientes(true);
            }

        }

        private void TBNombre_Leave(object sender, EventArgs e)
        {
            // Si el campo está bloqueado (por ejemplo, porque el DNI falló), no validamos nada
            if (!TBNombre.Enabled) return;

            if (!usuarioBusiness.ValidarNombre(TBNombre.Text, out string err))
                MostrarError(LErrorNombre, TBNombre, err);
            else
                LimpiarError(LErrorNombre, TBNombre);
        }

        private void TBApellido_Leave(object sender, EventArgs e)
        {
            if (!TBApellido.Enabled) return;

            if (!usuarioBusiness.ValidarApellido(TBApellido.Text, out string err))
                MostrarError(LErrorApellido, TBApellido, err);
            else
                LimpiarError(LErrorApellido, TBApellido);
        }

        private void TBCorreo_Leave(object sender, EventArgs e)
        {
            if (!TBCorreo.Enabled) return;

            if (!usuarioBusiness.ValidarCorreo(TBCorreo.Text, out string err))
                MostrarError(LErrorCorreo, TBCorreo, err);
            else
                LimpiarError(LErrorCorreo, TBCorreo);
        }

        private void TBTelefono_Leave(object sender, EventArgs e)
        {
            if (!TBTelefono.Enabled) return;

            if (!usuarioBusiness.ValidarTelefono(TBTelefono.Text, out string err))
                MostrarError(LErrorTelefono, TBTelefono, err);
            else
                LimpiarError(LErrorTelefono, TBTelefono);
        }

        private void TBContraseña_Leave(object sender, EventArgs e)
        {
            if (!TBContraseña.Enabled) return;

            bool esEdicion = usuarioIdSeleccionado.HasValue;
            if (!usuarioBusiness.ValidarContraseña(TBContraseña.Text, esEdicion, out string err))
                MostrarError(LErrorContraseña, TBContraseña, err);
            else
                LimpiarError(LErrorContraseña, TBContraseña);
        }

        private void CBRolAsignado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? rolId = (CBRolAsignado.SelectedValue != null && int.TryParse(CBRolAsignado.SelectedValue.ToString(), out int id))
                ? (int?)id
                : null;

            if (!usuarioBusiness.ValidarRol(rolId, out string err))
                MostrarError(LErrorRol, CBRolAsignado, err);
            else
                LimpiarError(LErrorRol, CBRolAsignado);
        }

        //valido todos los campos si el usuario dar click en guardar
        private bool ValidarFormularioCompleto()
        {
            bool esValido = true;

            // 1. DNI
            string dni = TBDni.Text.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                MostrarError(LErrorDni, TBDni, "El DNI es obligatorio.");
                esValido = false;
            }
            else if (usuarioBusiness.ExisteDni(dni, personaIdSeleccionado, out string errDni))
            {
                MostrarError(LErrorDni, TBDni, errDni);
                esValido = false;
            }
            else if (!string.IsNullOrEmpty(errDni))
            {
                MostrarError(LErrorDni, TBDni, errDni);
                esValido = false;
            }

            // 2. Nombre
            if (!usuarioBusiness.ValidarNombre(TBNombre.Text, out string errNom))
            {
                MostrarError(LErrorNombre, TBNombre, errNom);
                esValido = false;
            }

            // 3. Apellido
            if (!usuarioBusiness.ValidarApellido(TBApellido.Text, out string errApe))
            {
                MostrarError(LErrorApellido, TBApellido, errApe);
                esValido = false;
            }

            // 4. Correo
            if (!usuarioBusiness.ValidarCorreo(TBCorreo.Text, out string errMail))
            {
                MostrarError(LErrorCorreo, TBCorreo, errMail);
                esValido = false;
            }

            // 5. Teléfono
            if (!usuarioBusiness.ValidarTelefono(TBTelefono.Text, out string errTel))
            {
                MostrarError(LErrorTelefono, TBTelefono, errTel);
                esValido = false;
            }

            // 6. Rol
            int? rolId = (CBRolAsignado.SelectedValue != null && int.TryParse(CBRolAsignado.SelectedValue.ToString(), out int id))
                ? (int?)id
                : null;
            if (!usuarioBusiness.ValidarRol(rolId, out string errRol))
            {
                MostrarError(LErrorRol, CBRolAsignado, errRol);
                esValido = false;
            }

            // 7. Password
            bool esEdicion = usuarioIdSeleccionado.HasValue;
            if (!usuarioBusiness.ValidarContraseña(TBContraseña.Text, esEdicion, out string errPass))
            {
                MostrarError(LErrorContraseña, TBContraseña, errPass);
                esValido = false;
            }

            return esValido;
        }

        // Métodos genericos error
        private void MostrarError(Label lbl, Control control, string mensaje)
        {
            lbl.Text = mensaje;
            lbl.Visible = true;
            control.BackColor = Color.MistyRose;
        }

        private void LimpiarError(Label lbl, Control control)
        {
            lbl.Text = string.Empty;
            lbl.Visible = false;
            control.BackColor = Color.White;
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
        private void TBBuscar_KeyDown(object sender, KeyEventArgs e)
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

        //paint de cards
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
                e.Graphics.FillRectangle(brocha, 0, 0, 4, PCard2.Height);
            }
        }

        private void PCard3_Paint(object sender, PaintEventArgs e)
        {
            using (Brush brocha = new SolidBrush(Color.FromArgb(56, 97, 80)))
            {
                e.Graphics.FillRectangle(brocha, 0, 0, 4, PCard3.Height);
            }
        }

        // Método auxiliar para no dejar continuar al usuario si el DNI está duplicado
        private void BloquearCamposSiguientes(bool habilitar)
        {
            TBNombre.Enabled = habilitar;
            TBApellido.Enabled = habilitar;
            TBCorreo.Enabled = habilitar;
            TBTelefono.Enabled = habilitar;
            TBContraseña.Enabled = habilitar;
            CBRolAsignado.Enabled = habilitar;
            BGuardar.Enabled = habilitar;

            if (!habilitar)
            {
                LimpiarError(LErrorNombre, TBNombre);
                LimpiarError(LErrorApellido, TBApellido);
                LimpiarError(LErrorCorreo, TBCorreo);
                LimpiarError(LErrorTelefono, TBTelefono);
                LimpiarError(LErrorContraseña, TBContraseña);
                LimpiarError(LErrorRol, CBRolAsignado);
            }

        }
    } 
}
