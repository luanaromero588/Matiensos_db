using Presentation.GestionAdministrador;
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

            
            //  Nombre / Descripción
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
            DGVMetodosPago.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "estado",
                HeaderText = "Estado",
                Name = "colEstado",
                ReadOnly = true,
                Width = 90,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 6. Editar
            DGVMetodosPago.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "Acción",
                Name = "btnEditarFila",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });
            // 7. Eliminar - baja lógica
            DGVMetodosPago.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "Acción",
                Name = "btnEliminarFila",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });


        }

        private void BNuevoMP_Click(object sender, EventArgs e)
        {
            Diseno.MostrarModal(this, new FormNuevoMetodoPago());
        }
    }
}
