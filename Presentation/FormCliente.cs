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
    public partial class FormCliente : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        public FormCliente()
        {
            InitializeComponent();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(FLPCards);
            Diseno.FormatearGrilla(DGVCliente);
            ConfigurarColumnasGrid();

            SendMessage(TBBuscar.Handle, EM_SETCUEBANNER, 0, "Buscar por DNI ...");
        }

        private void ConfigurarColumnasGrid()
        {
            DGVCliente.Columns.Clear();

            // 0. Columna ID 
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id",
                HeaderText = "ID",
                Name = "colId",
                Width = 35,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }

            });
            // 1. Columna ID de Persona (oculto)
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "person_id",
                HeaderText = "PersonId",
                Name = "colPersonId",
                Visible = false
            });
            // 2. Columna DNI
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "dni",
                HeaderText = "DNI",
                Name = "colDni"

            });
            // 3. Columna Nombre
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "first_name",
                HeaderText = "Nombre",
                Name = "colNombre"


            });
            // 4. Columna Apellido
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "last_name",
                HeaderText = "Apellido",
                Name = "colApellido"

            });
            // 5. Columna Email
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "email",
                HeaderText = "Correo",
                Name = "colEmail"

            });
            // 6. Columna Teléfono
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "phone",
                HeaderText = "Teléfono",
                Name = "colTelefono"
            });
            // 7. Columna direccion
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "adress",
                HeaderText = "Dirección",
                Name = "colDireccion"
            });
           
            // 8. Columna Estado
            DGVCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "status_text",
                HeaderText = "Estado",
                Name = "colEstado",
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }

            });
            // 9. Columna de Botón Editar
            DGVCliente.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Editar",
                Name = "btnEditarFila",
                UseColumnTextForButtonValue = true,
                Width = 70,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });

            // 10. Columna Botón Eliminar
            DGVCliente.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Eliminar",
                Name = "btnEliminarFila",
                UseColumnTextForButtonValue = true,
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });


        }
    }


}
