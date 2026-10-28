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

        private readonly ClienteBusiness clienteBusiness = new ClienteBusiness();
        private int filaEnEdicionIndex = -1;

        // Paginación (15 registros por página)
        private const int TamanoPagina = 15;
        private int paginaActual = 1;
        private int totalPaginas = 1;
        private List<Cliente> listaClientesFiltrada = new List<Cliente>();

        public FormCliente()
        {
            InitializeComponent();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(TLPCards);
            Diseno.FormatearGrilla(DGVCliente, soloLectura: false);
            DGVCliente.EditMode = DataGridViewEditMode.EditProgrammatically;

            Diseno.FormatearBotonPrimario(BAnterior);
            Diseno.FormatearBotonPrimario(BSiguiente);
            Diseno.FormatearBotonPrimario(BBuscar);
            Diseno.FormatearBotonSecundario(BLimpiarFiltros);

            ConfigurarColumnasGrid();
            CargarGrillaClientes();
            CargarIndicadoresCards();

            SendMessage(TBBuscar.Handle, EM_SETCUEBANNER, 0, "Buscar por DNI o nombre ...");

            BAnterior.Click += BAnterior_Click;
            BSiguiente.Click += BSiguiente_Click;
            BBuscar.Click += BBuscar_Click;
            BLimpiarFiltros.Click += BLimpiarFiltros_Click;
            TBBuscar.KeyDown += TBBuscar_KeyDown;
        }

        #region Configuración de Columnas y Grilla
        private void ConfigurarColumnasGrid()
        {
            DGVCliente.Columns.Clear();
            DGVCliente.AutoGenerateColumns = false;
            DGVCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVCliente.ReadOnly = false;

            // 1. Columna DNI
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Dni",
                HeaderText = "DNI",
                ReadOnly = true,
                Name = "colDni",
                FillWeight = 85
            });

            // 2. Columna Nombre
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "colNombre",
                ReadOnly = false,
                FillWeight = 110
            });

            // 3. Columna Apellido
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                ReadOnly = false,
                Name = "colApellido",
                FillWeight = 110
            });

            // 4. Columna Email
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Correo",
                ReadOnly = false,
                Name = "colEmail",
                FillWeight = 140
            });

            // 5. Columna Teléfono
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                ReadOnly = false,
                Name = "colTelefono",
                FillWeight = 95
            });

            // 6. Columna Estado
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                Name = "colEstado",
                ReadOnly = true,
                FillWeight = 75,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 7. Botón Editar / Guardar
            DGVCliente.Columns.Add(new DataGridViewImageColumn
            {
                Name = "btnEditarFila",
                HeaderText = "Acción",
                ImageLayout = DataGridViewImageCellLayout.Normal,
                FillWeight = 55,
                ReadOnly = true
            });

            // 8. Botón Eliminar / Reactivar
            DGVCliente.Columns.Add(new DataGridViewImageColumn
            {
                Name = "btnEliminarFila",
                HeaderText = "Estado",
                ImageLayout = DataGridViewImageCellLayout.Normal,
                FillWeight = 55,
                ReadOnly = true
            });
        }
        #endregion

        #region Carga de Datos y Paginación
        private void CargarGrillaClientes()
        {
            string filtro = TBBuscar.Text.Trim();
            if (string.IsNullOrWhiteSpace(filtro) || filtro == "Buscar por DNI o nombre ...")
            {
                listaClientesFiltrada = clienteBusiness.ListarTodos();
            }
            else
            {
                listaClientesFiltrada = clienteBusiness.BuscarPorDniONombre(filtro);
            }

            AplicarPaginacion();
        }

        private void AplicarPaginacion()
        {
            if (listaClientesFiltrada == null || listaClientesFiltrada.Count == 0)
            {
                paginaActual = 1;
                totalPaginas = 1;
                DGVCliente.DataSource = null;
                DGVCliente.DataSource = new List<Cliente>();
            }
            else
            {
                totalPaginas = (int)Math.Ceiling((double)listaClientesFiltrada.Count / TamanoPagina);
                if (totalPaginas < 1) totalPaginas = 1;

                if (paginaActual > totalPaginas) paginaActual = totalPaginas;
                if (paginaActual < 1) paginaActual = 1;

                var itemsPagina = listaClientesFiltrada
                    .Skip((paginaActual - 1) * TamanoPagina)
                    .Take(TamanoPagina)
                    .ToList();

                DGVCliente.DataSource = null;
                DGVCliente.DataSource = itemsPagina;
            }

            filaEnEdicionIndex = -1;
            ActualizarControlesPaginacion();
        }

        private void ActualizarControlesPaginacion()
        {
            LPaginas.Text = $"Página {paginaActual} de {totalPaginas}";
            BAnterior.Enabled = paginaActual > 1;
            BSiguiente.Enabled = paginaActual < totalPaginas;
        }

        private void BAnterior_Click(object sender, EventArgs e)
        {
            if (filaEnEdicionIndex != -1) return;

            if (paginaActual > 1)
            {
                paginaActual--;
                AplicarPaginacion();
            }
        }

        private void BSiguiente_Click(object sender, EventArgs e)
        {
            if (filaEnEdicionIndex != -1) return;

            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                AplicarPaginacion();
            }
        }

        private void CargarIndicadoresCards()
        {
            LValorTotalClientes.Text = clienteBusiness.ContarTotalClientes().ToString();
            LValorNuevosMes.Text = clienteBusiness.ContarClientesNuevosMes().ToString();
            LValorTopMes.Text = clienteBusiness.ObtenerClienteTopMes();
            LValorTopMes.AutoEllipsis = true;
        }
        #endregion

        #region Acciones y Eventos de Grilla
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

            // Icono dinámico Editar / Guardar
            if (nombreColumna == "btnEditarFila")
            {
                bool estaEnEdicion = (e.RowIndex == filaEnEdicionIndex);
                e.Value = estaEnEdicion ? Resources.guardar : Resources.editar;
                e.FormattingApplied = true;
            }
            // Icono dinámico Eliminar / Reactivar
            else if (nombreColumna == "btnEliminarFila")
            {
                if (!(DGVCliente.Rows[e.RowIndex].DataBoundItem is Cliente cliente)) return;

                e.Value = cliente.Activo ? Resources.eliminar : Resources.activar;
                e.FormattingApplied = true;
            }
            // Columna Estado
            else if (nombreColumna == "colEstado")
            {
                if (!(DGVCliente.Rows[e.RowIndex].DataBoundItem is Cliente cliente)) return;

                e.Value = cliente.Estado;
                Diseno.FormatearCeldaEstado(e, DGVCliente, cliente.Activo);
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
            if (DGVCliente.Columns.Contains("colDireccion"))
            {
                cliente.Direccion = fila.Cells["colDireccion"].Value?.ToString()?.Trim() ?? "";
            }

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
        #endregion

        #region Búsqueda y Filtros
        private void BBuscar_Click(object sender, EventArgs e)
        {
            if (filaEnEdicionIndex != -1) return;
            paginaActual = 1;
            CargarGrillaClientes();
        }

        private void BLimpiarFiltros_Click(object sender, EventArgs e)
        {
            if (filaEnEdicionIndex != -1) return;
            TBBuscar.Text = string.Empty;
            paginaActual = 1;
            CargarGrillaClientes();
        }

        private void TBBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                if (filaEnEdicionIndex != -1) return;
                paginaActual = 1;
                CargarGrillaClientes();

                if (DGVCliente.Rows.Count > 0)
                {
                    DGVCliente.Focus();
                }
            }
        }
        #endregion
    }
}
