using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    public static class Diseno
    {
        //COLORES DE MATIENSOS
        public static readonly Color ColorVerdeOscuro = Color.FromArgb(43, 84, 69);
        public static readonly Color ColorVerdeMedio = Color.FromArgb(56, 97, 80);
        public static readonly Color ColorVerdeClaro = Color.FromArgb(235, 243, 240);
        public static readonly Color ColorGrisBorde = Color.FromArgb(200, 200, 200);
        public static readonly Color ColorGrisBoton = Color.FromArgb(230, 230, 230);
        public static readonly Color ColorTextoGris = Color.FromArgb(80, 80, 80);

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

        /// <summary>
        /// Configura el formulario modal.
        /// </summary>
        public static void FormatearModal(Form modal)
        {
            if (modal == null) return;

            modal.StartPosition = FormStartPosition.CenterParent;
            modal.FormBorderStyle = FormBorderStyle.FixedDialog; // o None si usan barra personalizada
            modal.MaximizeBox = false;
            modal.MinimizeBox = false;
            modal.ShowInTaskbar = false;
            modal.BackColor = Color.White;
            modal.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            // Recorre controles para estandarizar cajas de texto y combos
            FormatearControlesEntrada(modal);
        }
        /// <summary>
        /// Botón principal de guardado o confirmación.
        /// </summary>
        public static void FormatearBotonPrimario(Button btn)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = ColorVerdeOscuro;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Height = 36;
        }

        /// <summary>
        /// Botón secundario para cancelar o cerrar.
        /// </summary>
        public static void FormatearBotonSecundario(Button btn)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = ColorGrisBorde;
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = ColorGrisBoton;
            btn.ForeColor = ColorTextoGris;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            btn.Cursor = Cursors.Hand;
            btn.Height = 36;
        }

        /// <summary>
        /// Para inputs
        /// </summary>
        private static void FormatearControlesEntrada(Control contenedor)
        {
            foreach (Control c in contenedor.Controls)
            {
                if (c is TextBox txt)
                {
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
                }
                else if (c is ComboBox cb)
                {
                    cb.FlatStyle = FlatStyle.Flat;
                    cb.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
                }
                else if (c.HasChildren)
                {
                    FormatearControlesEntrada(c); // Recursivo para paneles internos
                }
            }
        }
    }
}