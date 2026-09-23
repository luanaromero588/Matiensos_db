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
    public partial class FormMetodosPago : Form
    {
        public FormMetodosPago()
        {
            InitializeComponent();
        }

        private void ConfigurarColumnasGrid()
        {
            DGVMetodosPago.Columns.Clear();

            DGVMetodosPago.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id",
                HeaderText = "ID",
                Name = "colID",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            // 2. Nombre / Descripción
            DGVMetodosPago.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "metodopago",
                HeaderText = "Método de Pago",
                Name = "colMetodoPago",
                Width = 150,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            DGVMetodosPago.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "descripcion",
                HeaderText = "Descripción",
                Name = "colDescripcion",
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 5. Estado
            DGVMetodosPago  .Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "status",
                HeaderText = "Estado",
                Name = "colEstado",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 6. ver detalle
            DGVMetodosPago.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Ver detalle",
                Name = "btnVerDetalleFila",
                UseColumnTextForButtonValue = true,
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });
            // 7. editar estado
            DGVMetodosPago.Columns.Add(new DataGridViewButtonColumn
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
