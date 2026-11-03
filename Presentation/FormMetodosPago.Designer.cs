namespace Presentation
{
    partial class FormMetodosPago
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMetodosPago));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LTituloGrilla = new System.Windows.Forms.Label();
            this.PContenedorFP = new System.Windows.Forms.Panel();
            this.TLPCards = new System.Windows.Forms.TableLayoutPanel();
            this.PCard2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LCategoriasMenosV = new System.Windows.Forms.Label();
            this.LCard2 = new System.Windows.Forms.Label();
            this.PCard1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LCategoriasMasV = new System.Windows.Forms.Label();
            this.LCard3 = new System.Windows.Forms.Label();
            this.PCard3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LTotalActivos = new System.Windows.Forms.Label();
            this.LCard1 = new System.Windows.Forms.Label();
            this.PContenedorGrilla = new System.Windows.Forms.Panel();
            this.LSubTitle = new System.Windows.Forms.Label();
            this.DGVMetodosPago = new System.Windows.Forms.DataGridView();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditarFila = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEliminarFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BNuevoMP = new System.Windows.Forms.Button();
            this.PContenedorFP.SuspendLayout();
            this.TLPCards.SuspendLayout();
            this.PCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.PCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.PCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PContenedorGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMetodosPago)).BeginInit();
            this.SuspendLayout();
            // 
            // LTituloGrilla
            // 
            this.LTituloGrilla.AutoSize = true;
            this.LTituloGrilla.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloGrilla.Location = new System.Drawing.Point(56, 37);
            this.LTituloGrilla.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloGrilla.Name = "LTituloGrilla";
            this.LTituloGrilla.Size = new System.Drawing.Size(510, 31);
            this.LTituloGrilla.TabIndex = 4;
            this.LTituloGrilla.Text = "GESTIÓN DE MÉTODOS DE PAGO";
            // 
            // PContenedorFP
            // 
            this.PContenedorFP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.PContenedorFP.Controls.Add(this.TLPCards);
            this.PContenedorFP.Controls.Add(this.LTituloGrilla);
            this.PContenedorFP.Controls.Add(this.PContenedorGrilla);
            this.PContenedorFP.Controls.Add(this.BNuevoMP);
            this.PContenedorFP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenedorFP.Location = new System.Drawing.Point(0, 0);
            this.PContenedorFP.Margin = new System.Windows.Forms.Padding(4);
            this.PContenedorFP.Name = "PContenedorFP";
            this.PContenedorFP.Size = new System.Drawing.Size(1445, 814);
            this.PContenedorFP.TabIndex = 6;
            // 
            // TLPCards
            // 
            this.TLPCards.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TLPCards.ColumnCount = 3;
            this.TLPCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TLPCards.Controls.Add(this.PCard2, 2, 0);
            this.TLPCards.Controls.Add(this.PCard1, 1, 0);
            this.TLPCards.Controls.Add(this.PCard3, 0, 0);
            this.TLPCards.Location = new System.Drawing.Point(63, 107);
            this.TLPCards.Margin = new System.Windows.Forms.Padding(4);
            this.TLPCards.Name = "TLPCards";
            this.TLPCards.RowCount = 1;
            this.TLPCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPCards.Size = new System.Drawing.Size(1349, 96);
            this.TLPCards.TabIndex = 28;
            // 
            // PCard2
            // 
            this.PCard2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PCard2.BackColor = System.Drawing.Color.White;
            this.PCard2.Controls.Add(this.pictureBox3);
            this.PCard2.Controls.Add(this.LCategoriasMenosV);
            this.PCard2.Controls.Add(this.LCard2);
            this.PCard2.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCard2.Location = new System.Drawing.Point(903, 0);
            this.PCard2.Margin = new System.Windows.Forms.Padding(0, 0, 27, 0);
            this.PCard2.Name = "PCard2";
            this.PCard2.Padding = new System.Windows.Forms.Padding(21, 15, 21, 15);
            this.PCard2.Size = new System.Drawing.Size(413, 96);
            this.PCard2.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Presentation.Properties.Resources.declive_financiero;
            this.pictureBox3.Location = new System.Drawing.Point(317, 15);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(68, 58);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // LCategoriasMenosV
            // 
            this.LCategoriasMenosV.AutoSize = true;
            this.LCategoriasMenosV.BackColor = System.Drawing.Color.White;
            this.LCategoriasMenosV.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCategoriasMenosV.Location = new System.Drawing.Point(29, 49);
            this.LCategoriasMenosV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LCategoriasMenosV.Name = "LCategoriasMenosV";
            this.LCategoriasMenosV.Size = new System.Drawing.Size(18, 24);
            this.LCategoriasMenosV.TabIndex = 1;
            this.LCategoriasMenosV.Text = "-";
            // 
            // LCard2
            // 
            this.LCard2.AutoEllipsis = true;
            this.LCard2.AutoSize = true;
            this.LCard2.BackColor = System.Drawing.Color.White;
            this.LCard2.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCard2.Location = new System.Drawing.Point(29, 17);
            this.LCard2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LCard2.Name = "LCard2";
            this.LCard2.Size = new System.Drawing.Size(191, 20);
            this.LCard2.TabIndex = 0;
            this.LCard2.Text = "MENOS INGRESOS";
            // 
            // PCard1
            // 
            this.PCard1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PCard1.BackColor = System.Drawing.Color.White;
            this.PCard1.Controls.Add(this.pictureBox2);
            this.PCard1.Controls.Add(this.LCategoriasMasV);
            this.PCard1.Controls.Add(this.LCard3);
            this.PCard1.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCard1.Location = new System.Drawing.Point(454, 0);
            this.PCard1.Margin = new System.Windows.Forms.Padding(0, 0, 27, 0);
            this.PCard1.Name = "PCard1";
            this.PCard1.Padding = new System.Windows.Forms.Padding(21, 15, 21, 15);
            this.PCard1.Size = new System.Drawing.Size(412, 96);
            this.PCard1.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Presentation.Properties.Resources.ingresos;
            this.pictureBox2.Location = new System.Drawing.Point(315, 15);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(68, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // LCategoriasMasV
            // 
            this.LCategoriasMasV.AutoSize = true;
            this.LCategoriasMasV.BackColor = System.Drawing.Color.White;
            this.LCategoriasMasV.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCategoriasMasV.Location = new System.Drawing.Point(29, 49);
            this.LCategoriasMasV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LCategoriasMasV.Name = "LCategoriasMasV";
            this.LCategoriasMasV.Size = new System.Drawing.Size(18, 24);
            this.LCategoriasMasV.TabIndex = 1;
            this.LCategoriasMasV.Text = "-";
            // 
            // LCard3
            // 
            this.LCard3.AutoEllipsis = true;
            this.LCard3.AutoSize = true;
            this.LCard3.BackColor = System.Drawing.Color.White;
            this.LCard3.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCard3.Location = new System.Drawing.Point(29, 17);
            this.LCard3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LCard3.Name = "LCard3";
            this.LCard3.Size = new System.Drawing.Size(163, 20);
            this.LCard3.TabIndex = 0;
            this.LCard3.Text = "MÁS INGRESOS";
            // 
            // PCard3
            // 
            this.PCard3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PCard3.BackColor = System.Drawing.Color.White;
            this.PCard3.Controls.Add(this.pictureBox1);
            this.PCard3.Controls.Add(this.LTotalActivos);
            this.PCard3.Controls.Add(this.LCard1);
            this.PCard3.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCard3.Location = new System.Drawing.Point(5, 0);
            this.PCard3.Margin = new System.Windows.Forms.Padding(0, 0, 27, 0);
            this.PCard3.Name = "PCard3";
            this.PCard3.Padding = new System.Windows.Forms.Padding(21, 15, 21, 15);
            this.PCard3.Size = new System.Drawing.Size(412, 96);
            this.PCard3.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Presentation.Properties.Resources.categorias;
            this.pictureBox1.Location = new System.Drawing.Point(345, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // LTotalActivos
            // 
            this.LTotalActivos.AutoSize = true;
            this.LTotalActivos.BackColor = System.Drawing.Color.White;
            this.LTotalActivos.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTotalActivos.Location = new System.Drawing.Point(29, 49);
            this.LTotalActivos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTotalActivos.Name = "LTotalActivos";
            this.LTotalActivos.Size = new System.Drawing.Size(18, 24);
            this.LTotalActivos.TabIndex = 1;
            this.LTotalActivos.Text = "-";
            // 
            // LCard1
            // 
            this.LCard1.AutoEllipsis = true;
            this.LCard1.AutoSize = true;
            this.LCard1.BackColor = System.Drawing.Color.White;
            this.LCard1.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCard1.Location = new System.Drawing.Point(29, 17);
            this.LCard1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LCard1.Name = "LCard1";
            this.LCard1.Size = new System.Drawing.Size(191, 20);
            this.LCard1.TabIndex = 0;
            this.LCard1.Text = "TOTAL  METODOS";
            // 
            // PContenedorGrilla
            // 
            this.PContenedorGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PContenedorGrilla.BackColor = System.Drawing.Color.White;
            this.PContenedorGrilla.Controls.Add(this.LSubTitle);
            this.PContenedorGrilla.Controls.Add(this.DGVMetodosPago);
            this.PContenedorGrilla.Location = new System.Drawing.Point(63, 228);
            this.PContenedorGrilla.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PContenedorGrilla.Name = "PContenedorGrilla";
            this.PContenedorGrilla.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.PContenedorGrilla.Size = new System.Drawing.Size(1317, 539);
            this.PContenedorGrilla.TabIndex = 6;
            // 
            // LSubTitle
            // 
            this.LSubTitle.AutoSize = true;
            this.LSubTitle.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSubTitle.Location = new System.Drawing.Point(36, 39);
            this.LSubTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LSubTitle.Name = "LSubTitle";
            this.LSubTitle.Size = new System.Drawing.Size(382, 31);
            this.LSubTitle.TabIndex = 26;
            this.LSubTitle.Text = "Listado de Métodos de Pago";
            // 
            // DGVMetodosPago
            // 
            this.DGVMetodosPago.AllowUserToAddRows = false;
            this.DGVMetodosPago.AllowUserToDeleteRows = false;
            this.DGVMetodosPago.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.DGVMetodosPago.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVMetodosPago.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVMetodosPago.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGVMetodosPago.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVMetodosPago.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVMetodosPago.ColumnHeadersHeight = 29;
            this.DGVMetodosPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombre,
            this.coldescripcion,
            this.colEstado,
            this.colEditarFila,
            this.colEliminarFila});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVMetodosPago.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGVMetodosPago.EnableHeadersVisualStyles = false;
            this.DGVMetodosPago.Location = new System.Drawing.Point(43, 118);
            this.DGVMetodosPago.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DGVMetodosPago.MultiSelect = false;
            this.DGVMetodosPago.Name = "DGVMetodosPago";
            this.DGVMetodosPago.ReadOnly = true;
            this.DGVMetodosPago.RowHeadersVisible = false;
            this.DGVMetodosPago.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.DGVMetodosPago.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGVMetodosPago.RowTemplate.Height = 28;
            this.DGVMetodosPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVMetodosPago.Size = new System.Drawing.Size(1232, 336);
            this.DGVMetodosPago.TabIndex = 0;
            this.DGVMetodosPago.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMetodosPago_CellContentClick);
            this.DGVMetodosPago.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVMetodosPago_CellFormatting);
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 6;
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 308;
            // 
            // coldescripcion
            // 
            this.coldescripcion.DataPropertyName = "Descripcion";
            this.coldescripcion.HeaderText = "Descripción";
            this.coldescripcion.MinimumWidth = 6;
            this.coldescripcion.Name = "coldescripcion";
            this.coldescripcion.ReadOnly = true;
            this.coldescripcion.Width = 308;
            // 
            // colEstado
            // 
            this.colEstado.DataPropertyName = "Activo";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 6;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 307;
            // 
            // colEditarFila
            // 
            this.colEditarFila.DataPropertyName = "btnEditarFila";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Magenta;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Transparent;
            this.colEditarFila.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEditarFila.HeaderText = "Acción";
            this.colEditarFila.MinimumWidth = 6;
            this.colEditarFila.Name = "colEditarFila";
            this.colEditarFila.ReadOnly = true;
            this.colEditarFila.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEditarFila.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEditarFila.Visible = false;
            this.colEditarFila.Width = 125;
            // 
            // colEliminarFila
            // 
            this.colEliminarFila.DataPropertyName = "btnEliminarFila";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Fuchsia;
            this.colEliminarFila.DefaultCellStyle = dataGridViewCellStyle4;
            this.colEliminarFila.HeaderText = "Acción";
            this.colEliminarFila.MinimumWidth = 6;
            this.colEliminarFila.Name = "colEliminarFila";
            this.colEliminarFila.ReadOnly = true;
            this.colEliminarFila.Width = 308;
            // 
            // BNuevoMP
            // 
            this.BNuevoMP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BNuevoMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BNuevoMP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BNuevoMP.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevoMP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BNuevoMP.Location = new System.Drawing.Point(1132, 31);
            this.BNuevoMP.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.BNuevoMP.Name = "BNuevoMP";
            this.BNuevoMP.Size = new System.Drawing.Size(248, 49);
            this.BNuevoMP.TabIndex = 1;
            this.BNuevoMP.Text = "+ Nuevo Método";
            this.BNuevoMP.UseVisualStyleBackColor = false;
            this.BNuevoMP.Click += new System.EventHandler(this.BNuevoMP_Click);
            // 
            // FormMetodosPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 814);
            this.Controls.Add(this.PContenedorFP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMetodosPago";
            this.Text = "FormMetodosPago";
            this.Load += new System.EventHandler(this.FormMetodosPago_Load);
            this.PContenedorFP.ResumeLayout(false);
            this.PContenedorFP.PerformLayout();
            this.TLPCards.ResumeLayout(false);
            this.PCard2.ResumeLayout(false);
            this.PCard2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.PCard1.ResumeLayout(false);
            this.PCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.PCard3.ResumeLayout(false);
            this.PCard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PContenedorGrilla.ResumeLayout(false);
            this.PContenedorGrilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMetodosPago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LTituloGrilla;
        private System.Windows.Forms.Panel PContenedorFP;
        private System.Windows.Forms.Panel PContenedorGrilla;
        private System.Windows.Forms.DataGridView DGVMetodosPago;
        private System.Windows.Forms.Button BNuevoMP;
        private System.Windows.Forms.Label LSubTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewImageColumn colEditarFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEliminarFila;
        private System.Windows.Forms.TableLayoutPanel TLPCards;
        private System.Windows.Forms.Panel PCard2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label LCategoriasMenosV;
        private System.Windows.Forms.Label LCard2;
        private System.Windows.Forms.Panel PCard1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LCategoriasMasV;
        private System.Windows.Forms.Label LCard3;
        private System.Windows.Forms.Panel PCard3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LTotalActivos;
        private System.Windows.Forms.Label LCard1;
    }
}