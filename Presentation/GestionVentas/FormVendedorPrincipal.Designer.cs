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
            this.LConsulta = new System.Windows.Forms.Label();
            this.LGestion = new System.Windows.Forms.Label();
            this.BHistorialVentas = new System.Windows.Forms.Button();
            this.BCerrarSesion = new System.Windows.Forms.Button();
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
            this.panelMenu.Controls.Add(this.BNuevaVenta);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.LPanelVendedor);
            this.panelMenu.Controls.Add(this.LConsulta);
            this.panelMenu.Controls.Add(this.LGestion);
            this.panelMenu.Controls.Add(this.BHistorialVentas);
            this.panelMenu.Controls.Add(this.BCerrarSesion);
            this.panelMenu.Controls.Add(this.BProductos);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMenu.Location = new System.Drawing.Point(0, 55);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(172, 624);
            this.panelMenu.TabIndex = 2;
            // 
            // BNuevaVenta
            // 
            this.BNuevaVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BNuevaVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.BNuevaVenta.BackgroundImage = global::Presentation.Properties.Resources.nuevaVenta32;
            this.BNuevaVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BNuevaVenta.FlatAppearance.BorderSize = 0;
            this.BNuevaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BNuevaVenta.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevaVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BNuevaVenta.Location = new System.Drawing.Point(12, 144);
            this.BNuevaVenta.Name = "BNuevaVenta";
            this.BNuevaVenta.Size = new System.Drawing.Size(150, 38);
            this.BNuevaVenta.TabIndex = 6;
            this.BNuevaVenta.Text = "Nueva Venta";
            this.BNuevaVenta.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            this.panel1.Location = new System.Drawing.Point(3, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 1);
            this.panel1.TabIndex = 0;
            // 
            // LPanelVendedor
            // 
            this.LPanelVendedor.AutoSize = true;
            this.LPanelVendedor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LPanelVendedor.Location = new System.Drawing.Point(32, 16);
            this.LPanelVendedor.Name = "LPanelVendedor";
            this.LPanelVendedor.Size = new System.Drawing.Size(96, 46);
            this.LPanelVendedor.TabIndex = 0;
            this.LPanelVendedor.Text = "Panel de \r\nVentas";
            this.LPanelVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LConsulta
            // 
            this.LConsulta.AutoSize = true;
            this.LConsulta.Font = new System.Drawing.Font("Mongolian Baiti", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LConsulta.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.LConsulta.Location = new System.Drawing.Point(12, 224);
            this.LConsulta.Name = "LConsulta";
            this.LConsulta.Size = new System.Drawing.Size(79, 11);
            this.LConsulta.TabIndex = 5;
            this.LConsulta.Text = "CONSULTAS";
            // 
            // LGestion
            // 
            this.LGestion.AutoSize = true;
            this.LGestion.Font = new System.Drawing.Font("Mongolian Baiti", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGestion.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.LGestion.Location = new System.Drawing.Point(12, 120);
            this.LGestion.Name = "LGestion";
            this.LGestion.Size = new System.Drawing.Size(60, 11);
            this.LGestion.TabIndex = 0;
            this.LGestion.Text = "GESTIÓN";
            // 
            // BHistorialVentas
            // 
            this.BHistorialVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.BHistorialVentas.FlatAppearance.BorderSize = 0;
            this.BHistorialVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BHistorialVentas.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BHistorialVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BHistorialVentas.Location = new System.Drawing.Point(12, 295);
            this.BHistorialVentas.Name = "BHistorialVentas";
            this.BHistorialVentas.Size = new System.Drawing.Size(150, 38);
            this.BHistorialVentas.TabIndex = 4;
            this.BHistorialVentas.Text = "Historial";
            this.BHistorialVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BHistorialVentas.UseVisualStyleBackColor = false;
            // 
            // BCerrarSesion
            // 
            this.BCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.BCerrarSesion.FlatAppearance.BorderSize = 0;
            this.BCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCerrarSesion.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrarSesion.Location = new System.Drawing.Point(10, 535);
            this.BCerrarSesion.Name = "BCerrarSesion";
            this.BCerrarSesion.Size = new System.Drawing.Size(150, 38);
            this.BCerrarSesion.TabIndex = 3;
            this.BCerrarSesion.Text = "Cerrar Sesión";
            this.BCerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BCerrarSesion.UseVisualStyleBackColor = false;
            // 
            // BProductos
            // 
            this.BProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.BProductos.FlatAppearance.BorderSize = 0;
            this.BProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BProductos.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BProductos.Location = new System.Drawing.Point(12, 251);
            this.BProductos.Name = "BProductos";
            this.BProductos.Size = new System.Drawing.Size(150, 38);
            this.BProductos.TabIndex = 0;
            this.BProductos.Text = "Productos";
            this.BProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BProductos.UseVisualStyleBackColor = false;
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(226)))), ((int)(((byte)(220)))));
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 55);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1008, 624);
            this.panelContenedor.TabIndex = 4;
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
            this.panelNavbar.TabIndex = 3;
            // 
            // LInfoSesion
            // 
            this.LInfoSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LInfoSesion.AutoSize = true;
            this.LInfoSesion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LInfoSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(112)))), ((int)(((byte)(102)))));
            this.LInfoSesion.Location = new System.Drawing.Point(800, 18);
            this.LInfoSesion.Name = "LInfoSesion";
            this.LInfoSesion.Size = new System.Drawing.Size(127, 15);
            this.LInfoSesion.TabIndex = 1;
            this.LInfoSesion.Text = "Operador: Luis Pareto";
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 679);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelNavbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVendedorPrincipal";
            this.Text = "Panel de Gestión";
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
        private System.Windows.Forms.Label LConsulta;
        private System.Windows.Forms.Label LGestion;
        private System.Windows.Forms.Button BHistorialVentas;
        private System.Windows.Forms.Button BProductos;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panelNavbar;
        private System.Windows.Forms.Label LInfoSesion;
        private System.Windows.Forms.Label LMarca;
        private System.Windows.Forms.Button BCerrarSesion;
        private System.Windows.Forms.Button BNuevaVenta;
    }
}