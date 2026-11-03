using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Entities;

namespace Presentation
{
    public partial class FormAuditoria : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        //Paginado
        private int paginaActual = 1;
        private int totalPaginas = 1;
        private const int FILAS_POR_PAGINA = 15;

        public FormAuditoria()
        {
            InitializeComponent();

        }
        private void FormAuditoria_Load(object sender, EventArgs e)
        {
            Diseno.FormatearGrilla(DGVAuditoria);
            Diseno.FormatearBotonPrimario(BAnterior);
            Diseno.FormatearBotonPrimario(BSiguiente);
            Diseno.FormatearBotonPrimario(BBusqueda);
            Diseno.FormatearBotonSecundario(BLimpiarFiltros);
            Diseno.FormatearBotonPrimario(BImprimir);
            ConfigurarColumnasGrid();
            ConfigurarFiltros();

            SendMessage(TBBusqueda.Handle, EM_SETCUEBANNER, 0, "Buscar por usuario o módulo ...");
            
            CargarAuditoria();
        }

        private void ConfigurarFiltros()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new object[] {
                "Todas",
                "Alta",
                "Modificación",
                "Baja Lógica",
                "Reactivación"
            });
            comboBox1.SelectedIndex = 0;

            DateTime ahora = DateTime.Now;
            DTPDesde.Value = new DateTime(ahora.Year, ahora.Month, 1);
            DTPHasta.Value = ahora;
        }

        private void BBusqueda_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            CargarAuditoria();
        }

        private void BLimpiarFiltros_Click(object sender, EventArgs e)
        {
            TBBusqueda.Clear();
            ConfigurarFiltros();
            paginaActual = 1;
            CargarAuditoria();
        }

        private void BImprimir_Click(object sender, EventArgs e)
        {
            ImprimirReporte();
        }

        private void ImprimirReporte()
        {
            try
            {
                DateTime? fechaDesde = DTPDesde.Value.Date;
                DateTime? fechaHasta = DTPHasta.Value.Date;
                string operacion = comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString() : "Todas";
                string textoBusqueda = TBBusqueda.Text;

                // Obtenemos la totalidad de registros que cumplen los filtros actuales (sin limitar a los 15 de la página)
                var registrosCompletos = Business.AuditoriaBusiness.ObtenerHistorialFiltradoCompleto(
                    fechaDesde,
                    fechaHasta,
                    operacion,
                    textoBusqueda
                );

                if (registrosCompletos == null || registrosCompletos.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros de auditoría para el período y filtros seleccionados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string periodoStr = $"{DTPDesde.Value:dd/MM/yyyy} al {DTPHasta.Value:dd/MM/yyyy}";
                string usuarioEmisor = Sesion.Nombre ?? "Administrador";

                GeneradorReporteAuditoria.ExportarAWeb(
                    registros: registrosCompletos,
                    periodo: periodoStr,
                    operacion: operacion,
                    criterioBusqueda: textoBusqueda,
                    emitidoPor: usuarioEmisor
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar la impresión de auditoría: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TBBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                paginaActual = 1;
                CargarAuditoria();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVAuditoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGVAuditoria.Columns[e.ColumnIndex].Name == "colVer")
            {
                string fecha = DGVAuditoria.Rows[e.RowIndex].Cells["colFecha"].Value.ToString();
                string usuario = DGVAuditoria.Rows[e.RowIndex].Cells["colUsuario"].Value.ToString();
                string detalles = DGVAuditoria.Rows[e.RowIndex].Cells["colDetalles"].Value.ToString();
                string modulo = DGVAuditoria.Rows[e.RowIndex].Cells["colModulo"].Value.ToString();
                string accion = DGVAuditoria.Rows[e.RowIndex].Cells["colAccion"].Value.ToString();

                string detallesFormateados = detalles.Replace(", ", Environment.NewLine);
                detallesFormateados = detallesFormateados.Replace(" - ", Environment.NewLine);

                using (FormDetalleAuditoria modal = new FormDetalleAuditoria(modulo, accion, fecha, usuario, detallesFormateados))
                {
                    modal.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Carga los registros de auditoría del mes actual en el DataGridView aplicando filtros y paginación.
        /// </summary>
        private void CargarAuditoria()
        {
            DateTime? fechaDesde = DTPDesde.Value.Date;
            DateTime? fechaHasta = DTPHasta.Value.Date;
            string operacion = comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString() : null;
            string textoBusqueda = TBBusqueda.Text;

            var historial = Business.AuditoriaBusiness.ObtenerHistorialFiltrado(
                fechaDesde,
                fechaHasta,
                operacion,
                textoBusqueda,
                paginaActual,
                FILAS_POR_PAGINA,
                out totalPaginas);

            DGVAuditoria.DataSource = historial;
            ActualizarPaginacion();
        }

        /// <summary>
        /// Actualiza la información de paginación y habilita/deshabilita los botones de navegación según corresponda.
        /// </summary>
        private void ActualizarPaginacion()
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
                CargarAuditoria();
            }
        }
        private void BSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                CargarAuditoria();
            }
        }

        /// <summary>
        /// Configura las columnas del DataGridView para mostrar los registros de auditoría.
        /// </summary>
        private void ConfigurarColumnasGrid()
        {
            DGVAuditoria.AutoGenerateColumns = false;
            DGVAuditoria.Columns.Clear();
            DGVAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            DGVAuditoria.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaHora",
                HeaderText = "Fecha",
                Name = "colFecha",
                Width = 150
            });

            DGVAuditoria.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Usuario",
                HeaderText = "Usuario / Autor",
                Name = "colUsuario",
                Width = 150
            });

            DGVAuditoria.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Modulo",
                HeaderText = "Módulo",
                Name = "colModulo",
                Width = 150
            });

            DGVAuditoria.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Accion",
                HeaderText = "Acción",
                Name = "colAccion",
                Width = 150
            });

            DGVAuditoria.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Detalles",
                HeaderText = "Resumen",
                Name = "colDetalles",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            DGVAuditoria.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Ver",
                UseColumnTextForButtonValue = true,
                Name = "colVer",
                Width = 60
            });
        }

        
    }
}
