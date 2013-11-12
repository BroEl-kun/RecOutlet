namespace RecreationOutletPOS
{
    partial class CheckOutForm
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
            this.cmbCommissionTo = new System.Windows.Forms.ComboBox();
            this.lblCommissionTo = new System.Windows.Forms.Label();
            this.pnlCheckoutSummary = new System.Windows.Forms.Panel();
            this.summaryTax = new System.Windows.Forms.Label();
            this.summarySubTotal = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.summaryTotal = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnConfirmCheckOut = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.radCash = new System.Windows.Forms.RadioButton();
            this.radCredit = new System.Windows.Forms.RadioButton();
            this.ccField = new System.Windows.Forms.TextBox();
            this.pnlCheckoutSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCommissionTo
            // 
            this.cmbCommissionTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCommissionTo.FormattingEnabled = true;
            this.cmbCommissionTo.Items.AddRange(new object[] {
            "<Defaulted to Logged In User>",
            "Associate 1",
            "Associate 2",
            "Manager 1",
            "Manager 2"});
            this.cmbCommissionTo.Location = new System.Drawing.Point(158, 32);
            this.cmbCommissionTo.Name = "cmbCommissionTo";
            this.cmbCommissionTo.Size = new System.Drawing.Size(264, 21);
            this.cmbCommissionTo.TabIndex = 0;
            // 
            // lblCommissionTo
            // 
            this.lblCommissionTo.AutoSize = true;
            this.lblCommissionTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommissionTo.Location = new System.Drawing.Point(23, 33);
            this.lblCommissionTo.Name = "lblCommissionTo";
            this.lblCommissionTo.Size = new System.Drawing.Size(117, 20);
            this.lblCommissionTo.TabIndex = 1;
            this.lblCommissionTo.Text = "Commission To";
            // 
            // pnlCheckoutSummary
            // 
            this.pnlCheckoutSummary.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlCheckoutSummary.Controls.Add(this.summaryTax);
            this.pnlCheckoutSummary.Controls.Add(this.summarySubTotal);
            this.pnlCheckoutSummary.Controls.Add(this.lblSubtotal);
            this.pnlCheckoutSummary.Controls.Add(this.summaryTotal);
            this.pnlCheckoutSummary.Controls.Add(this.lblTax);
            this.pnlCheckoutSummary.Controls.Add(this.lblTotal);
            this.pnlCheckoutSummary.Location = new System.Drawing.Point(27, 88);
            this.pnlCheckoutSummary.Name = "pnlCheckoutSummary";
            this.pnlCheckoutSummary.Size = new System.Drawing.Size(395, 129);
            this.pnlCheckoutSummary.TabIndex = 2;
            // 
            // summaryTax
            // 
            this.summaryTax.AutoSize = true;
            this.summaryTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryTax.Location = new System.Drawing.Point(300, 41);
            this.summaryTax.Name = "summaryTax";
            this.summaryTax.Size = new System.Drawing.Size(55, 22);
            this.summaryTax.TabIndex = 11;
            this.summaryTax.Text = "$0.00";
            // 
            // summarySubTotal
            // 
            this.summarySubTotal.AutoSize = true;
            this.summarySubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summarySubTotal.Location = new System.Drawing.Point(300, 15);
            this.summarySubTotal.Name = "summarySubTotal";
            this.summarySubTotal.Size = new System.Drawing.Size(55, 22);
            this.summarySubTotal.TabIndex = 9;
            this.summarySubTotal.Text = "$0.00";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(14, 15);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(76, 22);
            this.lblSubtotal.TabIndex = 6;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // summaryTotal
            // 
            this.summaryTotal.AutoSize = true;
            this.summaryTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryTotal.Location = new System.Drawing.Point(300, 94);
            this.summaryTotal.Name = "summaryTotal";
            this.summaryTotal.Size = new System.Drawing.Size(55, 22);
            this.summaryTotal.TabIndex = 10;
            this.summaryTotal.Text = "$0.00";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(14, 41);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(41, 22);
            this.lblTax.TabIndex = 7;
            this.lblTax.Text = "Tax";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(14, 94);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(51, 22);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Total";
            // 
            // btnConfirmCheckOut
            // 
            this.btnConfirmCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmCheckOut.Location = new System.Drawing.Point(525, 389);
            this.btnConfirmCheckOut.Name = "btnConfirmCheckOut";
            this.btnConfirmCheckOut.Size = new System.Drawing.Size(166, 57);
            this.btnConfirmCheckOut.TabIndex = 3;
            this.btnConfirmCheckOut.Text = "Confirm Check Out";
            this.btnConfirmCheckOut.UseVisualStyleBackColor = true;
            this.btnConfirmCheckOut.Click += new System.EventHandler(this.btnConfirmCheckOut_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(342, 389);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(166, 57);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // radCash
            // 
            this.radCash.AutoSize = true;
            this.radCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCash.Location = new System.Drawing.Point(561, 281);
            this.radCash.Name = "radCash";
            this.radCash.Size = new System.Drawing.Size(80, 29);
            this.radCash.TabIndex = 5;
            this.radCash.TabStop = true;
            this.radCash.Text = "Cash";
            this.radCash.UseVisualStyleBackColor = true;
            this.radCash.CheckedChanged += new System.EventHandler(this.radCash_CheckedChanged);
            // 
            // radCredit
            // 
            this.radCredit.AutoSize = true;
            this.radCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCredit.Location = new System.Drawing.Point(561, 322);
            this.radCredit.Name = "radCredit";
            this.radCredit.Size = new System.Drawing.Size(87, 29);
            this.radCredit.TabIndex = 6;
            this.radCredit.TabStop = true;
            this.radCredit.Text = "Credit";
            this.radCredit.UseVisualStyleBackColor = true;
            this.radCredit.CheckedChanged += new System.EventHandler(this.radCredit_CheckedChanged);
            // 
            // ccField
            // 
            this.ccField.Location = new System.Drawing.Point(27, 409);
            this.ccField.Name = "ccField";
            this.ccField.Size = new System.Drawing.Size(100, 20);
            this.ccField.TabIndex = 7;
            this.ccField.TextChanged += new System.EventHandler(this.readCard);
            // 
            // CheckOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 458);
            this.Controls.Add(this.ccField);
            this.Controls.Add(this.radCredit);
            this.Controls.Add(this.radCash);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirmCheckOut);
            this.Controls.Add(this.pnlCheckoutSummary);
            this.Controls.Add(this.lblCommissionTo);
            this.Controls.Add(this.cmbCommissionTo);
            this.Name = "CheckOutForm";
            this.Text = "CheckOutForm";
            this.pnlCheckoutSummary.ResumeLayout(false);
            this.pnlCheckoutSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCommissionTo;
        private System.Windows.Forms.Label lblCommissionTo;
        private System.Windows.Forms.Panel pnlCheckoutSummary;
        private System.Windows.Forms.Button btnConfirmCheckOut;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label summaryTax;
        private System.Windows.Forms.Label summarySubTotal;
        private System.Windows.Forms.Label summaryTotal;
        private System.Windows.Forms.RadioButton radCash;
        private System.Windows.Forms.RadioButton radCredit;
        private System.Windows.Forms.TextBox ccField;
    }
}