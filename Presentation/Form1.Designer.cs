namespace Presentation
{
    partial class form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.BClientes = new System.Windows.Forms.Button();
            this.BUsuarios = new System.Windows.Forms.Button();
            this.BCategorias = new System.Windows.Forms.Button();
            this.panelAdmin = new System.Windows.Forms.TextBox();
            this.BProductos = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.panelMenu.Controls.Add(this.BClientes);
            this.panelMenu.Controls.Add(this.BUsuarios);
            this.panelMenu.Controls.Add(this.BCategorias);
            this.panelMenu.Controls.Add(this.panelAdmin);
            this.panelMenu.Controls.Add(this.BProductos);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(192, 679);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BClientes
            // 
            this.BClientes.Image = global::Presentation.Properties.Resources.cliente;
            this.BClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BClientes.Location = new System.Drawing.Point(25, 342);
            this.BClientes.Name = "BClientes";
            this.BClientes.Size = new System.Drawing.Size(135, 38);
            this.BClientes.TabIndex = 4;
            this.BClientes.Text = "Clientes";
            this.BClientes.UseVisualStyleBackColor = true;
            this.BClientes.Click += new System.EventHandler(this.BClientes_Click_1);
            // 
            // BUsuarios
            // 
            this.BUsuarios.Image = global::Presentation.Properties.Resources.user;
            this.BUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BUsuarios.Location = new System.Drawing.Point(25, 386);
            this.BUsuarios.Name = "BUsuarios";
            this.BUsuarios.Size = new System.Drawing.Size(135, 38);
            this.BUsuarios.TabIndex = 3;
            this.BUsuarios.Text = "Usuarios";
            this.BUsuarios.UseVisualStyleBackColor = true;
            this.BUsuarios.Click += new System.EventHandler(this.BUsuarios_Click);
            // 
            // BCategorias
            // 
            this.BCategorias.Image = global::Presentation.Properties.Resources.categoria;
            this.BCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCategorias.Location = new System.Drawing.Point(25, 298);
            this.BCategorias.Name = "BCategorias";
            this.BCategorias.Size = new System.Drawing.Size(135, 38);
            this.BCategorias.TabIndex = 2;
            this.BCategorias.Text = "Categorias";
            this.BCategorias.UseVisualStyleBackColor = true;
            this.BCategorias.Click += new System.EventHandler(this.BCategorias_Click_1);
            // 
            // panelAdmin
            // 
            this.panelAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.panelAdmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panelAdmin.Font = new System.Drawing.Font("Mongolian Baiti", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelAdmin.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.panelAdmin.Location = new System.Drawing.Point(3, 88);
            this.panelAdmin.Multiline = true;
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(189, 70);
            this.panelAdmin.TabIndex = 1;
            this.panelAdmin.Text = "Panel de \r\nAdministración ";
            this.panelAdmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.panelAdmin.WordWrap = false;
            // 
            // BProductos
            // 
            this.BProductos.Image = global::Presentation.Properties.Resources.paquete;
            this.BProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BProductos.Location = new System.Drawing.Point(25, 254);
            this.BProductos.Name = "BProductos";
            this.BProductos.Size = new System.Drawing.Size(135, 38);
            this.BProductos.TabIndex = 0;
            this.BProductos.Text = "Productos";
            this.BProductos.UseVisualStyleBackColor = true;
            this.BProductos.Click += new System.EventHandler(this.BProductos_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(192, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(816, 679);
            this.panelContenedor.TabIndex = 1;
            // 
            // form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 679);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 718);
            this.Name = "form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button BProductos;
        private System.Windows.Forms.TextBox panelAdmin;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Button BClientes;
        private System.Windows.Forms.Button BUsuarios;
        private System.Windows.Forms.Button BCategorias;
    }
}

