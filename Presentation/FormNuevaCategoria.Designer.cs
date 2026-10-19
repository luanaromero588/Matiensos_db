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
            this.PContenedorModal = new System.Windows.Forms.Panel();
            this.PCuerpo = new System.Windows.Forms.Panel();
            this.LErrorNombre = new System.Windows.Forms.Label();
            this.LErrorCodigo = new System.Windows.Forms.Label();
            this.LCodigo = new System.Windows.Forms.Label();
            this.TBCodCategoria = new System.Windows.Forms.TextBox();
            this.LNombreCategoria = new System.Windows.Forms.Label();
            this.TBNombreCategoria = new System.Windows.Forms.TextBox();
            this.LDescripcion = new System.Windows.Forms.Label();
            this.TBDescripcion = new System.Windows.Forms.TextBox();
            this.PLineaDivisoria = new System.Windows.Forms.Panel();
            this.LDatosCategoria = new System.Windows.Forms.Label();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BGuardar = new System.Windows.Forms.Button();
            this.PHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.LTituloNuevaCategoria = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PContenedorModal.SuspendLayout();
            this.PCuerpo.SuspendLayout();
            this.PHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.PContenedorModal.Size = new System.Drawing.Size(550, 380);
            this.PContenedorModal.TabIndex = 37;
            // 
            // PCuerpo
            // 
            this.PCuerpo.BackColor = System.Drawing.Color.White;
            this.PCuerpo.Controls.Add(this.LErrorNombre);
            this.PCuerpo.Controls.Add(this.LErrorCodigo);
            this.PCuerpo.Controls.Add(this.LCodigo);
            this.PCuerpo.Controls.Add(this.TBCodCategoria);
            this.PCuerpo.Controls.Add(this.LNombreCategoria);
            this.PCuerpo.Controls.Add(this.TBNombreCategoria);
            this.PCuerpo.Controls.Add(this.LDescripcion);
            this.PCuerpo.Controls.Add(this.TBDescripcion);
            this.PCuerpo.Controls.Add(this.PLineaDivisoria);
            this.PCuerpo.Controls.Add(this.LDatosCategoria);
            this.PCuerpo.Controls.Add(this.BCancelar);
            this.PCuerpo.Controls.Add(this.BGuardar);
            this.PCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCuerpo.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PCuerpo.Location = new System.Drawing.Point(0, 55);
            this.PCuerpo.Name = "PCuerpo";
            this.PCuerpo.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.PCuerpo.Size = new System.Drawing.Size(550, 325);
            this.PCuerpo.TabIndex = 37;
            // 
            // LErrorNombre
            // 
            this.LErrorNombre.AutoSize = true;
            this.LErrorNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.LErrorNombre.Location = new System.Drawing.Point(295, 122);
            this.LErrorNombre.Name = "LErrorNombre";
            this.LErrorNombre.Size = new System.Drawing.Size(0, 19);
            this.LErrorNombre.TabIndex = 43;
            this.LErrorNombre.Visible = false;
            // 
            // LErrorCodigo
            // 
            this.LErrorCodigo.AutoSize = true;
            this.LErrorCodigo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LErrorCodigo.ForeColor = System.Drawing.Color.Red;
            this.LErrorCodigo.Location = new System.Drawing.Point(35, 122);
            this.LErrorCodigo.Name = "LErrorCodigo";
            this.LErrorCodigo.Size = new System.Drawing.Size(0, 19);
            this.LErrorCodigo.TabIndex = 42;
            this.LErrorCodigo.Visible = false;
            // 
            // LCodigo
            // 
            this.LCodigo.AutoSize = true;
            this.LCodigo.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCodigo.Location = new System.Drawing.Point(35, 75);
            this.LCodigo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LCodigo.Name = "LCodigo";
            this.LCodigo.Size = new System.Drawing.Size(67, 19);
            this.LCodigo.TabIndex = 41;
            this.LCodigo.Text = "Código:";
            // 
            // TBCodCategoria
            // 
            this.TBCodCategoria.AcceptsTab = true;
            this.TBCodCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBCodCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TBCodCategoria.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCodCategoria.Location = new System.Drawing.Point(35, 95);
            this.TBCodCategoria.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TBCodCategoria.MaxLength = 4;
            this.TBCodCategoria.Name = "TBCodCategoria";
            this.TBCodCategoria.Size = new System.Drawing.Size(220, 29);
            this.TBCodCategoria.TabIndex = 0;
            this.TBCodCategoria.TextChanged += new System.EventHandler(this.TBCodCategoria_TextChanged);
            this.TBCodCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBCodCategoria_KeyPress);
            this.TBCodCategoria.Leave += new System.EventHandler(this.TBCodCategoria_Leave);
            // 
            // LNombreCategoria
            // 
            this.LNombreCategoria.AutoSize = true;
            this.LNombreCategoria.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombreCategoria.Location = new System.Drawing.Point(295, 75);
            this.LNombreCategoria.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LNombreCategoria.Name = "LNombreCategoria";
            this.LNombreCategoria.Size = new System.Drawing.Size(77, 20);
            this.LNombreCategoria.TabIndex = 40;
            this.LNombreCategoria.Text = "Nombre:";
            // 
            // TBNombreCategoria
            // 
            this.TBNombreCategoria.AcceptsTab = true;
            this.TBNombreCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBNombreCategoria.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNombreCategoria.Location = new System.Drawing.Point(295, 95);
            this.TBNombreCategoria.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TBNombreCategoria.MaxLength = 100;
            this.TBNombreCategoria.Name = "TBNombreCategoria";
            this.TBNombreCategoria.Size = new System.Drawing.Size(220, 29);
            this.TBNombreCategoria.TabIndex = 1;
            this.TBNombreCategoria.TextChanged += new System.EventHandler(this.TBNombreCategoria_TextChanged);
            this.TBNombreCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNombreCategoria_KeyPress);
            this.TBNombreCategoria.Leave += new System.EventHandler(this.TBNombreCategoria_Leave);
            // 
            // LDescripcion
            // 
            this.LDescripcion.AutoSize = true;
            this.LDescripcion.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDescripcion.Location = new System.Drawing.Point(35, 145);
            this.LDescripcion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LDescripcion.Name = "LDescripcion";
            this.LDescripcion.Size = new System.Drawing.Size(105, 20);
            this.LDescripcion.TabIndex = 36;
            this.LDescripcion.Text = "Descripción:";
            // 
            // TBDescripcion
            // 
            this.TBDescripcion.AcceptsTab = true;
            this.TBDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDescripcion.Location = new System.Drawing.Point(35, 165);
            this.TBDescripcion.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TBDescripcion.MaxLength = 255;
            this.TBDescripcion.Multiline = true;
            this.TBDescripcion.Name = "TBDescripcion";
            this.TBDescripcion.Size = new System.Drawing.Size(480, 80);
            this.TBDescripcion.TabIndex = 2;
            // 
            // PLineaDivisoria
            // 
            this.PLineaDivisoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(112)))), ((int)(((byte)(102)))));
            this.PLineaDivisoria.Location = new System.Drawing.Point(35, 50);
            this.PLineaDivisoria.Name = "PLineaDivisoria";
            this.PLineaDivisoria.Size = new System.Drawing.Size(480, 1);
            this.PLineaDivisoria.TabIndex = 38;
            // 
            // LDatosCategoria
            // 
            this.LDatosCategoria.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDatosCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LDatosCategoria.Location = new System.Drawing.Point(35, 25);
            this.LDatosCategoria.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LDatosCategoria.Name = "LDatosCategoria";
            this.LDatosCategoria.Size = new System.Drawing.Size(260, 17);
            this.LDatosCategoria.TabIndex = 5;
            this.LDatosCategoria.Text = "DATOS DE LA CATEGORÍA";
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
            this.BCancelar.Location = new System.Drawing.Point(265, 265);
            this.BCancelar.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(115, 32);
            this.BCancelar.TabIndex = 4;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = false;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BGuardar
            // 
            this.BGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGuardar.FlatAppearance.BorderSize = 0;
            this.BGuardar.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BGuardar.Location = new System.Drawing.Point(400, 265);
            this.BGuardar.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(115, 32);
            this.BGuardar.TabIndex = 3;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = false;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // PHeader
            // 
            this.PHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.PHeader.Controls.Add(this.panel1);
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
            this.panel1.Controls.Add(this.LTituloNuevaCategoria);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.label1.Click += new System.EventHandler(this.BCancelar_Click);
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
            // LTituloNuevaCategoria
            // 
            this.LTituloNuevaCategoria.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloNuevaCategoria.Location = new System.Drawing.Point(66, 12);
            this.LTituloNuevaCategoria.Name = "LTituloNuevaCategoria";
            this.LTituloNuevaCategoria.Size = new System.Drawing.Size(250, 32);
            this.LTituloNuevaCategoria.TabIndex = 1;
            this.LTituloNuevaCategoria.Text = "Nueva Categoría";
            this.LTituloNuevaCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Presentation.Properties.Resources.categoriaModal;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormNuevaCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(550, 380);
            this.ControlBox = false;
            this.Controls.Add(this.PContenedorModal);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(522, 380);
            this.Name = "FormNuevaCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FormNuevaCategoria_Load);
            this.PContenedorModal.ResumeLayout(false);
            this.PCuerpo.ResumeLayout(false);
            this.PCuerpo.PerformLayout();
            this.PHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LDatosCategoria;
        private System.Windows.Forms.TextBox TBDescripcion;
        private System.Windows.Forms.Label LDescripcion;
        private System.Windows.Forms.TextBox TBNombreCategoria;
        private System.Windows.Forms.Label LNombreCategoria;
        private System.Windows.Forms.TextBox TBCodCategoria;
        private System.Windows.Forms.Label LCodigo;
        private System.Windows.Forms.Label LErrorCodigo;
        private System.Windows.Forms.Label LErrorNombre;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Panel PContenedorModal;
        private System.Windows.Forms.Panel PHeader;
        private System.Windows.Forms.Panel PCuerpo;
        private System.Windows.Forms.Panel PLineaDivisoria;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label LTituloNuevaCategoria;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}