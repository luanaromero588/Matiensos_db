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
        public static void ConfigurarCards(Control contenedor)
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

            using (Brush brocha = new SolidBrush(ColorVerdeOscuro))
            {
                e.Graphics.FillRectangle(brocha, 0, 0, 4, card.Height);
            }
        }

        //diseño del grid
        public static void FormatearGrilla(DataGridView dgv, bool soloLectura = true)
        {
            dgv.ScrollBars = ScrollBars.Both;

            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.ReadOnly = soloLectura;
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

            // Cursor Hand automático para columnas de acciones/imágenes
            dgv.CellMouseMove += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var col = dgv.Columns[e.ColumnIndex];
                    if (col is DataGridViewImageColumn || col is DataGridViewButtonColumn)
                    {
                        dgv.Cursor = Cursors.Hand;
                        return;
                    }
                }
                dgv.Cursor = Cursors.Default;
            };

            dgv.CellMouseLeave += (s, e) =>
            {
                dgv.Cursor = Cursors.Default;
            };

        }

        /// Muestra un modal con fondo oscuro semitransparente centrado sobre la ventana principal.
        /// Al hacer clic fuera del formulario, se cierra automáticamente.
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

        /// <summary>
        /// Configura el formulario modal con diseño moderno y colores institucionales.
        /// </summary>
        public static void FormatearModal(Form modal)
        {
            if (modal == null) return;

            modal.StartPosition = FormStartPosition.CenterParent;
            modal.FormBorderStyle = FormBorderStyle.FixedSingle;
            modal.MaximizeBox = false;
            modal.MinimizeBox = false;
            modal.ShowInTaskbar = false;
            modal.BackColor = ColorVerdeClaro;
            modal.Font = new Font("Mongolian Baiti", 10f, FontStyle.Regular);

            // Decoración: Franja superior institucional
            modal.Paint -= PintarBordeModal;
            modal.Paint += PintarBordeModal;

            // Recorre controles para estandarizar cajas de texto y combos
            FormatearControlesEntrada(modal);
        }

        /// <summary>
        /// Dibuja una línea decorativa verde.
        /// </summary>
        private static void PintarBordeModal(object sender, PaintEventArgs e)
        {
            Form modal = sender as Form;
            if (modal == null) return;

            using (Brush brocha = new SolidBrush(ColorVerdeOscuro))
            {
                // Dibuja un rectángulo de 5 píxeles de alto ocupando todo el ancho superior
                e.Graphics.FillRectangle(brocha, 0, 0, modal.Width, 5);
            }
        }

        /// <summary>
        /// Botón principal de guardado o confirmación.
        /// </summary>
        public static void FormatearBotonPrimario(Button btn)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = ColorVerdeOscuro;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Mongolian Baiti", 10f, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Height = 31;
        }

        /// <summary>
        /// Botón secundario para cancelar o cerrar.
        /// </summary>
        public static void FormatearBotonSecundario(Button btn)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Standard;
            btn.FlatAppearance.BorderColor = Color.IndianRed;
            btn.FlatAppearance.BorderSize = 2;
            btn.BackColor = Color.WhiteSmoke;
            btn.ForeColor = Color.Firebrick;
            btn.Font = new Font("Mongolian Baiti", 10f, FontStyle.Regular);
            btn.Cursor = Cursors.Hand;
            btn.Height = 31;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Padding = new Padding(0, 3, 0, 0);
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
                    txt.BorderStyle = BorderStyle.Fixed3D;
                    txt.Font = new Font("Mongolian Baiti", 9.5f, FontStyle.Regular);
                }
                else if (c is ComboBox cb)
                {
                    cb.FlatStyle = FlatStyle.Flat;
                    cb.Font = new Font("Mongolian Baiti", 9.5f, FontStyle.Regular);
                }
                else if (c is Button btn)
                {
                    string nombre = btn.Name.ToLower();
                    if (nombre.Contains("aplicar") || nombre.Contains("guardar") || nombre.Contains("aceptar"))
                    {
                        FormatearBotonPrimario(btn);
                    }
                    else if (nombre.Contains("cancelar") || nombre.Contains("limpiar") || nombre.Contains("cerrar"))
                    {
                        FormatearBotonSecundario(btn);
                    }
                }
                else if (c.HasChildren)
                {
                    FormatearControlesEntrada(c);
                }
            }
        }
    }
}