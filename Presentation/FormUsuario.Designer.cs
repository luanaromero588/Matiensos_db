namespace Presentation
{
    partial class FormUsuario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LTitleGestionUsuarios = new System.Windows.Forms.Label();
            this.PPanelDivisorio = new System.Windows.Forms.Panel();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.BGuardar = new System.Windows.Forms.Button();
            this.TBContraseña = new System.Windows.Forms.TextBox();
            this.LRolAsignado = new System.Windows.Forms.Label();
            this.LContraseña = new System.Windows.Forms.Label();
            this.TBTelefono = new System.Windows.Forms.TextBox();
            this.TBCorreo = new System.Windows.Forms.TextBox();
            this.TBApellido = new System.Windows.Forms.TextBox();
            this.TBDni = new System.Windows.Forms.TextBox();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.LTeléfono = new System.Windows.Forms.Label();
            this.LCorreo = new System.Windows.Forms.Label();
            this.LDni = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.CBRolAsignado = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGVUsuarios = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BBuscar = new System.Windows.Forms.Button();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LTitleGestionUsuarios);
            this.panel1.Controls.Add(this.PPanelDivisorio);
            this.panel1.Controls.Add(this.BLimpiar);
            this.panel1.Controls.Add(this.BGuardar);
            this.panel1.Controls.Add(this.TBContraseña);
            this.panel1.Controls.Add(this.LRolAsignado);
            this.panel1.Controls.Add(this.LContraseña);
            this.panel1.Controls.Add(this.TBTelefono);
            this.panel1.Controls.Add(this.TBCorreo);
            this.panel1.Controls.Add(this.TBApellido);
            this.panel1.Controls.Add(this.TBDni);
            this.panel1.Controls.Add(this.TBNombre);
            this.panel1.Controls.Add(this.LTeléfono);
            this.panel1.Controls.Add(this.LCorreo);
            this.panel1.Controls.Add(this.LDni);
            this.panel1.Controls.Add(this.LApellido);
            this.panel1.Controls.Add(this.LNombre);
            this.panel1.Controls.Add(this.CBRolAsignado);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 700);
            this.panel1.TabIndex = 0;
            // 
            // LTitleGestionUsuarios
            // 
            this.LTitleGestionUsuarios.AutoSize = true;
            this.LTitleGestionUsuarios.Font = new System.Drawing.Font("Mongolian Baiti", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitleGestionUsuarios.Location = new System.Drawing.Point(57, 50);
            this.LTitleGestionUsuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTitleGestionUsuarios.Name = "LTitleGestionUsuarios";
            this.LTitleGestionUsuarios.Size = new System.Drawing.Size(277, 31);
            this.LTitleGestionUsuarios.TabIndex = 17;
            this.LTitleGestionUsuarios.Text = "Gestión de Usuarios";
            // 
            // PPanelDivisorio
            // 
            this.PPanelDivisorio.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.PPanelDivisorio.Location = new System.Drawing.Point(398, 82);
            this.PPanelDivisorio.Name = "PPanelDivisorio";
            this.PPanelDivisorio.Size = new System.Drawing.Size(4, 560);
            this.PPanelDivisorio.TabIndex = 16;
            // 
            // BLimpiar
            // 
            this.BLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BLimpiar.Location = new System.Drawing.Point(213, 539);
            this.BLimpiar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BLimpiar.Size = new System.Drawing.Size(110, 40);
            this.BLimpiar.TabIndex = 1;
            this.BLimpiar.Text = "Limpiar";
            this.BLimpiar.UseVisualStyleBackColor = false;
            this.BLimpiar.Click += new System.EventHandler(this.BLimpiar_Click);
            // 
            // BGuardar
            // 
            this.BGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BGuardar.Location = new System.Drawing.Point(73, 539);
            this.BGuardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(110, 40);
            this.BGuardar.TabIndex = 14;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = false;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // TBContraseña
            // 
            this.TBContraseña.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBContraseña.Location = new System.Drawing.Point(73, 429);
            this.TBContraseña.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBContraseña.Name = "TBContraseña";
            this.TBContraseña.Size = new System.Drawing.Size(250, 25);
            this.TBContraseña.TabIndex = 13;
            // 
            // LRolAsignado
            // 
            this.LRolAsignado.AutoSize = true;
            this.LRolAsignado.Location = new System.Drawing.Point(70, 470);
            this.LRolAsignado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LRolAsignado.Name = "LRolAsignado";
            this.LRolAsignado.Size = new System.Drawing.Size(83, 14);
            this.LRolAsignado.TabIndex = 12;
            this.LRolAsignado.Text = "Rol asignado:";
            // 
            // LContraseña
            // 
            this.LContraseña.AutoSize = true;
            this.LContraseña.Location = new System.Drawing.Point(70, 411);
            this.LContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LContraseña.Name = "LContraseña";
            this.LContraseña.Size = new System.Drawing.Size(72, 14);
            this.LContraseña.TabIndex = 11;
            this.LContraseña.Text = "Contraseña:";
            // 
            // TBTelefono
            // 
            this.TBTelefono.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTelefono.Location = new System.Drawing.Point(73, 373);
            this.TBTelefono.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(250, 25);
            this.TBTelefono.TabIndex = 10;
            this.TBTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBTelefono_KeyPress);
            // 
            // TBCorreo
            // 
            this.TBCorreo.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCorreo.Location = new System.Drawing.Point(74, 317);
            this.TBCorreo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBCorreo.Name = "TBCorreo";
            this.TBCorreo.Size = new System.Drawing.Size(250, 25);
            this.TBCorreo.TabIndex = 9;
            // 
            // TBApellido
            // 
            this.TBApellido.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBApellido.Location = new System.Drawing.Point(74, 202);
            this.TBApellido.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBApellido.Name = "TBApellido";
            this.TBApellido.Size = new System.Drawing.Size(250, 25);
            this.TBApellido.TabIndex = 8;
            this.TBApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBApellido_KeyPress);
            // 
            // TBDni
            // 
            this.TBDni.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDni.Location = new System.Drawing.Point(74, 264);
            this.TBDni.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBDni.Name = "TBDni";
            this.TBDni.Size = new System.Drawing.Size(250, 25);
            this.TBDni.TabIndex = 7;
            this.TBDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBDni_KeyPress);
            // 
            // TBNombre
            // 
            this.TBNombre.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNombre.Location = new System.Drawing.Point(73, 148);
            this.TBNombre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(250, 25);
            this.TBNombre.TabIndex = 6;
            this.TBNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNombre_KeyPress);
            // 
            // LTeléfono
            // 
            this.LTeléfono.AutoSize = true;
            this.LTeléfono.Location = new System.Drawing.Point(70, 355);
            this.LTeléfono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTeléfono.Name = "LTeléfono";
            this.LTeléfono.Size = new System.Drawing.Size(60, 14);
            this.LTeléfono.TabIndex = 5;
            this.LTeléfono.Text = "Teléfono:";
            // 
            // LCorreo
            // 
            this.LCorreo.AutoSize = true;
            this.LCorreo.Location = new System.Drawing.Point(70, 299);
            this.LCorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LCorreo.Name = "LCorreo";
            this.LCorreo.Size = new System.Drawing.Size(114, 14);
            this.LCorreo.TabIndex = 4;
            this.LCorreo.Text = "Correo Electrónico:";
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Location = new System.Drawing.Point(70, 247);
            this.LDni.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(33, 14);
            this.LDni.TabIndex = 3;
            this.LDni.Text = "DNI:";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Location = new System.Drawing.Point(70, 185);
            this.LApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(59, 14);
            this.LApellido.TabIndex = 2;
            this.LApellido.Text = "Apellido:";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Location = new System.Drawing.Point(70, 130);
            this.LNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(54, 14);
            this.LNombre.TabIndex = 1;
            this.LNombre.Text = "Nombre:";
            // 
            // CBRolAsignado
            // 
            this.CBRolAsignado.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBRolAsignado.FormattingEnabled = true;
            this.CBRolAsignado.Location = new System.Drawing.Point(74, 487);
            this.CBRolAsignado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CBRolAsignado.Name = "CBRolAsignado";
            this.CBRolAsignado.Size = new System.Drawing.Size(250, 24);
            this.CBRolAsignado.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DGVUsuarios);
            this.panel2.Controls.Add(this.BBuscar);
            this.panel2.Controls.Add(this.TBBuscar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(400, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 700);
            this.panel2.TabIndex = 1;
            // 
            // DGVUsuarios
            // 
            this.DGVUsuarios.AllowUserToAddRows = false;
            this.DGVUsuarios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.DGVUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.DGVUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVUsuarios.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGVUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVUsuarios.ColumnHeadersHeight = 29;
            this.DGVUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column10,
            this.Column4,
            this.Column7,
            this.Column5,
            this.Column6,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVUsuarios.DefaultCellStyle = dataGridViewCellStyle20;
            this.DGVUsuarios.EnableHeadersVisualStyles = false;
            this.DGVUsuarios.Location = new System.Drawing.Point(82, 218);
            this.DGVUsuarios.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGVUsuarios.MultiSelect = false;
            this.DGVUsuarios.Name = "DGVUsuarios";
            this.DGVUsuarios.ReadOnly = true;
            this.DGVUsuarios.RowHeadersVisible = false;
            this.DGVUsuarios.RowHeadersWidth = 51;
            this.DGVUsuarios.RowTemplate.Height = 28;
            this.DGVUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVUsuarios.Size = new System.Drawing.Size(546, 162);
            this.DGVUsuarios.TabIndex = 0;
            this.DGVUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVUsuarios_CellContentClick);
            this.DGVUsuarios.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVUsuarios_CellPainting);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Nombre";
            this.Column2.HeaderText = "Nombre";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Apellido";
            this.Column3.HeaderText = "Apellido";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "DNI";
            this.Column10.HeaderText = "DNI";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Correo";
            this.Column4.HeaderText = "Correo";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Estado";
            this.Column7.HeaderText = "Estado";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Teléfono";
            this.Column5.HeaderText = "Teléfono";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Rol";
            this.Column6.HeaderText = "Rol";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column8
            // 
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.Magenta;
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Transparent;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle18;
            this.Column8.HeaderText = "Editar";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.Fuchsia;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle19;
            this.Column9.HeaderText = "Eliminar";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // BBuscar
            // 
            this.BBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BBuscar.Location = new System.Drawing.Point(473, 123);
            this.BBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(90, 38);
            this.BBuscar.TabIndex = 2;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = false;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            this.BBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BBuscar_KeyDown);
            // 
            // TBBuscar
            // 
            this.TBBuscar.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscar.Location = new System.Drawing.Point(165, 128);
            this.TBBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(300, 25);
            this.TBBuscar.TabIndex = 1;
            this.TBBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBBuscar_KeyPress);
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "Editar";
            this.colEditar.MinimumWidth = 6;
            this.colEditar.Name = "colEditar";
            this.colEditar.UseColumnTextForButtonValue = true;
            this.colEditar.Width = 259;
            // 
            // colEliminar
            // 
            this.colEliminar.HeaderText = "Eliminar";
            this.colEliminar.MinimumWidth = 6;
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.UseColumnTextForButtonValue = true;
            this.colEliminar.Width = 259;
            // 
            // FormUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormUsuario";
            this.Text = "FormUsuario";
            this.Load += new System.EventHandler(this.FormUsuario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.Label LTeléfono;
        private System.Windows.Forms.Label LCorreo;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.ComboBox CBRolAsignado;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TBTelefono;
        private System.Windows.Forms.TextBox TBCorreo;
        private System.Windows.Forms.TextBox TBApellido;
        private System.Windows.Forms.TextBox TBDni;
        private System.Windows.Forms.TextBox TBContraseña;
        private System.Windows.Forms.Label LRolAsignado;
        private System.Windows.Forms.Label LContraseña;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.DataGridView DGVUsuarios;
        private System.Windows.Forms.Panel PPanelDivisorio;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colEliminar;
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.Label LTitleGestionUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}