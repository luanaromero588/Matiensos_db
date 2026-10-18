using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Presentation
{
    public partial class FormVentas : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        private const int EM_SETCUEBANNER = 0x1501;
        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(FLPCards);
            Diseno.FormatearGrilla(DGVVentas);
            ConfigurarColumnasGrid();

            //placeholder buscador ventas
            SendMessage(TBBuscar.Handle, EM_SETCUEBANNER, 0, "Buscar por código o cliente ...");

        }

        private void ConfigurarColumnasGrid()
        {
            DGVVentas.Columns.Clear();

            // 1.Código de Venta
            DGVVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "code",
                HeaderText = "Código",
                Name = "colCodigo",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 2. Cliente 
            DGVVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "cliente_nombre",
                HeaderText = "Cliente",
                Name = "colCliente"
            });

            // 3. Fecha
            DGVVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "created_at",
                HeaderText = "Fecha",
                Name = "colFecha",
                Width = 130,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "dd/MM/yyyy HH:mm" }
            });

            // 4. Total
            DGVVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "total_amount",
                HeaderText = "Total",
                Name = "colTotal",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "C2" }
            });

            // 5. Estado
            DGVVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "status",
                HeaderText = "Estado",
                Name = "colEstado",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 6. ver detalle
            DGVVentas.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Ver detalle",
                Name = "btnVerDetalleFila",
                UseColumnTextForButtonValue = true,
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });
            // 7. editar estado
            DGVVentas.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Editar",
                Name = "btnEditarFila",
                UseColumnTextForButtonValue = true,
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });

            
        }
    }


}
