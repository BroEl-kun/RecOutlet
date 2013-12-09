namespace RecreationOutletPOS
{
    partial class PinNumberForm
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
            this.tbPinNumber = new System.Windows.Forms.TextBox();
            this.lblPin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPinNumber
            // 
            this.tbPinNumber.Location = new System.Drawing.Point(60, 12);
            this.tbPinNumber.Name = "tbPinNumber";
            this.tbPinNumber.PasswordChar = '*';
            this.tbPinNumber.Size = new System.Drawing.Size(93, 20);
            this.tbPinNumber.TabIndex = 0;
            this.tbPinNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPinNumber_KeyPress);
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Location = new System.Drawing.Point(12, 15);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(28, 13);
            this.lblPin.TabIndex = 1;
            this.lblPin.Text = "PIN:";
            // 
            // PinNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 39);
            this.Controls.Add(this.lblPin);
            this.Controls.Add(this.tbPinNumber);
            this.Name = "PinNumberForm";
            this.Text = "PinNumberForm";
            this.Load += new System.EventHandler(this.PinNumberForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPinNumber;
        private System.Windows.Forms.Label lblPin;
    }
}