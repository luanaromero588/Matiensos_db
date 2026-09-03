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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.BGuardar = new System.Windows.Forms.Button();
            this.BEditar = new System.Windows.Forms.Button();
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
            this.BBuscar = new System.Windows.Forms.Button();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.DGVUsuarios = new System.Windows.Forms.DataGridView();
            this.BDesactivar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BLimpiar);
            this.panel1.Controls.Add(this.BGuardar);
            this.panel1.Controls.Add(this.BEditar);
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
            this.panel1.Size = new System.Drawing.Size(400, 485);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BLimpiar
            // 
            this.BLimpiar.Location = new System.Drawing.Point(271, 433);
            this.BLimpiar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BLimpiar.Size = new System.Drawing.Size(110, 40);
            this.BLimpiar.TabIndex = 1;
            this.BLimpiar.Text = "Limpiar";
            this.BLimpiar.UseVisualStyleBackColor = true;
            // 
            // BGuardar
            // 
            this.BGuardar.Location = new System.Drawing.Point(38, 433);
            this.BGuardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(110, 40);
            this.BGuardar.TabIndex = 14;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = false;
            // 
            // BEditar
            // 
            this.BEditar.Location = new System.Drawing.Point(153, 433);
            this.BEditar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BEditar.Name = "BEditar";
            this.BEditar.Size = new System.Drawing.Size(110, 40);
            this.BEditar.TabIndex = 0;
            this.BEditar.Text = "Editar";
            this.BEditar.UseVisualStyleBackColor = true;
            // 
            // TBContraseña
            // 
            this.TBContraseña.Location = new System.Drawing.Point(41, 345);
            this.TBContraseña.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBContraseña.Name = "TBContraseña";
            this.TBContraseña.Size = new System.Drawing.Size(116, 22);
            this.TBContraseña.TabIndex = 13;
            // 
            // LRolAsignado
            // 
            this.LRolAsignado.AutoSize = true;
            this.LRolAsignado.Location = new System.Drawing.Point(38, 369);
            this.LRolAsignado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LRolAsignado.Name = "LRolAsignado";
            this.LRolAsignado.Size = new System.Drawing.Size(83, 14);
            this.LRolAsignado.TabIndex = 12;
            this.LRolAsignado.Text = "Rol asignado:";
            this.LRolAsignado.Click += new System.EventHandler(this.LRolAsignado_Click);
            // 
            // LContraseña
            // 
            this.LContraseña.AutoSize = true;
            this.LContraseña.Location = new System.Drawing.Point(38, 327);
            this.LContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LContraseña.Name = "LContraseña";
            this.LContraseña.Size = new System.Drawing.Size(68, 14);
            this.LContraseña.TabIndex = 11;
            this.LContraseña.Text = "Contraseña";
            this.LContraseña.Click += new System.EventHandler(this.label1_Click);
            // 
            // TBTelefono
            // 
            this.TBTelefono.Location = new System.Drawing.Point(41, 289);
            this.TBTelefono.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(116, 22);
            this.TBTelefono.TabIndex = 10;
            // 
            // TBCorreo
            // 
            this.TBCorreo.Location = new System.Drawing.Point(42, 233);
            this.TBCorreo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBCorreo.Name = "TBCorreo";
            this.TBCorreo.Size = new System.Drawing.Size(116, 22);
            this.TBCorreo.TabIndex = 9;
            // 
            // TBApellido
            // 
            this.TBApellido.Location = new System.Drawing.Point(42, 118);
            this.TBApellido.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBApellido.Name = "TBApellido";
            this.TBApellido.Size = new System.Drawing.Size(116, 22);
            this.TBApellido.TabIndex = 8;
            // 
            // TBDni
            // 
            this.TBDni.Location = new System.Drawing.Point(42, 180);
            this.TBDni.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBDni.Name = "TBDni";
            this.TBDni.Size = new System.Drawing.Size(116, 22);
            this.TBDni.TabIndex = 7;
            // 
            // TBNombre
            // 
            this.TBNombre.Location = new System.Drawing.Point(41, 64);
            this.TBNombre.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(116, 22);
            this.TBNombre.TabIndex = 6;
            // 
            // LTeléfono
            // 
            this.LTeléfono.AutoSize = true;
            this.LTeléfono.Location = new System.Drawing.Point(38, 271);
            this.LTeléfono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LTeléfono.Name = "LTeléfono";
            this.LTeléfono.Size = new System.Drawing.Size(56, 14);
            this.LTeléfono.TabIndex = 5;
            this.LTeléfono.Text = "Teléfono";
            // 
            // LCorreo
            // 
            this.LCorreo.AutoSize = true;
            this.LCorreo.Location = new System.Drawing.Point(38, 215);
            this.LCorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LCorreo.Name = "LCorreo";
            this.LCorreo.Size = new System.Drawing.Size(110, 14);
            this.LCorreo.TabIndex = 4;
            this.LCorreo.Text = "Correo Electrónico";
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Location = new System.Drawing.Point(38, 163);
            this.LDni.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(33, 14);
            this.LDni.TabIndex = 3;
            this.LDni.Text = "DNI:";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Location = new System.Drawing.Point(38, 101);
            this.LApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(59, 14);
            this.LApellido.TabIndex = 2;
            this.LApellido.Text = "Apellido:";
            this.LApellido.Click += new System.EventHandler(this.LApellido_Click);
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Location = new System.Drawing.Point(38, 46);
            this.LNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(54, 14);
            this.LNombre.TabIndex = 1;
            this.LNombre.Text = "Nombre:";
            // 
            // CBRolAsignado
            // 
            this.CBRolAsignado.FormattingEnabled = true;
            this.CBRolAsignado.Location = new System.Drawing.Point(42, 387);
            this.CBRolAsignado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CBRolAsignado.Name = "CBRolAsignado";
            this.CBRolAsignado.Size = new System.Drawing.Size(140, 22);
            this.CBRolAsignado.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BDesactivar);
            this.panel2.Controls.Add(this.BBuscar);
            this.panel2.Controls.Add(this.TBBuscar);
            this.panel2.Controls.Add(this.DGVUsuarios);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(400, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(533, 485);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // BBuscar
            // 
            this.BBuscar.Location = new System.Drawing.Point(231, 61);
            this.BBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(90, 30);
            this.BBuscar.TabIndex = 2;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = true;
            // 
            // TBBuscar
            // 
            this.TBBuscar.Location = new System.Drawing.Point(93, 64);
            this.TBBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(116, 22);
            this.TBBuscar.TabIndex = 1;
            // 
            // DGVUsuarios
            // 
            this.DGVUsuarios.AllowUserToAddRows = false;
            this.DGVUsuarios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.DGVUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DGVUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVUsuarios.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGVUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVUsuarios.DefaultCellStyle = dataGridViewCellStyle8;
            this.DGVUsuarios.EnableHeadersVisualStyles = false;
            this.DGVUsuarios.Location = new System.Drawing.Point(4, 276);
            this.DGVUsuarios.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGVUsuarios.MultiSelect = false;
            this.DGVUsuarios.Name = "DGVUsuarios";
            this.DGVUsuarios.ReadOnly = true;
            this.DGVUsuarios.RowHeadersVisible = false;
            this.DGVUsuarios.RowTemplate.Height = 28;
            this.DGVUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVUsuarios.Size = new System.Drawing.Size(546, 162);
            this.DGVUsuarios.TabIndex = 0;
            this.DGVUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVUsuarios_CellContentClick);
            // 
            // BDesactivar
            // 
            this.BDesactivar.BackColor = System.Drawing.Color.OrangeRed;
            this.BDesactivar.Location = new System.Drawing.Point(380, 444);
            this.BDesactivar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BDesactivar.Name = "BDesactivar";
            this.BDesactivar.Size = new System.Drawing.Size(140, 38);
            this.BDesactivar.TabIndex = 15;
            this.BDesactivar.Text = "Desactivar / Eliminar";
            this.BDesactivar.UseVisualStyleBackColor = false;
            // 
            // FormUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(933, 485);
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
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button BEditar;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.DataGridView DGVUsuarios;
        private System.Windows.Forms.Button BDesactivar;
    }
}