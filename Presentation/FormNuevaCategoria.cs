namespace Presentation
{
    partial class FormNuevaCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNuevaCategoria));
            this.LDatosProductos = new System.Windows.Forms.Label();
            this.TBDescripcion = new System.Windows.Forms.TextBox();
            this.LDescripcionProduc = new System.Windows.Forms.Label();
            this.TBPrecio = new System.Windows.Forms.TextBox();
            this.LStock = new System.Windows.Forms.Label();
            this.TBStock = new System.Windows.Forms.TextBox();
            this.TBCodProduc = new System.Windows.Forms.TextBox();
            this.LPrecio = new System.Windows.Forms.Label();
            this.LCategoria = new System.Windows.Forms.Label();
            this.LCodigo = new System.Windows.Forms.Label();
            this.BGuardar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.PContenedorModal = new System.Windows.Forms.Panel();
            this.PCuerpo = new System.Windows.Forms.Panel();
            this.CBcategoriaProduc = new System.Windows.Forms.ComboBox();
            this.LNombreProduc = new System.Windows.Forms.Label();
            this.TBNombreProduc = new System.Windows.Forms.TextBox();
            this.PLineaDivisoria = new System.Windows.Forms.Panel();
            this.PHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.LTituloNuevoProduc = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LCerrar = new System.Windows.Forms.Label();
            this.FLPLineaDivisoria = new System.Windows.Forms.FlowLayoutPanel();
            this.LTituloModal = new System.Windows.Forms.Label();
            this.PBTituloModal = new System.Windows.Forms.PictureBox();
            this.PContenedorModal.SuspendLayout();
            this.PCuerpo.SuspendLayout();
            this.PHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBTituloModal)).BeginInit();
            this.SuspendLayout();
            // 
            // LDatosProductos
            // 
            this.LDatosProductos.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDatosProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LDatosProductos.Location = new System.Drawing.Point(35, 30);
            this.LDatosProductos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LDatosProductos.Name = "LDatosProductos";
            this.LDatosProductos.Size = new System.Drawing.Size(220, 17);
            this.LDatosProductos.TabIndex = 5;
            this.LDatosProductos.Text = "DATOS DEL PRODUCTO";
            // 
            // TBDescripcion
            // 
            this.TBDescripcion.AcceptsTab = true;
            this.TBDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDescripcion.Location = new System.Drawing.Point(295, 263);
            this.TBDescripcion.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TBDescripcion.Name = "TBDescripcion";
            this.TBDescripcion.Size = new System.Drawing.Size(220, 25);
            this.TBDescripcion.TabIndex = 4;
            // 
            // LDescripcionProduc
            // 
            this.LDescripcionProduc.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDescripcionProduc.Location = new System.Drawing.Point(295, 243);
            this.LDescripcionProduc.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LDescripcionProduc.Name = "LDescripcionProduc";
            this.LDescripcionProduc.Size = new System.Drawing.Size(85, 14);
            this.LDescripcionProduc.TabIndex = 36;
            this.LDescripcionProduc.Text = "Descripción:";
            // 
            // TBPrecio
            // 
            this.TBPrecio.AcceptsTab = true;
            this.TBPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBPrecio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPrecio.Location = new System.Drawing.Point(295, 195);
            this.TBPrecio.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TBPrecio.Name = "TBPrecio";
            this.TBPrecio.Size = new System.Drawing.Size(220, 25);
            this.TBPrecio.TabIndex = 2;
            // 
            // LStock
            // 
            this.LStock.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LStock.Location = new System.Drawing.Point(35, 243);
            this.LStock.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LStock.Name = "LStock";
            this.LStock.Size = new System.Drawing.Size(84, 14);
            this.LStock.TabIndex = 30;
            this.LStock.Text = "Stock Inicial:";
            // 
            // TBStock
            // 
            this.TBStock.AcceptsTab = true;
            this.TBStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBStock.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBStock.Location = new System.Drawing.Point(35, 263);
            this.TBStock.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TBStock.MaxLength = 8;
            this.TBStock.Name = "TBStock";
            this.TBStock.Size = new System.Drawing.Size(220, 25);
            this.TBStock.TabIndex = 3;
            // 
            // TBCodProduc
            // 
            this.TBCodProduc.AcceptsTab = true;
            this.TBCodProduc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBCodProduc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCodProduc.Location = new System.Drawing.Point(35, 127);
            this.TBCodProduc.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TBCodProduc.MaxLength = 8;
            this.TBCodProduc.Name = "TBCodProduc";
            this.TBCodProduc.Size = new System.Drawing.Size(220, 25);
            this.TBCodProduc.TabIndex = 0;
            // 
            // LPrecio
            // 
            this.LPrecio.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPrecio.Location = new System.Drawing.Point(295, 175);
            this.LPrecio.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LPrecio.Name = "LPrecio";
            this.LPrecio.Size = new System.Drawing.Size(110, 14);
            this.LPrecio.TabIndex = 29;
            this.LPrecio.Text = "Precio:";
            // 
            // LCategoria
            // 
            this.LCategoria.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCategoria.Location = new System.Drawing.Point(35, 175);
            this.LCategoria.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LCategoria.Name = "LCategoria";
            this.LCategoria.Size = new System.Drawing.Size(110, 14);
            this.LCategoria.TabIndex = 3;
            this.LCategoria.Text = "Categoría:";
            // 
            // LCodigo
            // 
            this.LCodigo.AutoSize = true;
            this.LCodigo.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCodigo.Location = new System.Drawing.Point(35, 107);
            this.LCodigo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LCodigo.Name = "LCodigo";
            this.LCodigo.Size = new System.Drawing.Size(52, 14);
            this.LCodigo.TabIndex = 0;
            this.LCodigo.Text = "Código:";
            // 
            // BGuardar
            // 
            this.BGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGuardar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BGuardar.FlatAppearance.BorderSize = 0;
            this.BGuardar.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BGuardar.Location = new System.Drawing.Point(400, 357);
            this.BGuardar.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(115, 32);
            this.BGuardar.TabIndex = 3;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = false;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BCancelar.FlatAppearance.BorderSize = 0;
            this.BCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.BCancelar.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar.ForeColor = System.Drawing.Color.Red;
            this.BCancelar.Location = new System.Drawing.Point(265, 357);
            this.BCancelar.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(115, 32);
            this.BCancelar.TabIndex = 4;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = false;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // PContenedorModal
            // 
            this.PContenedorModal.BackColor = System.Drawing.Color.PaleVioletRed;
            this.PContenedorModal.Controls.Add(this.PCuerpo);
            this.PContenedorModal.Controls.Add(this.PHeader);
            this.PContenedorModal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenedorModal.Location = new System.Drawing.Point(0, 0);
            this.PContenedorModal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PContenedorModal.Name = "PContenedorModal";
            this.PContenedorModal.Size = new System.Drawing.Size(550, 500);
            this.PContenedorModal.TabIndex = 37;
            // 
            // PCuerpo
            // 
            this.PCuerpo.BackColor = System.Drawing.Color.White;
            this.PCuerpo.Controls.Add(this.CBcategoriaProduc);
            this.PCuerpo.Controls.Add(this.LNombreProduc);
            this.PCuerpo.Controls.Add(this.TBNombreProduc);
            this.PCuerpo.Controls.Add(this.BCancelar);
            this.PCuerpo.Controls.Add(this.PLineaDivisoria);
            this.PCuerpo.Controls.Add(this.BGuardar);
            this.PCuerpo.Controls.Add(this.LDatosProductos);
            this.PCuerpo.Controls.Add(this.LCodigo);
            this.PCuerpo.Controls.Add(this.LCategoria);
            this.PCuerpo.Controls.Add(this.TBPrecio);
            this.PCuerpo.Controls.Add(this.TBCodProduc);
            this.PCuerpo.Controls.Add(this.LPrecio);
            this.PCuerpo.Controls.Add(this.LDescripcionProduc);
            this.PCuerpo.Controls.Add(this.TBDescripcion);
            this.PCuerpo.Controls.Add(this.LStock);
            this.PCuerpo.Controls.Add(this.TBStock);
            this.PCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCuerpo.Location = new System.Drawing.Point(0, 55);
            this.PCuerpo.Name = "PCuerpo";
            this.PCuerpo.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.PCuerpo.Size = new System.Drawing.Size(550, 445);
            this.PCuerpo.TabIndex = 37;
            // 
            // CBcategoriaProduc
            // 
            this.CBcategoriaProduc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBcategoriaProduc.FormattingEnabled = true;
            this.CBcategoriaProduc.Location = new System.Drawing.Point(35, 197);
            this.CBcategoriaProduc.Name = "CBcategoriaProduc";
            this.CBcategoriaProduc.Size = new System.Drawing.Size(220, 23);
            this.CBcategoriaProduc.TabIndex = 41;
            // 
            // LNombreProduc
            // 
            this.LNombreProduc.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombreProduc.Location = new System.Drawing.Point(295, 107);
            this.LNombreProduc.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LNombreProduc.Name = "LNombreProduc";
            this.LNombreProduc.Size = new System.Drawing.Size(130, 14);
            this.LNombreProduc.TabIndex = 40;
            this.LNombreProduc.Text = "Nombre del producto:";
            // 
            // TBNombreProduc
            // 
            this.TBNombreProduc.AcceptsTab = true;
            this.TBNombreProduc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBNombreProduc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNombreProduc.Location = new System.Drawing.Point(295, 127);
            this.TBNombreProduc.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TBNombreProduc.MaxLength = 8;
            this.TBNombreProduc.Name = "TBNombreProduc";
            this.TBNombreProduc.Size = new System.Drawing.Size(220, 25);
            this.TBNombreProduc.TabIndex = 39;
            // 
            // PLineaDivisoria
            // 
            this.PLineaDivisoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(112)))), ((int)(((byte)(102)))));
            this.PLineaDivisoria.Location = new System.Drawing.Point(35, 58);
            this.PLineaDivisoria.Name = "PLineaDivisoria";
            this.PLineaDivisoria.Size = new System.Drawing.Size(480, 1);
            this.PLineaDivisoria.TabIndex = 38;
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.PHeader.Controls.Add(this.panel1);
            this.PHeader.Controls.Add(this.LCerrar);
            this.PHeader.Controls.Add(this.FLPLineaDivisoria);
            this.PHeader.Controls.Add(this.LTituloModal);
            this.PHeader.Controls.Add(this.PBTituloModal);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(550, 55);
            this.PHeader.TabIndex = 35;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.LTituloNuevoProduc);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 55);
            this.panel1.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.label1.Location = new System.Drawing.Point(496, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.LCerrar_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 53);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(550, 2);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // LTituloNuevoProduc
            // 
            this.LTituloNuevoProduc.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloNuevoProduc.Location = new System.Drawing.Point(66, 12);
            this.LTituloNuevoProduc.Name = "LTituloNuevoProduc";
            this.LTituloNuevoProduc.Size = new System.Drawing.Size(189, 32);
            this.LTituloNuevoProduc.TabIndex = 1;
            this.LTituloNuevoProduc.Text = "Nuevo Producto";
            this.LTituloNuevoProduc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Presentation.Properties.Resources.caja;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LCerrar
            // 
            this.LCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LCerrar.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.LCerrar.Location = new System.Drawing.Point(496, 12);
            this.LCerrar.Name = "LCerrar";
            this.LCerrar.Size = new System.Drawing.Size(32, 32);
            this.LCerrar.TabIndex = 3;
            this.LCerrar.Text = "X";
            this.LCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LCerrar.Click += new System.EventHandler(this.LCerrar_Click);
            // 
            // FLPLineaDivisoria
            // 
            this.FLPLineaDivisoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.FLPLineaDivisoria.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FLPLineaDivisoria.Location = new System.Drawing.Point(0, 53);
            this.FLPLineaDivisoria.Name = "FLPLineaDivisoria";
            this.FLPLineaDivisoria.Size = new System.Drawing.Size(550, 2);
            this.FLPLineaDivisoria.TabIndex = 2;
            // 
            // LTituloModal
            // 
            this.LTituloModal.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloModal.Location = new System.Drawing.Point(66, 12);
            this.LTituloModal.Name = "LTituloModal";
            this.LTituloModal.Size = new System.Drawing.Size(178, 32);
            this.LTituloModal.TabIndex = 1;
            this.LTituloModal.Text = "Nuevo Cliente";
            this.LTituloModal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PBTituloModal
            // 
            this.PBTituloModal.BackColor = System.Drawing.Color.Transparent;
            this.PBTituloModal.Image = global::Presentation.Properties.Resources.nueva_cuenta;
            this.PBTituloModal.InitialImage = ((System.Drawing.Image)(resources.GetObject("PBTituloModal.InitialImage")));
            this.PBTituloModal.Location = new System.Drawing.Point(18, 12);
            this.PBTituloModal.Name = "PBTituloModal";
            this.PBTituloModal.Size = new System.Drawing.Size(32, 32);
            this.PBTituloModal.TabIndex = 0;
            this.PBTituloModal.TabStop = false;
            // 
            // FormNuevoProducto
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(550, 500);
            this.ControlBox = false;
            this.Controls.Add(this.PContenedorModal);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(522, 479);
            this.Name = "FormNuevaCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FormNuevaCategoria_Load);
            this.PContenedorModal.ResumeLayout(false);
            this.PCuerpo.ResumeLayout(false);
            this.PCuerpo.PerformLayout();
            this.PHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBTituloModal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LDatosProductos;
        private System.Windows.Forms.TextBox TBDescripcion;
        private System.Windows.Forms.Label LDescripcionProduc;
        private System.Windows.Forms.TextBox TBPrecio;
        private System.Windows.Forms.Label LStock;
        private System.Windows.Forms.TextBox TBStock;
        private System.Windows.Forms.TextBox TBCodProduc;
        private System.Windows.Forms.Label LPrecio;
        private System.Windows.Forms.Label LCategoria;
        private System.Windows.Forms.Label LCodigo;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Panel PContenedorModal;
        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Panel PCuerpo;
        private System.Windows.Forms.FlowLayoutPanel FLPLineaDivisoria;
        private System.Windows.Forms.Label LTituloModal;
        private System.Windows.Forms.PictureBox PBTituloModal;
        private System.Windows.Forms.Label LCerrar;
        private System.Windows.Forms.Panel PLineaDivisoria;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label LTituloNuevoProduc;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}