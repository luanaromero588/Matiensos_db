namespace Presentation.GestionVentas
{
    partial class FormVendedorPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendedorPrincipal));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.BNuevaVenta = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LPanelVendedor = new System.Windows.Forms.Label();
            this.LConsultas = new System.Windows.Forms.Label();
            this.LGestion = new System.Windows.Forms.Label();
            this.BHistorial = new System.Windows.Forms.Button();
            this.BCerrarSesion = new System.Windows.Forms.Button();
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
            this.panelMenu.Controls.Add(this.BNuevaVenta);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.LPanelVendedor);
            this.panelMenu.Controls.Add(this.LConsultas);
            this.panelMenu.Controls.Add(this.LGestion);
            this.panelMenu.Controls.Add(this.BHistorial);
            this.panelMenu.Controls.Add(this.BCerrarSesion);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMenu.Location = new System.Drawing.Point(0, 55);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(172, 700);
            this.panelMenu.TabIndex = 2;
            // 
            // BNuevaVenta
            // 
            this.BNuevaVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.BNuevaVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BNuevaVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BNuevaVenta.FlatAppearance.BorderSize = 0;
            this.BNuevaVenta.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevaVenta.Image = global::Presentation.Properties.Resources.nueva_factura1;
            this.BNuevaVenta.Location = new System.Drawing.Point(12, 143);
            this.BNuevaVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BNuevaVenta.Name = "BNuevaVenta";
            this.BNuevaVenta.Size = new System.Drawing.Size(150, 40);
            this.BNuevaVenta.TabIndex = 6;
            this.BNuevaVenta.Text = "Nueva Venta";
            this.BNuevaVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BNuevaVenta.UseVisualStyleBackColor = false;
            this.BNuevaVenta.Click += new System.EventHandler(this.BNuevaVenta_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            this.panel1.Location = new System.Drawing.Point(3, 78);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 1);
            this.panel1.TabIndex = 0;
            // 
            // LPanelVendedor
            // 
            this.LPanelVendedor.Font = new System.Drawing.Font("Mongolian Baiti", 15.78F, System.Drawing.FontStyle.Bold);
            this.LPanelVendedor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LPanelVendedor.Location = new System.Drawing.Point(3, 15);
            this.LPanelVendedor.Name = "LPanelVendedor";
            this.LPanelVendedor.Size = new System.Drawing.Size(169, 46);
            this.LPanelVendedor.TabIndex = 0;
            this.LPanelVendedor.Text = "Panel de \r\nVentas";
            this.LPanelVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LConsultas
            // 
            this.LConsultas.Font = new System.Drawing.Font("Mongolian Baiti", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LConsultas.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.LConsultas.Location = new System.Drawing.Point(34, 243);
            this.LConsultas.Name = "LConsultas";
            this.LConsultas.Size = new System.Drawing.Size(106, 22);
            this.LConsultas.TabIndex = 5;
            this.LConsultas.Text = "CONSULTAS";
            // 
            // LGestion
            // 
            this.LGestion.AutoSize = true;
            this.LGestion.Font = new System.Drawing.Font("Mongolian Baiti", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGestion.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.LGestion.Location = new System.Drawing.Point(34, 120);
            this.LGestion.Name = "LGestion";
            this.LGestion.Size = new System.Drawing.Size(60, 11);
            this.LGestion.TabIndex = 0;
            this.LGestion.Text = "GESTIÓN";
            // 
            // BHistorial
            // 
            this.BHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.BHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BHistorial.FlatAppearance.BorderSize = 0;
            this.BHistorial.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BHistorial.Image = global::Presentation.Properties.Resources.historial_de_transacciones1;
            this.BHistorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BHistorial.Location = new System.Drawing.Point(10, 267);
            this.BHistorial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BHistorial.Name = "BHistorial";
            this.BHistorial.Size = new System.Drawing.Size(150, 40);
            this.BHistorial.TabIndex = 4;
            this.BHistorial.Text = "Historial";
            this.BHistorial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BHistorial.UseVisualStyleBackColor = false;
            this.BHistorial.Click += new System.EventHandler(this.BHistorial_Click);
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
            this.BCerrarSesion.TabIndex = 3;
            this.BCerrarSesion.Text = "Cerrar Sesión";
            this.BCerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BCerrarSesion.UseVisualStyleBackColor = false;
            this.BCerrarSesion.Click += new System.EventHandler(this.BCerrarSesion_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(172, 55);
            this.panelContenedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1200, 700);
            this.panelContenedor.TabIndex = 4;
            // 
            // panelNavbar
            // 
            this.panelNavbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            this.panelNavbar.Controls.Add(this.LInfoSesion);
            this.panelNavbar.Controls.Add(this.LMarca);
            this.panelNavbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNavbar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelNavbar.Location = new System.Drawing.Point(0, 0);
            this.panelNavbar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelNavbar.Name = "panelNavbar";
            this.panelNavbar.Size = new System.Drawing.Size(1372, 55);
            this.panelNavbar.TabIndex = 3;
            this.panelNavbar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelNavbar_Paint);
            // 
            // LInfoSesion
            // 
            this.LInfoSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LInfoSesion.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LInfoSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(112)))), ((int)(((byte)(102)))));
            this.LInfoSesion.Location = new System.Drawing.Point(1057, 15);
            this.LInfoSesion.Name = "LInfoSesion";
            this.LInfoSesion.Size = new System.Drawing.Size(202, 15);
            this.LInfoSesion.TabIndex = 1;
            this.LInfoSesion.Text = "Operador:";
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
            // FormVendedorPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(1200, 700);
            this.ClientSize = new System.Drawing.Size(1284, 679);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelNavbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormVendedorPrincipal";
            this.Text = "Panel de Gestión";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormVendedorPrincipal_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelNavbar.ResumeLayout(false);
            this.panelNavbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LPanelVendedor;
        private System.Windows.Forms.Label LConsultas;
        private System.Windows.Forms.Label LGestion;
        private System.Windows.Forms.Button BHistorial;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panelNavbar;
        private System.Windows.Forms.Label LInfoSesion;
        private System.Windows.Forms.Label LMarca;
        private System.Windows.Forms.Button BCerrarSesion;
        private System.Windows.Forms.Button BNuevaVenta;
    }
}