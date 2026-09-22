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
    public partial class FormCategorias : Form
    {
        
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(FLPCards);
            Diseno.FormatearGrilla(DGVCategorias);
            ConfigurarColumnasGrid();

        }

        private void ConfigurarColumnasGrid()
        {
            DGVCategorias.Columns.Clear();

            // 2. Nombre / Descripción
            DGVCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre/Descripcion",
                HeaderText = "Nombre / Descripción",
                Name = "col"
            });

            // 3. Cant. Productos
            DGVCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Productos",
                HeaderText = "Productos",
                Name = "colProductos",
                Width = 130,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            });

            // 4. Stock Total
            DGVCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = " Stock Total",
                HeaderText = "Stock Total",
                Name = "colStockTotal",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            });

            // 5. Estado
            DGVCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "status",
                HeaderText = "Estado",
                Name = "colEstado",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 6. ver detalle
            DGVCategorias.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Ver detalle",
                Name = "btnVerDetalleFila",
                UseColumnTextForButtonValue = true,
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });
            // 7. editar estado
            DGVCategorias.Columns.Add(new DataGridViewButtonColumn
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
