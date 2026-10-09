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

            DGVAuditoria.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaHora",
                HeaderText = "Fecha",
                Name = "colFecha",
                Width = 130,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
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
                Width = 120
            });

            DGVAuditoria.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Accion",
                HeaderText = "Acción",
                Name = "colAccion",
                Width = 100
            });

            DGVAuditoria.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Detalles",
                HeaderText = "Detalles del Evento",
                Name = "colDetalles",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        
    }
}
