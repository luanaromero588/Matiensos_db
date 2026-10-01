namespace Presentation.GestionVentas
{
    partial class FormNuevoCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNuevoCliente));
            this.LDatosPersonales = new System.Windows.Forms.Label();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.LEmail = new System.Windows.Forms.Label();
            this.TBApellido = new System.Windows.Forms.TextBox();
            this.LTelefono = new System.Windows.Forms.Label();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.TBTelefono = new System.Windows.Forms.TextBox();
            this.TBDni = new System.Windows.Forms.TextBox();
            this.LApellido = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.LDni = new System.Windows.Forms.Label();
            this.BGuardar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.PContenedorModal = new System.Windows.Forms.Panel();
            this.PCuerpo = new System.Windows.Forms.Panel();
            this.PHeader = new System.Windows.Forms.Panel();
            this.LCerrar = new System.Windows.Forms.Label();
            this.FLPLineaDivisoria = new System.Windows.Forms.FlowLayoutPanel();
            this.LTituloModal = new System.Windows.Forms.Label();
            this.PBTituloModal = new System.Windows.Forms.PictureBox();
            this.PFooter = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.PContenedorModal.SuspendLayout();
            this.PCuerpo.SuspendLayout();
            this.PHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBTituloModal)).BeginInit();
            this.PFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // LDatosPersonales
            // 
            this.LDatosPersonales.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDatosPersonales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LDatosPersonales.Location = new System.Drawing.Point(30, 18);
            this.LDatosPersonales.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LDatosPersonales.Name = "LDatosPersonales";
            this.LDatosPersonales.Size = new System.Drawing.Size(192, 17);
            this.LDatosPersonales.TabIndex = 5;
            this.LDatosPersonales.Text = "DATOS PERSONALES";
            // 
            // TBEmail
            // 
            this.TBEmail.AcceptsTab = true;
            this.TBEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBEmail.Location = new System.Drawing.Point(285, 220);
            this.TBEmail.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(224, 25);
            this.TBEmail.TabIndex = 4;
            // 
            // LEmail
            // 
            this.LEmail.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEmail.Location = new System.Drawing.Point(285, 196);
            this.LEmail.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(55, 14);
            this.LEmail.TabIndex = 36;
            this.LEmail.Text = "E-mail:";
            // 
            // TBApellido
            // 
            this.TBApellido.AcceptsTab = true;
            this.TBApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBApellido.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBApellido.Location = new System.Drawing.Point(285, 152);
            this.TBApellido.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TBApellido.Name = "TBApellido";
            this.TBApellido.Size = new System.Drawing.Size(224, 25);
            this.TBApellido.TabIndex = 2;
            this.TBApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBApellido_KeyPress);
            // 
            // LTelefono
            // 
            this.LTelefono.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.Location = new System.Drawing.Point(30, 196);
            this.LTelefono.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(70, 14);
            this.LTelefono.TabIndex = 30;
            this.LTelefono.Text = "Telefono:";
            // 
            // TBNombre
            // 
            this.TBNombre.AcceptsTab = true;
            this.TBNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNombre.Location = new System.Drawing.Point(30, 152);
            this.TBNombre.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(224, 25);
            this.TBNombre.TabIndex = 1;
            this.TBNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNombre_KeyPress);
            // 
            // TBTelefono
            // 
            this.TBTelefono.AcceptsTab = true;
            this.TBTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBTelefono.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTelefono.Location = new System.Drawing.Point(30, 220);
            this.TBTelefono.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TBTelefono.MaxLength = 8;
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(224, 25);
            this.TBTelefono.TabIndex = 3;
            this.TBTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBTelefono_KeyPress);
            // 
            // TBDni
            // 
            this.TBDni.AcceptsTab = true;
            this.TBDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBDni.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDni.Location = new System.Drawing.Point(30, 84);
            this.TBDni.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TBDni.MaxLength = 8;
            this.TBDni.Name = "TBDni";
            this.TBDni.Size = new System.Drawing.Size(224, 25);
            this.TBDni.TabIndex = 0;
            this.TBDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBDni_KeyPress);
            this.TBDni.Leave += new System.EventHandler(this.TBDni_Leave);
            // 
            // LApellido
            // 
            this.LApellido.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.Location = new System.Drawing.Point(285, 128);
            this.LApellido.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(110, 14);
            this.LApellido.TabIndex = 29;
            this.LApellido.Text = "Apellido/s (*):";
            // 
            // LNombre
            // 
            this.LNombre.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(30, 128);
            this.LNombre.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(110, 14);
            this.LNombre.TabIndex = 3;
            this.LNombre.Text = "Nombre/s (*):";
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDni.Location = new System.Drawing.Point(30, 60);
            this.LDni.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(51, 14);
            this.LDni.TabIndex = 0;
            this.LDni.Text = "DNI (*):";
            // 
            // BGuardar
            // 
            this.BGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGuardar.FlatAppearance.BorderSize = 0;
            this.BGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardar.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BGuardar.Location = new System.Drawing.Point(102, 17);
            this.BGuardar.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(140, 30);
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
            this.BCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCancelar.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar.ForeColor = System.Drawing.Color.White;
            this.BCancelar.Location = new System.Drawing.Point(304, 17);
            this.BCancelar.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(140, 30);
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
            this.PContenedorModal.Controls.Add(this.PFooter);
            this.PContenedorModal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenedorModal.Location = new System.Drawing.Point(0, 0);
            this.PContenedorModal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PContenedorModal.Name = "PContenedorModal";
            this.PContenedorModal.Size = new System.Drawing.Size(553, 479);
            this.PContenedorModal.TabIndex = 37;
            // 
            // PCuerpo
            // 
            this.PCuerpo.BackColor = System.Drawing.Color.White;
            this.PCuerpo.Controls.Add(this.LDatosPersonales);
            this.PCuerpo.Controls.Add(this.LDni);
            this.PCuerpo.Controls.Add(this.LNombre);
            this.PCuerpo.Controls.Add(this.TBApellido);
            this.PCuerpo.Controls.Add(this.TBNombre);
            this.PCuerpo.Controls.Add(this.TBDni);
            this.PCuerpo.Controls.Add(this.LApellido);
            this.PCuerpo.Controls.Add(this.LEmail);
            this.PCuerpo.Controls.Add(this.TBEmail);
            this.PCuerpo.Controls.Add(this.LTelefono);
            this.PCuerpo.Controls.Add(this.TBTelefono);
            this.PCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCuerpo.Location = new System.Drawing.Point(0, 55);
            this.PCuerpo.Name = "PCuerpo";
            this.PCuerpo.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.PCuerpo.Size = new System.Drawing.Size(553, 364);
            this.PCuerpo.TabIndex = 37;
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.PHeader.Controls.Add(this.LCerrar);
            this.PHeader.Controls.Add(this.FLPLineaDivisoria);
            this.PHeader.Controls.Add(this.LTituloModal);
            this.PHeader.Controls.Add(this.PBTituloModal);
            this.PHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeader.Location = new System.Drawing.Point(0, 0);
            this.PHeader.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PHeader.Name = "PHeader";
            this.PHeader.Size = new System.Drawing.Size(553, 55);
            this.PHeader.TabIndex = 35;
            // 
            // LCerrar
            // 
            this.LCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LCerrar.AutoSize = true;
            this.LCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LCerrar.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.LCerrar.Location = new System.Drawing.Point(510, 19);
            this.LCerrar.Name = "LCerrar";
            this.LCerrar.Size = new System.Drawing.Size(20, 16);
            this.LCerrar.TabIndex = 3;
            this.LCerrar.Text = "X";
            this.LCerrar.Click += new System.EventHandler(this.LCerrar_Click);
            // 
            // FLPLineaDivisoria
            // 
            this.FLPLineaDivisoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.FLPLineaDivisoria.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FLPLineaDivisoria.Location = new System.Drawing.Point(0, 53);
            this.FLPLineaDivisoria.Name = "FLPLineaDivisoria";
            this.FLPLineaDivisoria.Size = new System.Drawing.Size(553, 2);
            this.FLPLineaDivisoria.TabIndex = 2;
            // 
            // LTituloModal
            // 
            this.LTituloModal.AutoSize = true;
            this.LTituloModal.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloModal.Location = new System.Drawing.Point(76, 14);
            this.LTituloModal.Name = "LTituloModal";
            this.LTituloModal.Size = new System.Drawing.Size(146, 23);
            this.LTituloModal.TabIndex = 1;
            this.LTituloModal.Text = "Nuevo Cliente";
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
            // PFooter
            // 
            this.PFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.PFooter.Controls.Add(this.flowLayoutPanel1);
            this.PFooter.Controls.Add(this.BCancelar);
            this.PFooter.Controls.Add(this.BGuardar);
            this.PFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PFooter.Location = new System.Drawing.Point(0, 419);
            this.PFooter.Name = "PFooter";
            this.PFooter.Size = new System.Drawing.Size(553, 60);
            this.PFooter.TabIndex = 36;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(553, 2);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // FormNuevoCliente
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(553, 479);
            this.ControlBox = false;
            this.Controls.Add(this.PContenedorModal);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(522, 479);
            this.Name = "FormNuevoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FormNuevoCliente_Load);
            this.PContenedorModal.ResumeLayout(false);
            this.PCuerpo.ResumeLayout(false);
            this.PCuerpo.PerformLayout();
            this.PHeader.ResumeLayout(false);
            this.PHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBTituloModal)).EndInit();
            this.PFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LDatosPersonales;
        private System.Windows.Forms.TextBox TBEmail;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.TextBox TBApellido;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.TextBox TBTelefono;
        private System.Windows.Forms.TextBox TBDni;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Panel PContenedorModal;
        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Panel PCuerpo;
        private System.Windows.Forms.Panel PFooter;
        private System.Windows.Forms.FlowLayoutPanel FLPLineaDivisoria;
        private System.Windows.Forms.Label LTituloModal;
        private System.Windows.Forms.PictureBox PBTituloModal;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label LCerrar;
    }
}