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
            this.BLimpiarFiltros = new System.Windows.Forms.Button();
            this.CBMetodoPagoFiltro = new System.Windows.Forms.ComboBox();
            this.LFormaPago = new System.Windows.Forms.Label();
            this.DTPFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.LFechaHasta = new System.Windows.Forms.Label();
            this.DTPFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.LFechaDesde = new System.Windows.Forms.Label();
            this.LFiltros = new System.Windows.Forms.Label();
            this.BFiltrar = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.FCardsVentas.SuspendLayout();
            this.PCardVentasHoy.SuspendLayout();
            this.PCardRecaudacionHoy.SuspendLayout();
            this.CardRubroTop.SuspendLayout();
            this.PanelCliente.SuspendLayout();
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
            this.panelHeader.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1467, 98);
            this.panelHeader.TabIndex = 20;
            // 
            // FCardsVentas
            // 
            this.FCardsVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FCardsVentas.BackColor = System.Drawing.Color.Transparent;
            this.FCardsVentas.Controls.Add(this.PCardVentasHoy);
            this.FCardsVentas.Controls.Add(this.PCardRecaudacionHoy);
            this.FCardsVentas.Controls.Add(this.CardRubroTop);
            this.FCardsVentas.Location = new System.Drawing.Point(660, 15);
            this.FCardsVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FCardsVentas.Name = "FCardsVentas";
            this.FCardsVentas.Size = new System.Drawing.Size(803, 69);
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
            this.PCardVentasHoy.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.PCardVentasHoy.Name = "PCardVentasHoy";
            this.PCardVentasHoy.Size = new System.Drawing.Size(247, 64);
            this.PCardVentasHoy.TabIndex = 4;
            // 
            // LValorVentasHoy
            // 
            this.LValorVentasHoy.BackColor = System.Drawing.Color.White;
            this.LValorVentasHoy.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LValorVentasHoy.Location = new System.Drawing.Point(13, 30);
            this.LValorVentasHoy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LValorVentasHoy.Name = "LValorVentasHoy";
            this.LValorVentasHoy.Size = new System.Drawing.Size(189, 31);
            this.LValorVentasHoy.TabIndex = 1;
            this.LValorVentasHoy.Text = "0";
            // 
            // LTituloVentasHoy
            // 
            this.LTituloVentasHoy.AutoEllipsis = true;
            this.LTituloVentasHoy.BackColor = System.Drawing.Color.White;
            this.LTituloVentasHoy.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloVentasHoy.Location = new System.Drawing.Point(16, 10);
            this.LTituloVentasHoy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloVentasHoy.Name = "LTituloVentasHoy";
            this.LTituloVentasHoy.Size = new System.Drawing.Size(187, 20);
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
            this.PCardRecaudacionHoy.Location = new System.Drawing.Point(263, 0);
            this.PCardRecaudacionHoy.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.PCardRecaudacionHoy.Name = "PCardRecaudacionHoy";
            this.PCardRecaudacionHoy.Size = new System.Drawing.Size(247, 64);
            this.PCardRecaudacionHoy.TabIndex = 4;
            // 
            // LValorRecaudacionHoy
            // 
            this.LValorRecaudacionHoy.BackColor = System.Drawing.Color.White;
            this.LValorRecaudacionHoy.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LValorRecaudacionHoy.Location = new System.Drawing.Point(13, 30);
            this.LValorRecaudacionHoy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LValorRecaudacionHoy.Name = "LValorRecaudacionHoy";
            this.LValorRecaudacionHoy.Size = new System.Drawing.Size(189, 31);
            this.LValorRecaudacionHoy.TabIndex = 1;
            this.LValorRecaudacionHoy.Text = "$ ";
            // 
            // LTituloRecaudacionHoy
            // 
            this.LTituloRecaudacionHoy.AutoEllipsis = true;
            this.LTituloRecaudacionHoy.BackColor = System.Drawing.Color.White;
            this.LTituloRecaudacionHoy.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloRecaudacionHoy.Location = new System.Drawing.Point(16, 10);
            this.LTituloRecaudacionHoy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloRecaudacionHoy.Name = "LTituloRecaudacionHoy";
            this.LTituloRecaudacionHoy.Size = new System.Drawing.Size(187, 20);
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
            this.CardRubroTop.Location = new System.Drawing.Point(526, 0);
            this.CardRubroTop.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.CardRubroTop.Name = "CardRubroTop";
            this.CardRubroTop.Size = new System.Drawing.Size(247, 64);
            this.CardRubroTop.TabIndex = 3;
            // 
            // LValorRubroTop
            // 
            this.LValorRubroTop.BackColor = System.Drawing.Color.White;
            this.LValorRubroTop.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LValorRubroTop.Location = new System.Drawing.Point(13, 30);
            this.LValorRubroTop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LValorRubroTop.Name = "LValorRubroTop";
            this.LValorRubroTop.Size = new System.Drawing.Size(189, 31);
            this.LValorRubroTop.TabIndex = 1;
            this.LValorRubroTop.Text = "-";
            // 
            // LTituloRubroTop
            // 
            this.LTituloRubroTop.AutoEllipsis = true;
            this.LTituloRubroTop.BackColor = System.Drawing.Color.White;
            this.LTituloRubroTop.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloRubroTop.Location = new System.Drawing.Point(16, 10);
            this.LTituloRubroTop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloRubroTop.Name = "LTituloRubroTop";
            this.LTituloRubroTop.Size = new System.Drawing.Size(187, 20);
            this.LTituloRubroTop.TabIndex = 0;
            this.LTituloRubroTop.Text = "RUBRO TOP HOY";
            // 
            // LTituloHistorial
            // 
            this.LTituloHistorial.AutoSize = true;
            this.LTituloHistorial.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LTituloHistorial.Location = new System.Drawing.Point(31, 34);
            this.LTituloHistorial.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
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
            this.PanelCliente.Controls.Add(this.BLimpiarFiltros);
            this.PanelCliente.Controls.Add(this.CBMetodoPagoFiltro);
            this.PanelCliente.Controls.Add(this.LFormaPago);
            this.PanelCliente.Controls.Add(this.DTPFechaHasta);
            this.PanelCliente.Controls.Add(this.LFechaHasta);
            this.PanelCliente.Controls.Add(this.DTPFechaDesde);
            this.PanelCliente.Controls.Add(this.LFechaDesde);
            this.PanelCliente.Controls.Add(this.LFiltros);
            this.PanelCliente.Controls.Add(this.BFiltrar);
            this.PanelCliente.Location = new System.Drawing.Point(32, 108);
            this.PanelCliente.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.PanelCliente.Name = "PanelCliente";
            this.PanelCliente.Padding = new System.Windows.Forms.Padding(27, 22, 27, 22);
            this.PanelCliente.Size = new System.Drawing.Size(1402, 118);
            this.PanelCliente.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LPaginas);
            this.panel1.Controls.Add(this.BSiguiente);
            this.panel1.Controls.Add(this.BAnterior);
            this.panel1.Controls.Add(this.DGVHistorial);
            this.panel1.Controls.Add(this.LListadoHistorial);
            this.panel1.Location = new System.Drawing.Point(32, 236);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(27, 22, 27, 22);
            this.panel1.Size = new System.Drawing.Size(1402, 580);
            this.panel1.TabIndex = 1;
            // 
            // LPaginas
            // 
            this.LPaginas.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LPaginas.AutoSize = true;
            this.LPaginas.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPaginas.Location = new System.Drawing.Point(662, 529);
            this.LPaginas.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LPaginas.Name = "LPaginas";
            this.LPaginas.Size = new System.Drawing.Size(92, 16);
            this.LPaginas.TabIndex = 22;
            this.LPaginas.Text = "Pagina 1 de 3";
            // 
            // BSiguiente
            // 
            this.BSiguiente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSiguiente.ForeColor = System.Drawing.Color.White;
            this.BSiguiente.Location = new System.Drawing.Point(793, 521);
            this.BSiguiente.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.BSiguiente.Name = "BSiguiente";
            this.BSiguiente.Size = new System.Drawing.Size(119, 31);
            this.BSiguiente.TabIndex = 21;
            this.BSiguiente.Text = "Siguiente >";
            this.BSiguiente.UseVisualStyleBackColor = false;
            this.BSiguiente.Click += new System.EventHandler(this.BSiguiente_Click);
            // 
            // BAnterior
            // 
            this.BAnterior.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAnterior.ForeColor = System.Drawing.Color.White;
            this.BAnterior.Location = new System.Drawing.Point(496, 521);
            this.BAnterior.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.BAnterior.Name = "BAnterior";
            this.BAnterior.Size = new System.Drawing.Size(119, 31);
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
            this.DGVHistorial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.DGVHistorial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.DGVHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColComprobante,
            this.ColFecha,
            this.ColCliente,
            this.ColMetodoPago,
            this.ColTotal,
            this.ColAccion});
            this.DGVHistorial.Location = new System.Drawing.Point(-1, 57);
            this.DGVHistorial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGVHistorial.MultiSelect = false;
            this.DGVHistorial.Name = "DGVHistorial";
            this.DGVHistorial.ReadOnly = true;
            this.DGVHistorial.RowTemplate.Height = 24;
            this.DGVHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVHistorial.Size = new System.Drawing.Size(1401, 437);
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
            this.LListadoHistorial.Location = new System.Drawing.Point(25, 22);
            this.LListadoHistorial.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LListadoHistorial.Name = "LListadoHistorial";
            this.LListadoHistorial.Size = new System.Drawing.Size(84, 16);
            this.LListadoHistorial.TabIndex = 17;
            this.LListadoHistorial.Text = "LISTADO";
            // 
            // BLimpiarFiltros
            // 
            this.BLimpiarFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BLimpiarFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BLimpiarFiltros.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BLimpiarFiltros.FlatAppearance.BorderSize = 2;
            this.BLimpiarFiltros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.BLimpiarFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiarFiltros.ForeColor = System.Drawing.Color.Firebrick;
            this.BLimpiarFiltros.Location = new System.Drawing.Point(1297, 61);
            this.BLimpiarFiltros.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BLimpiarFiltros.Name = "BLimpiarFiltros";
            this.BLimpiarFiltros.Size = new System.Drawing.Size(75, 34);
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
            this.CBMetodoPagoFiltro.Location = new System.Drawing.Point(761, 65);
            this.CBMetodoPagoFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.CBMetodoPagoFiltro.Name = "CBMetodoPagoFiltro";
            this.CBMetodoPagoFiltro.Size = new System.Drawing.Size(199, 24);
            this.CBMetodoPagoFiltro.TabIndex = 2;
            this.CBMetodoPagoFiltro.Tag = "";
            // 
            // LFormaPago
            // 
            this.LFormaPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LFormaPago.AutoSize = true;
            this.LFormaPago.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFormaPago.Location = new System.Drawing.Point(600, 68);
            this.LFormaPago.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LFormaPago.Name = "LFormaPago";
            this.LFormaPago.Size = new System.Drawing.Size(113, 16);
            this.LFormaPago.TabIndex = 43;
            this.LFormaPago.Text = "Método de Pago:";
            // 
            // DTPFechaHasta
            // 
            this.DTPFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DTPFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaHasta.Location = new System.Drawing.Point(391, 66);
            this.DTPFechaHasta.Margin = new System.Windows.Forms.Padding(4);
            this.DTPFechaHasta.Name = "DTPFechaHasta";
            this.DTPFechaHasta.Size = new System.Drawing.Size(147, 22);
            this.DTPFechaHasta.TabIndex = 1;
            // 
            // LFechaHasta
            // 
            this.LFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LFechaHasta.AutoSize = true;
            this.LFechaHasta.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaHasta.Location = new System.Drawing.Point(319, 66);
            this.LFechaHasta.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LFechaHasta.Name = "LFechaHasta";
            this.LFechaHasta.Size = new System.Drawing.Size(46, 16);
            this.LFechaHasta.TabIndex = 41;
            this.LFechaHasta.Text = "Hasta:";
            // 
            // DTPFechaDesde
            // 
            this.DTPFechaDesde.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DTPFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaDesde.Location = new System.Drawing.Point(111, 66);
            this.DTPFechaDesde.Margin = new System.Windows.Forms.Padding(4);
            this.DTPFechaDesde.Name = "DTPFechaDesde";
            this.DTPFechaDesde.Size = new System.Drawing.Size(155, 22);
            this.DTPFechaDesde.TabIndex = 0;
            // 
            // LFechaDesde
            // 
            this.LFechaDesde.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LFechaDesde.AutoSize = true;
            this.LFechaDesde.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaDesde.Location = new System.Drawing.Point(33, 66);
            this.LFechaDesde.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LFechaDesde.Name = "LFechaDesde";
            this.LFechaDesde.Size = new System.Drawing.Size(50, 16);
            this.LFechaDesde.TabIndex = 38;
            this.LFechaDesde.Text = "Desde:";
            // 
            // LFiltros
            // 
            this.LFiltros.AutoSize = true;
            this.LFiltros.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LFiltros.Location = new System.Drawing.Point(29, 22);
            this.LFiltros.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LFiltros.Name = "LFiltros";
            this.LFiltros.Size = new System.Drawing.Size(212, 16);
            this.LFiltros.TabIndex = 37;
            this.LFiltros.Text = "FILTROS DE BUSQUEDA";
            // 
            // BFiltrar
            // 
            this.BFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BFiltrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BFiltrar.Location = new System.Drawing.Point(1212, 61);
            this.BFiltrar.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.BFiltrar.Name = "BFiltrar";
            this.BFiltrar.Size = new System.Drawing.Size(75, 34);
            this.BFiltrar.TabIndex = 3;
            this.BFiltrar.Text = "Filtrar";
            this.BFiltrar.UseVisualStyleBackColor = false;
            this.BFiltrar.Click += new System.EventHandler(this.BFiltrar_Click);
            // 
            // FormHistorialVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1467, 862);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelCliente);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormHistorialVentas";
            this.Text = "FormHistorialVentas";
            this.Load += new System.EventHandler(this.FormHistorialVentas_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.FCardsVentas.ResumeLayout(false);
            this.PCardVentasHoy.ResumeLayout(false);
            this.PCardRecaudacionHoy.ResumeLayout(false);
            this.CardRubroTop.ResumeLayout(false);
            this.PanelCliente.ResumeLayout(false);
            this.PanelCliente.PerformLayout();
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
        protected internal System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.Label LFiltros;
        private System.Windows.Forms.Button BFiltrar;
    }
}