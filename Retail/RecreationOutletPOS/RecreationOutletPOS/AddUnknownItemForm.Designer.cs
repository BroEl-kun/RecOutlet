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
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbAddItemPrice
            // 
            this.tbAddItemPrice.Location = new System.Drawing.Point(97, 40);
            this.tbAddItemPrice.Name = "tbAddItemPrice";
            this.tbAddItemPrice.Size = new System.Drawing.Size(100, 20);
            this.tbAddItemPrice.TabIndex = 2;
            this.tbAddItemPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAddItemPrice_KeyPress);
            // 
            // lblAddItemPrice
            // 
            this.lblAddItemPrice.AutoSize = true;
            this.lblAddItemPrice.Location = new System.Drawing.Point(12, 43);
            this.lblAddItemPrice.Name = "lblAddItemPrice";
            this.lblAddItemPrice.Size = new System.Drawing.Size(84, 13);
            this.lblAddItemPrice.TabIndex = 3;
            this.lblAddItemPrice.Text = "Price of Item:   $";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(97, 66);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbQuantity.TabIndex = 4;
            this.tbQuantity.Text = "1";
            this.tbQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbQuantity_KeyPress);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(12, 69);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "Quantity:";
            // 
            // tbItemName
            // 
            this.tbItemName.Location = new System.Drawing.Point(97, 15);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(100, 20);
            this.tbItemName.TabIndex = 6;
            this.tbItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbItemName_KeyPress);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(12, 18);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(73, 13);
            this.lblItemName.TabIndex = 7;
            this.lblItemName.Text = "Name of Item:";
            // 
            // AddUnknownItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 102);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.tbItemName);
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
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.Label lblItemName;
    }
}