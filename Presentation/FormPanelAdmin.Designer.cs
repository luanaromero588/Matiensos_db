namespace Presentation
{
    partial class FormPanelAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPanelAdmin));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.BCerrarSesion = new System.Windows.Forms.Button();
            this.BAuditoria = new System.Windows.Forms.Button();
            this.BVentas = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LPanelAdmin = new System.Windows.Forms.Label();
            this.Lgestion = new System.Windows.Forms.Label();
            this.Lcatalogo = new System.Windows.Forms.Label();
            this.BClientes = new System.Windows.Forms.Button();
            this.BUsuarios = new System.Windows.Forms.Button();
            this.BCategorias = new System.Windows.Forms.Button();
            this.BProductos = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelNavbar = new System.Windows.Forms.Panel();
            this.LInfoSesion = new System.Windows.Forms.Label();
            this.LMarca = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelNavbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.panelMenu.Controls.Add(this.BCerrarSesion);
            this.panelMenu.Controls.Add(this.BAuditoria);
            this.panelMenu.Controls.Add(this.BVentas);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.LPanelAdmin);
            this.panelMenu.Controls.Add(this.Lgestion);
            this.panelMenu.Controls.Add(this.Lcatalogo);
            this.panelMenu.Controls.Add(this.BClientes);
            this.panelMenu.Controls.Add(this.BUsuarios);
            this.panelMenu.Controls.Add(this.BCategorias);
            this.panelMenu.Controls.Add(this.BProductos);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMenu.Location = new System.Drawing.Point(0, 55);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(172, 624);
            this.panelMenu.TabIndex = 0;
            // 
            // BCerrarSesion
            // 
            this.BCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.BCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCerrarSesion.FlatAppearance.BorderSize = 0;
            this.BCerrarSesion.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCerrarSesion.Image = global::Presentation.Properties.Resources.cerrar_sesion__1_;
            this.BCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrarSesion.Location = new System.Drawing.Point(12, 553);
            this.BCerrarSesion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BCerrarSesion.MinimumSize = new System.Drawing.Size(150, 40);
            this.BCerrarSesion.Name = "BCerrarSesion";
            this.BCerrarSesion.Size = new System.Drawing.Size(150, 40);
            this.BCerrarSesion.TabIndex = 10;
            this.BCerrarSesion.Text = "Cerrar Sesión";
            this.BCerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BCerrarSesion.UseVisualStyleBackColor = false;
            this.BCerrarSesion.Click += new System.EventHandler(this.BCerrarSesion_Click);
            // 
            // BAuditoria
            // 
            this.BAuditoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.BAuditoria.FlatAppearance.BorderSize = 0;
            this.BAuditoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAuditoria.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAuditoria.Image = global::Presentation.Properties.Resources.investigar;
            this.BAuditoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAuditoria.Location = new System.Drawing.Point(10, 399);
            this.BAuditoria.Name = "BAuditoria";
            this.BAuditoria.Size = new System.Drawing.Size(150, 38);
            this.BAuditoria.TabIndex = 7;
            this.BAuditoria.Text = "Auditoria";
            this.BAuditoria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BAuditoria.UseVisualStyleBackColor = false;
            this.BAuditoria.Click += new System.EventHandler(this.BAuditoria_Click);
            // 
            // BVentas
            // 
            this.BVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.BVentas.FlatAppearance.BorderSize = 0;
            this.BVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVentas.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVentas.Image = global::Presentation.Properties.Resources.venta_de_compras;
            this.BVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BVentas.Location = new System.Drawing.Point(10, 355);
            this.BVentas.Name = "BVentas";
            this.BVentas.Size = new System.Drawing.Size(150, 38);
            this.BVentas.TabIndex = 6;
            this.BVentas.Text = "Ventas";
            this.BVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BVentas.UseVisualStyleBackColor = false;
            this.BVentas.Click += new System.EventHandler(this.BVentas_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            this.panel1.Location = new System.Drawing.Point(3, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 1);
            this.panel1.TabIndex = 0;
            // 
            // LPanelAdmin
            // 
            this.LPanelAdmin.AutoSize = true;
            this.LPanelAdmin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LPanelAdmin.Location = new System.Drawing.Point(3, 15);
            this.LPanelAdmin.Name = "LPanelAdmin";
            this.LPanelAdmin.Size = new System.Drawing.Size(156, 46);
            this.LPanelAdmin.TabIndex = 0;
            this.LPanelAdmin.Text = "Panel de \r\nAdministración\r\n";
            this.LPanelAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lgestion
            // 
            this.Lgestion.AutoSize = true;
            this.Lgestion.Font = new System.Drawing.Font("Mongolian Baiti", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lgestion.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Lgestion.Location = new System.Drawing.Point(34, 243);
            this.Lgestion.Name = "Lgestion";
            this.Lgestion.Size = new System.Drawing.Size(60, 11);
            this.Lgestion.TabIndex = 5;
            this.Lgestion.Text = "GESTIÓN";
            // 
            // Lcatalogo
            // 
            this.Lcatalogo.AutoSize = true;
            this.Lcatalogo.Font = new System.Drawing.Font("Mongolian Baiti", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lcatalogo.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Lcatalogo.Location = new System.Drawing.Point(34, 120);
            this.Lcatalogo.Name = "Lcatalogo";
            this.Lcatalogo.Size = new System.Drawing.Size(74, 11);
            this.Lcatalogo.TabIndex = 0;
            this.Lcatalogo.Text = "CATÁLOGO";
            // 
            // BClientes
            // 
            this.BClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.BClientes.FlatAppearance.BorderSize = 0;
            this.BClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BClientes.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BClientes.Image = global::Presentation.Properties.Resources.cliente;
            this.BClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BClientes.Location = new System.Drawing.Point(10, 267);
            this.BClientes.Name = "BClientes";
            this.BClientes.Size = new System.Drawing.Size(150, 38);
            this.BClientes.TabIndex = 4;
            this.BClientes.Text = "Clientes";
            this.BClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BClientes.UseVisualStyleBackColor = false;
            this.BClientes.Click += new System.EventHandler(this.BClientes_Click_1);
            // 
            // BUsuarios
            // 
            this.BUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.BUsuarios.FlatAppearance.BorderSize = 0;
            this.BUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BUsuarios.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUsuarios.Image = global::Presentation.Properties.Resources.user;
            this.BUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BUsuarios.Location = new System.Drawing.Point(10, 311);
            this.BUsuarios.Name = "BUsuarios";
            this.BUsuarios.Size = new System.Drawing.Size(150, 38);
            this.BUsuarios.TabIndex = 3;
            this.BUsuarios.Text = "Usuarios";
            this.BUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BUsuarios.UseVisualStyleBackColor = false;
            this.BUsuarios.Click += new System.EventHandler(this.BUsuarios_Click);
            // 
            // BCategorias
            // 
            this.BCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.BCategorias.FlatAppearance.BorderSize = 0;
            this.BCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCategorias.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCategorias.Image = global::Presentation.Properties.Resources.categoria;
            this.BCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCategorias.Location = new System.Drawing.Point(12, 187);
            this.BCategorias.Name = "BCategorias";
            this.BCategorias.Size = new System.Drawing.Size(150, 38);
            this.BCategorias.TabIndex = 2;
            this.BCategorias.Text = "Categorias";
            this.BCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BCategorias.UseVisualStyleBackColor = false;
            this.BCategorias.Click += new System.EventHandler(this.BCategorias_Click_1);
            // 
            // BProductos
            // 
            this.BProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.BProductos.FlatAppearance.BorderSize = 0;
            this.BProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BProductos.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BProductos.Image = global::Presentation.Properties.Resources.paquete;
            this.BProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BProductos.Location = new System.Drawing.Point(12, 143);
            this.BProductos.Name = "BProductos";
            this.BProductos.Size = new System.Drawing.Size(150, 38);
            this.BProductos.TabIndex = 0;
            this.BProductos.Text = "Productos";
            this.BProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BProductos.UseVisualStyleBackColor = false;
            this.BProductos.Click += new System.EventHandler(this.BProductos_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(172, 55);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(836, 624);
            this.panelContenedor.TabIndex = 1;
            // 
            // panelNavbar
            // 
            this.panelNavbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            this.panelNavbar.Controls.Add(this.LInfoSesion);
            this.panelNavbar.Controls.Add(this.LMarca);
            this.panelNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNavbar.Location = new System.Drawing.Point(0, 0);
            this.panelNavbar.Name = "panelNavbar";
            this.panelNavbar.Size = new System.Drawing.Size(1008, 55);
            this.panelNavbar.TabIndex = 0;
            this.panelNavbar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelNavbar_Paint);
            // 
            // LInfoSesion
            // 
            this.LInfoSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LInfoSesion.AutoSize = true;
            this.LInfoSesion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LInfoSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(112)))), ((int)(((byte)(102)))));
            this.LInfoSesion.Location = new System.Drawing.Point(800, 18);
            this.LInfoSesion.Name = "LInfoSesion";
            this.LInfoSesion.Size = new System.Drawing.Size(172, 15);
            this.LInfoSesion.TabIndex = 1;
            this.LInfoSesion.Text = "Operador: SuperAdmin (ID: 1)";
            // 
            // LMarca
            // 
            this.LMarca.AutoSize = true;
            this.LMarca.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.LMarca.Location = new System.Drawing.Point(20, 15);
            this.LMarca.Name = "LMarca";
            this.LMarca.Size = new System.Drawing.Size(140, 23);
            this.LMarca.TabIndex = 0;
            this.LMarca.Text = "MATIENSOS";
            // 
            // FormPanelAdmin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 679);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelNavbar);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 718);
            this.Name = "FormPanelAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de Administración";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelNavbar.ResumeLayout(false);
            this.panelNavbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button BProductos;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Button BClientes;
        private System.Windows.Forms.Button BUsuarios;
        private System.Windows.Forms.Button BCategorias;
        private System.Windows.Forms.Label Lgestion;
        private System.Windows.Forms.Label Lcatalogo;
        private System.Windows.Forms.Panel panelNavbar;
        private System.Windows.Forms.Label LInfoSesion;
        private System.Windows.Forms.Label LMarca;
        private System.Windows.Forms.Label LPanelAdmin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BAuditoria;
        private System.Windows.Forms.Button BVentas;
        private System.Windows.Forms.Button BCerrarSesion;
    }
}

