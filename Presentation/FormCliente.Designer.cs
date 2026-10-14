namespace Presentation
{
    partial class FormCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGVCliente = new System.Windows.Forms.DataGridView();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditarFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PContenido = new System.Windows.Forms.Panel();
            this.PContenedorGrilla = new System.Windows.Forms.Panel();
            this.LPaginas = new System.Windows.Forms.Label();
            this.BSiguiente = new System.Windows.Forms.Button();
            this.BAnterior = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BBuscar = new System.Windows.Forms.Button();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.LTituloGrilla = new System.Windows.Forms.Label();
            this.FLPCards = new System.Windows.Forms.FlowLayoutPanel();
            this.PCard3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LTotalActivos = new System.Windows.Forms.Label();
            this.LCard1 = new System.Windows.Forms.Label();
            this.PCard1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LClientesNuevos = new System.Windows.Forms.Label();
            this.LCard3 = new System.Windows.Forms.Label();
            this.PCard2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LClientesTop = new System.Windows.Forms.Label();
            this.LCard2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCliente)).BeginInit();
            this.PContenido.SuspendLayout();
            this.PContenedorGrilla.SuspendLayout();
            this.FLPCards.SuspendLayout();
            this.PCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.PCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVCliente
            // 
            this.DGVCliente.AllowDrop = true;
            this.DGVCliente.AllowUserToAddRows = false;
            this.DGVCliente.AllowUserToDeleteRows = false;
            this.DGVCliente.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.DGVCliente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCliente.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGVCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVCliente.ColumnHeadersHeight = 29;
            this.DGVCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombre,
            this.colApellido,
            this.colDNI,
            this.colEmail,
            this.colEstado,
            this.colTelefono,
            this.colDireccion,
            this.btnEditarFila,
            this.btnEliminarFila});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVCliente.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGVCliente.EnableHeadersVisualStyles = false;
            this.DGVCliente.Location = new System.Drawing.Point(42, 140);
            this.DGVCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGVCliente.MultiSelect = false;
            this.DGVCliente.Name = "DGVCliente";
            this.DGVCliente.ReadOnly = true;
            this.DGVCliente.RowHeadersVisible = false;
            this.DGVCliente.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.DGVCliente.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGVCliente.RowTemplate.Height = 28;
            this.DGVCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCliente.Size = new System.Drawing.Size(855, 231);
            this.DGVCliente.TabIndex = 0;
            this.DGVCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCliente_CellContentClick);
            this.DGVCliente.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVCliente_CellFormatting);
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "nombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 6;
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colApellido
            // 
            this.colApellido.DataPropertyName = "apellido";
            this.colApellido.HeaderText = "Apellido";
            this.colApellido.MinimumWidth = 6;
            this.colApellido.Name = "colApellido";
            this.colApellido.ReadOnly = true;
            // 
            // colDNI
            // 
            this.colDNI.DataPropertyName = "dni";
            this.colDNI.HeaderText = "DNI";
            this.colDNI.MinimumWidth = 6;
            this.colDNI.Name = "colDNI";
            this.colDNI.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "email";
            this.colEmail.HeaderText = "Correo";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.DataPropertyName = "Estado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 6;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // colTelefono
            // 
            this.colTelefono.DataPropertyName = "telefono";
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.MinimumWidth = 6;
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.ReadOnly = true;
            // 
            // colDireccion
            // 
            this.colDireccion.DataPropertyName = "direccion";
            this.colDireccion.HeaderText = "Direccíon";
            this.colDireccion.MinimumWidth = 6;
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.ReadOnly = true;
            // 
            // btnEditarFila
            // 
            this.btnEditarFila.DataPropertyName = "accion";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Magenta;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Transparent;
            this.btnEditarFila.DefaultCellStyle = dataGridViewCellStyle3;
            this.btnEditarFila.HeaderText = "Acción";
            this.btnEditarFila.MinimumWidth = 6;
            this.btnEditarFila.Name = "btnEditarFila";
            this.btnEditarFila.ReadOnly = true;
            // 
            // btnEliminarFila
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Fuchsia;
            this.btnEliminarFila.DefaultCellStyle = dataGridViewCellStyle4;
            this.btnEliminarFila.HeaderText = "Acción";
            this.btnEliminarFila.MinimumWidth = 6;
            this.btnEliminarFila.Name = "btnEliminarFila";
            this.btnEliminarFila.ReadOnly = true;
            // 
            // PContenido
            // 
            this.PContenido.Controls.Add(this.PContenedorGrilla);
            this.PContenido.Controls.Add(this.LTituloGrilla);
            this.PContenido.Controls.Add(this.FLPCards);
            this.PContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenido.Location = new System.Drawing.Point(0, 0);
            this.PContenido.Name = "PContenido";
            this.PContenido.Size = new System.Drawing.Size(1178, 671);
            this.PContenido.TabIndex = 26;
            // 
            // PContenedorGrilla
            // 
            this.PContenedorGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.PContenedorGrilla.BackColor = System.Drawing.Color.White;
            this.PContenedorGrilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PContenedorGrilla.Controls.Add(this.LPaginas);
            this.PContenedorGrilla.Controls.Add(this.BSiguiente);
            this.PContenedorGrilla.Controls.Add(this.BAnterior);
            this.PContenedorGrilla.Controls.Add(this.DGVCliente);
            this.PContenedorGrilla.Controls.Add(this.label3);
            this.PContenedorGrilla.Controls.Add(this.BBuscar);
            this.PContenedorGrilla.Controls.Add(this.TBBuscar);
            this.PContenedorGrilla.Location = new System.Drawing.Point(99, 170);
            this.PContenedorGrilla.Margin = new System.Windows.Forms.Padding(20);
            this.PContenedorGrilla.Name = "PContenedorGrilla";
            this.PContenedorGrilla.Padding = new System.Windows.Forms.Padding(20);
            this.PContenedorGrilla.Size = new System.Drawing.Size(980, 470);
            this.PContenedorGrilla.TabIndex = 22;
            // 
            // LPaginas
            // 
            this.LPaginas.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LPaginas.AutoSize = true;
            this.LPaginas.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPaginas.Location = new System.Drawing.Point(450, 423);
            this.LPaginas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
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
            this.BSiguiente.Location = new System.Drawing.Point(565, 418);
            this.BSiguiente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BSiguiente.Name = "BSiguiente";
            this.BSiguiente.Size = new System.Drawing.Size(75, 26);
            this.BSiguiente.TabIndex = 27;
            this.BSiguiente.Text = "Siguiente >";
            this.BSiguiente.UseVisualStyleBackColor = false;
            // 
            // BAnterior
            // 
            this.BAnterior.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAnterior.ForeColor = System.Drawing.Color.White;
            this.BAnterior.Location = new System.Drawing.Point(355, 418);
            this.BAnterior.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BAnterior.Name = "BAnterior";
            this.BAnterior.Size = new System.Drawing.Size(75, 26);
            this.BAnterior.TabIndex = 26;
            this.BAnterior.Text = "< Anterior";
            this.BAnterior.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Listado de clientes";
            // 
            // BBuscar
            // 
            this.BBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BBuscar.Location = new System.Drawing.Point(832, 65);
            this.BBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(90, 30);
            this.BBuscar.TabIndex = 2;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = false;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            this.BBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBBuscar_KeyDown);
            // 
            // TBBuscar
            // 
            this.TBBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TBBuscar.BackColor = System.Drawing.Color.White;
            this.TBBuscar.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TBBuscar.Location = new System.Drawing.Point(513, 65);
            this.TBBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(300, 25);
            this.TBBuscar.TabIndex = 1;
            // 
            // LTituloGrilla
            // 
            this.LTituloGrilla.AutoSize = true;
            this.LTituloGrilla.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloGrilla.Location = new System.Drawing.Point(52, 25);
            this.LTituloGrilla.Name = "LTituloGrilla";
            this.LTituloGrilla.Size = new System.Drawing.Size(216, 25);
            this.LTituloGrilla.TabIndex = 3;
            this.LTituloGrilla.Text = "Gestión de clientes";
            // 
            // FLPCards
            // 
            this.FLPCards.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FLPCards.Controls.Add(this.PCard3);
            this.FLPCards.Controls.Add(this.PCard1);
            this.FLPCards.Controls.Add(this.PCard2);
            this.FLPCards.Location = new System.Drawing.Point(99, 67);
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
            this.pictureBox1.Image = global::Presentation.Properties.Resources.cliente5;
            this.pictureBox1.Location = new System.Drawing.Point(162, 20);
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
            this.LCard1.Size = new System.Drawing.Size(95, 13);
            this.LCard1.TabIndex = 0;
            this.LCard1.Text = "TOTAL  CLIENTES";
            // 
            // PCard1
            // 
            this.PCard1.BackColor = System.Drawing.Color.White;
            this.PCard1.Controls.Add(this.pictureBox2);
            this.PCard1.Controls.Add(this.LClientesNuevos);
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
            this.pictureBox2.Image = global::Presentation.Properties.Resources.nueva_cuenta;
            this.pictureBox2.Location = new System.Drawing.Point(158, 20);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // LClientesNuevos
            // 
            this.LClientesNuevos.AutoSize = true;
            this.LClientesNuevos.BackColor = System.Drawing.Color.White;
            this.LClientesNuevos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LClientesNuevos.Location = new System.Drawing.Point(18, 38);
            this.LClientesNuevos.Name = "LClientesNuevos";
            this.LClientesNuevos.Size = new System.Drawing.Size(23, 25);
            this.LClientesNuevos.TabIndex = 1;
            this.LClientesNuevos.Text = "3";
            // 
            // LCard3
            // 
            this.LCard3.AutoEllipsis = true;
            this.LCard3.AutoSize = true;
            this.LCard3.BackColor = System.Drawing.Color.White;
            this.LCard3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCard3.Location = new System.Drawing.Point(18, 12);
            this.LCard3.Name = "LCard3";
            this.LCard3.Size = new System.Drawing.Size(100, 13);
            this.LCard3.TabIndex = 0;
            this.LCard3.Text = "NUEVOS DEL MES";
            // 
            // PCard2
            // 
            this.PCard2.BackColor = System.Drawing.Color.White;
            this.PCard2.Controls.Add(this.pictureBox3);
            this.PCard2.Controls.Add(this.LClientesTop);
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
            this.pictureBox3.Image = global::Presentation.Properties.Resources.clasificacion1;
            this.pictureBox3.Location = new System.Drawing.Point(163, 20);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(38, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // LClientesTop
            // 
            this.LClientesTop.AutoSize = true;
            this.LClientesTop.BackColor = System.Drawing.Color.White;
            this.LClientesTop.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LClientesTop.Location = new System.Drawing.Point(18, 38);
            this.LClientesTop.Name = "LClientesTop";
            this.LClientesTop.Size = new System.Drawing.Size(23, 25);
            this.LClientesTop.TabIndex = 1;
            this.LClientesTop.Text = "3";
            // 
            // LCard2
            // 
            this.LCard2.AutoEllipsis = true;
            this.LCard2.AutoSize = true;
            this.LCard2.BackColor = System.Drawing.Color.White;
            this.LCard2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCard2.Location = new System.Drawing.Point(18, 12);
            this.LCard2.Name = "LCard2";
            this.LCard2.Size = new System.Drawing.Size(77, 13);
            this.LCard2.TabIndex = 0;
            this.LCard2.Text = "TOP DEL MES";
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1178, 671);
            this.Controls.Add(this.PContenido);
            this.Name = "FormCliente";
            this.Text = "FormCliente";
            this.Load += new System.EventHandler(this.FormCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCliente)).EndInit();
            this.PContenido.ResumeLayout(false);
            this.PContenido.PerformLayout();
            this.PContenedorGrilla.ResumeLayout(false);
            this.PContenedorGrilla.PerformLayout();
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
        private System.Windows.Forms.DataGridView DGVCliente;
        private System.Windows.Forms.Panel PContenido;
        private System.Windows.Forms.Label LTituloGrilla;
        private System.Windows.Forms.FlowLayoutPanel FLPCards;
        private System.Windows.Forms.Panel PCard3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LTotalActivos;
        private System.Windows.Forms.Label LCard1;
        private System.Windows.Forms.Panel PCard1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LClientesNuevos;
        private System.Windows.Forms.Label LCard3;
        private System.Windows.Forms.Panel PCard2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label LClientesTop;
        private System.Windows.Forms.Label LCard2;
        private System.Windows.Forms.Panel PContenedorGrilla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Label LPaginas;
        private System.Windows.Forms.Button BSiguiente;
        private System.Windows.Forms.Button BAnterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn btnEditarFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn btnEliminarFila;
    }
}