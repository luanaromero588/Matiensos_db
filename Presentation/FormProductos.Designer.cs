namespace Presentation
{
    partial class FormProductos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PContenedorGrilla = new System.Windows.Forms.Panel();
            this.BNuevoProducto = new System.Windows.Forms.Button();
            this.LPaginas = new System.Windows.Forms.Label();
            this.BSiguiente = new System.Windows.Forms.Button();
            this.BAnterior = new System.Windows.Forms.Button();
            this.LTituloListado = new System.Windows.Forms.Label();
            this.BBuscar = new System.Windows.Forms.Button();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.DGVProductos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Acciones2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTituloGrilla = new System.Windows.Forms.Label();
            this.PCardTotalProductos = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LTotalProductos = new System.Windows.Forms.Label();
            this.LCard1 = new System.Windows.Forms.Label();
            this.PCardSinStock = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LProdSinStock = new System.Windows.Forms.Label();
            this.LCard2 = new System.Windows.Forms.Label();
            this.PCardStockCritico = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LProdStockCritico = new System.Windows.Forms.Label();
            this.LCard3 = new System.Windows.Forms.Label();
            this.PCardValorInventario = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.LProdValorInventario = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TLPCards = new System.Windows.Forms.TableLayoutPanel();
            this.PContenedorGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductos)).BeginInit();
            this.PCardTotalProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PCardSinStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.PCardStockCritico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.PCardValorInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.TLPCards.SuspendLayout();
            this.SuspendLayout();
            // 
            // PContenedorGrilla
            // 
            this.PContenedorGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PContenedorGrilla.BackColor = System.Drawing.Color.White;
            this.PContenedorGrilla.Controls.Add(this.BNuevoProducto);
            this.PContenedorGrilla.Controls.Add(this.LPaginas);
            this.PContenedorGrilla.Controls.Add(this.BSiguiente);
            this.PContenedorGrilla.Controls.Add(this.BAnterior);
            this.PContenedorGrilla.Controls.Add(this.LTituloListado);
            this.PContenedorGrilla.Controls.Add(this.BBuscar);
            this.PContenedorGrilla.Controls.Add(this.TBBuscar);
            this.PContenedorGrilla.Controls.Add(this.DGVProductos);
            this.PContenedorGrilla.Location = new System.Drawing.Point(69, 230);
            this.PContenedorGrilla.Margin = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.PContenedorGrilla.Name = "PContenedorGrilla";
            this.PContenedorGrilla.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.PContenedorGrilla.Size = new System.Drawing.Size(1307, 532);
            this.PContenedorGrilla.TabIndex = 25;
            // 
            // BNuevoProducto
            // 
            this.BNuevoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BNuevoProducto.AutoSize = true;
            this.BNuevoProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BNuevoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevoProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BNuevoProducto.Location = new System.Drawing.Point(1097, 29);
            this.BNuevoProducto.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BNuevoProducto.Name = "BNuevoProducto";
            this.BNuevoProducto.Size = new System.Drawing.Size(186, 37);
            this.BNuevoProducto.TabIndex = 1;
            this.BNuevoProducto.Text = "+ Nuevo Producto";
            this.BNuevoProducto.UseVisualStyleBackColor = false;
            // 
            // LPaginas
            // 
            this.LPaginas.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LPaginas.AutoSize = true;
            this.LPaginas.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPaginas.Location = new System.Drawing.Point(611, 491);
            this.LPaginas.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LPaginas.Name = "LPaginas";
            this.LPaginas.Size = new System.Drawing.Size(92, 16);
            this.LPaginas.TabIndex = 28;
            this.LPaginas.Text = "Pagina 1 de 3";
            // 
            // BSiguiente
            // 
            this.BSiguiente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSiguiente.ForeColor = System.Drawing.Color.White;
            this.BSiguiente.Location = new System.Drawing.Point(738, 482);
            this.BSiguiente.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.BSiguiente.Name = "BSiguiente";
            this.BSiguiente.Size = new System.Drawing.Size(119, 32);
            this.BSiguiente.TabIndex = 27;
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
            this.BAnterior.Location = new System.Drawing.Point(458, 482);
            this.BAnterior.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.BAnterior.Name = "BAnterior";
            this.BAnterior.Size = new System.Drawing.Size(119, 32);
            this.BAnterior.TabIndex = 26;
            this.BAnterior.Text = "< Anterior";
            this.BAnterior.UseVisualStyleBackColor = false;
            this.BAnterior.Click += new System.EventHandler(this.BAnterior_Click);
            // 
            // LTituloListado
            // 
            this.LTituloListado.AutoSize = true;
            this.LTituloListado.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloListado.Location = new System.Drawing.Point(48, 71);
            this.LTituloListado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloListado.Name = "LTituloListado";
            this.LTituloListado.Size = new System.Drawing.Size(235, 25);
            this.LTituloListado.TabIndex = 25;
            this.LTituloListado.Text = "Listado de productos";
            // 
            // BBuscar
            // 
            this.BBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BBuscar.Location = new System.Drawing.Point(1179, 113);
            this.BBuscar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(100, 27);
            this.BBuscar.TabIndex = 3;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = false;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            // 
            // TBBuscar
            // 
            this.TBBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TBBuscar.BackColor = System.Drawing.Color.White;
            this.TBBuscar.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TBBuscar.Location = new System.Drawing.Point(771, 115);
            this.TBBuscar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(399, 25);
            this.TBBuscar.TabIndex = 2;
            this.TBBuscar.Tag = "Buscar Producto";
            // 
            // DGVProductos
            // 
            this.DGVProductos.AllowUserToAddRows = false;
            this.DGVProductos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle41.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle41.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle41.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.DGVProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle41;
            this.DGVProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVProductos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGVProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle42.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle42;
            this.DGVProductos.ColumnHeadersHeight = 29;
            this.DGVProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column10,
            this.Column7,
            this.Column4,
            this.Acciones2});
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle43.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle43.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle43.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle43.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVProductos.DefaultCellStyle = dataGridViewCellStyle43;
            this.DGVProductos.EnableHeadersVisualStyles = false;
            this.DGVProductos.Location = new System.Drawing.Point(27, 183);
            this.DGVProductos.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DGVProductos.MultiSelect = false;
            this.DGVProductos.Name = "DGVProductos";
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle44.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle44;
            this.DGVProductos.RowHeadersVisible = false;
            this.DGVProductos.RowHeadersWidth = 51;
            dataGridViewCellStyle45.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle45.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle45.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle45.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.DGVProductos.RowsDefaultCellStyle = dataGridViewCellStyle45;
            this.DGVProductos.RowTemplate.Height = 28;
            this.DGVProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductos.Size = new System.Drawing.Size(1256, 290);
            this.DGVProductos.TabIndex = 4;
            this.DGVProductos.TabStop = false;
            this.DGVProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVProductos_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Codigo";
            this.Column1.HeaderText = "Código";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 179;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "nombre/descripcion";
            this.Column2.HeaderText = "Nombre/Descripcion";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 180;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "categoria";
            this.Column3.HeaderText = "Categoría";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 179;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "precio";
            this.Column10.HeaderText = "Precio";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Width = 179;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "stock";
            this.Column7.HeaderText = "Stock";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 179;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Acciones";
            this.Column4.HeaderText = "Acciones";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 180;
            // 
            // Acciones2
            // 
            this.Acciones2.HeaderText = "Acciones";
            this.Acciones2.Name = "Acciones2";
            this.Acciones2.Width = 179;
            // 
            // LTituloGrilla
            // 
            this.LTituloGrilla.AutoSize = true;
            this.LTituloGrilla.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloGrilla.Location = new System.Drawing.Point(64, 48);
            this.LTituloGrilla.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloGrilla.Name = "LTituloGrilla";
            this.LTituloGrilla.Size = new System.Drawing.Size(237, 25);
            this.LTituloGrilla.TabIndex = 23;
            this.LTituloGrilla.Text = "Gestión de productos";
            // 
            // PCardTotalProductos
            // 
            this.PCardTotalProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PCardTotalProductos.BackColor = System.Drawing.Color.White;
            this.PCardTotalProductos.Controls.Add(this.pictureBox1);
            this.PCardTotalProductos.Controls.Add(this.LTotalProductos);
            this.PCardTotalProductos.Controls.Add(this.LCard1);
            this.PCardTotalProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCardTotalProductos.Location = new System.Drawing.Point(0, 0);
            this.PCardTotalProductos.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.PCardTotalProductos.Name = "PCardTotalProductos";
            this.PCardTotalProductos.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.PCardTotalProductos.Size = new System.Drawing.Size(312, 86);
            this.PCardTotalProductos.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Presentation.Properties.Resources.caja;
            this.pictureBox1.Location = new System.Drawing.Point(245, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // LTotalProductos
            // 
            this.LTotalProductos.BackColor = System.Drawing.Color.White;
            this.LTotalProductos.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTotalProductos.Location = new System.Drawing.Point(24, 47);
            this.LTotalProductos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTotalProductos.Name = "LTotalProductos";
            this.LTotalProductos.Size = new System.Drawing.Size(198, 25);
            this.LTotalProductos.TabIndex = 1;
            this.LTotalProductos.Text = "-";
            // 
            // LCard1
            // 
            this.LCard1.AutoEllipsis = true;
            this.LCard1.AutoSize = true;
            this.LCard1.BackColor = System.Drawing.Color.White;
            this.LCard1.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCard1.Location = new System.Drawing.Point(24, 15);
            this.LCard1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LCard1.Name = "LCard1";
            this.LCard1.Size = new System.Drawing.Size(164, 16);
            this.LCard1.TabIndex = 0;
            this.LCard1.Text = "TOTAL PRODUCTOS";
            // 
            // PCardSinStock
            // 
            this.PCardSinStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PCardSinStock.BackColor = System.Drawing.Color.White;
            this.PCardSinStock.Controls.Add(this.pictureBox2);
            this.PCardSinStock.Controls.Add(this.LProdSinStock);
            this.PCardSinStock.Controls.Add(this.LCard2);
            this.PCardSinStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCardSinStock.Location = new System.Drawing.Point(326, 0);
            this.PCardSinStock.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.PCardSinStock.Name = "PCardSinStock";
            this.PCardSinStock.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.PCardSinStock.Size = new System.Drawing.Size(312, 86);
            this.PCardSinStock.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Presentation.Properties.Resources.carrito_vacio;
            this.pictureBox2.Location = new System.Drawing.Point(245, 25);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 47);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // LProdSinStock
            // 
            this.LProdSinStock.BackColor = System.Drawing.Color.White;
            this.LProdSinStock.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProdSinStock.Location = new System.Drawing.Point(24, 47);
            this.LProdSinStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LProdSinStock.Name = "LProdSinStock";
            this.LProdSinStock.Size = new System.Drawing.Size(176, 25);
            this.LProdSinStock.TabIndex = 1;
            this.LProdSinStock.Text = "-";
            // 
            // LCard2
            // 
            this.LCard2.AutoEllipsis = true;
            this.LCard2.AutoSize = true;
            this.LCard2.BackColor = System.Drawing.Color.White;
            this.LCard2.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCard2.Location = new System.Drawing.Point(24, 15);
            this.LCard2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LCard2.Name = "LCard2";
            this.LCard2.Size = new System.Drawing.Size(93, 16);
            this.LCard2.TabIndex = 0;
            this.LCard2.Text = "SIN STOCK";
            // 
            // PCardStockCritico
            // 
            this.PCardStockCritico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PCardStockCritico.BackColor = System.Drawing.Color.White;
            this.PCardStockCritico.Controls.Add(this.pictureBox3);
            this.PCardStockCritico.Controls.Add(this.LProdStockCritico);
            this.PCardStockCritico.Controls.Add(this.LCard3);
            this.PCardStockCritico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCardStockCritico.Location = new System.Drawing.Point(652, 0);
            this.PCardStockCritico.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.PCardStockCritico.Name = "PCardStockCritico";
            this.PCardStockCritico.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.PCardStockCritico.Size = new System.Drawing.Size(312, 86);
            this.PCardStockCritico.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Presentation.Properties.Resources.alerta;
            this.pictureBox3.Location = new System.Drawing.Point(245, 25);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(51, 47);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // LProdStockCritico
            // 
            this.LProdStockCritico.BackColor = System.Drawing.Color.White;
            this.LProdStockCritico.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProdStockCritico.Location = new System.Drawing.Point(24, 47);
            this.LProdStockCritico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LProdStockCritico.Name = "LProdStockCritico";
            this.LProdStockCritico.Size = new System.Drawing.Size(176, 25);
            this.LProdStockCritico.TabIndex = 1;
            this.LProdStockCritico.Text = "-";
            // 
            // LCard3
            // 
            this.LCard3.AutoEllipsis = true;
            this.LCard3.AutoSize = true;
            this.LCard3.BackColor = System.Drawing.Color.White;
            this.LCard3.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCard3.Location = new System.Drawing.Point(24, 15);
            this.LCard3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LCard3.Name = "LCard3";
            this.LCard3.Size = new System.Drawing.Size(133, 16);
            this.LCard3.TabIndex = 0;
            this.LCard3.Text = "STOCK CRÍTICO";
            // 
            // PCardValorInventario
            // 
            this.PCardValorInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PCardValorInventario.BackColor = System.Drawing.Color.White;
            this.PCardValorInventario.Controls.Add(this.label2);
            this.PCardValorInventario.Controls.Add(this.pictureBox4);
            this.PCardValorInventario.Controls.Add(this.LProdValorInventario);
            this.PCardValorInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCardValorInventario.Location = new System.Drawing.Point(978, 0);
            this.PCardValorInventario.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.PCardValorInventario.Name = "PCardValorInventario";
            this.PCardValorInventario.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.PCardValorInventario.Size = new System.Drawing.Size(315, 86);
            this.PCardValorInventario.TabIndex = 4;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Presentation.Properties.Resources.ahorrar_dinero;
            this.pictureBox4.Location = new System.Drawing.Point(248, 25);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(51, 47);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // LProdValorInventario
            // 
            this.LProdValorInventario.BackColor = System.Drawing.Color.White;
            this.LProdValorInventario.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProdValorInventario.Location = new System.Drawing.Point(24, 47);
            this.LProdValorInventario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LProdValorInventario.Name = "LProdValorInventario";
            this.LProdValorInventario.Size = new System.Drawing.Size(187, 25);
            this.LProdValorInventario.TabIndex = 1;
            this.LProdValorInventario.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "VALOR DEL INVENTARIO";
            // 
            // TLPCards
            // 
            this.TLPCards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TLPCards.ColumnCount = 4;
            this.TLPCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPCards.Controls.Add(this.PCardValorInventario, 3, 0);
            this.TLPCards.Controls.Add(this.PCardSinStock, 1, 0);
            this.TLPCards.Controls.Add(this.PCardStockCritico, 2, 0);
            this.TLPCards.Controls.Add(this.PCardTotalProductos, 0, 0);
            this.TLPCards.Location = new System.Drawing.Point(69, 99);
            this.TLPCards.Name = "TLPCards";
            this.TLPCards.RowCount = 1;
            this.TLPCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPCards.Size = new System.Drawing.Size(1307, 95);
            this.TLPCards.TabIndex = 26;
            // 
            // FormProductos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1445, 814);
            this.Controls.Add(this.TLPCards);
            this.Controls.Add(this.PContenedorGrilla);
            this.Controls.Add(this.LTituloGrilla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormProductos";
            this.Text = "FormProductos";
            this.Load += new System.EventHandler(this.FormProductos_Load);
            this.PContenedorGrilla.ResumeLayout(false);
            this.PContenedorGrilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductos)).EndInit();
            this.PCardTotalProductos.ResumeLayout(false);
            this.PCardTotalProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PCardSinStock.ResumeLayout(false);
            this.PCardSinStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.PCardStockCritico.ResumeLayout(false);
            this.PCardStockCritico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.PCardValorInventario.ResumeLayout(false);
            this.PCardValorInventario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.TLPCards.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PContenedorGrilla;
        private System.Windows.Forms.Button BNuevoProducto;
        private System.Windows.Forms.Label LPaginas;
        private System.Windows.Forms.Button BSiguiente;
        private System.Windows.Forms.Button BAnterior;
        private System.Windows.Forms.Label LTituloListado;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.DataGridView DGVProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Acciones2;
        private System.Windows.Forms.Label LTituloGrilla;
        private System.Windows.Forms.Panel PCardTotalProductos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LTotalProductos;
        private System.Windows.Forms.Label LCard1;
        private System.Windows.Forms.Panel PCardSinStock;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LProdSinStock;
        private System.Windows.Forms.Label LCard2;
        private System.Windows.Forms.Panel PCardStockCritico;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label LProdStockCritico;
        private System.Windows.Forms.Label LCard3;
        private System.Windows.Forms.Panel PCardValorInventario;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label LProdValorInventario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel TLPCards;
    }
}