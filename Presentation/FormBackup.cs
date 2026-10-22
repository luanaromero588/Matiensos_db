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
        public FormBackup()
        {
            InitializeComponent();
        }

        private void FormBackup_Load(object sender, EventArgs e)
        {
            Diseno.FormatearGrilla(DGVBackup, soloLectura: true);
            DGVBackup.ReadOnly = true;
            DGVBackup.EditMode = DataGridViewEditMode.EditOnEnter;
            ConfigurarColumnasGrid();
            CargarBackupsYCards();

        }

        private void ConfigurarColumnasGrid()
        {
            DGVBackup.Columns.Clear();
            DGVBackup.AutoGenerateColumns = false;
            DGVBackup.CellFormatting += DGVBackup_CellFormatting;


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
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter}
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


        private void DGVBackup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nombreColumna = DGVBackup.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "btnRestaurarFila" )
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
                // Usá tu icono de restaurar/recargar
                e.Value = Properties.Resources.sincronizar;
                e.FormattingApplied = true;
            }
            else if (nombreColumna == "btnEliminarFila")
            {
                e.Value = Properties.Resources.eliminar;
                e.FormattingApplied = true;
            }
        }
        private void CargarBackupsYCards()
        {
            try
            {
                var lista = backupBusiness.ListarBackups();
                DGVBackup.DataSource = null;
                DGVBackup.DataSource = lista;

                // Carga de Cards
                LTotalRespaldos.Text = lista.Count.ToString(); // Total de copias
                LUltRespaldoFecha.Text = lista.Count > 0 ? lista[0].fecha : "Sin registros"; // Último backup
                LUltRespaldoTamaño.Text = lista.Count > 0 ? lista[0].tamaño : "0 MB"; // Peso último
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar archivos de backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManejarClickRestaurar(int filaIndex)
        {
            if (!(DGVBackup.Rows[filaIndex].DataBoundItem is BackupItem item)) return;

            var confirmacion = MessageBox.Show(
                $"¿Está seguro de restaurar la base de datos con el archivo:\n\n{item.archvo}?\n\nADVERTENCIA: Se sobrescribirán todos los cambios posteriores a esa fecha.",
                "Confirmar Restauración",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion != DialogResult.Yes) return;

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

            try
            {
                backupBusiness.EliminarBackup(item.RutaCompleta);
                CargarBackupsYCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BNuevoRespaldo_Click(object sender, EventArgs e)
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
        }

        private void BRestaurarExterno_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de Respaldo SQL (*.bak)|*.bak";
                ofd.Title = "Seleccionar archivo de copia de seguridad";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string rutaSeleccionada = ofd.FileName;

                    var confirmacion = MessageBox.Show(
                        $"¿Está seguro de restaurar la base de datos desde el archivo externo?\n\n{ofd.SafeFileName}\n\nADVERTENCIA: Se perderán los datos que no estén incluidos en este respaldo.",
                        "Confirmar Restauración Externa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirmacion != DialogResult.Yes) return;

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
        }
    }
}

