namespace Presentation
{
    partial class FormCategorias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.LTituloGrilla = new System.Windows.Forms.Label();
            this.PContenido = new System.Windows.Forms.Panel();
            this.BNuevaCategoria = new System.Windows.Forms.Button();
            this.PContenedorGrilla = new System.Windows.Forms.Panel();
            this.DGVCategorias = new System.Windows.Forms.DataGridView();
            this.FLPCards = new System.Windows.Forms.FlowLayoutPanel();
            this.PCard3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LTotalActivos = new System.Windows.Forms.Label();
            this.LCard1 = new System.Windows.Forms.Label();
            this.PCard1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LVendedoresActivos = new System.Windows.Forms.Label();
            this.LCard3 = new System.Windows.Forms.Label();
            this.PCard2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LAdminsActivos = new System.Windows.Forms.Label();
            this.LCard2 = new System.Windows.Forms.Label();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditarFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PContenido.SuspendLayout();
            this.PContenedorGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCategorias)).BeginInit();
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
            this.label3.Size = new System.Drawing.Size(240, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Listado de categorías";
            // 
            // LTituloGrilla
            // 
            this.LTituloGrilla.AutoSize = true;
            this.LTituloGrilla.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloGrilla.Location = new System.Drawing.Point(52, 25);
            this.LTituloGrilla.Name = "LTituloGrilla";
            this.LTituloGrilla.Size = new System.Drawing.Size(242, 25);
            this.LTituloGrilla.TabIndex = 3;
            this.LTituloGrilla.Text = "Gestión de categorías";
            // 
            // PContenido
            // 
            this.PContenido.Controls.Add(this.BNuevaCategoria);
            this.PContenido.Controls.Add(this.PContenedorGrilla);
            this.PContenido.Controls.Add(this.LTituloGrilla);
            this.PContenido.Controls.Add(this.FLPCards);
            this.PContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenido.Location = new System.Drawing.Point(0, 0);
            this.PContenido.Name = "PContenido";
            this.PContenido.Size = new System.Drawing.Size(1084, 661);
            this.PContenido.TabIndex = 25;
            // 
            // BNuevaCategoria
            // 
            this.BNuevaCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BNuevaCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BNuevaCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BNuevaCategoria.Location = new System.Drawing.Point(875, 25);
            this.BNuevaCategoria.Name = "BNuevaCategoria";
            this.BNuevaCategoria.Size = new System.Drawing.Size(115, 32);
            this.BNuevaCategoria.TabIndex = 24;
            this.BNuevaCategoria.Text = "+ Nueva Categoría";
            this.BNuevaCategoria.UseVisualStyleBackColor = false;
            this.BNuevaCategoria.Click += new System.EventHandler(this.BNuevacategoria_Click);
            // 
            // PContenedorGrilla
            // 
            this.PContenedorGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.PContenedorGrilla.BackColor = System.Drawing.Color.White;
            this.PContenedorGrilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PContenedorGrilla.Controls.Add(this.label3);
            this.PContenedorGrilla.Controls.Add(this.DGVCategorias);
            this.PContenedorGrilla.Location = new System.Drawing.Point(52, 170);
            this.PContenedorGrilla.Margin = new System.Windows.Forms.Padding(20);
            this.PContenedorGrilla.Name = "PContenedorGrilla";
            this.PContenedorGrilla.Padding = new System.Windows.Forms.Padding(20);
            this.PContenedorGrilla.Size = new System.Drawing.Size(980, 460);
            this.PContenedorGrilla.TabIndex = 22;
            // 
            // DGVCategorias
            // 
            this.DGVCategorias.AllowUserToAddRows = false;
            this.DGVCategorias.AllowUserToDeleteRows = false;
            this.DGVCategorias.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.DGVCategorias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCategorias.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGVCategorias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVCategorias.ColumnHeadersHeight = 29;
            this.DGVCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombre,
            this.colDescripcion,
            this.colProductos,
            this.colStockTotal,
            this.colEstado,
            this.btnEditarFila,
            this.btnEliminarFila});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVCategorias.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVCategorias.EnableHeadersVisualStyles = false;
            this.DGVCategorias.Location = new System.Drawing.Point(20, 140);
            this.DGVCategorias.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGVCategorias.MultiSelect = false;
            this.DGVCategorias.Name = "DGVCategorias";
            this.DGVCategorias.ReadOnly = true;
            this.DGVCategorias.RowHeadersVisible = false;
            this.DGVCategorias.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.DGVCategorias.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVCategorias.RowTemplate.Height = 28;
            this.DGVCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCategorias.Size = new System.Drawing.Size(940, 286);
            this.DGVCategorias.TabIndex = 0;
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
            this.pictureBox1.Image = global::Presentation.Properties.Resources.categorias;
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
            this.LCard1.Size = new System.Drawing.Size(112, 13);
            this.LCard1.TabIndex = 0;
            this.LCard1.Text = "TOTAL  CATEGORÍAS";
            // 
            // PCard1
            // 
            this.PCard1.BackColor = System.Drawing.Color.White;
            this.PCard1.Controls.Add(this.pictureBox2);
            this.PCard1.Controls.Add(this.LVendedoresActivos);
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
            this.pictureBox2.Image = global::Presentation.Properties.Resources.ingresos;
            this.pictureBox2.Location = new System.Drawing.Point(158, 20);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // LVendedoresActivos
            // 
            this.LVendedoresActivos.AutoSize = true;
            this.LVendedoresActivos.BackColor = System.Drawing.Color.White;
            this.LVendedoresActivos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LVendedoresActivos.Location = new System.Drawing.Point(18, 38);
            this.LVendedoresActivos.Name = "LVendedoresActivos";
            this.LVendedoresActivos.Size = new System.Drawing.Size(23, 25);
            this.LVendedoresActivos.TabIndex = 1;
            this.LVendedoresActivos.Text = "3";
            // 
            // LCard3
            // 
            this.LCard3.AutoEllipsis = true;
            this.LCard3.AutoSize = true;
            this.LCard3.BackColor = System.Drawing.Color.White;
            this.LCard3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCard3.Location = new System.Drawing.Point(18, 12);
            this.LCard3.Name = "LCard3";
            this.LCard3.Size = new System.Drawing.Size(106, 13);
            this.LCard3.TabIndex = 0;
            this.LCard3.Text = "MÁS VENDIDADAS";
            // 
            // PCard2
            // 
            this.PCard2.BackColor = System.Drawing.Color.White;
            this.PCard2.Controls.Add(this.pictureBox3);
            this.PCard2.Controls.Add(this.LAdminsActivos);
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
            this.pictureBox3.Image = global::Presentation.Properties.Resources.declive_financiero;
            this.pictureBox3.Location = new System.Drawing.Point(163, 20);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(38, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // LAdminsActivos
            // 
            this.LAdminsActivos.AutoSize = true;
            this.LAdminsActivos.BackColor = System.Drawing.Color.White;
            this.LAdminsActivos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAdminsActivos.Location = new System.Drawing.Point(18, 38);
            this.LAdminsActivos.Name = "LAdminsActivos";
            this.LAdminsActivos.Size = new System.Drawing.Size(23, 25);
            this.LAdminsActivos.TabIndex = 1;
            this.LAdminsActivos.Text = "3";
            // 
            // LCard2
            // 
            this.LCard2.AutoEllipsis = true;
            this.LCard2.AutoSize = true;
            this.LCard2.BackColor = System.Drawing.Color.White;
            this.LCard2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCard2.Location = new System.Drawing.Point(18, 12);
            this.LCard2.Name = "LCard2";
            this.LCard2.Size = new System.Drawing.Size(105, 13);
            this.LCard2.TabIndex = 0;
            this.LCard2.Text = "MENOS VENDIDAS";
            // 
            // colNombre
            // 
            this.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colNombre.DataPropertyName = "nombre";
            this.colNombre.FillWeight = 319.797F;
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 6;
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colNombre.Width = 90;
            // 
            // colDescripcion
            // 
            this.colDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescripcion.DataPropertyName = "descripcion";
            this.colDescripcion.FillWeight = 63.36717F;
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // colProductos
            // 
            this.colProductos.DataPropertyName = "CantidadProductos";
            this.colProductos.FillWeight = 63.36717F;
            this.colProductos.HeaderText = "Productos";
            this.colProductos.MinimumWidth = 6;
            this.colProductos.Name = "colProductos";
            this.colProductos.ReadOnly = true;
            // 
            // colStockTotal
            // 
            this.colStockTotal.DataPropertyName = "stocktotal";
            this.colStockTotal.FillWeight = 63.36717F;
            this.colStockTotal.HeaderText = "Stock Total";
            this.colStockTotal.MinimumWidth = 6;
            this.colStockTotal.Name = "colStockTotal";
            this.colStockTotal.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.DataPropertyName = "estado";
            this.colEstado.FillWeight = 63.36717F;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 6;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // btnEditarFila
            // 
            this.btnEditarFila.DataPropertyName = "btnEditarFila";
            this.btnEditarFila.FillWeight = 63.36717F;
            this.btnEditarFila.HeaderText = "Acciones";
            this.btnEditarFila.MinimumWidth = 6;
            this.btnEditarFila.Name = "btnEditarFila";
            this.btnEditarFila.ReadOnly = true;
            // 
            // btnEliminarFila
            // 
            this.btnEliminarFila.FillWeight = 63.36717F;
            this.btnEliminarFila.HeaderText = "Acciones";
            this.btnEliminarFila.Name = "btnEliminarFila";
            this.btnEliminarFila.ReadOnly = true;
            // 
            // FormCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.PContenido);
            this.Name = "FormCategorias";
            this.Text = "FormCategorias";
            this.Load += new System.EventHandler(this.FormCategorias_Load);
            this.PContenido.ResumeLayout(false);
            this.PContenido.PerformLayout();
            this.PContenedorGrilla.ResumeLayout(false);
            this.PContenedorGrilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCategorias)).EndInit();
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
        private System.Windows.Forms.DataGridView DGVCategorias;
        private System.Windows.Forms.FlowLayoutPanel FLPCards;
        private System.Windows.Forms.Panel PCard3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LTotalActivos;
        private System.Windows.Forms.Label LCard1;
        private System.Windows.Forms.Panel PCard1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LVendedoresActivos;
        private System.Windows.Forms.Label LCard3;
        private System.Windows.Forms.Panel PCard2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label LAdminsActivos;
        private System.Windows.Forms.Label LCard2;
        private System.Windows.Forms.Button BNuevaCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn btnEditarFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn btnEliminarFila;
    }
}