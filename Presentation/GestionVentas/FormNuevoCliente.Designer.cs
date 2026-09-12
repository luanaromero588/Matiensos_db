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
            this.LDatosFacturacion = new System.Windows.Forms.Label();
            this.LDomicilio = new System.Windows.Forms.Label();
            this.TBDomicilio = new System.Windows.Forms.TextBox();
            this.BGuardarRegistro = new System.Windows.Forms.Button();
            this.BCancelarRegistro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LDatosPersonales
            // 
            this.LDatosPersonales.AutoSize = true;
            this.LDatosPersonales.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDatosPersonales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LDatosPersonales.Location = new System.Drawing.Point(31, 32);
            this.LDatosPersonales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LDatosPersonales.Name = "LDatosPersonales";
            this.LDatosPersonales.Size = new System.Drawing.Size(186, 16);
            this.LDatosPersonales.TabIndex = 17;
            this.LDatosPersonales.Text = "DATOS PERSONALES";
            // 
            // TBEmail
            // 
            this.TBEmail.AcceptsTab = true;
            this.TBEmail.Enabled = false;
            this.TBEmail.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBEmail.Location = new System.Drawing.Point(257, 223);
            this.TBEmail.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(193, 25);
            this.TBEmail.TabIndex = 37;
            // 
            // LEmail
            // 
            this.LEmail.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEmail.Location = new System.Drawing.Point(254, 205);
            this.LEmail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(47, 14);
            this.LEmail.TabIndex = 36;
            this.LEmail.Text = "E-mail:";
            // 
            // TBApellido
            // 
            this.TBApellido.AcceptsTab = true;
            this.TBApellido.Enabled = false;
            this.TBApellido.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBApellido.Location = new System.Drawing.Point(257, 158);
            this.TBApellido.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBApellido.Name = "TBApellido";
            this.TBApellido.Size = new System.Drawing.Size(193, 25);
            this.TBApellido.TabIndex = 31;
            // 
            // LTelefono
            // 
            this.LTelefono.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.Location = new System.Drawing.Point(31, 205);
            this.LTelefono.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(60, 14);
            this.LTelefono.TabIndex = 30;
            this.LTelefono.Text = "Telefono:";
            // 
            // TBNombre
            // 
            this.TBNombre.AcceptsTab = true;
            this.TBNombre.Enabled = false;
            this.TBNombre.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNombre.Location = new System.Drawing.Point(34, 158);
            this.TBNombre.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(193, 25);
            this.TBNombre.TabIndex = 32;
            // 
            // TBTelefono
            // 
            this.TBTelefono.AcceptsTab = true;
            this.TBTelefono.Enabled = false;
            this.TBTelefono.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTelefono.Location = new System.Drawing.Point(34, 223);
            this.TBTelefono.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(193, 25);
            this.TBTelefono.TabIndex = 35;
            // 
            // ChkConsumidorFinal
            // 
            this.ChkConsumidorFinal.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkConsumidorFinal.Location = new System.Drawing.Point(191, 324);
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
            this.TBDni.Location = new System.Drawing.Point(34, 96);
            this.TBDni.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBDni.Name = "TBDni";
            this.TBDni.Size = new System.Drawing.Size(193, 25);
            this.TBDni.TabIndex = 33;
            this.TBDni.TextChanged += new System.EventHandler(this.TBDniCliente_TextChanged);
            // 
            // LApellido
            // 
            this.LApellido.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.Location = new System.Drawing.Point(254, 140);
            this.LApellido.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(94, 14);
            this.LApellido.TabIndex = 29;
            this.LApellido.Text = "Apellido/s (*):";
            // 
            // LNombre
            // 
            this.LNombre.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(31, 140);
            this.LNombre.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(94, 14);
            this.LNombre.TabIndex = 28;
            this.LNombre.Text = "Nombre/s (*):";
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDni.Location = new System.Drawing.Point(31, 78);
            this.LDni.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(51, 14);
            this.LDni.TabIndex = 27;
            this.LDni.Text = "DNI (*):";
            // 
            // LDatosFacturacion
            // 
            this.LDatosFacturacion.AutoSize = true;
            this.LDatosFacturacion.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDatosFacturacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LDatosFacturacion.Location = new System.Drawing.Point(31, 279);
            this.LDatosFacturacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LDatosFacturacion.Name = "LDatosFacturacion";
            this.LDatosFacturacion.Size = new System.Drawing.Size(229, 16);
            this.LDatosFacturacion.TabIndex = 38;
            this.LDatosFacturacion.Text = "DATOS DE FACTURACIÓN";
            // 
            // LDomicilio
            // 
            this.LDomicilio.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDomicilio.Location = new System.Drawing.Point(31, 314);
            this.LDomicilio.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LDomicilio.Name = "LDomicilio";
            this.LDomicilio.Size = new System.Drawing.Size(60, 14);
            this.LDomicilio.TabIndex = 39;
            this.LDomicilio.Text = "Dirección de Entrega / Domicilio:";
            // 
            // TBDomicilio
            // 
            this.TBDomicilio.AcceptsTab = true;
            this.TBDomicilio.Enabled = false;
            this.TBDomicilio.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDomicilio.Location = new System.Drawing.Point(34, 332);
            this.TBDomicilio.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TBDomicilio.Name = "TBDomicilio";
            this.TBDomicilio.Size = new System.Drawing.Size(193, 25);
            this.TBDomicilio.TabIndex = 40;
            // 
            // BGuardarRegistro
            // 
            this.BGuardarRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BGuardarRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BGuardarRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardarRegistro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BGuardarRegistro.Location = new System.Drawing.Point(330, 386);
            this.BGuardarRegistro.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BGuardarRegistro.Name = "BGuardarRegistro";
            this.BGuardarRegistro.Size = new System.Drawing.Size(120, 31);
            this.BGuardarRegistro.TabIndex = 41;
            this.BGuardarRegistro.Text = "Guardar";
            this.BGuardarRegistro.UseVisualStyleBackColor = false;
            // 
            // BCancelarRegistro
            // 
            this.BCancelarRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BCancelarRegistro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BCancelarRegistro.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BCancelarRegistro.FlatAppearance.BorderSize = 2;
            this.BCancelarRegistro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.BCancelarRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelarRegistro.ForeColor = System.Drawing.Color.Firebrick;
            this.BCancelarRegistro.Location = new System.Drawing.Point(200, 386);
            this.BCancelarRegistro.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BCancelarRegistro.Name = "BCancelarRegistro";
            this.BCancelarRegistro.Size = new System.Drawing.Size(120, 31);
            this.BCancelarRegistro.TabIndex = 41;
            this.BCancelarRegistro.Text = "Cancelar";
            this.BCancelarRegistro.UseVisualStyleBackColor = false;
            // 
            // FormNuevoCliente
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(484, 441);
            this.Controls.Add(this.BCancelarRegistro);
            this.Controls.Add(this.BGuardarRegistro);
            this.Controls.Add(this.LDomicilio);
            this.Controls.Add(this.TBDomicilio);
            this.Controls.Add(this.LDatosFacturacion);
            this.Controls.Add(this.TBEmail);
            this.Controls.Add(this.LEmail);
            this.Controls.Add(this.TBApellido);
            this.Controls.Add(this.LTelefono);
            this.Controls.Add(this.TBNombre);
            this.Controls.Add(this.TBTelefono);
            this.Controls.Add(this.ChkConsumidorFinal);
            this.Controls.Add(this.TBDni);
            this.Controls.Add(this.LApellido);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.LDni);
            this.Controls.Add(this.LDatosPersonales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 480);
            this.Name = "FormNuevoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label LDatosFacturacion;
        private System.Windows.Forms.Label LDomicilio;
        private System.Windows.Forms.TextBox TBDomicilio;
        private System.Windows.Forms.Button BGuardarRegistro;
        private System.Windows.Forms.Button BCancelarRegistro;
    }
}