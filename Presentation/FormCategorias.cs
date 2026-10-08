using Business;
using Entities;
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
    public partial class FormCategorias : Form
    {
        private readonly CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            Diseno.ConfigurarCards(FLPCards);
            Diseno.FormatearGrilla(DGVCategorias);
            ConfigurarColumnasGrid();
            DGVCategorias.AutoGenerateColumns = false;
            DGVCategorias.DataSource = categoriaBusiness.ObtenerCategoriasParaGrilla();
            
        }

        private void ConfigurarColumnasGrid()
        {
            DGVCategorias.Columns.Clear();
            DGVCategorias.AutoGenerateColumns = false;

            // 1. Nombre 
            DGVCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "nombre",
                HeaderText = "Nombre ",
                Name = "colNombre" ,
                Width = 140,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });

            // 2. Descrición
            DGVCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "descripcion",
                HeaderText = "Descripción",
                Name = "colDescripcion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // 3. Cant. Productos
            DGVCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CantidadProductos",
                HeaderText = "Productos",
                Name = "colProductos",
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            });

            // 4. Stock Total
            DGVCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "stockTotal",
                HeaderText = "Stock Total",
                Name = "colStockTotal",
                Width = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            });

            // 5. Estado
            DGVCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "estado",
                HeaderText = "Estado",
                Name = "colEstado",
                Width = 90,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 6. Editar
            DGVCategorias.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Editar",
                Name = "btnEditarFila",
                UseColumnTextForButtonValue = true,
                Width = 90,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });
            // 7. Eliminar - baja lógica
            DGVCategorias.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Eliminar",
                Name = "btnEliminarFila",
                UseColumnTextForButtonValue = true,
                Width = 90,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            });


        }

        private void BNuevacategoria_Click(object sender, EventArgs e)
        {
            Diseno.MostrarModal(this, new FormNuevaCategoria());
        }
    }


}
