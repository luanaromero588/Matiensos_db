using System;
using System.Drawing;
using System.Windows.Forms;


namespace Presentation
{
    partial class FormNuevoMetodoPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNuevoMetodoPago));
            this.LDatosMP = new System.Windows.Forms.Label();
            this.TBNombreMP = new System.Windows.Forms.TextBox();
            this.BGuardar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.PContenedorModal = new System.Windows.Forms.Panel();
            this.PCuerpo = new System.Windows.Forms.Panel();
            this.TBDescripcionMP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.PLineaDivisoria = new System.Windows.Forms.Panel();
            this.PHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.LTituloNuevoMP = new System.Windows.Forms.Label();
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
            // LDatosMP
            // 
            this.LDatosMP.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDatosMP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LDatosMP.Location = new System.Drawing.Point(35, 30);
            this.LDatosMP.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LDatosMP.Name = "LDatosMP";
            this.LDatosMP.Size = new System.Drawing.Size(283, 17);
            this.LDatosMP.TabIndex = 5;
            this.LDatosMP.Text = "DATOS DEL MÉTODO DE PAGO";
            // 
            // TBNombreMP
            // 
            this.TBNombreMP.AcceptsTab = true;
            this.TBNombreMP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBNombreMP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNombreMP.Location = new System.Drawing.Point(35, 127);
            this.TBNombreMP.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TBNombreMP.MaxLength = 50;
            this.TBNombreMP.Name = "TBNombreMP";
            this.TBNombreMP.Size = new System.Drawing.Size(480, 25);
            this.TBNombreMP.TabIndex = 0;
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
            this.BGuardar.Location = new System.Drawing.Point(400, 339);
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
            this.BCancelar.Location = new System.Drawing.Point(265, 339);
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
            this.PCuerpo.Controls.Add(this.TBDescripcionMP);
            this.PCuerpo.Controls.Add(this.label2);
            this.PCuerpo.Controls.Add(this.LNombre);
            this.PCuerpo.Controls.Add(this.BCancelar);
            this.PCuerpo.Controls.Add(this.PLineaDivisoria);
            this.PCuerpo.Controls.Add(this.BGuardar);
            this.PCuerpo.Controls.Add(this.LDatosMP);
            this.PCuerpo.Controls.Add(this.TBNombreMP);
            this.PCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCuerpo.Location = new System.Drawing.Point(0, 55);
            this.PCuerpo.Name = "PCuerpo";
            this.PCuerpo.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.PCuerpo.Size = new System.Drawing.Size(550, 445);
            this.PCuerpo.TabIndex = 37;
            // 
            // TBDescripcionMP
            // 
            this.TBDescripcionMP.Location = new System.Drawing.Point(35, 197);
            this.TBDescripcionMP.Multiline = true;
            this.TBDescripcionMP.Name = "TBDescripcionMP";
            this.TBDescripcionMP.Size = new System.Drawing.Size(480, 71);
            this.TBDescripcionMP.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Descripción:";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(35, 107);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(49, 13);
            this.LNombre.TabIndex = 41;
            this.LNombre.Text = "Nombre:";
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
            this.panel1.Controls.Add(this.LTituloNuevoMP);
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
            // LTituloNuevoMP
            // 
            this.LTituloNuevoMP.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloNuevoMP.Location = new System.Drawing.Point(66, 12);
            this.LTituloNuevoMP.Name = "LTituloNuevoMP";
            this.LTituloNuevoMP.Size = new System.Drawing.Size(273, 32);
            this.LTituloNuevoMP.TabIndex = 1;
            this.LTituloNuevoMP.Text = "Nuevo Método de Pago";
            this.LTituloNuevoMP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Presentation.Properties.Resources.billeteraModal;
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
            // FormNuevoMetodoPago
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
            this.Name = "FormNuevoMetodoPago";
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
        private System.Windows.Forms.Label LDatosMP;
        private System.Windows.Forms.TextBox TBNombreMP;
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
        private System.Windows.Forms.Label LTituloNuevoMP;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TBDescripcionMP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LNombre;

    }
}