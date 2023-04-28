namespace frmShopping
{
    partial class frmCodigoBarras
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
            this.picCodigoBarras = new System.Windows.Forms.PictureBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.butDraw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCodigoBarras)).BeginInit();
            this.SuspendLayout();
            // 
            // picCodigoBarras
            // 
            this.picCodigoBarras.Location = new System.Drawing.Point(12, 47);
            this.picCodigoBarras.Name = "picCodigoBarras";
            this.picCodigoBarras.Size = new System.Drawing.Size(300, 240);
            this.picCodigoBarras.TabIndex = 0;
            this.picCodigoBarras.TabStop = false;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(22, 9);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(53, 20);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "label1";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(12, 293);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(135, 32);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir Código";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // butDraw
            // 
            this.butDraw.Location = new System.Drawing.Point(161, 293);
            this.butDraw.Name = "butDraw";
            this.butDraw.Size = new System.Drawing.Size(170, 32);
            this.butDraw.TabIndex = 3;
            this.butDraw.Text = "Gerar Código de Barras";
            this.butDraw.Click += new System.EventHandler(this.butDraw_Click);
            // 
            // frmCodigoBarras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 354);
            this.Controls.Add(this.butDraw);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.picCodigoBarras);
            this.Name = "frmCodigoBarras";
            this.Text = "frmCodigoBarras";
            this.Load += new System.EventHandler(this.frmCodigoBarras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCodigoBarras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCodigoBarras;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button butDraw;
    }
}