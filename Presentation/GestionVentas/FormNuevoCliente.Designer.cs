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
            this.LDatosPersonales = new System.Windows.Forms.Label();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.LEmail = new System.Windows.Forms.Label();
            this.TBApellido = new System.Windows.Forms.TextBox();
            this.LTelefono = new System.Windows.Forms.Label();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.TBTelefono = new System.Windows.Forms.TextBox();
            this.ChkConsumidorFinal = new System.Windows.Forms.CheckBox();
            this.TBDni = new System.Windows.Forms.TextBox();
            this.LApellido = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.LDni = new System.Windows.Forms.Label();
            this.BGuardar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.GBDatosPersonales = new System.Windows.Forms.GroupBox();
            this.GBDatosPersonales.SuspendLayout();
            this.SuspendLayout();
            // 
            // LDatosPersonales
            // 
            this.LDatosPersonales.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDatosPersonales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LDatosPersonales.Location = new System.Drawing.Point(-1, 8);
            this.LDatosPersonales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LDatosPersonales.Name = "LDatosPersonales";
            this.LDatosPersonales.Size = new System.Drawing.Size(165, 17);
            this.LDatosPersonales.TabIndex = 5;
            this.LDatosPersonales.Text = "DATOS PERSONALES";
            // 
            // TBEmail
            // 
            this.TBEmail.AcceptsTab = true;
            this.TBEmail.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBEmail.Location = new System.Drawing.Point(240, 193);
            this.TBEmail.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(193, 25);
            this.TBEmail.TabIndex = 4;
            // 
            // LEmail
            // 
            this.LEmail.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEmail.Location = new System.Drawing.Point(237, 175);
            this.LEmail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(47, 14);
            this.LEmail.TabIndex = 36;
            this.LEmail.Text = "E-mail:";
            // 
            // TBApellido
            // 
            this.TBApellido.AcceptsTab = true;
            this.TBApellido.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBApellido.Location = new System.Drawing.Point(240, 129);
            this.TBApellido.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBApellido.Name = "TBApellido";
            this.TBApellido.Size = new System.Drawing.Size(193, 25);
            this.TBApellido.TabIndex = 2;
            this.TBApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBApellido_KeyPress);
            // 
            // LTelefono
            // 
            this.LTelefono.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.Location = new System.Drawing.Point(-1, 175);
            this.LTelefono.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(60, 14);
            this.LTelefono.TabIndex = 30;
            this.LTelefono.Text = "Telefono:";
            // 
            // TBNombre
            // 
            this.TBNombre.AcceptsTab = true;
            this.TBNombre.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNombre.Location = new System.Drawing.Point(0, 129);
            this.TBNombre.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(193, 25);
            this.TBNombre.TabIndex = 1;
            this.TBNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNombre_KeyPress);
            // 
            // TBTelefono
            // 
            this.TBTelefono.AcceptsTab = true;
            this.TBTelefono.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTelefono.Location = new System.Drawing.Point(0, 193);
            this.TBTelefono.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBTelefono.MaxLength = 8;
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(193, 25);
            this.TBTelefono.TabIndex = 3;
            this.TBTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBTelefono_KeyPress);
            // 
            // ChkConsumidorFinal
            // 
            this.ChkConsumidorFinal.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkConsumidorFinal.Location = new System.Drawing.Point(181, 415);
            this.ChkConsumidorFinal.Margin = new System.Windows.Forms.Padding(4);
            this.ChkConsumidorFinal.Name = "ChkConsumidorFinal";
            this.ChkConsumidorFinal.Size = new System.Drawing.Size(0, 0);
            this.ChkConsumidorFinal.TabIndex = 34;
            this.ChkConsumidorFinal.Text = "Consumidor Final";
            this.ChkConsumidorFinal.UseVisualStyleBackColor = true;
            // 
            // TBDni
            // 
            this.TBDni.AcceptsTab = true;
            this.TBDni.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDni.Location = new System.Drawing.Point(2, 67);
            this.TBDni.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBDni.MaxLength = 8;
            this.TBDni.Name = "TBDni";
            this.TBDni.Size = new System.Drawing.Size(193, 25);
            this.TBDni.TabIndex = 0;
            this.TBDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBDni_KeyPress);
            this.TBDni.Leave += new System.EventHandler(this.TBDni_Leave);
            // 
            // LApellido
            // 
            this.LApellido.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.Location = new System.Drawing.Point(237, 111);
            this.LApellido.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(94, 14);
            this.LApellido.TabIndex = 29;
            this.LApellido.Text = "Apellido/s (*):";
            // 
            // LNombre
            // 
            this.LNombre.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(-3, 111);
            this.LNombre.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(94, 14);
            this.LNombre.TabIndex = 3;
            this.LNombre.Text = "Nombre/s (*):";
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDni.Location = new System.Drawing.Point(-1, 49);
            this.LDni.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(51, 14);
            this.LDni.TabIndex = 0;
            this.LDni.Text = "DNI (*):";
            // 
            // BGuardar
            // 
            this.BGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BGuardar.Location = new System.Drawing.Point(337, 415);
            this.BGuardar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(120, 30);
            this.BGuardar.TabIndex = 3;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = false;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BCancelar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BCancelar.FlatAppearance.BorderSize = 2;
            this.BCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.BCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar.ForeColor = System.Drawing.Color.Firebrick;
            this.BCancelar.Location = new System.Drawing.Point(207, 415);
            this.BCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(120, 30);
            this.BCancelar.TabIndex = 4;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = false;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // GBDatosPersonales
            // 
            this.GBDatosPersonales.Controls.Add(this.LDatosPersonales);
            this.GBDatosPersonales.Controls.Add(this.TBDni);
            this.GBDatosPersonales.Controls.Add(this.LDni);
            this.GBDatosPersonales.Controls.Add(this.TBApellido);
            this.GBDatosPersonales.Controls.Add(this.LNombre);
            this.GBDatosPersonales.Controls.Add(this.LApellido);
            this.GBDatosPersonales.Controls.Add(this.TBEmail);
            this.GBDatosPersonales.Controls.Add(this.LEmail);
            this.GBDatosPersonales.Controls.Add(this.TBNombre);
            this.GBDatosPersonales.Controls.Add(this.LTelefono);
            this.GBDatosPersonales.Controls.Add(this.TBTelefono);
            this.GBDatosPersonales.Location = new System.Drawing.Point(24, 21);
            this.GBDatosPersonales.Name = "GBDatosPersonales";
            this.GBDatosPersonales.Size = new System.Drawing.Size(433, 235);
            this.GBDatosPersonales.TabIndex = 0;
            this.GBDatosPersonales.TabStop = false;
            // 
            // FormNuevoCliente
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.GBDatosPersonales);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BGuardar);
            this.Controls.Add(this.ChkConsumidorFinal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 479);
            this.Name = "FormNuevoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FormNuevoCliente_Load);
            this.GBDatosPersonales.ResumeLayout(false);
            this.GBDatosPersonales.PerformLayout();
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
        private System.Windows.Forms.CheckBox ChkConsumidorFinal;
        private System.Windows.Forms.TextBox TBDni;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.GroupBox GBDatosPersonales;
    }
}