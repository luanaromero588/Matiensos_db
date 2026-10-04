namespace Presentation
{
    partial class FormFiltrosProductos
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
            this.CBCategoriaFiltro = new System.Windows.Forms.ComboBox();
            this.LCategoria = new System.Windows.Forms.Label();
            this.LEstado = new System.Windows.Forms.Label();
            this.CBEstadoFiltro = new System.Windows.Forms.ComboBox();
            this.LStock = new System.Windows.Forms.Label();
            this.CBStockFiltro = new System.Windows.Forms.ComboBox();
            this.BAplicarFiltros = new System.Windows.Forms.Button();
            this.BLimpiarFiltros = new System.Windows.Forms.Button();
            this.BCancelarFiltros = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CBCategoriaFiltro
            // 
            this.CBCategoriaFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCategoriaFiltro.FormattingEnabled = true;
            this.CBCategoriaFiltro.Location = new System.Drawing.Point(12, 43);
            this.CBCategoriaFiltro.Name = "CBCategoriaFiltro";
            this.CBCategoriaFiltro.Size = new System.Drawing.Size(260, 24);
            this.CBCategoriaFiltro.TabIndex = 0;
            // 
            // LCategoria
            // 
            this.LCategoria.AutoEllipsis = true;
            this.LCategoria.AutoSize = true;
            this.LCategoria.BackColor = System.Drawing.Color.Transparent;
            this.LCategoria.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCategoria.Location = new System.Drawing.Point(13, 24);
            this.LCategoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LCategoria.Name = "LCategoria";
            this.LCategoria.Size = new System.Drawing.Size(76, 16);
            this.LCategoria.TabIndex = 1;
            this.LCategoria.Text = "Categoria";
            // 
            // LEstado
            // 
            this.LEstado.AutoEllipsis = true;
            this.LEstado.AutoSize = true;
            this.LEstado.BackColor = System.Drawing.Color.Transparent;
            this.LEstado.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEstado.Location = new System.Drawing.Point(13, 88);
            this.LEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(55, 16);
            this.LEstado.TabIndex = 2;
            this.LEstado.Text = "Estado";
            // 
            // CBEstadoFiltro
            // 
            this.CBEstadoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBEstadoFiltro.FormattingEnabled = true;
            this.CBEstadoFiltro.Location = new System.Drawing.Point(12, 107);
            this.CBEstadoFiltro.Name = "CBEstadoFiltro";
            this.CBEstadoFiltro.Size = new System.Drawing.Size(260, 24);
            this.CBEstadoFiltro.TabIndex = 3;
            // 
            // LStock
            // 
            this.LStock.AutoEllipsis = true;
            this.LStock.AutoSize = true;
            this.LStock.BackColor = System.Drawing.Color.Transparent;
            this.LStock.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LStock.Location = new System.Drawing.Point(13, 156);
            this.LStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LStock.Name = "LStock";
            this.LStock.Size = new System.Drawing.Size(47, 16);
            this.LStock.TabIndex = 4;
            this.LStock.Text = "Stock";
            // 
            // CBStockFiltro
            // 
            this.CBStockFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBStockFiltro.FormattingEnabled = true;
            this.CBStockFiltro.Location = new System.Drawing.Point(12, 175);
            this.CBStockFiltro.Name = "CBStockFiltro";
            this.CBStockFiltro.Size = new System.Drawing.Size(260, 24);
            this.CBStockFiltro.TabIndex = 5;
            // 
            // BAplicarFiltros
            // 
            this.BAplicarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BAplicarFiltros.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAplicarFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BAplicarFiltros.Location = new System.Drawing.Point(172, 221);
            this.BAplicarFiltros.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BAplicarFiltros.Name = "BAplicarFiltros";
            this.BAplicarFiltros.Size = new System.Drawing.Size(100, 27);
            this.BAplicarFiltros.TabIndex = 6;
            this.BAplicarFiltros.Text = "Aplicar";
            this.BAplicarFiltros.UseVisualStyleBackColor = false;
            this.BAplicarFiltros.Click += new System.EventHandler(this.BAplicarFiltros_Click);
            // 
            // BLimpiarFiltros
            // 
            this.BLimpiarFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BLimpiarFiltros.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiarFiltros.ForeColor = System.Drawing.Color.Firebrick;
            this.BLimpiarFiltros.Location = new System.Drawing.Point(12, 221);
            this.BLimpiarFiltros.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BLimpiarFiltros.Name = "BLimpiarFiltros";
            this.BLimpiarFiltros.Size = new System.Drawing.Size(100, 27);
            this.BLimpiarFiltros.TabIndex = 7;
            this.BLimpiarFiltros.Text = "Limpiar filtros";
            this.BLimpiarFiltros.UseVisualStyleBackColor = false;
            this.BLimpiarFiltros.Click += new System.EventHandler(this.BLimpiarFiltros_Click);
            // 
            // BCancelarFiltros
            // 
            this.BCancelarFiltros.BackColor = System.Drawing.Color.Gainsboro;
            this.BCancelarFiltros.Location = new System.Drawing.Point(12, 221);
            this.BCancelarFiltros.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BCancelarFiltros.Name = "BCancelarFiltros";
            this.BCancelarFiltros.Size = new System.Drawing.Size(0, 0);
            this.BCancelarFiltros.TabIndex = 8;
            this.BCancelarFiltros.UseVisualStyleBackColor = false;
            this.BCancelarFiltros.Visible = false;
            this.BCancelarFiltros.Click += new System.EventHandler(this.BCancelarFiltros_Click);
            // 
            // FormFiltrosProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.BCancelarFiltros);
            this.Controls.Add(this.BLimpiarFiltros);
            this.Controls.Add(this.BAplicarFiltros);
            this.Controls.Add(this.CBStockFiltro);
            this.Controls.Add(this.LStock);
            this.Controls.Add(this.CBEstadoFiltro);
            this.Controls.Add(this.LEstado);
            this.Controls.Add(this.LCategoria);
            this.Controls.Add(this.CBCategoriaFiltro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormFiltrosProductos";
            this.Text = "Filtros Avanzados";
            this.Load += new System.EventHandler(this.FormFiltrosProductos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBCategoriaFiltro;
        private System.Windows.Forms.Label LCategoria;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.ComboBox CBEstadoFiltro;
        private System.Windows.Forms.Label LStock;
        private System.Windows.Forms.ComboBox CBStockFiltro;
        private System.Windows.Forms.Button BAplicarFiltros;
        private System.Windows.Forms.Button BLimpiarFiltros;
        private System.Windows.Forms.Button BCancelarFiltros;
    }
    }