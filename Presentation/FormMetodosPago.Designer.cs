namespace Presentation
{
    partial class FormMetodosPago
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMetodosPago));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LTituloGrilla = new System.Windows.Forms.Label();
            this.PContenedorFP = new System.Windows.Forms.Panel();
            this.BNuevoMP = new System.Windows.Forms.Button();
            this.PContenedorGrilla = new System.Windows.Forms.Panel();
            this.DGVMetodosPago = new System.Windows.Forms.DataGridView();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditarFila = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEliminarFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.PContenedorFP.SuspendLayout();
            this.PContenedorGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMetodosPago)).BeginInit();
            this.SuspendLayout();
            // 
            // LTituloGrilla
            // 
            this.LTituloGrilla.AutoSize = true;
            this.LTituloGrilla.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloGrilla.Location = new System.Drawing.Point(107, 74);
            this.LTituloGrilla.Name = "LTituloGrilla";
            this.LTituloGrilla.Size = new System.Drawing.Size(312, 25);
            this.LTituloGrilla.TabIndex = 4;
            this.LTituloGrilla.Text = "Gestión de métodos de pago";
            // 
            // PContenedorFP
            // 
            this.PContenedorFP.Controls.Add(this.LTituloGrilla);
            this.PContenedorFP.Controls.Add(this.PContenedorGrilla);
            this.PContenedorFP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenedorFP.Location = new System.Drawing.Point(0, 0);
            this.PContenedorFP.Name = "PContenedorFP";
            this.PContenedorFP.Size = new System.Drawing.Size(1084, 661);
            this.PContenedorFP.TabIndex = 6;
            // 
            // BNuevoMP
            // 
            this.BNuevoMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BNuevoMP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BNuevoMP.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevoMP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BNuevoMP.Location = new System.Drawing.Point(741, 61);
            this.BNuevoMP.Name = "BNuevoMP";
            this.BNuevoMP.Size = new System.Drawing.Size(186, 37);
            this.BNuevoMP.TabIndex = 25;
            this.BNuevoMP.Text = "+ Nuevo Método";
            this.BNuevoMP.UseVisualStyleBackColor = false;
            this.BNuevoMP.Click += new System.EventHandler(this.BNuevoMP_Click);
            // 
            // PContenedorGrilla
            // 
            this.PContenedorGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PContenedorGrilla.BackColor = System.Drawing.Color.White;
            this.PContenedorGrilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PContenedorGrilla.Controls.Add(this.label3);
            this.PContenedorGrilla.Controls.Add(this.DGVMetodosPago);
            this.PContenedorGrilla.Controls.Add(this.BNuevoMP);
            this.PContenedorGrilla.Location = new System.Drawing.Point(52, 170);
            this.PContenedorGrilla.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PContenedorGrilla.Name = "PContenedorGrilla";
            this.PContenedorGrilla.Padding = new System.Windows.Forms.Padding(15);
            this.PContenedorGrilla.Size = new System.Drawing.Size(980, 470);
            this.PContenedorGrilla.TabIndex = 6;
            // 
            // DGVMetodosPago
            // 
            this.DGVMetodosPago.AllowUserToAddRows = false;
            this.DGVMetodosPago.AllowUserToDeleteRows = false;
            this.DGVMetodosPago.AllowUserToResizeRows = false;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.DGVMetodosPago.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle31;
            this.DGVMetodosPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVMetodosPago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVMetodosPago.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGVMetodosPago.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVMetodosPago.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.DGVMetodosPago.ColumnHeadersHeight = 29;
            this.DGVMetodosPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombre,
            this.coldescripcion,
            this.colEstado,
            this.colEditarFila,
            this.colEliminarFila});
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVMetodosPago.DefaultCellStyle = dataGridViewCellStyle35;
            this.DGVMetodosPago.EnableHeadersVisualStyles = false;
            this.DGVMetodosPago.Location = new System.Drawing.Point(47, 123);
            this.DGVMetodosPago.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DGVMetodosPago.MultiSelect = false;
            this.DGVMetodosPago.Name = "DGVMetodosPago";
            this.DGVMetodosPago.ReadOnly = true;
            this.DGVMetodosPago.RowHeadersVisible = false;
            this.DGVMetodosPago.RowHeadersWidth = 51;
            dataGridViewCellStyle36.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(38)))));
            this.DGVMetodosPago.RowsDefaultCellStyle = dataGridViewCellStyle36;
            this.DGVMetodosPago.RowTemplate.Height = 28;
            this.DGVMetodosPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVMetodosPago.Size = new System.Drawing.Size(880, 192);
            this.DGVMetodosPago.TabIndex = 0;
            this.DGVMetodosPago.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVMetodosPago_CellContentClick);
            this.DGVMetodosPago.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVMetodosPago_CellFormatting);
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 6;
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // coldescripcion
            // 
            this.coldescripcion.DataPropertyName = "Descripcion";
            this.coldescripcion.HeaderText = "Descripción";
            this.coldescripcion.MinimumWidth = 6;
            this.coldescripcion.Name = "coldescripcion";
            this.coldescripcion.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.DataPropertyName = "Activo";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 6;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // colEditarFila
            // 
            this.colEditarFila.DataPropertyName = "btnEditarFila";
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.Magenta;
            dataGridViewCellStyle33.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle33.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle33.NullValue")));
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.Transparent;
            this.colEditarFila.DefaultCellStyle = dataGridViewCellStyle33;
            this.colEditarFila.HeaderText = "Acción";
            this.colEditarFila.MinimumWidth = 6;
            this.colEditarFila.Name = "colEditarFila";
            this.colEditarFila.ReadOnly = true;
            this.colEditarFila.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEditarFila.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEditarFila.Visible = false;
            // 
            // colEliminarFila
            // 
            this.colEliminarFila.DataPropertyName = "btnEliminarFila";
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.Fuchsia;
            this.colEliminarFila.DefaultCellStyle = dataGridViewCellStyle34;
            this.colEliminarFila.HeaderText = "Acción";
            this.colEliminarFila.MinimumWidth = 6;
            this.colEliminarFila.Name = "colEliminarFila";
            this.colEliminarFila.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Listado de Métodos de Pago";
            // 
            // FormMetodosPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.PContenedorFP);
            this.Name = "FormMetodosPago";
            this.Text = "FormMetodosPago";
            this.PContenedorFP.ResumeLayout(false);
            this.PContenedorFP.PerformLayout();
            this.PContenedorGrilla.ResumeLayout(false);
            this.PContenedorGrilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMetodosPago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LTituloGrilla;
        private System.Windows.Forms.Panel PContenedorFP;
        private System.Windows.Forms.Panel PContenedorGrilla;
        private System.Windows.Forms.DataGridView DGVMetodosPago;
        private System.Windows.Forms.Button BNuevoMP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewImageColumn colEditarFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEliminarFila;
        private System.Windows.Forms.Label label3;
    }
}