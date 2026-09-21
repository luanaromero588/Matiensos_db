namespace Presentation.GestionVentas
{
    partial class FormTicket
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
            this.PFondoTicket = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BImprimirTicket = new System.Windows.Forms.Button();
            this.BCerrarTicket = new System.Windows.Forms.Button();
            this.TBContenidoTicket = new System.Windows.Forms.TextBox();
            this.PrintDocumentTicket = new System.Drawing.Printing.PrintDocument();
            this.PFondoTicket.SuspendLayout();
            this.SuspendLayout();
            // 
            // PFondoTicket
            // 
            this.PFondoTicket.BackColor = System.Drawing.Color.White;
            this.PFondoTicket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PFondoTicket.Controls.Add(this.TBContenidoTicket);
            this.PFondoTicket.Location = new System.Drawing.Point(25, 20);
            this.PFondoTicket.Name = "PFondoTicket";
            this.PFondoTicket.Padding = new System.Windows.Forms.Padding(10);
            this.PFondoTicket.Size = new System.Drawing.Size(315, 420);
            this.PFondoTicket.TabIndex = 0;
            // 
            // BImprimirTicket
            // 
            this.Load += new System.EventHandler(this.FormTicket_Load);
            this.BImprimirTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(80)))));
            this.BImprimirTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BImprimirTicket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(250)))));
            this.BImprimirTicket.Location = new System.Drawing.Point(94, 452);
            this.BImprimirTicket.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BImprimirTicket.Name = "BImprimirTicket";
            this.BImprimirTicket.Size = new System.Drawing.Size(81, 25);
            this.BImprimirTicket.TabIndex = 25;
            this.BImprimirTicket.Text = "Imprimir";
            this.BImprimirTicket.UseVisualStyleBackColor = false;
            this.BImprimirTicket.Click += new System.EventHandler(this.BImprimirTicket_Click);
            // 
            // BCerrarTicket
            // 
            this.BCerrarTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BCerrarTicket.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BCerrarTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCerrarTicket.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCerrarTicket.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.BCerrarTicket.FlatAppearance.BorderSize = 2;
            this.BCerrarTicket.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.BCerrarTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCerrarTicket.ForeColor = System.Drawing.Color.Firebrick;
            this.BCerrarTicket.Location = new System.Drawing.Point(184, 454);
            this.BCerrarTicket.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BCerrarTicket.Name = "BCerrarTicket";
            this.BCerrarTicket.Size = new System.Drawing.Size(56, 21);
            this.BCerrarTicket.TabIndex = 26;
            this.BCerrarTicket.Text = "Cerrar";
            this.BCerrarTicket.UseVisualStyleBackColor = false;
            this.BCerrarTicket.Click += new System.EventHandler(this.BCerrarTicket_Click);
            this.PrintDocumentTicket.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocumentTicket_PrintPage);
            // 
            // TBContenidoTicket
            // 
            
            this.TBContenidoTicket.BackColor = System.Drawing.Color.White;
            this.TBContenidoTicket.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBContenidoTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBContenidoTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBContenidoTicket.ForeColor = System.Drawing.Color.Black;
            this.TBContenidoTicket.Location = new System.Drawing.Point(10, 10);
            this.TBContenidoTicket.Multiline = true;
            this.TBContenidoTicket.Name = "TBContenidoTicket";
            this.TBContenidoTicket.ReadOnly = true;
            this.TBContenidoTicket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBContenidoTicket.Size = new System.Drawing.Size(293, 398);
            this.TBContenidoTicket.TabIndex = 0;
            // 
            // FormTicket
            // 
            this.AcceptButton = this.BImprimirTicket;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCerrarTicket;
            this.ClientSize = new System.Drawing.Size(364, 521);
            this.Controls.Add(this.BCerrarTicket);
            this.Controls.Add(this.BImprimirTicket);
            this.Controls.Add(this.PFondoTicket);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Comprobante  de Venta - Matiensos";
            this.PFondoTicket.ResumeLayout(false);
            this.PFondoTicket.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PFondoTicket;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button BImprimirTicket;
        private System.Windows.Forms.Button BCerrarTicket;
        private System.Windows.Forms.TextBox TBContenidoTicket;
        private System.Drawing.Printing.PrintDocument PrintDocumentTicket;
    }
}