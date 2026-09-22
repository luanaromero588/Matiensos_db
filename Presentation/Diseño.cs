using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    public static class Diseno
    {
        // centra y refresca todas las cards del contenedor
        public static void ConfigurarCards(FlowLayoutPanel contenedor)
        {
            if (contenedor == null) return;

            foreach (Control control in contenedor.Controls)
            {
                if (control is Panel panelCard)
                {
                    panelCard.Paint -= PintarBordeVerde;
                    panelCard.Paint += PintarBordeVerde;
                    panelCard.Invalidate();
                }
            }
        }

        public static void PintarBordeVerde(object sender, PaintEventArgs e)
        {
            Panel card = sender as Panel;
            if (card == null) return;

            using (Brush brocha = new SolidBrush(Color.FromArgb(56, 97, 80)))
            {
                e.Graphics.FillRectangle(brocha, 0, 0, 4, card.Height);
            }
        }

  
        //diseño del grid
        public static void FormatearGrilla(DataGridView dgv)
        {
            dgv.ScrollBars = ScrollBars.None;

            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;

            dgv.BackgroundColor = Color.White;;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.GridColor = Color.DarkGray; 

            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 84, 69);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(43, 84, 69);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 32;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 243, 240);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowTemplate.Height = 28;
        }

    }
}