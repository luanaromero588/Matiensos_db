using Business;
using Entities;
using Presentation.GestionAdministrador;
using Presentation.Properties;
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
    public partial class FormMetodosPago : Form
    {
        private readonly MetodoPagoBusiness metodoPagoBusiness = new MetodoPagoBusiness();
        private int filaEnEdicionIndex = -1;
        public FormMetodosPago()
        {
            InitializeComponent();
        }
        private void FormMetodosPago_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(TLPCards);
            Diseno.FormatearGrilla(DGVMetodosPago, soloLectura: false);
            //DGVMetodosPago.ReadOnly = false;
            //DGVMetodosPago.EditMode = DataGridViewEditMode.EditOnEnter;
            //Diseno.FormatearBotonPrimario(BNuevoMP);
            ConfigurarColumnasGrid();
            CargarMetodosPago();
            CargarIndicadoresCards();
        }
        
        /// <summary>
        /// Configura el grid para la correcta visualización de los datos.
        /// </summary>
        private void ConfigurarColumnasGrid()
        {
            DGVMetodosPago.DataSource = null;
            DGVMetodosPago.AutoGenerateColumns = false;
            DGVMetodosPago.Columns.Clear();
            DGVMetodosPago.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Nombre
            var colNombre = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                ReadOnly = true,
                Name = "colNombre",
                Width = 200,
                MaxInputLength = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            DGVMetodosPago.Columns.Add(colNombre);

            // Descripción
            var colDescripcion = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                Name = "colDescripcion",
                ReadOnly = true,
                MaxInputLength = 255,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DGVMetodosPago.Columns.Add(colDescripcion);

            // 5. Estado
            DGVMetodosPago.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Activo",
                HeaderText = "Estado",
                Name = "colEstado",
                ReadOnly = true,
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 6. Editar
            DGVMetodosPago.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "Acción",
                Name = "btnEditarFila",
                ImageLayout = DataGridViewImageCellLayout.Normal,
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });
            // 7. Eliminar - baja lógica
            DGVMetodosPago.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "Acción",
                Name = "btnEliminarFila",
                ImageLayout = DataGridViewImageCellLayout.Normal,
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });


        }

        /// <summary>
        /// Boton para crear un nuevo metodo de pago.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BNuevoMP_Click(object sender, EventArgs e)
        {
            var modal = new FormNuevoMetodoPago();
            Diseno.MostrarModal(this, modal, () =>
            {
                CargarMetodosPago();
                CargarIndicadoresCards();
            });
        }


        private void DGVMetodosPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = DGVMetodosPago.Columns[e.ColumnIndex].Name;

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

            var item = DGVMetodosPago.Rows[filaIndex].DataBoundItem as MetodoPago;
            if (item == null) return;

            bool nuevoEstado = !item.Activo;
            string accion = item.Activo ? "desactivar" : "reactivar";

            var confirmacion = MessageBox.Show(
                $"¿Deseas {accion} el método de pago \"{item.Nombre}\"?",
                "Confirmar acción",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes) return;

            if (!metodoPagoBusiness.CambiarEstado(item.Id, nuevoEstado, out string mensaje))
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarMetodosPago();
            CargarIndicadoresCards();
        }

        private void DGVMetodosPago_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = DGVMetodosPago.Columns[e.ColumnIndex].Name;

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
                if (!(DGVMetodosPago.Rows[e.RowIndex].DataBoundItem is MetodoPago item)) return;

                e.Value = item.Activo ? Resources.eliminar : Resources.activar;
                e.FormattingApplied = true;
            }
            // Columna Estado: texto verde / rojo
            else if (nombreColumna == "colEstado" && e.Value != null)
            {
                bool esActivo = Convert.ToBoolean(e.Value);
                e.Value = esActivo ? "Activo" : "Inactivo";

                if (esActivo)
                {
                    e.CellStyle.ForeColor = Color.ForestGreen;
                    e.CellStyle.Font = new Font(DGVMetodosPago.Font, FontStyle.Regular);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Crimson;
                    e.CellStyle.Font = new Font(DGVMetodosPago.Font, FontStyle.Regular);
                }
                e.FormattingApplied = true;
            }
        }

        private void HabilitarEdicionFila(int filaIndex)
        {
            var fila = DGVMetodosPago.Rows[filaIndex];

            fila.Cells["colNombre"].ReadOnly = false;
            fila.Cells["colDescripcion"].ReadOnly = false;
            fila.Cells["colEstado"].ReadOnly = true;

            fila.DefaultCellStyle.BackColor = Color.LightYellow;
            filaEnEdicionIndex = filaIndex;

            DGVMetodosPago.CurrentCell = fila.Cells["colNombre"];
            DGVMetodosPago.BeginEdit(true);
            DGVMetodosPago.InvalidateRow(filaIndex);
        }

        private void GuardarFila(int filaIndex)
        {
            DGVMetodosPago.EndEdit();

            var fila = DGVMetodosPago.Rows[filaIndex];
            var itemOriginal = fila.DataBoundItem as MetodoPago;
            if (itemOriginal == null) return;

            string nuevoNombre = fila.Cells["colNombre"].Value?.ToString()?.Trim() ?? "";
            string nuevaDescripcion = fila.Cells["colDescripcion"].Value?.ToString()?.Trim() ?? "";

            if (!metodoPagoBusiness.ModificarMetodoPago(itemOriginal.Id, nuevoNombre, nuevaDescripcion, out string mensaje))
            {
                MessageBox.Show(mensaje, "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DGVMetodosPago.CurrentCell = fila.Cells["colNombre"];
                DGVMetodosPago.BeginEdit(true);
                return;
            }

            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            fila.DefaultCellStyle.BackColor = Color.White;
            filaEnEdicionIndex = -1;

            CargarMetodosPago();
            CargarIndicadoresCards();
        }

        private void CargarMetodosPago()
        {
            DGVMetodosPago.DataSource = null;
            DGVMetodosPago.DataSource = metodoPagoBusiness.ListarTodos();
        }

        /// <summary>
        /// Carga valores estadísticos en las tarjetas informativas superiores.
        /// </summary>
        private void CargarIndicadoresCards()
        {
            LTotalActivos.Text = metodoPagoBusiness.ContarTotalMetodosPago().ToString();
            LCategoriasMasV.Text = metodoPagoBusiness.ObtenerMetodoMasIngresos();
            LCategoriasMenosV.Text = metodoPagoBusiness.ObtenerMetodoMenosIngresos();
        }
    }
}

