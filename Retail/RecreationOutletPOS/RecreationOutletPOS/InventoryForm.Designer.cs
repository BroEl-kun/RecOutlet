namespace RecreationOutletPOS
{
    /// <summary>
    /// Created By: Michael Vuong
    /// Last Updated: 10/11/2013 by Michael Vuong
    /// 
    /// Represent a form that will allow the user to look up inventory information
    /// </summary>
    partial class InventoryForm
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
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnReturns = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.cmbInventoryFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lsvCheckOutItems = new System.Windows.Forms.ListView();
            this.RecRPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductLineID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SeasonCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CategoryID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DepartmentID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RetrictedAge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreatedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreatedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LegacyDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MSRP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SellPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaxRateID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(822, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(87, 59);
            this.btnSettings.TabIndex = 23;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(405, 12);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(125, 59);
            this.btnReports.TabIndex = 22;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventory.Enabled = false;
            this.btnInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.Location = new System.Drawing.Point(274, 12);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(125, 59);
            this.btnInventory.TabIndex = 21;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = false;
            // 
            // btnReturns
            // 
            this.btnReturns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturns.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturns.Location = new System.Drawing.Point(143, 12);
            this.btnReturns.Name = "btnReturns";
            this.btnReturns.Size = new System.Drawing.Size(125, 59);
            this.btnReturns.TabIndex = 20;
            this.btnReturns.Text = "Returns";
            this.btnReturns.UseVisualStyleBackColor = true;
            // 
            // btnSales
            // 
            this.btnSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.Location = new System.Drawing.Point(12, 12);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(125, 59);
            this.btnSales.TabIndex = 36;
            this.btnSales.Text = "Sales";
            this.btnSales.UseVisualStyleBackColor = true;
            // 
            // cmbInventoryFrom
            // 
            this.cmbInventoryFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInventoryFrom.FormattingEnabled = true;
            this.cmbInventoryFrom.Location = new System.Drawing.Point(129, 99);
            this.cmbInventoryFrom.Name = "cmbInventoryFrom";
            this.cmbInventoryFrom.Size = new System.Drawing.Size(199, 21);
            this.cmbInventoryFrom.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Inventory From";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(464, 99);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(441, 20);
            this.txtSearch.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(401, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "Search";
            // 
            // lsvCheckOutItems
            // 
            this.lsvCheckOutItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RecRPC,
            this.ItemID,
            this.ProductLineID,
            this.Description,
            this.SeasonCode,
            this.CategoryID,
            this.DepartmentID,
            this.RetrictedAge,
            this.CreatedBy,
            this.CreatedDate,
            this.LegacyDate,
            this.MSRP,
            this.SellPrice,
            this.TaxRateID});
            this.lsvCheckOutItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvCheckOutItems.FullRowSelect = true;
            this.lsvCheckOutItems.HideSelection = false;
            this.lsvCheckOutItems.Location = new System.Drawing.Point(12, 138);
            this.lsvCheckOutItems.MultiSelect = false;
            this.lsvCheckOutItems.Name = "lsvCheckOutItems";
            this.lsvCheckOutItems.Size = new System.Drawing.Size(893, 370);
            this.lsvCheckOutItems.TabIndex = 42;
            this.lsvCheckOutItems.UseCompatibleStateImageBehavior = false;
            this.lsvCheckOutItems.View = System.Windows.Forms.View.Details;
            // 
            // RecRPC
            // 
            this.RecRPC.Text = "RecRPC";
            this.RecRPC.Width = 115;
            // 
            // ItemID
            // 
            this.ItemID.Text = "ItemID";
            this.ItemID.Width = 115;
            // 
            // ProductLineID
            // 
            this.ProductLineID.Text = "ProductLineID";
            this.ProductLineID.Width = 120;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 338;
            // 
            // SeasonCode
            // 
            this.SeasonCode.Text = "SeasonCode";
            this.SeasonCode.Width = 120;
            // 
            // CategoryID
            // 
            this.CategoryID.Text = "CategoryID";
            this.CategoryID.Width = 120;
            // 
            // DepartmentID
            // 
            this.DepartmentID.Text = "DepartmentID";
            this.DepartmentID.Width = 120;
            // 
            // RetrictedAge
            // 
            this.RetrictedAge.Text = "RestrictedAge";
            this.RetrictedAge.Width = 120;
            // 
            // CreatedBy
            // 
            this.CreatedBy.Text = "CreatedBy";
            this.CreatedBy.Width = 100;
            // 
            // CreatedDate
            // 
            this.CreatedDate.Text = "CreatedDate";
            this.CreatedDate.Width = 100;
            // 
            // LegacyDate
            // 
            this.LegacyDate.Text = "LegacyDate";
            this.LegacyDate.Width = 100;
            // 
            // MSRP
            // 
            this.MSRP.Text = "MSRP";
            this.MSRP.Width = 100;
            // 
            // SellPrice
            // 
            this.SellPrice.Text = "SellPrice";
            this.SellPrice.Width = 100;
            // 
            // TaxRateID
            // 
            this.TaxRateID.Text = "TaxRateID";
            this.TaxRateID.Width = 120;
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 520);
            this.Controls.Add(this.lsvCheckOutItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbInventoryFrom);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnReturns);
            this.Name = "InventoryForm";
            this.Text = "InventoryFormcs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnReturns;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.ComboBox cmbInventoryFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsvCheckOutItems;
        private System.Windows.Forms.ColumnHeader RecRPC;
        private System.Windows.Forms.ColumnHeader ItemID;
        private System.Windows.Forms.ColumnHeader ProductLineID;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader SeasonCode;
        private System.Windows.Forms.ColumnHeader CategoryID;
        private System.Windows.Forms.ColumnHeader DepartmentID;
        private System.Windows.Forms.ColumnHeader RetrictedAge;
        private System.Windows.Forms.ColumnHeader CreatedBy;
        private System.Windows.Forms.ColumnHeader CreatedDate;
        private System.Windows.Forms.ColumnHeader LegacyDate;
        private System.Windows.Forms.ColumnHeader MSRP;
        private System.Windows.Forms.ColumnHeader SellPrice;
        private System.Windows.Forms.ColumnHeader TaxRateID;

    }
}