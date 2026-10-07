namespace Presentation.GestionVentas
{
    partial class FormHistorialVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.FCardsVentas = new System.Windows.Forms.FlowLayoutPanel();
            this.PCardVentasHoy = new System.Windows.Forms.Panel();
            this.LValorVentas = new System.Windows.Forms.Label();
            this.LTituloVentas = new System.Windows.Forms.Label();
            this.PCardRecaudacionHoy = new System.Windows.Forms.Panel();
            this.LValorRecaudacion = new System.Windows.Forms.Label();
            this.LTituloRecaudacion = new System.Windows.Forms.Label();
            this.CardRubroTop = new System.Windows.Forms.Panel();
            this.LValorRubroTop = new System.Windows.Forms.Label();
            this.LTituloRubroTop = new System.Windows.Forms.Label();
            this.LTituloHistorial = new System.Windows.Forms.Label();
            this.PContenido = new System.Windows.Forms.Panel();
            this.PContenedorVentas = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelCliente = new System.Windows.Forms.Panel();
            this.BLimpiarFiltros = new System.Windows.Forms.Button();
            this.CBMetodoPagoFiltro = new System.Windows.Forms.ComboBox();
            this.LFormaPago = new System.Windows.Forms.Label();
            this.DTPFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.LFechaHasta = new System.Windows.Forms.Label();
            this.DTPFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.LFechaDesde = new System.Windows.Forms.Label();
            this.BFiltrar = new System.Windows.Forms.Button();
            this.PContenidoVentas = new System.Windows.Forms.Panel();
            this.LPaginas = new System.Windows.Forms.Label();
            this.BSiguiente = new System.Windows.Forms.Button();
            this.BAnterior = new System.Windows.Forms.Button();
            this.DGVHistorial = new System.Windows.Forms.DataGridView();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAccion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.LListadoHistorial = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.FCardsVentas.SuspendLayout();
            this.PCardVentasHoy.SuspendLayout();
            this.PCardRecaudacionHoy.SuspendLayout();
            this.CardRubroTop.SuspendLayout();
            this.PContenido.SuspendLayout();
            this.PanelCliente.SuspendLayout();
            this.PContenidoVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.panelHeader.Controls.Add(this.FCardsVentas);
            this.panelHeader.Controls.Add(this.LTituloHistorial);
            this.panelHeader.Controls.Add(this.PContenido);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1100, 700);
            this.panelHeader.TabIndex = 20;
            // 
            // FCardsVentas
            // 
            this.FCardsVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FCardsVentas.BackColor = System.Drawing.Color.Transparent;
            this.FCardsVentas.Controls.Add(this.PCardVentasHoy);
            this.FCardsVentas.Controls.Add(this.PCardRecaudacionHoy);
            this.FCardsVentas.Controls.Add(this.CardRubroTop);
            this.FCardsVentas.Location = new System.Drawing.Point(370, 12);
            this.FCardsVentas.Name = "FCardsVentas";
            this.FCardsVentas.Size = new System.Drawing.Size(662, 56);
            this.FCardsVentas.TabIndex = 20;
            // 
            // PCardVentasHoy
            // 
            this.PCardVentasHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PCardVentasHoy.BackColor = System.Drawing.Color.White;
            this.PCardVentasHoy.Controls.Add(this.LValorVentas);
            this.PCardVentasHoy.Controls.Add(this.LTituloVentas);
            this.PCardVentasHoy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCardVentasHoy.Location = new System.Drawing.Point(0, 0);
            this.PCardVentasHoy.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.PCardVentasHoy.Name = "PCardVentasHoy";
            this.PCardVentasHoy.Size = new System.Drawing.Size(185, 52);
            this.PCardVentasHoy.TabIndex = 4;
            // 
            // LValorVentas
            // 
            this.LValorVentas.BackColor = System.Drawing.Color.White;
            this.LValorVentas.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LValorVentas.Location = new System.Drawing.Point(10, 24);
            this.LValorVentas.Name = "LValorVentas";
            this.LValorVentas.Size = new System.Drawing.Size(142, 25);
            this.LValorVentas.TabIndex = 1;
            this.LValorVentas.Text = "0";
            // 
            // LTituloVentas
            // 
            this.LTituloVentas.AutoEllipsis = true;
            this.LTituloVentas.BackColor = System.Drawing.Color.White;
            this.LTituloVentas.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloVentas.Location = new System.Drawing.Point(12, 8);
            this.LTituloVentas.Name = "LTituloVentas";
            this.LTituloVentas.Size = new System.Drawing.Size(140, 16);
            this.LTituloVentas.TabIndex = 0;
            this.LTituloVentas.Text = "VENTAS";
            // 
            // PCardRecaudacionHoy
            // 
            this.PCardRecaudacionHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PCardRecaudacionHoy.BackColor = System.Drawing.Color.White;
            this.PCardRecaudacionHoy.Controls.Add(this.LValorRecaudacion);
            this.PCardRecaudacionHoy.Controls.Add(this.LTituloRecaudacion);
            this.PCardRecaudacionHoy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCardRecaudacionHoy.Location = new System.Drawing.Point(197, 0);
            this.PCardRecaudacionHoy.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.PCardRecaudacionHoy.Name = "PCardRecaudacionHoy";
            this.PCardRecaudacionHoy.Size = new System.Drawing.Size(185, 52);
            this.PCardRecaudacionHoy.TabIndex = 4;
            // 
            // LValorRecaudacion
            // 
            this.LValorRecaudacion.BackColor = System.Drawing.Color.White;
            this.LValorRecaudacion.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LValorRecaudacion.Location = new System.Drawing.Point(10, 24);
            this.LValorRecaudacion.Name = "LValorRecaudacion";
            this.LValorRecaudacion.Size = new System.Drawing.Size(142, 25);
            this.LValorRecaudacion.TabIndex = 1;
            this.LValorRecaudacion.Text = "$ ";
            // 
            // LTituloRecaudacion
            // 
            this.LTituloRecaudacion.AutoEllipsis = true;
            this.LTituloRecaudacion.BackColor = System.Drawing.Color.White;
            this.LTituloRecaudacion.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloRecaudacion.Location = new System.Drawing.Point(12, 8);
            this.LTituloRecaudacion.Name = "LTituloRecaudacion";
            this.LTituloRecaudacion.Size = new System.Drawing.Size(140, 16);
            this.LTituloRecaudacion.TabIndex = 0;
            this.LTituloRecaudacion.Text = "RECAUDADO HOY";
            // 
            // CardRubroTop
            // 
            this.CardRubroTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CardRubroTop.BackColor = System.Drawing.Color.White;
            this.CardRubroTop.Controls.Add(this.LValorRubroTop);
            this.CardRubroTop.Controls.Add(this.LTituloRubroTop);
            this.CardRubroTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.CardRubroTop.Location = new System.Drawing.Point(394, 0);
            this.CardRubroTop.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.CardRubroTop.Name = "CardRubroTop";
            this.CardRubroTop.Size = new System.Drawing.Size(185, 52);
            this.CardRubroTop.TabIndex = 3;
            // 
            // LValorRubroTop
            // 
            this.LValorRubroTop.BackColor = System.Drawing.Color.White;
            this.LValorRubroTop.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LValorRubroTop.Location = new System.Drawing.Point(10, 24);
            this.LValorRubroTop.Name = "LValorRubroTop";
            this.LValorRubroTop.Size = new System.Drawing.Size(142, 25);
            this.LValorRubroTop.TabIndex = 1;
            this.LValorRubroTop.Text = "-";
            // 
            // LTituloRubroTop
            // 
            this.LTituloRubroTop.AutoEllipsis = true;
            this.LTituloRubroTop.BackColor = System.Drawing.Color.White;
            this.LTituloRubroTop.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloRubroTop.Location = new System.Drawing.Point(12, 8);
            this.LTituloRubroTop.Name = "LTituloRubroTop";
            this.LTituloRubroTop.Size = new System.Drawing.Size(140, 16);
            this.LTituloRubroTop.TabIndex = 0;
            this.LTituloRubroTop.Text = "RUBRO TOP";
            // 
            // LTituloHistorial
            // 
            this.LTituloHistorial.AutoSize = true;
            this.LTituloHistorial.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloHistorial.ForeColor = System.Drawing.Color.Black;
            this.LTituloHistorial.Location = new System.Drawing.Point(52, 25);
            this.LTituloHistorial.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LTituloHistorial.Name = "LTituloHistorial";
            this.LTituloHistorial.Size = new System.Drawing.Size(218, 25);
            this.LTituloHistorial.TabIndex = 17;
            this.LTituloHistorial.Text = "Historial de Ventas";
            // 
            // PContenido
            // 
            this.PContenido.Controls.Add(this.PContenedorVentas);
            this.PContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenido.Location = new System.Drawing.Point(0, 0);
            this.PContenido.Name = "PContenido";
            this.PContenido.Size = new System.Drawing.Size(1100, 700);
            this.PContenido.TabIndex = 21;
            // 
            // PContenedorVentas
            // 
            this.PContenedorVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            this.PContenedorVentas.Location = new System.Drawing.Point(0, 0);
            this.PContenedorVentas.Name = "PContenedorVentas";
            this.PContenedorVentas.Size = new System.Drawing.Size(1100, 700);
            this.PContenedorVentas.TabIndex = 0;
            // 
            // PanelCliente
            // 
            this.PanelCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelCliente.BackColor = System.Drawing.Color.White;
            this.PanelCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelCliente.Controls.Add(this.BLimpiarFiltros);
            this.PanelCliente.Controls.Add(this.CBMetodoPagoFiltro);
            this.PanelCliente.Controls.Add(this.LFormaPago);
            this.PanelCliente.Controls.Add(this.DTPFechaHasta);
            this.PanelCliente.Controls.Add(this.LFechaHasta);
            this.PanelCliente.Controls.Add(this.DTPFechaDesde);
            this.PanelCliente.Controls.Add(this.LFechaDesde);
            this.PanelCliente.Controls.Add(this.BFiltrar);
            this.PanelCliente.Location = new System.Drawing.Point(52, 82);
            this.PanelCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PanelCliente.Name = "PanelCliente";
            this.PanelCliente.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.PanelCliente.Size = new System.Drawing.Size(980, 90);
            this.PanelCliente.TabIndex = 0;
            // 
            // BLimpiarFiltros
            // 
            this.BLimpiarFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BLimpiarFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BLimpiarFiltros.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BLimpiarFiltros.FlatAppearance.BorderSize = 2;
            this.BLimpiarFiltros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.BLimpiarFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiarFiltros.ForeColor = System.Drawing.Color.Firebrick;
            this.BLimpiarFiltros.Location = new System.Drawing.Point(820, 37);
            this.BLimpiarFiltros.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BLimpiarFiltros.Name = "BLimpiarFiltros";
            this.BLimpiarFiltros.Size = new System.Drawing.Size(120, 30);
            this.BLimpiarFiltros.TabIndex = 4;
            this.BLimpiarFiltros.Text = "Limpiar";
            this.BLimpiarFiltros.UseVisualStyleBackColor = false;
            this.BLimpiarFiltros.Click += new System.EventHandler(this.BLimpiarFiltros_Click);
            // 
            // CBMetodoPagoFiltro
            // 
            this.CBMetodoPagoFiltro.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBMetodoPagoFiltro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBMetodoPagoFiltro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBMetodoPagoFiltro.Location = new System.Drawing.Point(375, 48);
            this.CBMetodoPagoFiltro.Name = "CBMetodoPagoFiltro";
            this.CBMetodoPagoFiltro.Size = new System.Drawing.Size(150, 21);
            this.CBMetodoPagoFiltro.TabIndex = 2;
            this.CBMetodoPagoFiltro.Tag = "";
            // 
            // LFormaPago
            // 
            this.LFormaPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LFormaPago.AutoSize = true;
            this.LFormaPago.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFormaPago.Location = new System.Drawing.Point(372, 20);
            this.LFormaPago.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LFormaPago.Name = "LFormaPago";
            this.LFormaPago.Size = new System.Drawing.Size(130, 16);
            this.LFormaPago.TabIndex = 43;
            this.LFormaPago.Text = "Método de Pago:";
            // 
            // DTPFechaHasta
            // 
            this.DTPFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DTPFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaHasta.Location = new System.Drawing.Point(198, 48);
            this.DTPFechaHasta.Name = "DTPFechaHasta";
            this.DTPFechaHasta.Size = new System.Drawing.Size(111, 20);
            this.DTPFechaHasta.TabIndex = 1;
            // 
            // LFechaHasta
            // 
            this.LFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LFechaHasta.AutoSize = true;
            this.LFechaHasta.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaHasta.Location = new System.Drawing.Point(195, 20);
            this.LFechaHasta.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LFechaHasta.Name = "LFechaHasta";
            this.LFechaHasta.Size = new System.Drawing.Size(53, 16);
            this.LFechaHasta.TabIndex = 41;
            this.LFechaHasta.Text = "Hasta:";
            // 
            // DTPFechaDesde
            // 
            this.DTPFechaDesde.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DTPFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaDesde.Location = new System.Drawing.Point(21, 48);
            this.DTPFechaDesde.Name = "DTPFechaDesde";
            this.DTPFechaDesde.Size = new System.Drawing.Size(117, 20);
            this.DTPFechaDesde.TabIndex = 0;
            // 
            // LFechaDesde
            // 
            this.LFechaDesde.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LFechaDesde.AutoSize = true;
            this.LFechaDesde.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaDesde.Location = new System.Drawing.Point(21, 20);
            this.LFechaDesde.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LFechaDesde.Name = "LFechaDesde";
            this.LFechaDesde.Size = new System.Drawing.Size(57, 16);
            this.LFechaDesde.TabIndex = 38;
            this.LFechaDesde.Text = "Desde:";
            // 
            // BFiltrar
            // 
            this.BFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BFiltrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BFiltrar.Location = new System.Drawing.Point(671, 36);
            this.BFiltrar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BFiltrar.Name = "BFiltrar";
            this.BFiltrar.Size = new System.Drawing.Size(120, 30);
            this.BFiltrar.TabIndex = 3;
            this.BFiltrar.Text = "Filtrar";
            this.BFiltrar.UseVisualStyleBackColor = false;
            this.BFiltrar.Click += new System.EventHandler(this.BFiltrar_Click);
            // 
            // PContenidoVentas
            // 
            this.PContenidoVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PContenidoVentas.BackColor = System.Drawing.Color.White;
            this.PContenidoVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PContenidoVentas.Controls.Add(this.LPaginas);
            this.PContenidoVentas.Controls.Add(this.BSiguiente);
            this.PContenidoVentas.Controls.Add(this.BAnterior);
            this.PContenidoVentas.Controls.Add(this.DGVHistorial);
            this.PContenidoVentas.Controls.Add(this.LListadoHistorial);
            this.PContenidoVentas.Location = new System.Drawing.Point(52, 180);
            this.PContenidoVentas.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PContenidoVentas.Name = "PContenidoVentas";
            this.PContenidoVentas.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.PContenidoVentas.Size = new System.Drawing.Size(980, 461);
            this.PContenidoVentas.TabIndex = 1;
            // 
            // LPaginas
            // 
            this.LPaginas.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LPaginas.AutoSize = true;
            this.LPaginas.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPaginas.Location = new System.Drawing.Point(439, 417);
            this.LPaginas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LPaginas.Name = "LPaginas";
            this.LPaginas.Size = new System.Drawing.Size(92, 16);
            this.LPaginas.TabIndex = 22;
            this.LPaginas.Text = "Pagina 1 de 3";
            // 
            // BSiguiente
            // 
            this.BSiguiente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSiguiente.ForeColor = System.Drawing.Color.White;
            this.BSiguiente.Location = new System.Drawing.Point(559, 412);
            this.BSiguiente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BSiguiente.Name = "BSiguiente";
            this.BSiguiente.Size = new System.Drawing.Size(89, 25);
            this.BSiguiente.TabIndex = 21;
            this.BSiguiente.Text = "Siguiente >";
            this.BSiguiente.UseVisualStyleBackColor = false;
            this.BSiguiente.Click += new System.EventHandler(this.BSiguiente_Click);
            // 
            // BAnterior
            // 
            this.BAnterior.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAnterior.ForeColor = System.Drawing.Color.White;
            this.BAnterior.Location = new System.Drawing.Point(336, 412);
            this.BAnterior.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BAnterior.Name = "BAnterior";
            this.BAnterior.Size = new System.Drawing.Size(89, 25);
            this.BAnterior.TabIndex = 20;
            this.BAnterior.Text = "< Anterior";
            this.BAnterior.UseVisualStyleBackColor = false;
            this.BAnterior.Click += new System.EventHandler(this.BAnterior_Click);
            // 
            // DGVHistorial
            // 
            this.DGVHistorial.AllowUserToAddRows = false;
            this.DGVHistorial.AllowUserToDeleteRows = false;
            this.DGVHistorial.AllowUserToOrderColumns = true;
            this.DGVHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVHistorial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.DGVHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColComprobante,
            this.ColFecha,
            this.ColCliente,
            this.ColMetodoPago,
            this.ColTotal,
            this.ColAccion});
            this.DGVHistorial.EnableHeadersVisualStyles = false;
            this.DGVHistorial.Location = new System.Drawing.Point(25, 46);
            this.DGVHistorial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DGVHistorial.MultiSelect = false;
            this.DGVHistorial.Name = "DGVHistorial";
            this.DGVHistorial.ReadOnly = true;
            this.DGVHistorial.RowHeadersVisible = false;
            this.DGVHistorial.RowTemplate.Height = 24;
            this.DGVHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVHistorial.Size = new System.Drawing.Size(933, 344);
            this.DGVHistorial.TabIndex = 0;
            this.DGVHistorial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVHistorial_CellContentClick);
            // 
            // ColId
            // 
            this.ColId.HeaderText = "Id";
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            this.ColId.Visible = false;
            // 
            // ColComprobante
            // 
            this.ColComprobante.HeaderText = "Comprobante";
            this.ColComprobante.Name = "ColComprobante";
            this.ColComprobante.ReadOnly = true;
            // 
            // ColFecha
            // 
            this.ColFecha.HeaderText = "Fecha y Hora";
            this.ColFecha.Name = "ColFecha";
            this.ColFecha.ReadOnly = true;
            // 
            // ColCliente
            // 
            this.ColCliente.HeaderText = "Cliente";
            this.ColCliente.Name = "ColCliente";
            this.ColCliente.ReadOnly = true;
            // 
            // ColMetodoPago
            // 
            this.ColMetodoPago.HeaderText = "Método de Pago";
            this.ColMetodoPago.Name = "ColMetodoPago";
            this.ColMetodoPago.ReadOnly = true;
            // 
            // ColTotal
            // 
            this.ColTotal.HeaderText = "Total";
            this.ColTotal.Name = "ColTotal";
            this.ColTotal.ReadOnly = true;
            // 
            // ColAccion
            // 
            this.ColAccion.HeaderText = "Ver";
            this.ColAccion.Name = "ColAccion";
            this.ColAccion.ReadOnly = true;
            this.ColAccion.UseColumnTextForButtonValue = true;
            // 
            // LListadoHistorial
            // 
            this.LListadoHistorial.AutoSize = true;
            this.LListadoHistorial.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LListadoHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LListadoHistorial.Location = new System.Drawing.Point(19, 18);
            this.LListadoHistorial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LListadoHistorial.Name = "LListadoHistorial";
            this.LListadoHistorial.Size = new System.Drawing.Size(84, 16);
            this.LListadoHistorial.TabIndex = 17;
            this.LListadoHistorial.Text = "LISTADO";
            // 
            // FormHistorialVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.PContenidoVentas);
            this.Controls.Add(this.PanelCliente);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormHistorialVentas";
            this.Text = "FormHistorialVentas";
            this.Load += new System.EventHandler(this.FormHistorialVentas_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.FCardsVentas.ResumeLayout(false);
            this.PCardVentasHoy.ResumeLayout(false);
            this.PCardRecaudacionHoy.ResumeLayout(false);
            this.CardRubroTop.ResumeLayout(false);
            this.PContenido.ResumeLayout(false);
            this.PanelCliente.ResumeLayout(false);
            this.PanelCliente.PerformLayout();
            this.PContenidoVentas.ResumeLayout(false);
            this.PContenidoVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistorial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label LTituloHistorial;
        private System.Windows.Forms.FlowLayoutPanel FCardsVentas;
        private System.Windows.Forms.Panel PCardVentasHoy;
        private System.Windows.Forms.Label LValorVentas;
        private System.Windows.Forms.Label LTituloVentas;
        private System.Windows.Forms.Panel PCardRecaudacionHoy;
        private System.Windows.Forms.Label LValorRecaudacion;
        private System.Windows.Forms.Label LTituloRecaudacion;
        private System.Windows.Forms.Panel CardRubroTop;
        private System.Windows.Forms.Label LValorRubroTop;
        private System.Windows.Forms.Label LTituloRubroTop;
        protected internal System.Windows.Forms.Panel PanelCliente;
        protected internal System.Windows.Forms.Panel PContenidoVentas;
        private System.Windows.Forms.Label LListadoHistorial;
        private System.Windows.Forms.DataGridView DGVHistorial;
        private System.Windows.Forms.Button BSiguiente;
        private System.Windows.Forms.Button BAnterior;
        private System.Windows.Forms.Label LPaginas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMetodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotal;
        private System.Windows.Forms.DataGridViewButtonColumn ColAccion;
        private System.Windows.Forms.Button BLimpiarFiltros;
        private System.Windows.Forms.ComboBox CBMetodoPagoFiltro;
        private System.Windows.Forms.Label LFormaPago;
        private System.Windows.Forms.DateTimePicker DTPFechaHasta;
        private System.Windows.Forms.Label LFechaHasta;
        private System.Windows.Forms.DateTimePicker DTPFechaDesde;
        private System.Windows.Forms.Label LFechaDesde;
        private System.Windows.Forms.Button BFiltrar;
        private System.Windows.Forms.Panel PContenido;
        private System.Windows.Forms.FlowLayoutPanel PContenedorVentas;
    }
}