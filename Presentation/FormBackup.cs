using Business;
using Entities;
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
        public partial class FormBackup : Form
    {
        private readonly BackupBusiness backupBusiness = new BackupBusiness();

        // Variables de Paginación
        private int paginaActual = 1;
        private int totalPaginas = 1;
        private const int TamanoPagina = 15;
        private List<BackupItem> listaBackupsCompleta = new List<BackupItem>();
        public FormBackup()
        {
            InitializeComponent();
        }

        private void FormBackup_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.copia_de_respaldo;
            pictureBox2.Image = Properties.Resources.apoyo;
            pictureBox3.Image = Properties.Resources.tarjeta_de_memoria;
            Diseno.ConfigurarCards(FLPCards);
            Diseno.FormatearGrilla(DGVBackup, soloLectura: true);
            Diseno.FormatearBotonPrimario(BAnterior);
            Diseno.FormatearBotonPrimario(BSiguiente);
            DGVBackup.ReadOnly = true;
            DGVBackup.EditMode = DataGridViewEditMode.EditOnEnter;
            ConfigurarColumnasGrid();
            CargarBackupsYCards();

        }

        #region 1. Grilla
        private void ConfigurarColumnasGrid()
        {
            DGVBackup.Columns.Clear();
            DGVBackup.AutoGenerateColumns = false;

            // 1. Nombre 
            DGVBackup.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "archvo",
                HeaderText = "Archivo",
                ReadOnly = true,
                Name = "colArchivo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // 2. Descrición
            DGVBackup.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "fecha",
                HeaderText = "Fecha de Creación",
                ReadOnly = true,
                Name = "colFecha",
                Width = 150,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 3. Cant. Productos
            DGVBackup.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "tamaño",
                HeaderText = "Tamaño",
                ReadOnly = true,
                Name = "colTamaño",
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 4. Stock Total
            DGVBackup.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "usuario",
                HeaderText = "Usuario",
                ReadOnly = true,
                Name = "colUsuario",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 6. Editar
            DGVBackup.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "Restaurar",
                Name = "btnRestaurarFila",
                ImageLayout = DataGridViewImageCellLayout.Normal,
                Width = 85,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });
            // 7. Eliminar - baja lógica
            DGVBackup.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "Eliminar",
                Name = "btnEliminarFila",
                ImageLayout = DataGridViewImageCellLayout.Normal,
                Width = 85,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });


        }

        #endregion

        private void DGVBackup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = DGVBackup.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "btnRestaurarFila")
            {
                ManejarClickRestaurar(e.RowIndex);
            }
            else if (nombreColumna == "btnEliminarFila")
            {
                ManejarClickEliminar(e.RowIndex);
            }
        }

        private void DGVBackup_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = DGVBackup.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "btnRestaurarFila")
            {
                e.Value = Properties.Resources.sincronizar;
                e.FormattingApplied = true;
            }
            else if (nombreColumna == "btnEliminarFila")
            {
                e.Value = Properties.Resources.eliminar;
                e.FormattingApplied = true;
            }
        }
                /// <summary>
        /// Carga todos los archivos de respaldo disponibles, actualiza los indicadores KPI y aplica paginación.
        /// </summary>
        private void CargarBackupsYCards()
        {
            try
            {
                listaBackupsCompleta = backupBusiness.ListarBackups() ?? new List<BackupItem>();

                totalPaginas = (int)Math.Ceiling((double)listaBackupsCompleta.Count / TamanoPagina);
                if (totalPaginas < 1) totalPaginas = 1;

                if (paginaActual > totalPaginas) paginaActual = totalPaginas;
                if (paginaActual < 1) paginaActual = 1;

                AplicarPaginacionBackups();

                // Carga de Cards
                LTotalRespaldos.Text = listaBackupsCompleta.Count.ToString();
                LUltRespaldoFecha.Text = listaBackupsCompleta.Count > 0 ? listaBackupsCompleta[0].fecha : "Sin registros";
                LUltRespaldoTamaño.Text = listaBackupsCompleta.Count > 0 ? listaBackupsCompleta[0].tamaño : "0 MB";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar archivos de backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Aplica la paginación a la lista de respaldos y actualiza el DataGridView.
        /// </summary>
        private void AplicarPaginacionBackups()
        {
            var itemsPagina = listaBackupsCompleta
                .Skip((paginaActual - 1) * TamanoPagina)
                .Take(TamanoPagina)
                .ToList();

            DGVBackup.DataSource = null;
            DGVBackup.DataSource = itemsPagina;

            ActualizarControlesPaginacion();
        }

        /// <summary>
        /// Actualiza la etiqueta de paginación y el estado activo/desactivado de los botones anterior y siguiente.
        /// </summary>
        private void ActualizarControlesPaginacion()
        {
            LPaginas.Text = $"Página {paginaActual} de {totalPaginas}";
            BAnterior.Enabled = paginaActual > 1;
            BSiguiente.Enabled = paginaActual < totalPaginas;
        }

        private void BAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                AplicarPaginacionBackups();
            }
        }

        private void BSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                AplicarPaginacionBackups();
            }
        }

        private void ValidarAutorizacionRestauracion(Action onAutorizado)
        {
            var modal = new FormModalBackup();
            Diseno.MostrarModal(this, modal, () =>
            {
                onAutorizado?.Invoke();
            });
        }

        private void ManejarClickRestaurar(int filaIndex)
        {
            if (!(DGVBackup.Rows[filaIndex].DataBoundItem is BackupItem item)) return;

            ValidarAutorizacionRestauracion(() =>
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    backupBusiness.RestaurarBackup(item.RutaCompleta);
                    Cursor = Cursors.Default;
                    MessageBox.Show("Base de datos restaurada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Error al restaurar: " + ex.Message, "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void ManejarClickEliminar(int filaIndex)
        {
            if (!(DGVBackup.Rows[filaIndex].DataBoundItem is BackupItem item)) return;

            var confirmacion = MessageBox.Show(
                $"¿Desea eliminar del disco el archivo:\n\n{item.archvo}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes) return;

            //  Doble validación de seguridad (Admin + SuperAdmin)
            ValidarAutorizacionRestauracion(() =>
            {
                try
                {
                    backupBusiness.EliminarBackup(item.RutaCompleta);
                    CargarBackupsYCards();
                    MessageBox.Show("Archivo de respaldo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void BNuevoRespaldo_Click(object sender, EventArgs e)
        {
            ValidarAutorizacionRestauracion(() =>
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    BNuevoRespaldo.Enabled = false;

                    backupBusiness.GenerarNuevoBackup();

                    Cursor = Cursors.Default;
                    BNuevoRespaldo.Enabled = true;

                    MessageBox.Show("Copia de seguridad generada con éxito.", "Backup Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresca la grilla y los contadores
                    CargarBackupsYCards();
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    BNuevoRespaldo.Enabled = true;
                    MessageBox.Show("Error al generar el respaldo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void BRestaurarExterno_Click(object sender, EventArgs e)
        {
            ValidarAutorizacionRestauracion(() =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Archivos de Respaldo SQL (*.bak)|*.bak";
                    ofd.Title = "Seleccionar archivo de copia de seguridad";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string rutaSeleccionada = ofd.FileName;
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            BRestaurarExterno.Enabled = false;

                            backupBusiness.RestaurarBackup(rutaSeleccionada);

                            Cursor = Cursors.Default;
                            BRestaurarExterno.Enabled = true;

                            MessageBox.Show("Base de datos restaurada correctamente desde el archivo externo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Actualiza la grilla por si restauró un archivo que ya estaba en la carpeta
                            CargarBackupsYCards();
                        }
                        catch (Exception ex)
                        {
                            Cursor = Cursors.Default;
                            BRestaurarExterno.Enabled = true;
                            MessageBox.Show("Error al restaurar desde el archivo seleccionado: " + ex.Message, "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            });
        }
    }
}