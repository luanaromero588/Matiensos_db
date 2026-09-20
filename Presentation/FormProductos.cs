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
    public partial class FormProductos : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        private const int EM_SETCUEBANNER = 0x1501;
        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(FLPCards);
            Diseno.FormatearGrilla(DGVProductos);
            ConfigurarColumnasGrid();

            //placeholder buscador ventas
            SendMessage(TBBuscar.Handle, EM_SETCUEBANNER, 0, "Buscar por nombre o código  ...");

        }

        private void ConfigurarColumnasGrid()
        {
            DGVProductos.Columns.Clear();

            // 1.Código de producto
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "code",
                HeaderText = "Código",
                Name = "colCodigo",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
 
            // 2. Nombre / Descripción
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre/Descripcion",
                HeaderText = "Nombre / Descripción",
                Name = "col"
            });
            // 4. Precio
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "precio",
                HeaderText = "Precio",
                Name = "colPrecio",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "C2" }
            });

            // 5. Stock
            DGVProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "stock",
                HeaderText = "Stock",
                Name = "colStock",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 6. ver detalle
            DGVProductos.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Ver detalle",
                Name = "btnVerDetalleFila",
                UseColumnTextForButtonValue = true,
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });
            // 7. editar estado
            DGVProductos.Columns.Add(new DataGridViewButtonColumn
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
