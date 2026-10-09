using Business;
using Entities;
using Presentation.GestionAdministrador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation.Properties;

namespace Presentation
{
    public partial class FormCategorias : Form
    {
        private readonly CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        private int filaEnEdicionIndex = -1;
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(FLPCards);
            Diseno.FormatearGrilla(DGVCategorias, soloLectura: false);
            DGVCategorias.ReadOnly = false;
            DGVCategorias.EditMode = DataGridViewEditMode.EditOnEnter;
            ConfigurarColumnasGrid();
            DGVCategorias.AutoGenerateColumns = false;
            DGVCategorias.DataSource = categoriaBusiness.ObtenerCategoriasParaGrilla();
            
        }

        private void ConfigurarColumnasGrid()
        {
            DGVCategorias.Columns.Clear();
            DGVCategorias.AutoGenerateColumns = false;
            DGVCategorias.CellFormatting += DGVCategorias_CellFormatting;


            // 1. Nombre 
            DGVCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "nombre",
                HeaderText = "Nombre ",
                ReadOnly = true,
                Name = "colNombre" ,
                Width = 140,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // 2. Descrición
            DGVCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "descripcion",
                HeaderText = "Descripción",
                ReadOnly = true,
                Name = "colDescripcion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // 3. Cant. Productos
            DGVCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CantidadProductos",
                HeaderText = "Productos",
                Name = "colProductos",
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            });

            // 4. Stock Total
            DGVCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "stockTotal",
                HeaderText = "Stock Total",
                Name = "colStockTotal",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            });

            // 5. Estado
            DGVCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "estado",
                HeaderText = "Estado",
                Name = "colEstado",
                Width = 90,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 6. Editar
            DGVCategorias.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "Acción",
                Name = "btnEditarFila",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });
            // 7. Eliminar - baja lógica
            DGVCategorias.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "Acción",
                Name = "btnEliminarFila",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });


        }

        private void BNuevacategoria_Click(object sender, EventArgs e)
        {
            Diseno.MostrarModal(this, new FormNuevaCategoria());
        }

        // Acción: Alternar Estado (Desactivar / Reactivar)
        private void DGVCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = DGVCategorias.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "btnEditarFila" || nombreColumna == "colAccionEditar")
            {
                ManejarClickEditarGuardar(e.RowIndex);
            }
            else if (nombreColumna == "btnEliminarFila" || nombreColumna == "colAccionEstado")
            {
                ManejarClickEstado(e.RowIndex);
            }
        }

       

        /// <summary>
/// Cambia entre los modos de edición y guardado para la fila de categoría.
/// </summary>
private void ManejarClickEditarGuardar(int filaIndex)
        {
            bool estaEnEdicion = (filaIndex == filaEnEdicionIndex);

            if (!estaEnEdicion)
            {
                // Click en Editar
                if (filaEnEdicionIndex != -1)
                {
                    MessageBox.Show("Termine de editar la fila actual antes de editar otra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                HabilitarEdicionFila(filaIndex);
            }
            else
            {
                // Click en Guardar
                GuardarFila(filaIndex);
            }
        }

        /// <summary>
        /// Maneja la baja lógica o reactivación de la categoría seleccionada.
        /// </summary>
        private void ManejarClickEstado(int filaIndex)
        {
            if (filaEnEdicionIndex != -1)
            {
                MessageBox.Show("Termine de editar la fila actual antes de cambiar el estado de otra categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var categoria = DGVCategorias.Rows[filaIndex].DataBoundItem as CategoriaListadoDto;
            if (categoria == null) return;

            if (categoria.Estado == "Activo")
            {
                //  Bloqueo inmediato en la interfaz si tiene productos
                if (categoria.CantidadProductos > 0)
                {
                    MessageBox.Show(
                        $"No se puede desactivar la categoría \"{categoria.Nombre}\" porque tiene {categoria.CantidadProductos} producto(s) asociado(s).\n\nReasigne o elimine los productos primero.",
                        "Acción no permitida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Si no tiene productos, pide confirmación normal
                var confirmacion = MessageBox.Show(
                    $"¿Deseas desactivar la categoría \"{categoria.Nombre}\"?",
                    "Confirmar baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes) return;

                if (!categoriaBusiness.DesactivarCategoria(categoria.Id, categoria.CantidadProductos, out string mensaje))
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Reactivación normal
                var confirmacion = MessageBox.Show(
                    $"¿Deseas reactivar la categoría \"{categoria.Nombre}\"?",
                    "Confirmar reactivación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes) return;

                if (!categoriaBusiness.ReactivarCategoria(categoria.Id))
                {
                    MessageBox.Show("No se pudo reactivar la categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Categoría reactivada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarCategorias();
        }

        private void DGVCategorias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = DGVCategorias.Columns[e.ColumnIndex].Name;

            // Alternar icono entre Editar y Guardar
            if (nombreColumna == "btnEditarFila")
            {
                bool estaEnEdicion = (e.RowIndex == filaEnEdicionIndex);
                e.Value = estaEnEdicion ? Properties.Resources.guardar : Properties.Resources.editar;
                e.FormattingApplied = true;
            }
            // Alternar icono entre Eliminar y Activar
            else if (nombreColumna == "btnEliminarFila")
            {
                if (!(DGVCategorias.Rows[e.RowIndex].DataBoundItem is CategoriaListadoDto categoria)) return;

                bool esActivo = categoria.Estado == "Activo";
                e.Value = esActivo ? Properties.Resources.eliminar : Properties.Resources.activar;
                e.FormattingApplied = true;
            }
            // Colores de la columna Estado (Verde / Rojo)
            else if (nombreColumna == "colEstado" && e.Value != null)
            {
                string estado = e.Value.ToString();
                if (estado == "Activo")
                {
                    e.CellStyle.ForeColor = Color.ForestGreen;
                    e.CellStyle.Font = new Font(DGVCategorias.Font, FontStyle.Regular);
                }
                else if (estado == "Inactivo")
                {
                    e.CellStyle.ForeColor = Color.Crimson;
                    e.CellStyle.Font = new Font(DGVCategorias.Font, FontStyle.Regular);
                }
            }
        }

        private void HabilitarEdicionFila(int filaIndex)
        {
            var fila = DGVCategorias.Rows[filaIndex];

            // Solo habilitamos Nombre y Descripción 
            fila.Cells["colNombre"].ReadOnly = false;
            fila.Cells["colDescripcion"].ReadOnly = false;

            // Las demás permanecen bloqueadas
            fila.Cells["colProductos"].ReadOnly = true;
            fila.Cells["colStockTotal"].ReadOnly = true;
            fila.Cells["colEstado"].ReadOnly = true;

            fila.DefaultCellStyle.BackColor = Color.LightYellow;
            filaEnEdicionIndex = filaIndex;

            DGVCategorias.CurrentCell = fila.Cells["colNombre"];
            DGVCategorias.BeginEdit(true);

            // Refresca la celda del botón para que cambie a "Guardar"
            DGVCategorias.InvalidateRow(filaIndex);
        }

        private void GuardarFila(int filaIndex)
        {
            DGVCategorias.EndEdit();

            var fila = DGVCategorias.Rows[filaIndex];
            var categoriaOriginal = fila.DataBoundItem as CategoriaListadoDto;
            if (categoriaOriginal == null) return;

            string nuevoNombre = fila.Cells["colNombre"].Value?.ToString()?.Trim() ?? "";
            string nuevaDescripcion = fila.Cells["colDescripcion"].Value?.ToString()?.Trim() ?? "";

            if (!categoriaBusiness.ActualizarCategoria(categoriaOriginal.Id, nuevoNombre, nuevaDescripcion, out string mensaje))
            {
                MessageBox.Show(mensaje, "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            fila.DefaultCellStyle.BackColor = Color.White;
            filaEnEdicionIndex = -1;

            CargarCategorias();
        }

        private void CargarCategorias()
        {
            DGVCategorias.DataSource = categoriaBusiness.ObtenerCategoriasParaGrilla();
        }
    }
}
