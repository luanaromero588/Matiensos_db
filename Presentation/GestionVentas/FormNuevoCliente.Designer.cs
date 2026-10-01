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
            this.ChkConsumidorFinal = new System.Windows.Forms.CheckBox();
            this.BGuardar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.LDatosPersonales = new System.Windows.Forms.Label();
            this.TBDni = new System.Windows.Forms.TextBox();
            this.LDni = new System.Windows.Forms.Label();
            this.TBApellido = new System.Windows.Forms.TextBox();
            this.LNombre = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.LEmail = new System.Windows.Forms.Label();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.LTelefono = new System.Windows.Forms.Label();
            this.TBTelefono = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ChkConsumidorFinal
            // 
            this.ChkConsumidorFinal.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkConsumidorFinal.Location = new System.Drawing.Point(241, 511);
            this.ChkConsumidorFinal.Margin = new System.Windows.Forms.Padding(5);
            this.ChkConsumidorFinal.Name = "ChkConsumidorFinal";
            this.ChkConsumidorFinal.Size = new System.Drawing.Size(0, 0);
            this.ChkConsumidorFinal.TabIndex = 34;
            this.ChkConsumidorFinal.Text = "Consumidor Final";
            this.ChkConsumidorFinal.UseVisualStyleBackColor = true;
            // 
            // BGuardar
            // 
            this.BGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BGuardar.Location = new System.Drawing.Point(449, 389);
            this.BGuardar.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(160, 37);
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
            this.BCancelar.Location = new System.Drawing.Point(276, 389);
            this.BCancelar.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(160, 37);
            this.BCancelar.TabIndex = 4;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = false;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // LDatosPersonales
            // 
            this.LDatosPersonales.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDatosPersonales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LDatosPersonales.Location = new System.Drawing.Point(33, 37);
            this.LDatosPersonales.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LDatosPersonales.Name = "LDatosPersonales";
            this.LDatosPersonales.Size = new System.Drawing.Size(577, 21);
            this.LDatosPersonales.TabIndex = 44;
            this.LDatosPersonales.Text = "DATOS PERSONALES";
            // 
            // TBDni
            // 
            this.TBDni.AcceptsTab = true;
            this.TBDni.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDni.Location = new System.Drawing.Point(35, 128);
            this.TBDni.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.TBDni.MaxLength = 8;
            this.TBDni.Name = "TBDni";
            this.TBDni.Size = new System.Drawing.Size(256, 25);
            this.TBDni.TabIndex = 40;
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDni.Location = new System.Drawing.Point(33, 107);
            this.LDni.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(60, 16);
            this.LDni.TabIndex = 38;
            this.LDni.Text = "DNI (*):";
            // 
            // TBApellido
            // 
            this.TBApellido.AcceptsTab = true;
            this.TBApellido.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBApellido.Location = new System.Drawing.Point(352, 209);
            this.TBApellido.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.TBApellido.Name = "TBApellido";
            this.TBApellido.Size = new System.Drawing.Size(256, 25);
            this.TBApellido.TabIndex = 40;
            // 
            // LNombre
            // 
            this.LNombre.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(33, 187);
            this.LNombre.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(125, 17);
            this.LNombre.TabIndex = 41;
            this.LNombre.Text = "Nombre *";
            // 
            // LApellido
            // 
            this.LApellido.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.Location = new System.Drawing.Point(349, 187);
            this.LApellido.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(125, 24);
            this.LApellido.TabIndex = 45;
            this.LApellido.Text = "Apellido *";
            // 
            // TBEmail
            // 
            this.TBEmail.AcceptsTab = true;
            this.TBEmail.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBEmail.Location = new System.Drawing.Point(352, 288);
            this.TBEmail.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(256, 25);
            this.TBEmail.TabIndex = 40;
            // 
            // LEmail
            // 
            this.LEmail.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEmail.Location = new System.Drawing.Point(349, 265);
            this.LEmail.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(63, 17);
            this.LEmail.TabIndex = 47;
            this.LEmail.Text = "E-mail";
            // 
            // TBNombre
            // 
            this.TBNombre.AcceptsTab = true;
            this.TBNombre.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNombre.Location = new System.Drawing.Point(36, 209);
            this.TBNombre.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(256, 25);
            this.TBNombre.TabIndex = 40;
            // 
            // LTelefono
            // 
            this.LTelefono.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.Location = new System.Drawing.Point(33, 265);
            this.LTelefono.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(80, 17);
            this.LTelefono.TabIndex = 46;
            this.LTelefono.Text = "Telefono";
            // 
            // TBTelefono
            // 
            this.TBTelefono.AcceptsTab = true;
            this.TBTelefono.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTelefono.Location = new System.Drawing.Point(36, 288);
            this.TBTelefono.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.TBTelefono.MaxLength = 8;
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(256, 25);
            this.TBTelefono.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 355);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 29);
            this.label1.TabIndex = 49;
            this.label1.Text = "(*) Campos obligatorios";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.panel2.Location = new System.Drawing.Point(36, 60);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(574, 10);
            this.panel2.TabIndex = 50;
            // 
            // FormNuevoCliente
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(645, 445);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LDatosPersonales);
            this.Controls.Add(this.TBDni);
            this.Controls.Add(this.LDni);
            this.Controls.Add(this.TBApellido);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.LApellido);
            this.Controls.Add(this.TBEmail);
            this.Controls.Add(this.LEmail);
            this.Controls.Add(this.TBNombre);
            this.Controls.Add(this.LTelefono);
            this.Controls.Add(this.TBTelefono);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BGuardar);
            this.Controls.Add(this.ChkConsumidorFinal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNuevoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Cliente";
            this.Load += new System.EventHandler(this.FormNuevoCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox ChkConsumidorFinal;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Label LDatosPersonales;
        private System.Windows.Forms.TextBox TBDni;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.TextBox TBApellido;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.TextBox TBEmail;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.TextBox TBTelefono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}