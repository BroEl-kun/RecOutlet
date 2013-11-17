namespace RecreationOutletPOS
{
    partial class DiscountForm
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
            this.tbDiscountPrice = new System.Windows.Forms.TextBox();
            this.lblDiscPrice = new System.Windows.Forms.Label();
            this.tbDiscountPerc = new System.Windows.Forms.TextBox();
            this.lblDiscPerc = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbDiscountPrice
            // 
            this.tbDiscountPrice.Location = new System.Drawing.Point(109, 47);
            this.tbDiscountPrice.Name = "tbDiscountPrice";
            this.tbDiscountPrice.Size = new System.Drawing.Size(176, 20);
            this.tbDiscountPrice.TabIndex = 0;
            this.tbDiscountPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDiscountPrice_KeyPress);
            // 
            // lblDiscPrice
            // 
            this.lblDiscPrice.AutoSize = true;
            this.lblDiscPrice.Location = new System.Drawing.Point(12, 50);
            this.lblDiscPrice.Name = "lblDiscPrice";
            this.lblDiscPrice.Size = new System.Drawing.Size(100, 13);
            this.lblDiscPrice.TabIndex = 1;
            this.lblDiscPrice.Text = "Discount Price:     $";
            // 
            // tbDiscountPerc
            // 
            this.tbDiscountPerc.Location = new System.Drawing.Point(142, 72);
            this.tbDiscountPerc.Name = "tbDiscountPerc";
            this.tbDiscountPerc.Size = new System.Drawing.Size(143, 20);
            this.tbDiscountPerc.TabIndex = 2;
            this.tbDiscountPerc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDiscountPerc_KeyPress);
            // 
            // lblDiscPerc
            // 
            this.lblDiscPerc.AutoSize = true;
            this.lblDiscPerc.Location = new System.Drawing.Point(12, 79);
            this.lblDiscPerc.Name = "lblDiscPerc";
            this.lblDiscPerc.Size = new System.Drawing.Size(133, 13);
            this.lblDiscPerc.TabIndex = 3;
            this.lblDiscPerc.Text = "Discount Percentage:     %";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 9);
            this.lblDescription.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(282, 26);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Enter the discount as either a value or percentage. This is applied to individual" +
    " items.";
            // 
            // DiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 118);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblDiscPerc);
            this.Controls.Add(this.tbDiscountPerc);
            this.Controls.Add(this.lblDiscPrice);
            this.Controls.Add(this.tbDiscountPrice);
            this.Name = "DiscountForm";
            this.Text = "DiscountForm";
            this.Load += new System.EventHandler(this.DiscountForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDiscountPrice;
        private System.Windows.Forms.Label lblDiscPrice;
        private System.Windows.Forms.TextBox tbDiscountPerc;
        private System.Windows.Forms.Label lblDiscPerc;
        private System.Windows.Forms.Label lblDescription;
    }
}