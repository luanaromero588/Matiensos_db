using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentation
{
    public static class Diseno
    {
        //COLORES DE MATIENSOS
        public static readonly Color ColorVerdeOscuro = Color.FromArgb(56, 90, 80);
        public static readonly Color ColorVerdeClaro = Color.FromArgb(221, 232, 225);

        #region Movimiento y Bordes de Formularios

        // Importaciones de Windows API para el movimiento
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        #region CARDS
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
        #endregion

        #region GRILLAS
        /// <summary>
        /// Aplica un formato y comportamiento predeterminados a un DataGridView, configurando apariencia, selección,
        /// edición y manejo del cursor.
        /// <param name="dgv">DataGridView al que se aplicarán los estilos y la configuración.</param>
        /// <param name="soloLectura">Indica si el control quedará en modo solo lectura; true por defecto.</param>
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
        #endregion

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
            if (modal.FormBorderStyle != FormBorderStyle.None)
            {
                modal.FormBorderStyle = FormBorderStyle.FixedSingle;
            }

            AplicarBordesRedondeados(modal, 20);

            modal.MaximizeBox = false;
            modal.MinimizeBox = false;

            if (!modal.IsHandleCreated)
            {
                modal.ShowInTaskbar = false;
            }

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
        /// Permite mover un formulario sin bordes arrastrando un control específico (como un Panel superior) o el formulario entero.
        /// </summary>
        public static void HabilitarMovimiento(Form form, Control areaDeArrastre = null)
        {
            Control controlArrastre = areaDeArrastre ?? form;

            controlArrastre.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(form.Handle, 0x112, 0xf012, 0);
                }
            };
        }

        /// <summary>
        /// Quita los bordes nativos del formulario y le aplica esquinas redondeadas.
        /// </summary>
        public static void AplicarBordesRedondeados(Form form, int radio = 15)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            void SetRegion()
            {
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radio, radio, 180, 90);
                path.AddArc(form.Width - radio, 0, radio, radio, 270, 90);
                path.AddArc(form.Width - radio, form.Height - radio, radio, radio, 0, 90);
                path.AddArc(0, form.Height - radio, radio, radio, 90, 90);
                path.CloseFigure();

                form.Region = new Region(path);
            }

            // Aplicar la primera vez
            SetRegion();

            // Actualizar si el formulario cambia de tamaño
            form.Resize += (s, e) => SetRegion();
        }

        #region BOTONES PRIMARIO Y SECUNDARIO
        /// <summary>
        /// Botón principal de guardado o confirmación.
        /// </summary>
        public static void FormatearBotonPrimario(Button btn)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Standard;
            btn.FlatAppearance.BorderSize = 2;
            btn.BackColor = ColorVerdeOscuro;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Mongolian Baiti", 10f);
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
        #endregion

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
                    txt.Font = new Font("Mongolian Baiti", 10f, FontStyle.Regular);
                }
                else if (c is ComboBox cb)
                {
                    cb.FlatStyle = FlatStyle.Standard;
                    cb.Font = new Font("Mongolian Baiti", 10f, FontStyle.Regular);
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

        #region FILTROS

        private class EstadoBotonFiltro
        {
            public bool Activo { get; set; }
            public int Cantidad { get; set; }
            public ToolTip Tooltip { get; set; }
        }

        private static readonly ConditionalWeakTable<Button, EstadoBotonFiltro> estadosFiltro =
            new ConditionalWeakTable<Button, EstadoBotonFiltro>();

        /// <summary>
        /// Configura el diseño estándar de un botón compacto de filtros.
        /// </summary>
        public static void FormatearBotonFiltro(Button btn)
        {
            if (btn == null) return;

            btn.Cursor = Cursors.Hand;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.LightGray;
            btn.BackColor = Color.White;
            btn.Text = string.Empty;
            btn.ImageAlign = ContentAlignment.MiddleCenter;

            var estado = estadosFiltro.GetOrCreateValue(btn);
            if (estado.Tooltip == null)
            {
                estado.Tooltip = new ToolTip();
                estado.Tooltip.SetToolTip(btn, "Filtros");
            }

            btn.Paint -= PintarInsigniaBotonFiltro;
            btn.Paint += PintarInsigniaBotonFiltro;
        }

        /// <summary>
        /// Actualiza el estado visual del botón de filtro:
        /// - Si está activo, dibuja un círculo rojo en la esquina superior derecha.
        /// - Si no está activo, restaura la apariencia normal.
        /// </summary>
        /// <param name="btn">El botón de filtro a actualizar</param>
        /// <param name="activo">Indica si hay algún filtro aplicado</param>
        /// <param name="cantidadFiltros">Cantidad opcional de filtros aplicados</param>
        public static void ActualizarEstadoFiltro(Button btn, bool activo, int cantidadFiltros = 0)
        {
            if (btn == null) return;

            var estado = estadosFiltro.GetOrCreateValue(btn);
            estado.Activo = activo;
            estado.Cantidad = cantidadFiltros;

            if (estado.Tooltip != null)
            {
                string mensaje = activo
                    ? (cantidadFiltros > 0 ? $"Filtros aplicados ({cantidadFiltros})" : "Filtros activos")
                    : "Filtros";
                estado.Tooltip.SetToolTip(btn, mensaje);
            }

            if (activo)
            {
                btn.FlatAppearance.BorderColor = ColorVerdeOscuro;
                btn.BackColor = Color.FromArgb(240, 248, 245);
            }
            else
            {
                btn.FlatAppearance.BorderColor = Color.LightGray;
                btn.BackColor = Color.White;
            }

            btn.Invalidate();
        }

        /// <summary>
        /// Dibuja el redondito rojo en la esquina superior derecha del botón cuando tiene filtros activos.
        /// </summary>
        private static void PintarInsigniaBotonFiltro(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            if (!estadosFiltro.TryGetValue(btn, out var estado) || !estado.Activo)
                return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Brush brochaRojo = new SolidBrush(Color.FromArgb(220, 53, 69)))
            using (Pen bordeBlanco = new Pen(Color.White, 1.5f))
            {
                if (estado.Cantidad > 0)
                {
                    int diametro = 13;
                    int x = btn.Width - diametro - 2;
                    int y = 2;

                    e.Graphics.FillEllipse(brochaRojo, x, y, diametro, diametro);
                    e.Graphics.DrawEllipse(bordeBlanco, x, y, diametro, diametro);

                    string texto = estado.Cantidad > 9 ? "+9" : estado.Cantidad.ToString();
                    using (Font font = new Font("Segoe UI", 6.5f, FontStyle.Bold))
                    using (Brush brochaTexto = new SolidBrush(Color.White))
                    using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        e.Graphics.DrawString(texto, font, brochaTexto, new RectangleF(x, y + 0.5f, diametro, diametro), sf);
                    }
                }
                else
                {
                    int diametro = 8;
                    int x = btn.Width - diametro - 3;
                    int y = 3;

                    e.Graphics.FillEllipse(brochaRojo, x, y, diametro, diametro);
                    e.Graphics.DrawEllipse(bordeBlanco, x, y, diametro, diametro);
                }
            }
        }

        #endregion
    }
}