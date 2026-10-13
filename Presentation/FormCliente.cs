using Business;
using Entities;
using Presentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FormCliente : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private ClienteBusiness clienteBusiness = new ClienteBusiness();
        private int filaEnEdicionIndex = -1;
        public FormCliente()
        {
            InitializeComponent();
            this.AcceptButton = null;
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(FLPCards);
            Diseno.FormatearGrilla(DGVCliente, soloLectura: false);
            ConfigurarColumnasGrid();
            CargarGrillaClientes();
            CargarIndicadoresCards();

            SendMessage(TBBuscar.Handle, EM_SETCUEBANNER, 0, "Buscar por DNI ...");

            TBBuscar.KeyDown += TBBuscar_KeyDown;
        }

        private void CargarGrillaClientes()
        {
            DGVCliente.DataSource = null;
            DGVCliente.DataSource = clienteBusiness.ListarTodos();
        }
        private void ConfigurarColumnasGrid()
        {
            DGVCliente.Columns.Clear();
            DGVCliente.AutoGenerateColumns = false;
            DGVCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVCliente.ReadOnly = false;

            // 2. Columna DNI
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Dni",
                HeaderText = "DNI",
                ReadOnly=true,
                Name = "colDni"

            });
            // 3. Columna Nombre
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "colNombre",
                ReadOnly = false


            });
            // 4. Columna Apellido
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                ReadOnly = false,
                Name = "colApellido"

            });
            // 5. Columna Email
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Correo",
                ReadOnly = false,
                Name = "colEmail"

            });
            // 6. Columna Teléfono
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                ReadOnly = false,
                Name = "colTelefono"
            });
            // 7. Columna direccion
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Direccion",
                HeaderText = "Dirección",
                ReadOnly = false,
                Name = "colDireccion"
            });
           
            // 8. Columna Estado
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                Name = "colEstado",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }

            });
            // 6. Editar
            DGVCliente.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "Acción",
                Name = "btnEditarFila",
                ImageLayout = DataGridViewImageCellLayout.Normal,
                Width = 60,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });
            // 7. Eliminar - baja lógica
            DGVCliente.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "Acción",
                Name = "btnEliminarFila",
                ImageLayout = DataGridViewImageCellLayout.Normal,
                Width = 60,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });


        }
        private void CargarIndicadoresCards()
        {
            LTotalActivos.Text = clienteBusiness.ContarTotalClientes().ToString();
            LClientesNuevos.Text = clienteBusiness.ContarClientesNuevosMes().ToString();
            LClientesTop.Text = clienteBusiness.ObtenerClienteTopMes();
        }

        private void DGVCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = DGVCliente.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "btnEditarFila")
            {
                ManejarClickEditarGuardar(e.RowIndex);
            }
            else if (nombreColumna == "btnEliminarFila")
            {
                ManejarClickEstado(e.RowIndex);
            }
        }

        private void ManejarClickEditarGuardar(int filaIndex)
        {
            bool estaEnEdicion = (filaIndex == filaEnEdicionIndex);

            if (!estaEnEdicion)
            {
                if (filaEnEdicionIndex != -1)
                {
                    MessageBox.Show("Termine de editar la fila actual antes de editar otra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                HabilitarEdicionFila(filaIndex);
            }
            else
            {
                GuardarFila(filaIndex);
            }
        }

        private void ManejarClickEstado(int filaIndex)
        {
            if (filaEnEdicionIndex != -1)
            {
                MessageBox.Show("Termine de editar la fila actual antes de cambiar el estado de otro registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = DGVCliente.Rows[filaIndex].DataBoundItem as Cliente;
            if (cliente == null) return;

            bool nuevoEstado = !cliente.Activo;
            string accion = cliente.Activo ? "desactivar" : "reactivar";

            var confirmacion = MessageBox.Show(
                $"¿Deseas {accion} al cliente \"{cliente.NombreCompleto}\"?",
                "Confirmar acción",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes) return;

            if (!clienteBusiness.CambiarEstado(cliente.Id, nuevoEstado, out string mensaje))
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrillaClientes();
            CargarIndicadoresCards();
        }

        private void DGVCliente_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = DGVCliente.Columns[e.ColumnIndex].Name;

            //  Icono dinámico Editar / Guardar
            if (nombreColumna == "btnEditarFila")
            {
                bool estaEnEdicion = (e.RowIndex == filaEnEdicionIndex);
                e.Value = estaEnEdicion ? Resources.guardar : Resources.editar;
                e.FormattingApplied = true;
            }
            //  Icono dinámico Eliminar / Reactivar
            else if (nombreColumna == "btnEliminarFila")
            {
                if (!(DGVCliente.Rows[e.RowIndex].DataBoundItem is Cliente cliente)) return;

                e.Value = cliente.Activo ? Resources.eliminar : Resources.activar;
                e.FormattingApplied = true;
            }
            // Columna Estado: texto verde / rojo
            else if (nombreColumna == "colEstado")
            {
                if (!(DGVCliente.Rows[e.RowIndex].DataBoundItem is Cliente cliente)) return;

                e.Value = cliente.Estado;

                if (cliente.Activo)
                {
                    e.CellStyle.ForeColor = Color.ForestGreen;
                    e.CellStyle.Font = new Font(DGVCliente.Font, FontStyle.Regular);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Crimson;
                    e.CellStyle.Font = new Font(DGVCliente.Font, FontStyle.Regular);
                }
                e.FormattingApplied = true;
            }
        }

        private void HabilitarEdicionFila(int filaIndex)
        {
            var fila = DGVCliente.Rows[filaIndex];

            fila.DefaultCellStyle.BackColor = Color.LightYellow;
            filaEnEdicionIndex = filaIndex;

            DGVCliente.CurrentCell = fila.Cells["colNombre"];
            DGVCliente.BeginEdit(true);
            DGVCliente.InvalidateRow(filaIndex);
        }

        private void GuardarFila(int filaIndex)
        {
            DGVCliente.EndEdit();

            var fila = DGVCliente.Rows[filaIndex];
            var cliente = fila.DataBoundItem as Cliente;
            if (cliente == null) return;

            cliente.Nombre = fila.Cells["colNombre"].Value?.ToString()?.Trim() ?? "";
            cliente.Apellido = fila.Cells["colApellido"].Value?.ToString()?.Trim() ?? "";
            cliente.Email = fila.Cells["colEmail"].Value?.ToString()?.Trim() ?? "";
            cliente.Telefono = fila.Cells["colTelefono"].Value?.ToString()?.Trim() ?? "";
            cliente.Direccion = fila.Cells["colDireccion"].Value?.ToString()?.Trim() ?? "";

            if (!clienteBusiness.ModificarCliente(cliente, out string mensaje))
            {
                MessageBox.Show(mensaje, "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            fila.DefaultCellStyle.BackColor = Color.White;
            filaEnEdicionIndex = -1;

            CargarGrillaClientes();
            CargarIndicadoresCards();
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            if (filaEnEdicionIndex != -1) return;

            string dni = TBBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(dni))
            {
                DGVCliente.DataSource = null;
                DGVCliente.DataSource = clienteBusiness.ListarTodos();
                return;
            }

            List<Cliente> clientesEncontrados = clienteBusiness.BuscarCoincidenciasPorDni(dni);

            DGVCliente.DataSource = null;
            if (clientesEncontrados != null && clientesEncontrados.Count > 0)
            {
                DGVCliente.DataSource = clientesEncontrados;
            }
            else
            {
                DGVCliente.DataSource = new List<Cliente>();
            }
        }

        private void EjecutarBusqueda()
        {
            // Si hay una fila en edición, no filtramos para evitar perder datos
            if (filaEnEdicionIndex != -1) return;

            string filtro = TBBuscar.Text.Trim();

            DGVCliente.DataSource = null;
            if (string.IsNullOrWhiteSpace(filtro))
            {
                DGVCliente.DataSource = clienteBusiness.ListarTodos();
            }
            else
            {
                DGVCliente.DataSource = clienteBusiness.BuscarCoincidenciasPorDni(filtro);
            }
        }

        private void TBBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                EjecutarBusqueda();

                if (DGVCliente.Rows.Count > 0)
                {
                    DGVCliente.Focus();
                }
            }
        }
    }


}
