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
            this.lblInventoryFrom = new System.Windows.Forms.Label();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lsvCurrentInventory = new System.Windows.Forms.ListView();
            this.ItemID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RecRPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemUPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SellPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DepartmentID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CategoryID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaxRateID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductLineID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SeasonCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RestrictedAge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreatedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreatedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LegacyID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MSRP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSearchBy = new System.Windows.Forms.Label();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
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
            this.btnReturns.Click += new System.EventHandler(this.btnReturns_Click);
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
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // cmbInventoryFrom
            // 
            this.cmbInventoryFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInventoryFrom.FormattingEnabled = true;
            this.cmbInventoryFrom.Location = new System.Drawing.Point(117, 99);
            this.cmbInventoryFrom.Name = "cmbInventoryFrom";
            this.cmbInventoryFrom.Size = new System.Drawing.Size(118, 21);
            this.cmbInventoryFrom.TabIndex = 37;
            this.cmbInventoryFrom.SelectedIndexChanged += new System.EventHandler(this.cmbInventoryFrom_SelectedIndexChanged);
            // 
            // lblInventoryFrom
            // 
            this.lblInventoryFrom.AutoSize = true;
            this.lblInventoryFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventoryFrom.Location = new System.Drawing.Point(12, 100);
            this.lblInventoryFrom.Name = "lblInventoryFrom";
            this.lblInventoryFrom.Size = new System.Drawing.Size(102, 17);
            this.lblInventoryFrom.TabIndex = 38;
            this.lblInventoryFrom.Text = "Inventory From";
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(578, 99);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(327, 20);
            this.txtSearchValue.TabIndex = 40;
            this.txtSearchValue.TextChanged += new System.EventHandler(this.txtSearchValue_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(519, 99);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(53, 17);
            this.lblSearch.TabIndex = 41;
            this.lblSearch.Text = "Search";
            // 
            // lsvCurrentInventory
            // 
            this.lsvCurrentInventory.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lsvCurrentInventory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemID,
            this.RecRPC,
            this.ItemUPC,
            this.ItemName,
            this.Description,
            this.SellPrice,
            this.DepartmentID,
            this.CategoryID,
            this.TaxRateID,
            this.ProductLineID,
            this.SeasonCode,
            this.RestrictedAge,
            this.CreatedBy,
            this.CreatedDate,
            this.LegacyID,
            this.MSRP});
            this.lsvCurrentInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvCurrentInventory.FullRowSelect = true;
            this.lsvCurrentInventory.HideSelection = false;
            this.lsvCurrentInventory.LabelWrap = false;
            this.lsvCurrentInventory.Location = new System.Drawing.Point(12, 138);
            this.lsvCurrentInventory.MultiSelect = false;
            this.lsvCurrentInventory.Name = "lsvCurrentInventory";
            this.lsvCurrentInventory.Size = new System.Drawing.Size(893, 370);
            this.lsvCurrentInventory.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvCurrentInventory.TabIndex = 43;
            this.lsvCurrentInventory.UseCompatibleStateImageBehavior = false;
            this.lsvCurrentInventory.View = System.Windows.Forms.View.Details;
            // 
            // ItemID
            // 
            this.ItemID.Text = "ItemID";
            this.ItemID.Width = 150;
            // 
            // RecRPC
            // 
            this.RecRPC.Text = "RecRPC";
            this.RecRPC.Width = 170;
            // 
            // ItemUPC
            // 
            this.ItemUPC.Text = "ItemUPC";
            this.ItemUPC.Width = 170;
            // 
            // ItemName
            // 
            this.ItemName.Text = "Name";
            this.ItemName.Width = 240;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 350;
            // 
            // SellPrice
            // 
            this.SellPrice.Text = "SellPrice";
            this.SellPrice.Width = 90;
            // 
            // DepartmentID
            // 
            this.DepartmentID.Text = "DepartmentID";
            this.DepartmentID.Width = 100;
            // 
            // CategoryID
            // 
            this.CategoryID.Text = "CategoryID";
            this.CategoryID.Width = 80;
            // 
            // TaxRateID
            // 
            this.TaxRateID.Text = "TaxRateID";
            this.TaxRateID.Width = 90;
            // 
            // ProductLineID
            // 
            this.ProductLineID.Text = "ProductLineID";
            this.ProductLineID.Width = 110;
            // 
            // SeasonCode
            // 
            this.SeasonCode.Text = "SeasonCode";
            this.SeasonCode.Width = 100;
            // 
            // RestrictedAge
            // 
            this.RestrictedAge.Text = "RestrictedAge";
            this.RestrictedAge.Width = 120;
            // 
            // CreatedBy
            // 
            this.CreatedBy.Text = "CreatedBy";
            this.CreatedBy.Width = 110;
            // 
            // CreatedDate
            // 
            this.CreatedDate.Text = "CreatedDate";
            this.CreatedDate.Width = 120;
            // 
            // LegacyID
            // 
            this.LegacyID.Text = "LegacyID";
            this.LegacyID.Width = 90;
            // 
            // MSRP
            // 
            this.MSRP.Text = "MSRP";
            this.MSRP.Width = 90;
            // 
            // lblSearchBy
            // 
            this.lblSearchBy.AutoSize = true;
            this.lblSearchBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchBy.Location = new System.Drawing.Point(271, 100);
            this.lblSearchBy.Name = "lblSearchBy";
            this.lblSearchBy.Size = new System.Drawing.Size(73, 17);
            this.lblSearchBy.TabIndex = 44;
            this.lblSearchBy.Text = "Search By";
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.Location = new System.Drawing.Point(350, 99);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(137, 21);
            this.cmbSearchBy.TabIndex = 45;
            this.cmbSearchBy.SelectedIndexChanged += new System.EventHandler(this.cmbSearchBy_SelectedIndexChanged);
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(921, 520);
            this.Controls.Add(this.cmbSearchBy);
            this.Controls.Add(this.lblSearchBy);
            this.Controls.Add(this.lsvCurrentInventory);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearchValue);
            this.Controls.Add(this.lblInventoryFrom);
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
        private System.Windows.Forms.Label lblInventoryFrom;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ListView lsvCurrentInventory;
        private System.Windows.Forms.Label lblSearchBy;
        private System.Windows.Forms.ComboBox cmbSearchBy;
        private System.Windows.Forms.ColumnHeader RecRPC;
        private System.Windows.Forms.ColumnHeader ItemUPC;
        private System.Windows.Forms.ColumnHeader ItemID;
        private System.Windows.Forms.ColumnHeader ProductLineID;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader SeasonCode;
        private System.Windows.Forms.ColumnHeader CategoryID;
        private System.Windows.Forms.ColumnHeader DepartmentID;
        private System.Windows.Forms.ColumnHeader RestrictedAge;
        private System.Windows.Forms.ColumnHeader CreatedBy;
        private System.Windows.Forms.ColumnHeader CreatedDate;
        private System.Windows.Forms.ColumnHeader LegacyID;
        private System.Windows.Forms.ColumnHeader MSRP;
        private System.Windows.Forms.ColumnHeader SellPrice;
        private System.Windows.Forms.ColumnHeader TaxRateID;
        private System.Windows.Forms.ColumnHeader ItemName;

    }
}