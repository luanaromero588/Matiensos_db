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
            this.LValorVentasHoy = new System.Windows.Forms.Label();
            this.LTituloVentasHoy = new System.Windows.Forms.Label();
            this.PCardRecaudacionHoy = new System.Windows.Forms.Panel();
            this.LValorRecaudacionHoy = new System.Windows.Forms.Label();
            this.LTituloRecaudacionHoy = new System.Windows.Forms.Label();
            this.CardRubroTop = new System.Windows.Forms.Panel();
            this.LValorRubroTop = new System.Windows.Forms.Label();
            this.LTituloRubroTop = new System.Windows.Forms.Label();
            this.LTituloHistorial = new System.Windows.Forms.Label();
            this.PanelCliente = new System.Windows.Forms.Panel();
            this.GBFiltros = new System.Windows.Forms.GroupBox();
            this.BLimpiarFiltros = new System.Windows.Forms.Button();
            this.CBMetodoPagoFiltro = new System.Windows.Forms.ComboBox();
            this.LFormaPago = new System.Windows.Forms.Label();
            this.DTPFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.LFechaHasta = new System.Windows.Forms.Label();
            this.DTPFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LFechaDesde = new System.Windows.Forms.Label();
            this.LFiltros = new System.Windows.Forms.Label();
            this.BFiltrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.Load += new System.EventHandler(this.FormHistorialVentas_Load);
            this.BFiltrar.Click += new System.EventHandler(this.BFiltrar_Click);
            this.BLimpiarFiltros.Click += new System.EventHandler(this.BLimpiarFiltros_Click);
            this.BAnterior.Click += new System.EventHandler(this.BAnterior_Click);
            this.BSiguiente.Click += new System.EventHandler(this.BSiguiente_Click);
            this.DGVHistorial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVHistorial_CellContentClick);
            this.panelHeader.SuspendLayout();
            this.FCardsVentas.SuspendLayout();
            this.PCardVentasHoy.SuspendLayout();
            this.PCardRecaudacionHoy.SuspendLayout();
            this.CardRubroTop.SuspendLayout();
            this.PanelCliente.SuspendLayout();
            this.GBFiltros.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.panelHeader.Controls.Add(this.FCardsVentas);
            this.panelHeader.Controls.Add(this.LTituloHistorial);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(768, 80);
            this.panelHeader.TabIndex = 20;
            // 
            // FCardsVentas
            // 
            this.FCardsVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FCardsVentas.BackColor = System.Drawing.Color.Transparent;
            this.FCardsVentas.Controls.Add(this.PCardVentasHoy);
            this.FCardsVentas.Controls.Add(this.PCardRecaudacionHoy);
            this.FCardsVentas.Controls.Add(this.CardRubroTop);
            this.FCardsVentas.Location = new System.Drawing.Point(242, 11);
            this.FCardsVentas.Name = "FCardsVentas";
            this.FCardsVentas.Size = new System.Drawing.Size(517, 56);
            this.FCardsVentas.TabIndex = 20;
            // 
            // PCardVentasHoy
            // 
            this.PCardVentasHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PCardVentasHoy.BackColor = System.Drawing.Color.White;
            this.PCardVentasHoy.Controls.Add(this.LValorVentasHoy);
            this.PCardVentasHoy.Controls.Add(this.LTituloVentasHoy);
            this.PCardVentasHoy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCardVentasHoy.Location = new System.Drawing.Point(0, 0);
            this.PCardVentasHoy.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.PCardVentasHoy.Name = "PCardVentasHoy";
            this.PCardVentasHoy.Size = new System.Drawing.Size(160, 52);
            this.PCardVentasHoy.TabIndex = 4;
            // 
            // LValorVentasHoy
            // 
            this.LValorVentasHoy.BackColor = System.Drawing.Color.White;
            this.LValorVentasHoy.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LValorVentasHoy.Location = new System.Drawing.Point(10, 24);
            this.LValorVentasHoy.Name = "LValorVentasHoy";
            this.LValorVentasHoy.Size = new System.Drawing.Size(23, 25);
            this.LValorVentasHoy.TabIndex = 1;
            this.LValorVentasHoy.Text = "0";
            // 
            // LTituloVentasHoy
            // 
            this.LTituloVentasHoy.AutoEllipsis = true;
            this.LTituloVentasHoy.BackColor = System.Drawing.Color.White;
            this.LTituloVentasHoy.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloVentasHoy.Location = new System.Drawing.Point(12, 8);
            this.LTituloVentasHoy.Name = "LTituloVentasHoy";
            this.LTituloVentasHoy.Size = new System.Drawing.Size(109, 13);
            this.LTituloVentasHoy.TabIndex = 0;
            this.LTituloVentasHoy.Text = "VENTAS HOY";
            // 
            // PCardRecaudacionHoy
            // 
            this.PCardRecaudacionHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PCardRecaudacionHoy.BackColor = System.Drawing.Color.White;
            this.PCardRecaudacionHoy.Controls.Add(this.LValorRecaudacionHoy);
            this.PCardRecaudacionHoy.Controls.Add(this.LTituloRecaudacionHoy);
            this.PCardRecaudacionHoy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCardRecaudacionHoy.Location = new System.Drawing.Point(172, 0);
            this.PCardRecaudacionHoy.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.PCardRecaudacionHoy.Name = "PCardRecaudacionHoy";
            this.PCardRecaudacionHoy.Size = new System.Drawing.Size(160, 52);
            this.PCardRecaudacionHoy.TabIndex = 4;
            // 
            // LValorRecaudacionHoy
            // 
            this.LValorRecaudacionHoy.BackColor = System.Drawing.Color.White;
            this.LValorRecaudacionHoy.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LValorRecaudacionHoy.Location = new System.Drawing.Point(10, 24);
            this.LValorRecaudacionHoy.Name = "LValorRecaudacionHoy";
            this.LValorRecaudacionHoy.Size = new System.Drawing.Size(23, 25);
            this.LValorRecaudacionHoy.TabIndex = 1;
            this.LValorRecaudacionHoy.Text = "$ ";
            // 
            // LTituloRecaudacionHoy
            // 
            this.LTituloRecaudacionHoy.AutoEllipsis = true;
            this.LTituloRecaudacionHoy.BackColor = System.Drawing.Color.White;
            this.LTituloRecaudacionHoy.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloRecaudacionHoy.Location = new System.Drawing.Point(12, 8);
            this.LTituloRecaudacionHoy.Name = "LTituloRecaudacionHoy";
            this.LTituloRecaudacionHoy.Size = new System.Drawing.Size(109, 13);
            this.LTituloRecaudacionHoy.TabIndex = 0;
            this.LTituloRecaudacionHoy.Text = "RECAUDADO HOY";
            // 
            // CardRubroTop
            // 
            this.CardRubroTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CardRubroTop.BackColor = System.Drawing.Color.White;
            this.CardRubroTop.Controls.Add(this.LValorRubroTop);
            this.CardRubroTop.Controls.Add(this.LTituloRubroTop);
            this.CardRubroTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.CardRubroTop.Location = new System.Drawing.Point(344, 0);
            this.CardRubroTop.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.CardRubroTop.Name = "CardRubroTop";
            this.CardRubroTop.Size = new System.Drawing.Size(160, 52);
            this.CardRubroTop.TabIndex = 3;
            // 
            // LValorRubroTop
            // 
            this.LValorRubroTop.BackColor = System.Drawing.Color.White;
            this.LValorRubroTop.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LValorRubroTop.Location = new System.Drawing.Point(10, 24);
            this.LValorRubroTop.Name = "LValorRubroTop";
            this.LValorRubroTop.Size = new System.Drawing.Size(23, 25);
            this.LValorRubroTop.TabIndex = 1;
            this.LValorRubroTop.Text = "-";
            // 
            // LTituloRubroTop
            // 
            this.LTituloRubroTop.AutoEllipsis = true;
            this.LTituloRubroTop.BackColor = System.Drawing.Color.White;
            this.LTituloRubroTop.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloRubroTop.Location = new System.Drawing.Point(12, 8);
            this.LTituloRubroTop.Name = "LTituloRubroTop";
            this.LTituloRubroTop.Size = new System.Drawing.Size(109, 13);
            this.LTituloRubroTop.TabIndex = 0;
            this.LTituloRubroTop.Text = "RUBRO TOP HOY";
            // 
            // LTituloHistorial
            // 
            this.LTituloHistorial.AutoSize = true;
            this.LTituloHistorial.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LTituloHistorial.Location = new System.Drawing.Point(23, 28);
            this.LTituloHistorial.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LTituloHistorial.Name = "LTituloHistorial";
            this.LTituloHistorial.Size = new System.Drawing.Size(218, 25);
            this.LTituloHistorial.TabIndex = 17;
            this.LTituloHistorial.Text = "Historial de Ventas";
            // 
            // PanelCliente
            // 
            this.PanelCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelCliente.BackColor = System.Drawing.Color.White;
            this.PanelCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelCliente.Controls.Add(this.GBFiltros);
            this.PanelCliente.Location = new System.Drawing.Point(24, 88);
            this.PanelCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PanelCliente.Name = "PanelCliente";
            this.PanelCliente.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.PanelCliente.Size = new System.Drawing.Size(720, 96);
            this.PanelCliente.TabIndex = 21;
            // 
            // GBFiltros
            // 
            this.GBFiltros.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GBFiltros.Controls.Add(this.BLimpiarFiltros);
            this.GBFiltros.Controls.Add(this.CBMetodoPagoFiltro);
            this.GBFiltros.Controls.Add(this.LFormaPago);
            this.GBFiltros.Controls.Add(this.DTPFechaHasta);
            this.GBFiltros.Controls.Add(this.LFechaHasta);
            this.GBFiltros.Controls.Add(this.DTPFechaDesde);
            this.GBFiltros.Controls.Add(this.textBox1);
            this.GBFiltros.Controls.Add(this.LFechaDesde);
            this.GBFiltros.Controls.Add(this.LFiltros);
            this.GBFiltros.Controls.Add(this.BFiltrar);
            this.GBFiltros.Location = new System.Drawing.Point(7, 8);
            this.GBFiltros.Name = "GBFiltros";
            this.GBFiltros.Size = new System.Drawing.Size(703, 80);
            this.GBFiltros.TabIndex = 31;
            this.GBFiltros.TabStop = false;
            // 
            // BLimpiarFiltros
            // 
            this.BLimpiarFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BLimpiarFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BLimpiarFiltros.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BLimpiarFiltros.FlatAppearance.BorderSize = 2;
            this.BLimpiarFiltros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.BLimpiarFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiarFiltros.ForeColor = System.Drawing.Color.Firebrick;
            this.BLimpiarFiltros.Location = new System.Drawing.Point(626, 43);
            this.BLimpiarFiltros.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BLimpiarFiltros.Name = "BLimpiarFiltros";
            this.BLimpiarFiltros.Size = new System.Drawing.Size(56, 21);
            this.BLimpiarFiltros.TabIndex = 18;
            this.BLimpiarFiltros.Text = "Limpiar";
            this.BLimpiarFiltros.UseVisualStyleBackColor = false;
            // 
            // CBMetodoPagoFiltro
            // 
            this.CBMetodoPagoFiltro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBMetodoPagoFiltro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBMetodoPagoFiltro.Location = new System.Drawing.Point(430, 44);
            this.CBMetodoPagoFiltro.Name = "CBMetodoPagoFiltro";
            this.CBMetodoPagoFiltro.Size = new System.Drawing.Size(123, 21);
            this.CBMetodoPagoFiltro.TabIndex = 35;
            this.CBMetodoPagoFiltro.Tag = "";
            // 
            // LFormaPago
            // 
            this.LFormaPago.AutoSize = true;
            this.LFormaPago.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFormaPago.Location = new System.Drawing.Point(338, 47);
            this.LFormaPago.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LFormaPago.Name = "LFormaPago";
            this.LFormaPago.Size = new System.Drawing.Size(113, 16);
            this.LFormaPago.TabIndex = 34;
            this.LFormaPago.Text = "Método de Pago:";
            // 
            // DTPFechaHasta
            // 
            this.DTPFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaHasta.Location = new System.Drawing.Point(210, 44);
            this.DTPFechaHasta.Name = "DTPFechaHasta";
            this.DTPFechaHasta.Size = new System.Drawing.Size(98, 20);
            this.DTPFechaHasta.TabIndex = 33;
            // 
            // LFechaHasta
            // 
            this.LFechaHasta.AutoSize = true;
            this.LFechaHasta.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaHasta.Location = new System.Drawing.Point(171, 47);
            this.LFechaHasta.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LFechaHasta.Name = "LFechaHasta";
            this.LFechaHasta.Size = new System.Drawing.Size(46, 16);
            this.LFechaHasta.TabIndex = 32;
            this.LFechaHasta.Text = "Hasta:";
            // 
            // DTPFechaDesde
            // 
            this.DTPFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaDesde.Location = new System.Drawing.Point(58, 44);
            this.DTPFechaDesde.Name = "DTPFechaDesde";
            this.DTPFechaDesde.Size = new System.Drawing.Size(98, 20);
            this.DTPFechaDesde.TabIndex = 31;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1, 20);
            this.textBox1.TabIndex = 20;
            // 
            // LFechaDesde
            // 
            this.LFechaDesde.AutoSize = true;
            this.LFechaDesde.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaDesde.Location = new System.Drawing.Point(13, 47);
            this.LFechaDesde.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LFechaDesde.Name = "LFechaDesde";
            this.LFechaDesde.Size = new System.Drawing.Size(50, 16);
            this.LFechaDesde.TabIndex = 17;
            this.LFechaDesde.Text = "Desde:";
            // 
            // LFiltros
            // 
            this.LFiltros.AutoSize = true;
            this.LFiltros.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LFiltros.Location = new System.Drawing.Point(7, 10);
            this.LFiltros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LFiltros.Name = "LFiltros";
            this.LFiltros.Size = new System.Drawing.Size(212, 16);
            this.LFiltros.TabIndex = 16;
            this.LFiltros.Text = "FILTROS DE BUSQUEDA";
            // 
            // BFiltrar
            // 
            this.BFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BFiltrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BFiltrar.Location = new System.Drawing.Point(561, 42);
            this.BFiltrar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BFiltrar.Name = "BFiltrar";
            this.BFiltrar.Size = new System.Drawing.Size(56, 21);
            this.BFiltrar.TabIndex = 1;
            this.BFiltrar.Text = "Filtrar";
            this.BFiltrar.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LPaginas);
            this.panel1.Controls.Add(this.BSiguiente);
            this.panel1.Controls.Add(this.BAnterior);
            this.panel1.Controls.Add(this.DGVHistorial);
            this.panel1.Controls.Add(this.LListadoHistorial);
            this.panel1.Location = new System.Drawing.Point(24, 192);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.panel1.Size = new System.Drawing.Size(720, 381);
            this.panel1.TabIndex = 22;
            // 
            // LPaginas
            // 
            this.LPaginas.AutoSize = true;
            this.LPaginas.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPaginas.Location = new System.Drawing.Point(324, 340);
            this.LPaginas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LPaginas.Name = "LPaginas";
            this.LPaginas.Size = new System.Drawing.Size(92, 16);
            this.LPaginas.TabIndex = 22;
            this.LPaginas.Text = "Pagina 1 de 3";
            // 
            // BSiguiente
            // 
            this.BSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BSiguiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BSiguiente.Location = new System.Drawing.Point(402, 336);
            this.BSiguiente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BSiguiente.Name = "BSiguiente";
            this.BSiguiente.Size = new System.Drawing.Size(67, 21);
            this.BSiguiente.TabIndex = 21;
            this.BSiguiente.Text = "Siguiente >";
            this.BSiguiente.UseVisualStyleBackColor = false;
            // 
            // BAnterior
            // 
            this.BAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BAnterior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BAnterior.Location = new System.Drawing.Point(247, 336);
            this.BAnterior.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BAnterior.Name = "BAnterior";
            this.BAnterior.Size = new System.Drawing.Size(67, 21);
            this.BAnterior.TabIndex = 20;
            this.BAnterior.Text = "< Anterior";
            this.BAnterior.UseVisualStyleBackColor = false;
            // 
            // DGVHistorial
            // 
            this.DGVHistorial.AllowUserToAddRows = false;
            this.DGVHistorial.AllowUserToDeleteRows = false;
            this.DGVHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColComprobante,
            this.ColFecha,
            this.ColCliente,
            this.ColMetodoPago,
            this.ColTotal,
            this.ColAccion});
            this.DGVHistorial.Location = new System.Drawing.Point(16, 46);
            this.DGVHistorial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DGVHistorial.MultiSelect = false;
            this.DGVHistorial.Name = "DGVHistorial";
            this.DGVHistorial.ReadOnly = true;
            this.DGVHistorial.RowTemplate.Height = 24;
            this.DGVHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVHistorial.Size = new System.Drawing.Size(685, 275);
            this.DGVHistorial.TabIndex = 18;
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
            this.ColComprobante.Width = 120;
            // 
            // ColFecha
            // 
            this.ColFecha.HeaderText = "Fecha y Hora";
            this.ColFecha.Name = "ColFecha";
            this.ColFecha.ReadOnly = true;
            this.ColFecha.Width = 140;
            // 
            // ColCliente
            // 
            this.ColCliente.HeaderText = "Cliente";
            this.ColCliente.Name = "ColCliente";
            this.ColCliente.ReadOnly = true;
            this.ColCliente.Width = 200;
            // 
            // ColMetodoPago
            // 
            this.ColMetodoPago.HeaderText = "Método de Pago";
            this.ColMetodoPago.Name = "ColMetodoPago";
            this.ColMetodoPago.ReadOnly = true;
            this.ColMetodoPago.Width = 140;
            // 
            // ColTotal
            // 
            this.ColTotal.HeaderText = "Total";
            this.ColTotal.Name = "ColTotal";
            this.ColTotal.ReadOnly = true;
            this.ColTotal.Width = 110;
            // 
            // ColAccion
            // 
            this.ColAccion.HeaderText = "Ver";
            this.ColAccion.Name = "ColAccion";
            this.ColAccion.ReadOnly = true;
            this.ColAccion.UseColumnTextForButtonValue = true;
            this.ColAccion.Width = 60;
            // 
            // LListadoHistorial
            // 
            this.LListadoHistorial.AutoSize = true;
            this.LListadoHistorial.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LListadoHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LListadoHistorial.Location = new System.Drawing.Point(14, 18);
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
            this.ClientSize = new System.Drawing.Size(768, 583);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelCliente);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormHistorialVentas";
            this.Text = "FormHistorialVentas";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.FCardsVentas.ResumeLayout(false);
            this.PCardVentasHoy.ResumeLayout(false);
            this.PCardRecaudacionHoy.ResumeLayout(false);
            this.CardRubroTop.ResumeLayout(false);
            this.PanelCliente.ResumeLayout(false);
            this.GBFiltros.ResumeLayout(false);
            this.GBFiltros.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistorial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label LTituloHistorial;
        private System.Windows.Forms.FlowLayoutPanel FCardsVentas;
        private System.Windows.Forms.Panel PCardVentasHoy;
        private System.Windows.Forms.Label LValorVentasHoy;
        private System.Windows.Forms.Label LTituloVentasHoy;
        private System.Windows.Forms.Panel PCardRecaudacionHoy;
        private System.Windows.Forms.Label LValorRecaudacionHoy;
        private System.Windows.Forms.Label LTituloRecaudacionHoy;
        private System.Windows.Forms.Panel CardRubroTop;
        private System.Windows.Forms.Label LValorRubroTop;
        private System.Windows.Forms.Label LTituloRubroTop;
        protected internal System.Windows.Forms.Panel PanelCliente;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label LFechaDesde;
        private System.Windows.Forms.Label LFiltros;
        private System.Windows.Forms.Button BFiltrar;
        private System.Windows.Forms.GroupBox GBFiltros;
        private System.Windows.Forms.Label LFechaHasta;
        private System.Windows.Forms.DateTimePicker DTPFechaDesde;
        private System.Windows.Forms.Label LFormaPago;
        private System.Windows.Forms.DateTimePicker DTPFechaHasta;
        private System.Windows.Forms.ComboBox CBMetodoPagoFiltro;
        protected internal System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LListadoHistorial;
        private System.Windows.Forms.Button BLimpiarFiltros;
        private System.Windows.Forms.DataGridView DGVHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMetodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotal;
        private System.Windows.Forms.DataGridViewButtonColumn ColAccion;
        private System.Windows.Forms.Button BSiguiente;
        private System.Windows.Forms.Button BAnterior;
        private System.Windows.Forms.Label LPaginas;
    }
}