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

            SendMessage(TBBusqueda.Handle, EM_SETCUEBANNER, 0, "Buscar por usuario o DNI ...");
        }

        private void ConfigurarColumnasGrid()
            {
                DGVVentas.Columns.Clear();

                // 1.Fecha y hora
                DGVVentas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "created_at",
                    HeaderText = "Fecha",
                    Name = "colFecha",
                    Width = 130,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "dd/MM/yyyy HH:mm:ss" }
                });

                // 2. usuario 
                DGVVentas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "cliente_nombre",
                    HeaderText = "Cliente",
                    Name = "colCliente"
                });

                // 3. Rol
                DGVVentas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "usuario",
                    HeaderText = "Usuario",
                    Name = "colUsuario"
                });

                // 4. Operación 
                DGVVentas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "cliente_nombre",
                    HeaderText = "Cliente",
                    Name = "colCliente"
                });
                // 5. Entidad / Módulo
                DGVVentas.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "entidad/modulo",
                    HeaderText = "Entidad / Módulo",
                    Name = "colEntidadModulo"
                });

                // 6. Detalle
                DGVVentas.Columns.Add(new DataGridViewButtonColumn
                {
                    DataPropertyName = "detalle",
                    HeaderText = "Detalle",
                    Text = "Ver detalle",
                    Width = 100,

                });

            }

        
    }
}
