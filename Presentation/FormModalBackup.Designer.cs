namespace Presentation
{
    partial class FormModalBackup
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
            this.LAdmin = new System.Windows.Forms.Label();
            this.LSuper = new System.Windows.Forms.Label();
            this.BAceptar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BCancelarFiltros = new System.Windows.Forms.Button();
            this.PContenidoFiltros = new System.Windows.Forms.Panel();
            this.PHeaderFiltros = new System.Windows.Forms.Panel();
            this.LCruzFiltros = new System.Windows.Forms.Label();
            this.LTituloFiltros = new System.Windows.Forms.Label();
            this.PBFiltros = new System.Windows.Forms.PictureBox();
            this.PCuerpoFiltros = new System.Windows.Forms.Panel();
            this.PBOjoSuper = new System.Windows.Forms.PictureBox();
            this.PBOcultar = new System.Windows.Forms.PictureBox();
            this.TBContraseñaSuper = new System.Windows.Forms.TextBox();
            this.TBContraseñaAdmin = new System.Windows.Forms.TextBox();
            this.PContenidoFiltros.SuspendLayout();
            this.PHeaderFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBFiltros)).BeginInit();
            this.PCuerpoFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBOjoSuper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBOcultar)).BeginInit();
            this.SuspendLayout();
            // 
            // LAdmin
            // 
            this.LAdmin.AutoEllipsis = true;
            this.LAdmin.AutoSize = true;
            this.LAdmin.BackColor = System.Drawing.Color.Transparent;
            this.LAdmin.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAdmin.ForeColor = System.Drawing.Color.Black;
            this.LAdmin.Location = new System.Drawing.Point(29, 94);
            this.LAdmin.Name = "LAdmin";
            this.LAdmin.Size = new System.Drawing.Size(223, 16);
            this.LAdmin.TabIndex = 1;
            this.LAdmin.Text = "Contraseña del administrador:";
            // 
            // LSuper
            // 
            this.LSuper.AutoEllipsis = true;
            this.LSuper.AutoSize = true;
            this.LSuper.BackColor = System.Drawing.Color.Transparent;
            this.LSuper.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSuper.ForeColor = System.Drawing.Color.Black;
            this.LSuper.Location = new System.Drawing.Point(29, 172);
            this.LSuper.Name = "LSuper";
            this.LSuper.Size = new System.Drawing.Size(213, 16);
            this.LSuper.TabIndex = 2;
            this.LSuper.Text = "Contraseña del SuperAdmin:";
            // 
            // BAceptar
            // 
            this.BAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BAceptar.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BAceptar.Location = new System.Drawing.Point(181, 278);
            this.BAceptar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(75, 22);
            this.BAceptar.TabIndex = 6;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.UseVisualStyleBackColor = false;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BCancelar.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar.ForeColor = System.Drawing.Color.Firebrick;
            this.BCancelar.Location = new System.Drawing.Point(61, 278);
            this.BCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(75, 22);
            this.BCancelar.TabIndex = 7;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = false;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BCancelarFiltros
            // 
            this.BCancelarFiltros.BackColor = System.Drawing.Color.Gainsboro;
            this.BCancelarFiltros.Location = new System.Drawing.Point(9, 180);
            this.BCancelarFiltros.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BCancelarFiltros.Name = "BCancelarFiltros";
            this.BCancelarFiltros.Size = new System.Drawing.Size(0, 0);
            this.BCancelarFiltros.TabIndex = 8;
            this.BCancelarFiltros.UseVisualStyleBackColor = false;
            this.BCancelarFiltros.Visible = false;
            // 
            // PContenidoFiltros
            // 
            this.PContenidoFiltros.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PContenidoFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PContenidoFiltros.Controls.Add(this.PHeaderFiltros);
            this.PContenidoFiltros.Controls.Add(this.PCuerpoFiltros);
            this.PContenidoFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenidoFiltros.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PContenidoFiltros.Location = new System.Drawing.Point(0, 0);
            this.PContenidoFiltros.Margin = new System.Windows.Forms.Padding(0);
            this.PContenidoFiltros.Name = "PContenidoFiltros";
            this.PContenidoFiltros.Size = new System.Drawing.Size(320, 350);
            this.PContenidoFiltros.TabIndex = 9;
            // 
            // PHeaderFiltros
            // 
            this.PHeaderFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.PHeaderFiltros.Controls.Add(this.LCruzFiltros);
            this.PHeaderFiltros.Controls.Add(this.LTituloFiltros);
            this.PHeaderFiltros.Controls.Add(this.PBFiltros);
            this.PHeaderFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeaderFiltros.Location = new System.Drawing.Point(0, 0);
            this.PHeaderFiltros.Margin = new System.Windows.Forms.Padding(0);
            this.PHeaderFiltros.Name = "PHeaderFiltros";
            this.PHeaderFiltros.Size = new System.Drawing.Size(318, 45);
            this.PHeaderFiltros.TabIndex = 9;
            // 
            // LCruzFiltros
            // 
            this.LCruzFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LCruzFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LCruzFiltros.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCruzFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.LCruzFiltros.Location = new System.Drawing.Point(275, 8);
            this.LCruzFiltros.Name = "LCruzFiltros";
            this.LCruzFiltros.Size = new System.Drawing.Size(32, 32);
            this.LCruzFiltros.TabIndex = 4;
            this.LCruzFiltros.Text = "X";
            this.LCruzFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LCruzFiltros.Click += new System.EventHandler(this.LCruzFiltros_Click);
            // 
            // LTituloFiltros
            // 
            this.LTituloFiltros.AutoSize = true;
            this.LTituloFiltros.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloFiltros.ForeColor = System.Drawing.Color.Black;
            this.LTituloFiltros.Location = new System.Drawing.Point(50, 14);
            this.LTituloFiltros.Name = "LTituloFiltros";
            this.LTituloFiltros.Size = new System.Drawing.Size(206, 20);
            this.LTituloFiltros.TabIndex = 1;
            this.LTituloFiltros.Text = "Autorización requerida";
            // 
            // PBFiltros
            // 
            this.PBFiltros.Image = global::Presentation.Properties.Resources.alerta;
            this.PBFiltros.Location = new System.Drawing.Point(11, 6);
            this.PBFiltros.Name = "PBFiltros";
            this.PBFiltros.Size = new System.Drawing.Size(32, 32);
            this.PBFiltros.TabIndex = 0;
            this.PBFiltros.TabStop = false;
            // 
            // PCuerpoFiltros
            // 
            this.PCuerpoFiltros.BackColor = System.Drawing.Color.White;
            this.PCuerpoFiltros.Controls.Add(this.PBOjoSuper);
            this.PCuerpoFiltros.Controls.Add(this.PBOcultar);
            this.PCuerpoFiltros.Controls.Add(this.TBContraseñaSuper);
            this.PCuerpoFiltros.Controls.Add(this.TBContraseñaAdmin);
            this.PCuerpoFiltros.Controls.Add(this.BCancelarFiltros);
            this.PCuerpoFiltros.Controls.Add(this.LSuper);
            this.PCuerpoFiltros.Controls.Add(this.BAceptar);
            this.PCuerpoFiltros.Controls.Add(this.LAdmin);
            this.PCuerpoFiltros.Controls.Add(this.BCancelar);
            this.PCuerpoFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCuerpoFiltros.Location = new System.Drawing.Point(0, 0);
            this.PCuerpoFiltros.Margin = new System.Windows.Forms.Padding(0);
            this.PCuerpoFiltros.Name = "PCuerpoFiltros";
            this.PCuerpoFiltros.Size = new System.Drawing.Size(318, 348);
            this.PCuerpoFiltros.TabIndex = 10;
            // 
            // PBOjoSuper
            // 
            this.PBOjoSuper.Image = global::Presentation.Properties.Resources.ojoabierto;
            this.PBOjoSuper.Location = new System.Drawing.Point(260, 202);
            this.PBOjoSuper.Name = "PBOjoSuper";
            this.PBOjoSuper.Size = new System.Drawing.Size(32, 32);
            this.PBOjoSuper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBOjoSuper.TabIndex = 12;
            this.PBOjoSuper.TabStop = false;
            // 
            // PBOcultar
            // 
            this.PBOcultar.Image = global::Presentation.Properties.Resources.ojoabierto;
            this.PBOcultar.Location = new System.Drawing.Point(260, 123);
            this.PBOcultar.Name = "PBOcultar";
            this.PBOcultar.Size = new System.Drawing.Size(32, 26);
            this.PBOcultar.TabIndex = 11;
            this.PBOcultar.TabStop = false;
            this.PBOcultar.Click += new System.EventHandler(this.PBOcultar_Click);
            // 
            // TBContraseñaSuper
            // 
            this.TBContraseñaSuper.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBContraseñaSuper.Location = new System.Drawing.Point(32, 208);
            this.TBContraseñaSuper.Margin = new System.Windows.Forms.Padding(2);
            this.TBContraseñaSuper.Name = "TBContraseñaSuper";
            this.TBContraseñaSuper.Size = new System.Drawing.Size(212, 26);
            this.TBContraseñaSuper.TabIndex = 10;
            this.TBContraseñaSuper.UseSystemPasswordChar = true;
            // 
            // TBContraseñaAdmin
            // 
            this.TBContraseñaAdmin.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBContraseñaAdmin.Location = new System.Drawing.Point(32, 123);
            this.TBContraseñaAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.TBContraseñaAdmin.Name = "TBContraseñaAdmin";
            this.TBContraseñaAdmin.Size = new System.Drawing.Size(211, 26);
            this.TBContraseñaAdmin.TabIndex = 9;
            this.TBContraseñaAdmin.UseSystemPasswordChar = true;
            // 
            // FormModalBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 350);
            this.ControlBox = false;
            this.Controls.Add(this.PContenidoFiltros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormModalBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.PContenidoFiltros.ResumeLayout(false);
            this.PHeaderFiltros.ResumeLayout(false);
            this.PHeaderFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBFiltros)).EndInit();
            this.PCuerpoFiltros.ResumeLayout(false);
            this.PCuerpoFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBOjoSuper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBOcultar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LAdmin;
        private System.Windows.Forms.Label LSuper;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BCancelarFiltros;
        private System.Windows.Forms.Panel PContenidoFiltros;
        private System.Windows.Forms.Panel PHeaderFiltros;
        private System.Windows.Forms.PictureBox PBFiltros;
        private System.Windows.Forms.Panel PCuerpoFiltros;
        private System.Windows.Forms.Label LTituloFiltros;
        private System.Windows.Forms.Label LCruzFiltros;
        private System.Windows.Forms.TextBox TBContraseñaSuper;
        private System.Windows.Forms.TextBox TBContraseñaAdmin;
        private System.Windows.Forms.PictureBox PBOcultar;
        private System.Windows.Forms.PictureBox PBOjoSuper;
    }
}