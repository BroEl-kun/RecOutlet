namespace RecreationOutletPOS
{
    partial class PriceOverideForm
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
            this.txtPriceOveride = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPriceOveride
            // 
            this.txtPriceOveride.Location = new System.Drawing.Point(64, 56);
            this.txtPriceOveride.Name = "txtPriceOveride";
            this.txtPriceOveride.Size = new System.Drawing.Size(100, 20);
            this.txtPriceOveride.TabIndex = 0;
            this.txtPriceOveride.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtPriceOveride.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPriceOveride_KeyPress);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(12, 59);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(55, 13);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "Price:     $";
            // 
            // PriceOverideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 116);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPriceOveride);
            this.Name = "PriceOverideForm";
            this.Text = "PriceOverideForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPriceOveride;
        private System.Windows.Forms.Label lblPrice;
    }
}