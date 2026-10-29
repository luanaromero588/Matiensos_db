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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.TLPCards = new System.Windows.Forms.TableLayoutPanel();
            this.CardTop = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LValorTopMes = new System.Windows.Forms.Label();
            this.LTituloTop = new System.Windows.Forms.Label();
            this.PCardNuevos = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LValorNuevosMes = new System.Windows.Forms.Label();
            this.LTituloNuevoMes = new System.Windows.Forms.Label();
            this.PCardTotalClientes = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LValorTotalClientes = new System.Windows.Forms.Label();
            this.LTituloClientes = new System.Windows.Forms.Label();
            this.PContenedorGrilla = new System.Windows.Forms.Panel();
            this.BLimpiarFiltros = new System.Windows.Forms.Button();
            this.BBuscar = new System.Windows.Forms.Button();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.LPaginas = new System.Windows.Forms.Label();
            this.BSiguiente = new System.Windows.Forms.Button();
            this.BAnterior = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LTituloGrilla = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCliente)).BeginInit();
            this.PContenido.SuspendLayout();
            this.TLPCards.SuspendLayout();
            this.CardTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.PCardNuevos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.PCardTotalClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PContenedorGrilla.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVCliente
            // 
            this.DGVCliente.AllowDrop = true;
            this.DGVCliente.AllowUserToAddRows = false;
            this.DGVCliente.AllowUserToDeleteRows = false;
            this.DGVCliente.AllowUserToResizeRows = false;
            dataGridViewCellStyle55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle55.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle55.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle55.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle55.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.DGVCliente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle55;
            this.DGVCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCliente.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGVCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVCliente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle56.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle56.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle56;
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
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle59.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle59.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle59.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle59.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle59.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVCliente.DefaultCellStyle = dataGridViewCellStyle59;
            this.DGVCliente.EnableHeadersVisualStyles = false;
            this.DGVCliente.Location = new System.Drawing.Point(43, 118);
            this.DGVCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DGVCliente.MultiSelect = false;
            this.DGVCliente.Name = "DGVCliente";
            this.DGVCliente.ReadOnly = true;
            this.DGVCliente.RowHeadersVisible = false;
            this.DGVCliente.RowHeadersWidth = 51;
            dataGridViewCellStyle60.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle60.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle60.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle60.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle60.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.DGVCliente.RowsDefaultCellStyle = dataGridViewCellStyle60;
            this.DGVCliente.RowTemplate.Height = 28;
            this.DGVCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCliente.Size = new System.Drawing.Size(1195, 369);
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
            dataGridViewCellStyle57.BackColor = System.Drawing.Color.Magenta;
            dataGridViewCellStyle57.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle57.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle57.SelectionForeColor = System.Drawing.Color.Transparent;
            this.btnEditarFila.DefaultCellStyle = dataGridViewCellStyle57;
            this.btnEditarFila.HeaderText = "Acción";
            this.btnEditarFila.MinimumWidth = 6;
            this.btnEditarFila.Name = "btnEditarFila";
            this.btnEditarFila.ReadOnly = true;
            // 
            // btnEliminarFila
            // 
            dataGridViewCellStyle58.BackColor = System.Drawing.Color.Fuchsia;
            this.btnEliminarFila.DefaultCellStyle = dataGridViewCellStyle58;
            this.btnEliminarFila.HeaderText = "Acción";
            this.btnEliminarFila.MinimumWidth = 6;
            this.btnEliminarFila.Name = "btnEliminarFila";
            this.btnEliminarFila.ReadOnly = true;
            // 
            // PContenido
            // 
            this.PContenido.Controls.Add(this.TLPCards);
            this.PContenido.Controls.Add(this.PContenedorGrilla);
            this.PContenido.Controls.Add(this.LTituloGrilla);
            this.PContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenido.Location = new System.Drawing.Point(0, 0);
            this.PContenido.Margin = new System.Windows.Forms.Padding(0);
            this.PContenido.Name = "PContenido";
            this.PContenido.Size = new System.Drawing.Size(1386, 788);
            this.PContenido.TabIndex = 26;
            // 
            // TLPCards
            // 
            this.TLPCards.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TLPCards.ColumnCount = 3;
            this.TLPCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPCards.Controls.Add(this.CardTop, 2, 0);
            this.TLPCards.Controls.Add(this.PCardNuevos, 1, 0);
            this.TLPCards.Controls.Add(this.PCardTotalClientes, 0, 0);
            this.TLPCards.Location = new System.Drawing.Point(47, 81);
            this.TLPCards.Name = "TLPCards";
            this.TLPCards.RowCount = 1;
            this.TLPCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPCards.Size = new System.Drawing.Size(1306, 96);
            this.TLPCards.TabIndex = 23;
            // 
            // CardTop
            // 
            this.CardTop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardTop.BackColor = System.Drawing.Color.White;
            this.CardTop.Controls.Add(this.pictureBox3);
            this.CardTop.Controls.Add(this.LValorTopMes);
            this.CardTop.Controls.Add(this.LTituloTop);
            this.CardTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.CardTop.Location = new System.Drawing.Point(870, 0);
            this.CardTop.Margin = new System.Windows.Forms.Padding(0, 0, 27, 0);
            this.CardTop.Name = "CardTop";
            this.CardTop.Padding = new System.Windows.Forms.Padding(21, 15, 21, 15);
            this.CardTop.Size = new System.Drawing.Size(409, 96);
            this.CardTop.TabIndex = 3;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Presentation.Properties.Resources.clasificacion1;
            this.pictureBox3.Location = new System.Drawing.Point(329, 15);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(59, 58);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // LValorTopMes
            // 
            this.LValorTopMes.BackColor = System.Drawing.Color.White;
            this.LValorTopMes.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LValorTopMes.Location = new System.Drawing.Point(29, 50);
            this.LValorTopMes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LValorTopMes.Name = "LValorTopMes";
            this.LValorTopMes.Size = new System.Drawing.Size(189, 31);
            this.LValorTopMes.TabIndex = 1;
            this.LValorTopMes.Text = "-";
            // 
            // LTituloTop
            // 
            this.LTituloTop.AutoEllipsis = true;
            this.LTituloTop.BackColor = System.Drawing.Color.White;
            this.LTituloTop.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloTop.Location = new System.Drawing.Point(29, 17);
            this.LTituloTop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloTop.Name = "LTituloTop";
            this.LTituloTop.Size = new System.Drawing.Size(283, 20);
            this.LTituloTop.TabIndex = 0;
            this.LTituloTop.Text = "TOP DEL MES";
            // 
            // PCardNuevos
            // 
            this.PCardNuevos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PCardNuevos.BackColor = System.Drawing.Color.White;
            this.PCardNuevos.Controls.Add(this.pictureBox2);
            this.PCardNuevos.Controls.Add(this.LValorNuevosMes);
            this.PCardNuevos.Controls.Add(this.LTituloNuevoMes);
            this.PCardNuevos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCardNuevos.Location = new System.Drawing.Point(435, 0);
            this.PCardNuevos.Margin = new System.Windows.Forms.Padding(0, 0, 27, 0);
            this.PCardNuevos.Name = "PCardNuevos";
            this.PCardNuevos.Padding = new System.Windows.Forms.Padding(21, 15, 21, 15);
            this.PCardNuevos.Size = new System.Drawing.Size(408, 96);
            this.PCardNuevos.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Presentation.Properties.Resources.nueva_cuenta;
            this.pictureBox2.Location = new System.Drawing.Point(328, 17);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(59, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // LValorNuevosMes
            // 
            this.LValorNuevosMes.BackColor = System.Drawing.Color.White;
            this.LValorNuevosMes.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LValorNuevosMes.Location = new System.Drawing.Point(29, 50);
            this.LValorNuevosMes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LValorNuevosMes.Name = "LValorNuevosMes";
            this.LValorNuevosMes.Size = new System.Drawing.Size(189, 31);
            this.LValorNuevosMes.TabIndex = 1;
            this.LValorNuevosMes.Text = "$ ";
            // 
            // LTituloNuevoMes
            // 
            this.LTituloNuevoMes.AutoEllipsis = true;
            this.LTituloNuevoMes.BackColor = System.Drawing.Color.White;
            this.LTituloNuevoMes.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloNuevoMes.Location = new System.Drawing.Point(29, 17);
            this.LTituloNuevoMes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloNuevoMes.Name = "LTituloNuevoMes";
            this.LTituloNuevoMes.Size = new System.Drawing.Size(282, 20);
            this.LTituloNuevoMes.TabIndex = 0;
            this.LTituloNuevoMes.Text = "NUEVOS DEL MES";
            // 
            // PCardTotalClientes
            // 
            this.PCardTotalClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PCardTotalClientes.BackColor = System.Drawing.Color.White;
            this.PCardTotalClientes.Controls.Add(this.pictureBox1);
            this.PCardTotalClientes.Controls.Add(this.LValorTotalClientes);
            this.PCardTotalClientes.Controls.Add(this.LTituloClientes);
            this.PCardTotalClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.PCardTotalClientes.Location = new System.Drawing.Point(0, 0);
            this.PCardTotalClientes.Margin = new System.Windows.Forms.Padding(0, 0, 27, 0);
            this.PCardTotalClientes.Name = "PCardTotalClientes";
            this.PCardTotalClientes.Padding = new System.Windows.Forms.Padding(21, 15, 21, 15);
            this.PCardTotalClientes.Size = new System.Drawing.Size(408, 96);
            this.PCardTotalClientes.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Presentation.Properties.Resources.cliente5;
            this.pictureBox1.Location = new System.Drawing.Point(328, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // LValorTotalClientes
            // 
            this.LValorTotalClientes.BackColor = System.Drawing.Color.White;
            this.LValorTotalClientes.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LValorTotalClientes.Location = new System.Drawing.Point(29, 50);
            this.LValorTotalClientes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LValorTotalClientes.Name = "LValorTotalClientes";
            this.LValorTotalClientes.Size = new System.Drawing.Size(189, 31);
            this.LValorTotalClientes.TabIndex = 1;
            this.LValorTotalClientes.Text = "0";
            // 
            // LTituloClientes
            // 
            this.LTituloClientes.AutoEllipsis = true;
            this.LTituloClientes.BackColor = System.Drawing.Color.White;
            this.LTituloClientes.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloClientes.Location = new System.Drawing.Point(29, 17);
            this.LTituloClientes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloClientes.Name = "LTituloClientes";
            this.LTituloClientes.Size = new System.Drawing.Size(281, 20);
            this.LTituloClientes.TabIndex = 0;
            this.LTituloClientes.Text = "TOTAL CLIENTES";
            // 
            // PContenedorGrilla
            // 
            this.PContenedorGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PContenedorGrilla.BackColor = System.Drawing.Color.White;
            this.PContenedorGrilla.Controls.Add(this.BLimpiarFiltros);
            this.PContenedorGrilla.Controls.Add(this.BBuscar);
            this.PContenedorGrilla.Controls.Add(this.TBBuscar);
            this.PContenedorGrilla.Controls.Add(this.LPaginas);
            this.PContenedorGrilla.Controls.Add(this.BSiguiente);
            this.PContenedorGrilla.Controls.Add(this.BAnterior);
            this.PContenedorGrilla.Controls.Add(this.DGVCliente);
            this.PContenedorGrilla.Controls.Add(this.label3);
            this.PContenedorGrilla.Location = new System.Drawing.Point(47, 202);
            this.PContenedorGrilla.Margin = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.PContenedorGrilla.Name = "PContenedorGrilla";
            this.PContenedorGrilla.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.PContenedorGrilla.Size = new System.Drawing.Size(1280, 541);
            this.PContenedorGrilla.TabIndex = 22;
            // 
            // BLimpiarFiltros
            // 
            this.BLimpiarFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BLimpiarFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BLimpiarFiltros.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiarFiltros.ForeColor = System.Drawing.Color.Firebrick;
            this.BLimpiarFiltros.Location = new System.Drawing.Point(1162, 71);
            this.BLimpiarFiltros.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BLimpiarFiltros.Name = "BLimpiarFiltros";
            this.BLimpiarFiltros.Size = new System.Drawing.Size(75, 27);
            this.BLimpiarFiltros.TabIndex = 3;
            this.BLimpiarFiltros.Text = "Limpiar";
            this.BLimpiarFiltros.UseVisualStyleBackColor = false;
            // 
            // BBuscar
            // 
            this.BBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBuscar.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BBuscar.Location = new System.Drawing.Point(1077, 71);
            this.BBuscar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(75, 27);
            this.BBuscar.TabIndex = 2;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = false;
            // 
            // TBBuscar
            // 
            this.TBBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TBBuscar.BackColor = System.Drawing.Color.White;
            this.TBBuscar.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TBBuscar.Location = new System.Drawing.Point(741, 71);
            this.TBBuscar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(315, 29);
            this.TBBuscar.TabIndex = 1;
            this.TBBuscar.Tag = "Buscar Producto";
            // 
            // LPaginas
            // 
            this.LPaginas.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LPaginas.AutoSize = true;
            this.LPaginas.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPaginas.Location = new System.Drawing.Point(604, 485);
            this.LPaginas.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LPaginas.Name = "LPaginas";
            this.LPaginas.Size = new System.Drawing.Size(114, 20);
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
            this.BSiguiente.Location = new System.Drawing.Point(741, 479);
            this.BSiguiente.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.BSiguiente.Name = "BSiguiente";
            this.BSiguiente.Size = new System.Drawing.Size(119, 32);
            this.BSiguiente.TabIndex = 5;
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
            this.BAnterior.Location = new System.Drawing.Point(461, 479);
            this.BAnterior.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.BAnterior.Name = "BAnterior";
            this.BAnterior.Size = new System.Drawing.Size(119, 32);
            this.BAnterior.TabIndex = 4;
            this.BAnterior.Text = "< Anterior";
            this.BAnterior.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 31);
            this.label3.TabIndex = 24;
            this.label3.Text = "Listado de Clientes";
            // 
            // LTituloGrilla
            // 
            this.LTituloGrilla.AutoSize = true;
            this.LTituloGrilla.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloGrilla.Location = new System.Drawing.Point(42, 30);
            this.LTituloGrilla.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTituloGrilla.Name = "LTituloGrilla";
            this.LTituloGrilla.Size = new System.Drawing.Size(163, 31);
            this.LTituloGrilla.TabIndex = 3;
            this.LTituloGrilla.Text = "CLIENTES";
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.PContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCliente";
            this.Text = "FormCliente";
            this.Load += new System.EventHandler(this.FormCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCliente)).EndInit();
            this.PContenido.ResumeLayout(false);
            this.PContenido.PerformLayout();
            this.TLPCards.ResumeLayout(false);
            this.CardTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.PCardNuevos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.PCardTotalClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PContenedorGrilla.ResumeLayout(false);
            this.PContenedorGrilla.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView DGVCliente;
        private System.Windows.Forms.Panel PContenido;
        private System.Windows.Forms.Label LTituloGrilla;
        private System.Windows.Forms.Panel PContenedorGrilla;
        private System.Windows.Forms.Label label3;
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
        private System.Windows.Forms.TableLayoutPanel TLPCards;
        private System.Windows.Forms.Panel CardTop;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label LValorTopMes;
        private System.Windows.Forms.Label LTituloTop;
        private System.Windows.Forms.Panel PCardNuevos;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LValorNuevosMes;
        private System.Windows.Forms.Label LTituloNuevoMes;
        private System.Windows.Forms.Panel PCardTotalClientes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LValorTotalClientes;
        private System.Windows.Forms.Label LTituloClientes;
        private System.Windows.Forms.Button BLimpiarFiltros;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.TextBox TBBuscar;
    }
}