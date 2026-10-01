using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    public static class Diseno
    {
        //COLORES DE MATIENSOS
        public static readonly Color ColorVerdeOscuro = Color.FromArgb(56, 90, 80);
        public static readonly Color ColorVerdeClaro = Color.FromArgb(221, 232, 225);

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

            //Cabeceras
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorVerdeOscuro;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorVerdeOscuro;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Mongolian Baiti", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 32;

            //Celdas normales
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = ColorVerdeClaro;
            //dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 243, 240);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgv.RowTemplate.Height = 28;

        }

        /// 
        /// Muestra un modal con fondo oscuro semitransparente centrado sobre la ventana principal.
        /// Al hacer clic fuera del formulario, se cierra automáticamente.
        /// 
        public static void MostrarModal(Control invocador, Form modal, Action onOk = null)
        {
            var owner = invocador.TopLevelControl as Form ?? invocador.FindForm();

            Form fondoOscuro = new Form
            {
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.None,
                Opacity = 0.50d,
                BackColor = Color.Black,
                ShowInTaskbar = false,
                Location = owner != null ? owner.Location : Point.Empty,
                Size = owner != null ? owner.Size : Screen.PrimaryScreen.WorkingArea.Size
            };

            modal.StartPosition = FormStartPosition.Manual;
            if (owner != null)
            {
                modal.Location = new Point(
                    owner.Location.X + (owner.Width - modal.Width) / 2,
                    owner.Location.Y + (owner.Height - modal.Height) / 2
                );
            }

            // Clic en el fondo oscuro cierra el modal cancelando
            fondoOscuro.Click += (s, ev) =>
            {
                modal.DialogResult = DialogResult.Cancel;
                modal.Close();
            };

            // Al cerrarse el modal se ejecutan las acciones y se libera la memoria
            modal.FormClosed += (s, ev) =>
            {
                if (modal.DialogResult == DialogResult.OK)
                {
                    onOk?.Invoke();
                }

                modal.Dispose();
                fondoOscuro.Close();
                fondoOscuro.Dispose();
            };

            fondoOscuro.Show(owner);
            modal.Show(fondoOscuro);
        }

    }
}