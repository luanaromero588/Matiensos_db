namespace Presentation.GestionVentas
{
    partial class FormVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.LTitleGestionVentas = new System.Windows.Forms.Label();
            this.PanelCliente = new System.Windows.Forms.Panel();
            this.TBEmailCliente = new System.Windows.Forms.TextBox();
            this.LEmail = new System.Windows.Forms.Label();
            this.TBApellidoCliente = new System.Windows.Forms.TextBox();
            this.LTelefono = new System.Windows.Forms.Label();
            this.TBNombreCliente = new System.Windows.Forms.TextBox();
            this.TBTelefonoCliente = new System.Windows.Forms.TextBox();
            this.ChkConsumidorFinal = new System.Windows.Forms.CheckBox();
            this.TBDniCliente = new System.Windows.Forms.TextBox();
            this.LApellido = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.LDni = new System.Windows.Forms.Label();
            this.LCargaCliente = new System.Windows.Forms.Label();
            this.BBuscarCliente = new System.Windows.Forms.Button();
            this.PanelProductos = new System.Windows.Forms.Panel();
            this.LStockCantidad = new System.Windows.Forms.Label();
            this.NUDCantidad = new System.Windows.Forms.NumericUpDown();
            this.LPrecioUnitario = new System.Windows.Forms.Label();
            this.CBProductos = new System.Windows.Forms.ComboBox();
            this.BAgregarItem = new System.Windows.Forms.Button();
            this.LStockDisponible = new System.Windows.Forms.Label();
            this.LCantidad = new System.Windows.Forms.Label();
            this.LPrecio = new System.Windows.Forms.Label();
            this.BBuscarProducto = new System.Windows.Forms.Button();
            this.LProducto = new System.Windows.Forms.Label();
            this.LProductos = new System.Windows.Forms.Label();
            this.PanelDetalle = new System.Windows.Forms.Panel();
            this.DGVCarrito = new System.Windows.Forms.DataGridView();
            this.IDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.PResumen = new System.Windows.Forms.Panel();
            this.LVueltoNumerico = new System.Windows.Forms.Label();
            this.LTotalPagar = new System.Windows.Forms.Label();
            this.TBMontoAbonado = new System.Windows.Forms.TextBox();
            this.CBFormaPago = new System.Windows.Forms.ComboBox();
            this.LDescuentoNumerico = new System.Windows.Forms.Label();
            this.LSubtotalNumerico = new System.Windows.Forms.Label();
            this.BCancelarVenta = new System.Windows.Forms.Button();
            this.BConfirmarVenta = new System.Windows.Forms.Button();
            this.LVuelto = new System.Windows.Forms.Label();
            this.LMontoRecibido = new System.Windows.Forms.Label();
            this.LFormaPago = new System.Windows.Forms.Label();
            this.LTotal = new System.Windows.Forms.Label();
            this.LDescuento = new System.Windows.Forms.Label();
            this.LSubtotal = new System.Windows.Forms.Label();
            this.LTotalCobro = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.PanelCliente.SuspendLayout();
            this.PanelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCantidad)).BeginInit();
            this.PanelDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCarrito)).BeginInit();
            this.PResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.panelTop.Controls.Add(this.LTitleGestionVentas);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1100, 80);
            this.panelTop.TabIndex = 19;
            // 
            // LTitleGestionVentas
            // 
            this.LTitleGestionVentas.AutoSize = true;
            this.LTitleGestionVentas.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitleGestionVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LTitleGestionVentas.Location = new System.Drawing.Point(33, 28);
            this.LTitleGestionVentas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LTitleGestionVentas.Name = "LTitleGestionVentas";
            this.LTitleGestionVentas.Size = new System.Drawing.Size(206, 25);
            this.LTitleGestionVentas.TabIndex = 17;
            this.LTitleGestionVentas.Text = "Gestión de Ventas";
            // 
            // PanelCliente
            // 
            this.PanelCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelCliente.BackColor = System.Drawing.Color.White;
            this.PanelCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelCliente.Controls.Add(this.TBEmailCliente);
            this.PanelCliente.Controls.Add(this.LEmail);
            this.PanelCliente.Controls.Add(this.TBApellidoCliente);
            this.PanelCliente.Controls.Add(this.LTelefono);
            this.PanelCliente.Controls.Add(this.TBNombreCliente);
            this.PanelCliente.Controls.Add(this.TBTelefonoCliente);
            this.PanelCliente.Controls.Add(this.ChkConsumidorFinal);
            this.PanelCliente.Controls.Add(this.TBDniCliente);
            this.PanelCliente.Controls.Add(this.LApellido);
            this.PanelCliente.Controls.Add(this.LNombre);
            this.PanelCliente.Controls.Add(this.LDni);
            this.PanelCliente.Controls.Add(this.LCargaCliente);
            this.PanelCliente.Controls.Add(this.BBuscarCliente);
            this.PanelCliente.Location = new System.Drawing.Point(24, 88);
            this.PanelCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PanelCliente.Name = "PanelCliente";
            this.PanelCliente.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.PanelCliente.Size = new System.Drawing.Size(715, 172);
            this.PanelCliente.TabIndex = 20;
            // 
            // TBEmailCliente
            // 
            this.TBEmailCliente.AcceptsTab = true;
            this.TBEmailCliente.Enabled = false;
            this.TBEmailCliente.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBEmailCliente.Location = new System.Drawing.Point(436, 75);
            this.TBEmailCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBEmailCliente.Name = "TBEmailCliente";
            this.TBEmailCliente.Size = new System.Drawing.Size(225, 25);
            this.TBEmailCliente.TabIndex = 25;
            // 
            // LEmail
            // 
            this.LEmail.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEmail.Location = new System.Drawing.Point(371, 80);
            this.LEmail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(47, 14);
            this.LEmail.TabIndex = 24;
            this.LEmail.Text = "E-mail:";
            // 
            // TBApellidoCliente
            // 
            this.TBApellidoCliente.AcceptsTab = true;
            this.TBApellidoCliente.Enabled = false;
            this.TBApellidoCliente.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBApellidoCliente.Location = new System.Drawing.Point(103, 114);
            this.TBApellidoCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBApellidoCliente.Name = "TBApellidoCliente";
            this.TBApellidoCliente.Size = new System.Drawing.Size(225, 25);
            this.TBApellidoCliente.TabIndex = 21;
            // 
            // LTelefono
            // 
            this.LTelefono.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.Location = new System.Drawing.Point(371, 119);
            this.LTelefono.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(60, 14);
            this.LTelefono.TabIndex = 20;
            this.LTelefono.Text = "Telefono:";
            // 
            // TBNombreCliente
            // 
            this.TBNombreCliente.AcceptsTab = true;
            this.TBNombreCliente.Enabled = false;
            this.TBNombreCliente.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNombreCliente.Location = new System.Drawing.Point(103, 78);
            this.TBNombreCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBNombreCliente.Name = "TBNombreCliente";
            this.TBNombreCliente.Size = new System.Drawing.Size(225, 25);
            this.TBNombreCliente.TabIndex = 21;
            // 
            // TBTelefonoCliente
            // 
            this.TBTelefonoCliente.AcceptsTab = true;
            this.TBTelefonoCliente.Enabled = false;
            this.TBTelefonoCliente.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTelefonoCliente.Location = new System.Drawing.Point(436, 113);
            this.TBTelefonoCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBTelefonoCliente.Name = "TBTelefonoCliente";
            this.TBTelefonoCliente.Size = new System.Drawing.Size(225, 25);
            this.TBTelefonoCliente.TabIndex = 23;
            // 
            // ChkConsumidorFinal
            // 
            this.ChkConsumidorFinal.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkConsumidorFinal.Location = new System.Drawing.Point(454, 48);
            this.ChkConsumidorFinal.Margin = new System.Windows.Forms.Padding(4);
            this.ChkConsumidorFinal.Name = "ChkConsumidorFinal";
            this.ChkConsumidorFinal.Size = new System.Drawing.Size(124, 18);
            this.ChkConsumidorFinal.TabIndex = 22;
            this.ChkConsumidorFinal.Text = "Consumidor Final";
            this.ChkConsumidorFinal.UseVisualStyleBackColor = true;
            // 
            // TBDniCliente
            // 
            this.TBDniCliente.AcceptsTab = true;
            this.TBDniCliente.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDniCliente.Location = new System.Drawing.Point(190, 45);
            this.TBDniCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBDniCliente.Name = "TBDniCliente";
            this.TBDniCliente.Size = new System.Drawing.Size(164, 25);
            this.TBDniCliente.TabIndex = 21;
            // 
            // LApellido
            // 
            this.LApellido.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.Location = new System.Drawing.Point(25, 119);
            this.LApellido.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(68, 14);
            this.LApellido.TabIndex = 19;
            this.LApellido.Text = "Apellido/s:";
            // 
            // LNombre
            // 
            this.LNombre.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(24, 83);
            this.LNombre.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(63, 14);
            this.LNombre.TabIndex = 18;
            this.LNombre.Text = "Nombre/s:";
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDni.Location = new System.Drawing.Point(147, 50);
            this.LDni.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(33, 14);
            this.LDni.TabIndex = 17;
            this.LDni.Text = "DNI:";
            // 
            // LCargaCliente
            // 
            this.LCargaCliente.AutoSize = true;
            this.LCargaCliente.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCargaCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LCargaCliente.Location = new System.Drawing.Point(24, 18);
            this.LCargaCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LCargaCliente.Name = "LCargaCliente";
            this.LCargaCliente.Size = new System.Drawing.Size(82, 16);
            this.LCargaCliente.TabIndex = 16;
            this.LCargaCliente.Text = "CLIENTE";
            // 
            // BBuscarCliente
            // 
            this.BBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BBuscarCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BBuscarCliente.Location = new System.Drawing.Point(361, 45);
            this.BBuscarCliente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BBuscarCliente.Name = "BBuscarCliente";
            this.BBuscarCliente.Size = new System.Drawing.Size(81, 25);
            this.BBuscarCliente.TabIndex = 2;
            this.BBuscarCliente.Text = "Buscar";
            this.BBuscarCliente.UseVisualStyleBackColor = false;
            // 
            // PanelProductos
            // 
            this.PanelProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelProductos.BackColor = System.Drawing.Color.White;
            this.PanelProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelProductos.Controls.Add(this.LStockCantidad);
            this.PanelProductos.Controls.Add(this.NUDCantidad);
            this.PanelProductos.Controls.Add(this.LPrecioUnitario);
            this.PanelProductos.Controls.Add(this.CBProductos);
            this.PanelProductos.Controls.Add(this.BAgregarItem);
            this.PanelProductos.Controls.Add(this.LStockDisponible);
            this.PanelProductos.Controls.Add(this.LCantidad);
            this.PanelProductos.Controls.Add(this.LPrecio);
            this.PanelProductos.Controls.Add(this.BBuscarProducto);
            this.PanelProductos.Controls.Add(this.LProducto);
            this.PanelProductos.Controls.Add(this.LProductos);
            this.PanelProductos.Location = new System.Drawing.Point(24, 268);
            this.PanelProductos.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PanelProductos.Name = "PanelProductos";
            this.PanelProductos.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.PanelProductos.Size = new System.Drawing.Size(715, 172);
            this.PanelProductos.TabIndex = 21;
            // 
            // LStockCantidad
            // 
            this.LStockCantidad.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LStockCantidad.Location = new System.Drawing.Point(627, 92);
            this.LStockCantidad.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LStockCantidad.Name = "LStockCantidad";
            this.LStockCantidad.Size = new System.Drawing.Size(60, 14);
            this.LStockCantidad.TabIndex = 32;
            this.LStockCantidad.Text = "-";
            // 
            // NUDCantidad
            // 
            this.NUDCantidad.Location = new System.Drawing.Point(325, 84);
            this.NUDCantidad.Name = "NUDCantidad";
            this.NUDCantidad.Size = new System.Drawing.Size(120, 20);
            this.NUDCantidad.TabIndex = 31;
            // 
            // LPrecioUnitario
            // 
            this.LPrecioUnitario.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPrecioUnitario.Location = new System.Drawing.Point(95, 88);
            this.LPrecioUnitario.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LPrecioUnitario.Name = "LPrecioUnitario";
            this.LPrecioUnitario.Size = new System.Drawing.Size(60, 14);
            this.LPrecioUnitario.TabIndex = 29;
            this.LPrecioUnitario.Text = "$";
            // 
            // CBProductos
            // 
            this.CBProductos.FormattingEnabled = true;
            this.CBProductos.Location = new System.Drawing.Point(239, 42);
            this.CBProductos.Name = "CBProductos";
            this.CBProductos.Size = new System.Drawing.Size(225, 21);
            this.CBProductos.TabIndex = 28;
            this.CBProductos.Tag = "";
            // 
            // BAgregarItem
            // 
            this.BAgregarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BAgregarItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BAgregarItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BAgregarItem.Location = new System.Drawing.Point(568, 126);
            this.BAgregarItem.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BAgregarItem.Name = "BAgregarItem";
            this.BAgregarItem.Size = new System.Drawing.Size(120, 31);
            this.BAgregarItem.TabIndex = 27;
            this.BAgregarItem.Text = "+ Agregar Ítem";
            this.BAgregarItem.UseVisualStyleBackColor = false;
            // 
            // LStockDisponible
            // 
            this.LStockDisponible.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LStockDisponible.Location = new System.Drawing.Point(512, 92);
            this.LStockDisponible.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LStockDisponible.Name = "LStockDisponible";
            this.LStockDisponible.Size = new System.Drawing.Size(105, 14);
            this.LStockDisponible.TabIndex = 25;
            this.LStockDisponible.Text = "Stock Disponible:";
            // 
            // LCantidad
            // 
            this.LCantidad.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCantidad.Location = new System.Drawing.Point(252, 88);
            this.LCantidad.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LCantidad.Name = "LCantidad";
            this.LCantidad.Size = new System.Drawing.Size(65, 14);
            this.LCantidad.TabIndex = 26;
            this.LCantidad.Text = "Cantidad";
            // 
            // LPrecio
            // 
            this.LPrecio.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPrecio.Location = new System.Drawing.Point(33, 88);
            this.LPrecio.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LPrecio.Name = "LPrecio";
            this.LPrecio.Size = new System.Drawing.Size(52, 14);
            this.LPrecio.TabIndex = 24;
            this.LPrecio.Text = "Precio:";
            // 
            // BBuscarProducto
            // 
            this.BBuscarProducto.BackColor = System.Drawing.Color.Gainsboro;
            this.BBuscarProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BBuscarProducto.Image = global::Presentation.Properties.Resources.lupa;
            this.BBuscarProducto.Location = new System.Drawing.Point(472, 42);
            this.BBuscarProducto.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BBuscarProducto.MaximumSize = new System.Drawing.Size(55, 25);
            this.BBuscarProducto.MinimumSize = new System.Drawing.Size(55, 25);
            this.BBuscarProducto.Name = "BBuscarProducto";
            this.BBuscarProducto.Size = new System.Drawing.Size(55, 25);
            this.BBuscarProducto.TabIndex = 23;
            this.BBuscarProducto.UseVisualStyleBackColor = false;
            // 
            // LProducto
            // 
            this.LProducto.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProducto.Location = new System.Drawing.Point(171, 47);
            this.LProducto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LProducto.Name = "LProducto";
            this.LProducto.Size = new System.Drawing.Size(60, 14);
            this.LProducto.TabIndex = 19;
            this.LProducto.Text = "Producto:";
            // 
            // LProductos
            // 
            this.LProductos.AutoSize = true;
            this.LProductos.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LProductos.Location = new System.Drawing.Point(24, 18);
            this.LProductos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LProductos.Name = "LProductos";
            this.LProductos.Size = new System.Drawing.Size(114, 16);
            this.LProductos.TabIndex = 17;
            this.LProductos.Text = "PRODUCTOS";
            // 
            // PanelDetalle
            // 
            this.PanelDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelDetalle.BackColor = System.Drawing.Color.White;
            this.PanelDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelDetalle.Controls.Add(this.DGVCarrito);
            this.PanelDetalle.Controls.Add(this.label1);
            this.PanelDetalle.Location = new System.Drawing.Point(24, 448);
            this.PanelDetalle.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PanelDetalle.Name = "PanelDetalle";
            this.PanelDetalle.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.PanelDetalle.Size = new System.Drawing.Size(715, 227);
            this.PanelDetalle.TabIndex = 22;
            // 
            // DGVCarrito
            // 
            this.DGVCarrito.AllowUserToOrderColumns = true;
            this.DGVCarrito.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDProducto,
            this.Nombre,
            this.Precio,
            this.Cantidad,
            this.Subtotal,
            this.Quitar});
            this.DGVCarrito.Location = new System.Drawing.Point(-1, 48);
            this.DGVCarrito.Name = "DGVCarrito";
            this.DGVCarrito.RowHeadersWidth = 51;
            this.DGVCarrito.RowTemplate.Height = 24;
            this.DGVCarrito.Size = new System.Drawing.Size(715, 167);
            this.DGVCarrito.TabIndex = 19;
            // 
            // IDProducto
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDProducto.DefaultCellStyle = dataGridViewCellStyle7;
            this.IDProducto.HeaderText = "IDProducto";
            this.IDProducto.MinimumWidth = 6;
            this.IDProducto.Name = "IDProducto";
            this.IDProducto.Visible = false;
            // 
            // Nombre
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombre.DefaultCellStyle = dataGridViewCellStyle8;
            this.Nombre.HeaderText = "Descripción /Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            // 
            // Precio
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Precio.DefaultCellStyle = dataGridViewCellStyle9;
            this.Precio.HeaderText = "Precio Unitario";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            // 
            // Cantidad
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle10;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            // 
            // Subtotal
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subtotal.DefaultCellStyle = dataGridViewCellStyle11;
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.MinimumWidth = 6;
            this.Subtotal.Name = "Subtotal";
            // 
            // Quitar
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.NullValue = null;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Red;
            this.Quitar.DefaultCellStyle = dataGridViewCellStyle12;
            this.Quitar.HeaderText = "Acción";
            this.Quitar.MinimumWidth = 6;
            this.Quitar.Name = "Quitar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "DETALLE DEL CARRITO";
            // 
            // PResumen
            // 
            this.PResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PResumen.BackColor = System.Drawing.Color.White;
            this.PResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PResumen.Controls.Add(this.LVueltoNumerico);
            this.PResumen.Controls.Add(this.LTotalPagar);
            this.PResumen.Controls.Add(this.TBMontoAbonado);
            this.PResumen.Controls.Add(this.CBFormaPago);
            this.PResumen.Controls.Add(this.LDescuentoNumerico);
            this.PResumen.Controls.Add(this.LSubtotalNumerico);
            this.PResumen.Controls.Add(this.BCancelarVenta);
            this.PResumen.Controls.Add(this.BConfirmarVenta);
            this.PResumen.Controls.Add(this.LVuelto);
            this.PResumen.Controls.Add(this.LMontoRecibido);
            this.PResumen.Controls.Add(this.LFormaPago);
            this.PResumen.Controls.Add(this.LTotal);
            this.PResumen.Controls.Add(this.LDescuento);
            this.PResumen.Controls.Add(this.LSubtotal);
            this.PResumen.Controls.Add(this.LTotalCobro);
            this.PResumen.Location = new System.Drawing.Point(749, 88);
            this.PResumen.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PResumen.Name = "PResumen";
            this.PResumen.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.PResumen.Size = new System.Drawing.Size(327, 587);
            this.PResumen.TabIndex = 23;
            // 
            // LVueltoNumerico
            // 
            this.LVueltoNumerico.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LVueltoNumerico.Location = new System.Drawing.Point(125, 376);
            this.LVueltoNumerico.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LVueltoNumerico.Name = "LVueltoNumerico";
            this.LVueltoNumerico.Size = new System.Drawing.Size(90, 15);
            this.LVueltoNumerico.TabIndex = 38;
            this.LVueltoNumerico.Text = "$";
            // 
            // LTotalPagar
            // 
            this.LTotalPagar.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTotalPagar.Location = new System.Drawing.Point(25, 179);
            this.LTotalPagar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LTotalPagar.Name = "LTotalPagar";
            this.LTotalPagar.Size = new System.Drawing.Size(90, 15);
            this.LTotalPagar.TabIndex = 37;
            this.LTotalPagar.Text = "$";
            // 
            // TBMontoAbonado
            // 
            this.TBMontoAbonado.Enabled = false;
            this.TBMontoAbonado.Location = new System.Drawing.Point(28, 328);
            this.TBMontoAbonado.Name = "TBMontoAbonado";
            this.TBMontoAbonado.Size = new System.Drawing.Size(274, 20);
            this.TBMontoAbonado.TabIndex = 36;
            this.TBMontoAbonado.Text = "$";
            // 
            // CBFormaPago
            // 
            this.CBFormaPago.Enabled = false;
            this.CBFormaPago.FormattingEnabled = true;
            this.CBFormaPago.Location = new System.Drawing.Point(28, 258);
            this.CBFormaPago.Name = "CBFormaPago";
            this.CBFormaPago.Size = new System.Drawing.Size(274, 21);
            this.CBFormaPago.TabIndex = 35;
            this.CBFormaPago.Tag = "";
            // 
            // LDescuentoNumerico
            // 
            this.LDescuentoNumerico.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDescuentoNumerico.Location = new System.Drawing.Point(125, 99);
            this.LDescuentoNumerico.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LDescuentoNumerico.Name = "LDescuentoNumerico";
            this.LDescuentoNumerico.Size = new System.Drawing.Size(90, 15);
            this.LDescuentoNumerico.TabIndex = 34;
            this.LDescuentoNumerico.Text = "$";
            // 
            // LSubtotalNumerico
            // 
            this.LSubtotalNumerico.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSubtotalNumerico.Location = new System.Drawing.Point(125, 65);
            this.LSubtotalNumerico.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LSubtotalNumerico.Name = "LSubtotalNumerico";
            this.LSubtotalNumerico.Size = new System.Drawing.Size(90, 15);
            this.LSubtotalNumerico.TabIndex = 33;
            this.LSubtotalNumerico.Text = "$";
            // 
            // BCancelarVenta
            // 
            this.BCancelarVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BCancelarVenta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BCancelarVenta.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BCancelarVenta.FlatAppearance.BorderSize = 2;
            this.BCancelarVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.BCancelarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelarVenta.ForeColor = System.Drawing.Color.Firebrick;
            this.BCancelarVenta.Location = new System.Drawing.Point(12, 549);
            this.BCancelarVenta.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BCancelarVenta.Name = "BCancelarVenta";
            this.BCancelarVenta.Size = new System.Drawing.Size(123, 26);
            this.BCancelarVenta.TabIndex = 32;
            this.BCancelarVenta.Text = "Cancelar Venta";
            this.BCancelarVenta.UseVisualStyleBackColor = false;
            // 
            // BConfirmarVenta
            // 
            this.BConfirmarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BConfirmarVenta.Enabled = false;
            this.BConfirmarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BConfirmarVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BConfirmarVenta.Location = new System.Drawing.Point(69, 424);
            this.BConfirmarVenta.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BConfirmarVenta.Name = "BConfirmarVenta";
            this.BConfirmarVenta.Size = new System.Drawing.Size(184, 31);
            this.BConfirmarVenta.TabIndex = 31;
            this.BConfirmarVenta.Text = "CONFIRMAR VENTA";
            this.BConfirmarVenta.UseVisualStyleBackColor = false;
            // 
            // LVuelto
            // 
            this.LVuelto.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LVuelto.Location = new System.Drawing.Point(25, 377);
            this.LVuelto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LVuelto.Name = "LVuelto";
            this.LVuelto.Size = new System.Drawing.Size(126, 14);
            this.LVuelto.TabIndex = 30;
            this.LVuelto.Text = "Vuelto:";
            // 
            // LMontoRecibido
            // 
            this.LMontoRecibido.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMontoRecibido.Location = new System.Drawing.Point(24, 306);
            this.LMontoRecibido.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LMontoRecibido.Name = "LMontoRecibido";
            this.LMontoRecibido.Size = new System.Drawing.Size(126, 14);
            this.LMontoRecibido.TabIndex = 29;
            this.LMontoRecibido.Text = "Monto Recibido:";
            // 
            // LFormaPago
            // 
            this.LFormaPago.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFormaPago.Location = new System.Drawing.Point(24, 241);
            this.LFormaPago.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LFormaPago.Name = "LFormaPago";
            this.LFormaPago.Size = new System.Drawing.Size(126, 14);
            this.LFormaPago.TabIndex = 28;
            this.LFormaPago.Text = "Forma de Pago:";
            // 
            // LTotal
            // 
            this.LTotal.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTotal.Location = new System.Drawing.Point(25, 158);
            this.LTotal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LTotal.Name = "LTotal";
            this.LTotal.Size = new System.Drawing.Size(126, 14);
            this.LTotal.TabIndex = 27;
            this.LTotal.Text = "TOTAL A COBRAR:";
            // 
            // LDescuento
            // 
            this.LDescuento.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDescuento.Location = new System.Drawing.Point(25, 100);
            this.LDescuento.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LDescuento.Name = "LDescuento";
            this.LDescuento.Size = new System.Drawing.Size(90, 14);
            this.LDescuento.TabIndex = 26;
            this.LDescuento.Text = "DESCUENTO:";
            // 
            // LSubtotal
            // 
            this.LSubtotal.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSubtotal.Location = new System.Drawing.Point(25, 65);
            this.LSubtotal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LSubtotal.Name = "LSubtotal";
            this.LSubtotal.Size = new System.Drawing.Size(90, 15);
            this.LSubtotal.TabIndex = 25;
            this.LSubtotal.Text = "SUBTOTAL:";
            // 
            // LTotalCobro
            // 
            this.LTotalCobro.AutoSize = true;
            this.LTotalCobro.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTotalCobro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LTotalCobro.Location = new System.Drawing.Point(24, 18);
            this.LTotalCobro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTotalCobro.Name = "LTotalCobro";
            this.LTotalCobro.Size = new System.Drawing.Size(151, 16);
            this.LTotalCobro.TabIndex = 17;
            this.LTotalCobro.Text = "TOTAL Y COBRO";
            // 
            // FormVenta
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.PResumen);
            this.Controls.Add(this.PanelDetalle);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.PanelCliente);
            this.Controls.Add(this.PanelProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormVenta";
            this.Text = "FormVenta";
            this.Load += new System.EventHandler(this.FormVenta_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.PanelCliente.ResumeLayout(false);
            this.PanelCliente.PerformLayout();
            this.PanelProductos.ResumeLayout(false);
            this.PanelProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCantidad)).EndInit();
            this.PanelDetalle.ResumeLayout(false);
            this.PanelDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCarrito)).EndInit();
            this.PResumen.ResumeLayout(false);
            this.PResumen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label LTitleGestionVentas;
        private System.Windows.Forms.Button BBuscarCliente;
        private System.Windows.Forms.Panel PanelProductos;
        private System.Windows.Forms.Panel PanelDetalle;
        private System.Windows.Forms.Panel PResumen;
        private System.Windows.Forms.Label LCargaCliente;
        private System.Windows.Forms.Label LProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.CheckBox ChkConsumidorFinal;
        private System.Windows.Forms.TextBox TBDniCliente;
        private System.Windows.Forms.TextBox TBTelefonoCliente;
        private System.Windows.Forms.TextBox TBApellidoCliente;
        private System.Windows.Forms.TextBox TBNombreCliente;
        private System.Windows.Forms.TextBox TBEmailCliente;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.Label LProducto;
        private System.Windows.Forms.Label LCantidad;
        private System.Windows.Forms.Label LStockDisponible;
        private System.Windows.Forms.Label LPrecio;
        private System.Windows.Forms.Button BBuscarProducto;
        private System.Windows.Forms.Button BAgregarItem;
        protected internal System.Windows.Forms.Panel PanelCliente;
        private System.Windows.Forms.ComboBox CBProductos;
        private System.Windows.Forms.NumericUpDown NUDCantidad;
        private System.Windows.Forms.Label LPrecioUnitario;
        private System.Windows.Forms.Label LStockCantidad;
        private System.Windows.Forms.DataGridView DGVCarrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewButtonColumn Quitar;
        private System.Windows.Forms.Label LTotalCobro;
        private System.Windows.Forms.Label LDescuento;
        private System.Windows.Forms.Label LSubtotal;
        private System.Windows.Forms.Button BCancelarVenta;
        private System.Windows.Forms.Button BConfirmarVenta;
        private System.Windows.Forms.Label LVuelto;
        private System.Windows.Forms.Label LMontoRecibido;
        private System.Windows.Forms.Label LFormaPago;
        private System.Windows.Forms.Label LTotal;
        private System.Windows.Forms.Label LDescuentoNumerico;
        private System.Windows.Forms.Label LSubtotalNumerico;
        private System.Windows.Forms.Label LTotalPagar;
        private System.Windows.Forms.TextBox TBMontoAbonado;
        private System.Windows.Forms.ComboBox CBFormaPago;
        private System.Windows.Forms.Label LVueltoNumerico;
    }
}