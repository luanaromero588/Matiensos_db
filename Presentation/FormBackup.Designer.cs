namespace Presentation
{
    partial class FormBackup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.LTituloGrilla = new System.Windows.Forms.Label();
            this.PContenido = new System.Windows.Forms.Panel();
            this.PContenedorGrilla = new System.Windows.Forms.Panel();
            this.BRestaurarExterno = new System.Windows.Forms.Button();
            this.BNuevoRespaldo = new System.Windows.Forms.Button();
            this.DGVBackup = new System.Windows.Forms.DataGridView();
            this.colArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTamaño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRestaurarFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLPCards = new System.Windows.Forms.FlowLayoutPanel();
            this.PCard3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LTotalActivos = new System.Windows.Forms.Label();
            this.LCard1 = new System.Windows.Forms.Label();
            this.PCard1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LCategoriasMasV = new System.Windows.Forms.Label();
            this.LCard3 = new System.Windows.Forms.Label();
            this.PCard2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LCategoriasMenosV = new System.Windows.Forms.Label();
            this.LCard2 = new System.Windows.Forms.Label();
            this.PContenido.SuspendLayout();
            this.PContenedorGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBackup)).BeginInit();
            this.FLPCards.SuspendLayout();
            this.PCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.PCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Listado de archivos";
            // 
            // LTituloGrilla
            // 
            this.LTituloGrilla.AutoSize = true;
            this.LTituloGrilla.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloGrilla.Location = new System.Drawing.Point(52, 25);
            this.LTituloGrilla.Name = "LTituloGrilla";
            this.LTituloGrilla.Size = new System.Drawing.Size(181, 25);
            this.LTituloGrilla.TabIndex = 3;
            this.LTituloGrilla.Text = "Gestión Backup";
            // 
            // PContenido
            // 
            this.PContenido.Controls.Add(this.PContenedorGrilla);
            this.PContenido.Controls.Add(this.LTituloGrilla);
            this.PContenido.Controls.Add(this.FLPCards);
            this.PContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenido.Location = new System.Drawing.Point(0, 0);
            this.PContenido.Name = "PContenido";
            this.PContenido.Size = new System.Drawing.Size(1084, 661);
            this.PContenido.TabIndex = 25;
            // 
            // PContenedorGrilla
            // 
            this.PContenedorGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.PContenedorGrilla.BackColor = System.Drawing.Color.White;
            this.PContenedorGrilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PContenedorGrilla.Controls.Add(this.BRestaurarExterno);
            this.PContenedorGrilla.Controls.Add(this.BNuevoRespaldo);
            this.PContenedorGrilla.Controls.Add(this.label3);
            this.PContenedorGrilla.Controls.Add(this.DGVBackup);
            this.PContenedorGrilla.Location = new System.Drawing.Point(52, 170);
            this.PContenedorGrilla.Margin = new System.Windows.Forms.Padding(20);
            this.PContenedorGrilla.Name = "PContenedorGrilla";
            this.PContenedorGrilla.Padding = new System.Windows.Forms.Padding(20);
            this.PContenedorGrilla.Size = new System.Drawing.Size(980, 460);
            this.PContenedorGrilla.TabIndex = 22;
            // 
            // BRestaurarExterno
            // 
            this.BRestaurarExterno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BRestaurarExterno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BRestaurarExterno.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRestaurarExterno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BRestaurarExterno.Location = new System.Drawing.Point(624, 48);
            this.BRestaurarExterno.Name = "BRestaurarExterno";
            this.BRestaurarExterno.Size = new System.Drawing.Size(210, 57);
            this.BRestaurarExterno.TabIndex = 25;
            this.BRestaurarExterno.Text = "+ Restaurar desde \r\nArchivo Externo";
            this.BRestaurarExterno.UseVisualStyleBackColor = false;
            this.BRestaurarExterno.Click += new System.EventHandler(this.BRestaurarExterno_Click);
            // 
            // BNuevoRespaldo
            // 
            this.BNuevoRespaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BNuevoRespaldo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BNuevoRespaldo.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevoRespaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BNuevoRespaldo.Location = new System.Drawing.Point(374, 48);
            this.BNuevoRespaldo.Name = "BNuevoRespaldo";
            this.BNuevoRespaldo.Size = new System.Drawing.Size(210, 57);
            this.BNuevoRespaldo.TabIndex = 24;
            this.BNuevoRespaldo.Text = "+ Generar Nuevo\r\nRespaldo\r\n";
            this.BNuevoRespaldo.UseVisualStyleBackColor = false;
            this.BNuevoRespaldo.Click += new System.EventHandler(this.BNuevoRespaldo_Click);
            // 
            // DGVBackup
            // 
            this.DGVBackup.AllowUserToAddRows = false;
            this.DGVBackup.AllowUserToDeleteRows = false;
            this.DGVBackup.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.DGVBackup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVBackup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVBackup.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGVBackup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVBackup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGVBackup.ColumnHeadersHeight = 29;
            this.DGVBackup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colArchivo,
            this.colFecha,
            this.colTamaño,
            this.colUsuario,
            this.btnRestaurarFila,
            this.btnEliminarFila});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVBackup.DefaultCellStyle = dataGridViewCellStyle7;
            this.DGVBackup.EnableHeadersVisualStyles = false;
            this.DGVBackup.Location = new System.Drawing.Point(20, 140);
            this.DGVBackup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGVBackup.MultiSelect = false;
            this.DGVBackup.Name = "DGVBackup";
            this.DGVBackup.ReadOnly = true;
            this.DGVBackup.RowHeadersVisible = false;
            this.DGVBackup.RowHeadersWidth = 51;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.DGVBackup.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DGVBackup.RowTemplate.Height = 28;
            this.DGVBackup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVBackup.Size = new System.Drawing.Size(940, 286);
            this.DGVBackup.TabIndex = 0;
            this.DGVBackup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVBackup_CellContentClick);
            this.DGVBackup.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVBackup_CellFormatting);
            // 
            // colArchivo
            // 
            this.colArchivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colArchivo.DataPropertyName = "archivo";
            this.colArchivo.FillWeight = 319.797F;
            this.colArchivo.HeaderText = "Archivo";
            this.colArchivo.MinimumWidth = 6;
            this.colArchivo.Name = "colArchivo";
            this.colArchivo.ReadOnly = true;
            this.colArchivo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colArchivo.Width = 90;
            // 
            // colFecha
            // 
            this.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFecha.DataPropertyName = "fecha";
            this.colFecha.FillWeight = 63.36717F;
            this.colFecha.HeaderText = "Fecha de creación";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colTamaño
            // 
            this.colTamaño.DataPropertyName = "tamaño";
            this.colTamaño.FillWeight = 63.36717F;
            this.colTamaño.HeaderText = "Tamaño";
            this.colTamaño.MinimumWidth = 6;
            this.colTamaño.Name = "colTamaño";
            this.colTamaño.ReadOnly = true;
            // 
            // colUsuario
            // 
            this.colUsuario.DataPropertyName = "usuario";
            this.colUsuario.FillWeight = 63.36717F;
            this.colUsuario.HeaderText = "Usuario/Origen";
            this.colUsuario.MinimumWidth = 6;
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            // 
            // btnRestaurarFila
            // 
            this.btnRestaurarFila.DataPropertyName = "btnRestaurarFila";
            this.btnRestaurarFila.FillWeight = 63.36717F;
            this.btnRestaurarFila.HeaderText = "Acciones";
            this.btnRestaurarFila.MinimumWidth = 6;
            this.btnRestaurarFila.Name = "btnRestaurarFila";
            this.btnRestaurarFila.ReadOnly = true;
            this.btnRestaurarFila.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnEliminarFila
            // 
            this.btnEliminarFila.FillWeight = 63.36717F;
            this.btnEliminarFila.HeaderText = "Acciones";
            this.btnEliminarFila.Name = "btnEliminarFila";
            this.btnEliminarFila.ReadOnly = true;
            // 
            // FLPCards
            // 
            this.FLPCards.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FLPCards.Controls.Add(this.PCard3);
            this.FLPCards.Controls.Add(this.PCard1);
            this.FLPCards.Controls.Add(this.PCard2);
            this.FLPCards.Location = new System.Drawing.Point(52, 67);
            this.FLPCards.Name = "FLPCards";
            this.FLPCards.Padding = new System.Windows.Forms.Padding(125, 0, 0, 0);
            this.FLPCards.Size = new System.Drawing.Size(980, 90);
            this.FLPCards.TabIndex = 21;
            this.FLPCards.WrapContents = false;
            // 
            // PCard3
            // 
            this.PCard3.BackColor = System.Drawing.Color.White;
            this.PCard3.Controls.Add(this.pictureBox1);
            this.PCard3.Controls.Add(this.LTotalActivos);
            this.PCard3.Controls.Add(this.LCard1);
            this.PCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCard3.Location = new System.Drawing.Point(125, 0);
            this.PCard3.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.PCard3.Name = "PCard3";
            this.PCard3.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.PCard3.Size = new System.Drawing.Size(230, 85);
            this.PCard3.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Presentation.Properties.Resources.copia_de_respaldo;
            this.pictureBox1.Location = new System.Drawing.Point(167, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // LTotalActivos
            // 
            this.LTotalActivos.AutoSize = true;
            this.LTotalActivos.BackColor = System.Drawing.Color.White;
            this.LTotalActivos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTotalActivos.Location = new System.Drawing.Point(18, 38);
            this.LTotalActivos.Name = "LTotalActivos";
            this.LTotalActivos.Size = new System.Drawing.Size(45, 25);
            this.LTotalActivos.TabIndex = 1;
            this.LTotalActivos.Text = "150";
            // 
            // LCard1
            // 
            this.LCard1.AutoEllipsis = true;
            this.LCard1.AutoSize = true;
            this.LCard1.BackColor = System.Drawing.Color.White;
            this.LCard1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCard1.Location = new System.Drawing.Point(18, 12);
            this.LCard1.Name = "LCard1";
            this.LCard1.Size = new System.Drawing.Size(148, 13);
            this.LCard1.TabIndex = 0;
            this.LCard1.Text = "ÚLTIMA COPIA REALIZADA";
            // 
            // PCard1
            // 
            this.PCard1.BackColor = System.Drawing.Color.White;
            this.PCard1.Controls.Add(this.pictureBox2);
            this.PCard1.Controls.Add(this.LCategoriasMasV);
            this.PCard1.Controls.Add(this.LCard3);
            this.PCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCard1.Location = new System.Drawing.Point(375, 0);
            this.PCard1.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.PCard1.Name = "PCard1";
            this.PCard1.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.PCard1.Size = new System.Drawing.Size(230, 85);
            this.PCard1.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Presentation.Properties.Resources.apoyo;
            this.pictureBox2.Location = new System.Drawing.Point(158, 20);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // LCategoriasMasV
            // 
            this.LCategoriasMasV.AutoSize = true;
            this.LCategoriasMasV.BackColor = System.Drawing.Color.White;
            this.LCategoriasMasV.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCategoriasMasV.Location = new System.Drawing.Point(18, 38);
            this.LCategoriasMasV.Name = "LCategoriasMasV";
            this.LCategoriasMasV.Size = new System.Drawing.Size(23, 25);
            this.LCategoriasMasV.TabIndex = 1;
            this.LCategoriasMasV.Text = "3";
            // 
            // LCard3
            // 
            this.LCard3.AutoEllipsis = true;
            this.LCard3.AutoSize = true;
            this.LCard3.BackColor = System.Drawing.Color.White;
            this.LCard3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCard3.Location = new System.Drawing.Point(18, 12);
            this.LCard3.Name = "LCard3";
            this.LCard3.Size = new System.Drawing.Size(121, 13);
            this.LCard3.TabIndex = 0;
            this.LCard3.Text = "TOTAL DE RESPALDOS";
            // 
            // PCard2
            // 
            this.PCard2.BackColor = System.Drawing.Color.White;
            this.PCard2.Controls.Add(this.pictureBox3);
            this.PCard2.Controls.Add(this.LCategoriasMenosV);
            this.PCard2.Controls.Add(this.LCard2);
            this.PCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCard2.Location = new System.Drawing.Point(625, 0);
            this.PCard2.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.PCard2.Name = "PCard2";
            this.PCard2.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.PCard2.Size = new System.Drawing.Size(230, 85);
            this.PCard2.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Presentation.Properties.Resources.tarjeta_de_memoria;
            this.pictureBox3.Location = new System.Drawing.Point(163, 20);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(38, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // LCategoriasMenosV
            // 
            this.LCategoriasMenosV.AutoSize = true;
            this.LCategoriasMenosV.BackColor = System.Drawing.Color.White;
            this.LCategoriasMenosV.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCategoriasMenosV.Location = new System.Drawing.Point(18, 38);
            this.LCategoriasMenosV.Name = "LCategoriasMenosV";
            this.LCategoriasMenosV.Size = new System.Drawing.Size(23, 25);
            this.LCategoriasMenosV.TabIndex = 1;
            this.LCategoriasMenosV.Text = "3";
            // 
            // LCard2
            // 
            this.LCard2.AutoEllipsis = true;
            this.LCard2.AutoSize = true;
            this.LCard2.BackColor = System.Drawing.Color.White;
            this.LCard2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCard2.Location = new System.Drawing.Point(18, 12);
            this.LCard2.Name = "LCard2";
            this.LCard2.Size = new System.Drawing.Size(119, 13);
            this.LCard2.TabIndex = 0;
            this.LCard2.Text = "ESPACIOS OCUPADOS";
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.PContenido);
            this.Name = "FormBackup";
            this.Text = "FormCategorias";
            this.Load += new System.EventHandler(this.FormBackup_Load);
            this.PContenido.ResumeLayout(false);
            this.PContenido.PerformLayout();
            this.PContenedorGrilla.ResumeLayout(false);
            this.PContenedorGrilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBackup)).EndInit();
            this.FLPCards.ResumeLayout(false);
            this.PCard3.ResumeLayout(false);
            this.PCard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PCard1.ResumeLayout(false);
            this.PCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.PCard2.ResumeLayout(false);
            this.PCard2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LTituloGrilla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel PContenido;
        private System.Windows.Forms.Panel PContenedorGrilla;
        private System.Windows.Forms.DataGridView DGVBackup;
        private System.Windows.Forms.FlowLayoutPanel FLPCards;
        private System.Windows.Forms.Panel PCard3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LTotalActivos;
        private System.Windows.Forms.Label LCard1;
        private System.Windows.Forms.Panel PCard1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LCategoriasMasV;
        private System.Windows.Forms.Label LCard3;
        private System.Windows.Forms.Panel PCard2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label LCategoriasMenosV;
        private System.Windows.Forms.Label LCard2;
        private System.Windows.Forms.Button BNuevoRespaldo;
        private System.Windows.Forms.Button BRestaurarExterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTamaño;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn btnRestaurarFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn btnEliminarFila;
    }
}