namespace RecreationOutletPOS
{
    partial class ShowReportForm
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
            this.lvReportResults = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.lblValue1 = new System.Windows.Forms.Label();
            this.lblLabel2 = new System.Windows.Forms.Label();
            this.lblLabel1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblInventoryFrom = new System.Windows.Forms.Label();
            this.cmbInventoryFrom = new System.Windows.Forms.ComboBox();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.lblSearchBy = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.TransactionID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TransTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TransTax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TransactionDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmployeeID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StoreID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TerminalID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PaymentType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ManagerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvReportResults
            // 
            this.lvReportResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TransactionID,
            this.TransTotal,
            this.TransTax,
            this.PaymentType,
            this.TransactionDate,
            this.EmployeeID,
            this.ManagerID,
            this.StoreID,
            this.TerminalID});
            this.lvReportResults.Location = new System.Drawing.Point(12, 153);
            this.lvReportResults.Name = "lvReportResults";
            this.lvReportResults.Size = new System.Drawing.Size(733, 265);
            this.lvReportResults.TabIndex = 0;
            this.lvReportResults.UseCompatibleStateImageBehavior = false;
            this.lvReportResults.View = System.Windows.Forms.View.Details;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblValue2);
            this.groupBox1.Controls.Add(this.lblValue1);
            this.groupBox1.Controls.Add(this.lblLabel2);
            this.groupBox1.Controls.Add(this.lblLabel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 125);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Summary";
            // 
            // lblValue2
            // 
            this.lblValue2.AutoSize = true;
            this.lblValue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue2.Location = new System.Drawing.Point(172, 67);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(56, 17);
            this.lblValue2.TabIndex = 55;
            this.lblValue2.Text = "Value 2";
            // 
            // lblValue1
            // 
            this.lblValue1.AutoSize = true;
            this.lblValue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue1.Location = new System.Drawing.Point(172, 40);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.Size = new System.Drawing.Size(56, 17);
            this.lblValue1.TabIndex = 54;
            this.lblValue1.Text = "Value 1";
            // 
            // lblLabel2
            // 
            this.lblLabel2.AutoSize = true;
            this.lblLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel2.Location = new System.Drawing.Point(17, 67);
            this.lblLabel2.Name = "lblLabel2";
            this.lblLabel2.Size = new System.Drawing.Size(81, 17);
            this.lblLabel2.TabIndex = 53;
            this.lblLabel2.Text = "Total Count";
            // 
            // lblLabel1
            // 
            this.lblLabel1.AutoSize = true;
            this.lblLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel1.Location = new System.Drawing.Point(17, 40);
            this.lblLabel1.Name = "lblLabel1";
            this.lblLabel1.Size = new System.Drawing.Size(89, 17);
            this.lblLabel1.TabIndex = 52;
            this.lblLabel1.Text = "Money Made";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblInventoryFrom);
            this.groupBox2.Controls.Add(this.cmbInventoryFrom);
            this.groupBox2.Controls.Add(this.cmbSearchBy);
            this.groupBox2.Controls.Add(this.lblSearchBy);
            this.groupBox2.Controls.Add(this.lblSearch);
            this.groupBox2.Controls.Add(this.txtSearchValue);
            this.groupBox2.Location = new System.Drawing.Point(307, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 125);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Filters";
            // 
            // lblInventoryFrom
            // 
            this.lblInventoryFrom.AutoSize = true;
            this.lblInventoryFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventoryFrom.Location = new System.Drawing.Point(18, 93);
            this.lblInventoryFrom.Name = "lblInventoryFrom";
            this.lblInventoryFrom.Size = new System.Drawing.Size(102, 17);
            this.lblInventoryFrom.TabIndex = 56;
            this.lblInventoryFrom.Text = "Inventory From";
            // 
            // cmbInventoryFrom
            // 
            this.cmbInventoryFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInventoryFrom.FormattingEnabled = true;
            this.cmbInventoryFrom.Location = new System.Drawing.Point(126, 92);
            this.cmbInventoryFrom.Name = "cmbInventoryFrom";
            this.cmbInventoryFrom.Size = new System.Drawing.Size(137, 21);
            this.cmbInventoryFrom.TabIndex = 55;
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.Location = new System.Drawing.Point(126, 65);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(137, 21);
            this.cmbSearchBy.TabIndex = 54;
            // 
            // lblSearchBy
            // 
            this.lblSearchBy.AutoSize = true;
            this.lblSearchBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchBy.Location = new System.Drawing.Point(18, 67);
            this.lblSearchBy.Name = "lblSearchBy";
            this.lblSearchBy.Size = new System.Drawing.Size(73, 17);
            this.lblSearchBy.TabIndex = 53;
            this.lblSearchBy.Text = "Search By";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(18, 27);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(53, 17);
            this.lblSearch.TabIndex = 51;
            this.lblSearch.Text = "Search";
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(77, 27);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(340, 20);
            this.txtSearchValue.TabIndex = 50;
            // 
            // TransactionID
            // 
            this.TransactionID.Text = "TransactionID";
            // 
            // TransTotal
            // 
            this.TransTotal.Text = "TransTotal";
            // 
            // TransTax
            // 
            this.TransTax.Text = "TransTax";
            // 
            // TransactionDate
            // 
            this.TransactionDate.DisplayIndex = 3;
            this.TransactionDate.Text = "TransactionDate";
            // 
            // EmployeeID
            // 
            this.EmployeeID.DisplayIndex = 4;
            this.EmployeeID.Text = "EmployeeID";
            // 
            // StoreID
            // 
            this.StoreID.DisplayIndex = 5;
            this.StoreID.Text = "StoreID";
            // 
            // TerminalID
            // 
            this.TerminalID.DisplayIndex = 6;
            this.TerminalID.Text = "TerminalID";
            // 
            // PaymentType
            // 
            this.PaymentType.DisplayIndex = 7;
            this.PaymentType.Text = "PaymentType";
            // 
            // ManagerID
            // 
            this.ManagerID.DisplayIndex = 8;
            this.ManagerID.Text = "ManagerID";
            // 
            // ShowReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 426);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvReportResults);
            this.Name = "ShowReportForm";
            this.Text = "ShowReportForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvReportResults;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.ComboBox cmbSearchBy;
        private System.Windows.Forms.Label lblSearchBy;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.Label lblValue1;
        private System.Windows.Forms.Label lblLabel2;
        private System.Windows.Forms.Label lblLabel1;
        private System.Windows.Forms.Label lblInventoryFrom;
        private System.Windows.Forms.ComboBox cmbInventoryFrom;
        private System.Windows.Forms.ColumnHeader TransactionID;
        private System.Windows.Forms.ColumnHeader TransTotal;
        private System.Windows.Forms.ColumnHeader TransTax;
        private System.Windows.Forms.ColumnHeader PaymentType;
        private System.Windows.Forms.ColumnHeader TransactionDate;
        private System.Windows.Forms.ColumnHeader EmployeeID;
        private System.Windows.Forms.ColumnHeader ManagerID;
        private System.Windows.Forms.ColumnHeader StoreID;
        private System.Windows.Forms.ColumnHeader TerminalID;
    }
}