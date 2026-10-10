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
    public partial class FormAuditoria : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        private const int EM_SETCUEBANNER = 0x1501;
        public FormAuditoria()
        {
            InitializeComponent();

        }
        private void FormAuditoria_Load(object sender, EventArgs e)
        {
            Diseno.FormatearGrilla(DGVAuditoria);
            ConfigurarColumnasGrid();

            SendMessage(TBBusqueda.Handle, EM_SETCUEBANNER, 0, "Buscar por usuario o módulo ...");
            
            CargarAuditoria();
        }

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
        /// Carga los registros de auditoría del mes actual en el DataGridView.
        /// </summary>
        private void CargarAuditoria()
        {
            var historial = Business.AuditoriaBusiness.ObtenerHistorialDelMes();
            DGVAuditoria.DataSource = historial;
        }

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
                HeaderText = "Ver",
                Text = "Ver",
                UseColumnTextForButtonValue = true,
                Name = "colVer",
                Width = 60
            });
        }

        
    }
}
