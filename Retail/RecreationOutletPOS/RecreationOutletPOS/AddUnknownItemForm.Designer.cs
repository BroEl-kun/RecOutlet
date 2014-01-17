namespace RecreationOutletPOS
{
    partial class AddUnknownItemForm
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
            this.tbAddItemPrice = new System.Windows.Forms.TextBox();
            this.lblAddItemPrice = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbAddItemPrice
            // 
            this.tbAddItemPrice.Location = new System.Drawing.Point(97, 16);
            this.tbAddItemPrice.Name = "tbAddItemPrice";
            this.tbAddItemPrice.Size = new System.Drawing.Size(100, 20);
            this.tbAddItemPrice.TabIndex = 2;
            this.tbAddItemPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAddItemPrice_KeyPress);
            // 
            // lblAddItemPrice
            // 
            this.lblAddItemPrice.AutoSize = true;
            this.lblAddItemPrice.Location = new System.Drawing.Point(12, 19);
            this.lblAddItemPrice.Name = "lblAddItemPrice";
            this.lblAddItemPrice.Size = new System.Drawing.Size(84, 13);
            this.lblAddItemPrice.TabIndex = 3;
            this.lblAddItemPrice.Text = "Price of Item:   $";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(97, 42);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbQuantity.TabIndex = 4;
            this.tbQuantity.Text = "1";
            this.tbQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbQuantity_KeyPress);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(12, 45);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "Quantity:";
            // 
            // AddUnknownItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 78);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.lblAddItemPrice);
            this.Controls.Add(this.tbAddItemPrice);
            this.Name = "AddUnknownItemForm";
            this.Text = "Add Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAddItemPrice;
        private System.Windows.Forms.Label lblAddItemPrice;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label lblQuantity;
    }
}