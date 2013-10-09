namespace RecreationOutletPOS
{
    partial class SalesForm
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
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "123",
            "Coffee Mug",
            "$9.99",
            "1",
            "$9.99"}, -1);
            this.lsvCheckOutItems = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSales = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnReturns = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.dgvCategoryItems = new System.Windows.Forms.DataGridView();
            this.pnlCategories = new System.Windows.Forms.Panel();
            this.btnMiscCamp = new System.Windows.Forms.Button();
            this.btnWaterSports = new System.Windows.Forms.Button();
            this.btnTents = new System.Windows.Forms.Button();
            this.btnClimbing = new System.Windows.Forms.Button();
            this.btnSocks = new System.Windows.Forms.Button();
            this.btnSleepingPads = new System.Windows.Forms.Button();
            this.btnNonTax = new System.Windows.Forms.Button();
            this.btnWinterClothing = new System.Windows.Forms.Button();
            this.btnStoves = new System.Windows.Forms.Button();
            this.btnSnowHardgoods = new System.Windows.Forms.Button();
            this.btnOtherClothing = new System.Windows.Forms.Button();
            this.btnSleepingBags = new System.Windows.Forms.Button();
            this.btnFootwear = new System.Windows.Forms.Button();
            this.btnFurniture = new System.Windows.Forms.Button();
            this.btnPacks = new System.Windows.Forms.Button();
            this.btnFood = new System.Windows.Forms.Button();
            this.btnEmergency = new System.Windows.Forms.Button();
            this.btnAsIs = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.summaryTax = new System.Windows.Forms.Label();
            this.summaryTotal = new System.Windows.Forms.Label();
            this.summarySubTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryItems)).BeginInit();
            this.pnlCategories.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvCheckOutItems
            // 
            this.lsvCheckOutItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Item,
            this.Price,
            this.Quantity,
            this.Total});
            this.lsvCheckOutItems.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem5});
            this.lsvCheckOutItems.Location = new System.Drawing.Point(12, 77);
            this.lsvCheckOutItems.Name = "lsvCheckOutItems";
            this.lsvCheckOutItems.Size = new System.Drawing.Size(518, 306);
            this.lsvCheckOutItems.TabIndex = 0;
            this.lsvCheckOutItems.UseCompatibleStateImageBehavior = false;
            this.lsvCheckOutItems.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 43;
            // 
            // Item
            // 
            this.Item.Text = "Item";
            this.Item.Width = 265;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 64;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Qty";
            // 
            // Total
            // 
            this.Total.Text = "Total";
            this.Total.Width = 82;
            // 
            // btnSales
            // 
            this.btnSales.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSales.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSales.Location = new System.Drawing.Point(12, 12);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(125, 59);
            this.btnSales.TabIndex = 1;
            this.btnSales.Text = "Sales";
            this.btnSales.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 476);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 40);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(106, 476);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(88, 40);
            this.btnCheckOut.TabIndex = 7;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            // 
            // btnReturns
            // 
            this.btnReturns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturns.Location = new System.Drawing.Point(143, 12);
            this.btnReturns.Name = "btnReturns";
            this.btnReturns.Size = new System.Drawing.Size(125, 59);
            this.btnReturns.TabIndex = 9;
            this.btnReturns.Text = "Returns";
            this.btnReturns.UseVisualStyleBackColor = true;
            // 
            // btnInventory
            // 
            this.btnInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventory.Location = new System.Drawing.Point(274, 12);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(125, 59);
            this.btnInventory.TabIndex = 10;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.Location = new System.Drawing.Point(405, 12);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(125, 59);
            this.btnReports.TabIndex = 11;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // dgvCategoryItems
            // 
            this.dgvCategoryItems.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCategoryItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoryItems.Location = new System.Drawing.Point(536, 77);
            this.dgvCategoryItems.Name = "dgvCategoryItems";
            this.dgvCategoryItems.Size = new System.Drawing.Size(373, 209);
            this.dgvCategoryItems.TabIndex = 12;
            // 
            // pnlCategories
            // 
            this.pnlCategories.AutoScroll = true;
            this.pnlCategories.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCategories.Controls.Add(this.btnMiscCamp);
            this.pnlCategories.Controls.Add(this.btnWaterSports);
            this.pnlCategories.Controls.Add(this.btnTents);
            this.pnlCategories.Controls.Add(this.btnClimbing);
            this.pnlCategories.Controls.Add(this.btnSocks);
            this.pnlCategories.Controls.Add(this.btnSleepingPads);
            this.pnlCategories.Controls.Add(this.btnNonTax);
            this.pnlCategories.Controls.Add(this.btnWinterClothing);
            this.pnlCategories.Controls.Add(this.btnStoves);
            this.pnlCategories.Controls.Add(this.btnSnowHardgoods);
            this.pnlCategories.Controls.Add(this.btnOtherClothing);
            this.pnlCategories.Controls.Add(this.btnSleepingBags);
            this.pnlCategories.Controls.Add(this.btnFootwear);
            this.pnlCategories.Controls.Add(this.btnFurniture);
            this.pnlCategories.Controls.Add(this.btnPacks);
            this.pnlCategories.Controls.Add(this.btnFood);
            this.pnlCategories.Controls.Add(this.btnEmergency);
            this.pnlCategories.Controls.Add(this.btnAsIs);
            this.pnlCategories.Location = new System.Drawing.Point(536, 292);
            this.pnlCategories.Name = "pnlCategories";
            this.pnlCategories.Size = new System.Drawing.Size(373, 178);
            this.pnlCategories.TabIndex = 13;
            // 
            // btnMiscCamp
            // 
            this.btnMiscCamp.Location = new System.Drawing.Point(265, 4);
            this.btnMiscCamp.Name = "btnMiscCamp";
            this.btnMiscCamp.Size = new System.Drawing.Size(81, 73);
            this.btnMiscCamp.TabIndex = 15;
            this.btnMiscCamp.Text = "Misc Camp";
            this.btnMiscCamp.UseVisualStyleBackColor = true;
            // 
            // btnWaterSports
            // 
            this.btnWaterSports.Location = new System.Drawing.Point(700, 83);
            this.btnWaterSports.Name = "btnWaterSports";
            this.btnWaterSports.Size = new System.Drawing.Size(81, 73);
            this.btnWaterSports.TabIndex = 27;
            this.btnWaterSports.Text = "Water Sports";
            this.btnWaterSports.UseVisualStyleBackColor = true;
            // 
            // btnTents
            // 
            this.btnTents.Location = new System.Drawing.Point(613, 83);
            this.btnTents.Name = "btnTents";
            this.btnTents.Size = new System.Drawing.Size(81, 73);
            this.btnTents.TabIndex = 26;
            this.btnTents.Text = "Tents";
            this.btnTents.UseVisualStyleBackColor = true;
            // 
            // btnClimbing
            // 
            this.btnClimbing.Location = new System.Drawing.Point(4, 83);
            this.btnClimbing.Name = "btnClimbing";
            this.btnClimbing.Size = new System.Drawing.Size(81, 73);
            this.btnClimbing.TabIndex = 2;
            this.btnClimbing.Text = "Climbing";
            this.btnClimbing.UseVisualStyleBackColor = true;
            // 
            // btnSocks
            // 
            this.btnSocks.Location = new System.Drawing.Point(526, 83);
            this.btnSocks.Name = "btnSocks";
            this.btnSocks.Size = new System.Drawing.Size(81, 73);
            this.btnSocks.TabIndex = 25;
            this.btnSocks.Text = "Socks";
            this.btnSocks.UseVisualStyleBackColor = true;
            // 
            // btnSleepingPads
            // 
            this.btnSleepingPads.Location = new System.Drawing.Point(439, 83);
            this.btnSleepingPads.Name = "btnSleepingPads";
            this.btnSleepingPads.Size = new System.Drawing.Size(81, 73);
            this.btnSleepingPads.TabIndex = 24;
            this.btnSleepingPads.Text = "Sleeping Pads";
            this.btnSleepingPads.UseVisualStyleBackColor = true;
            // 
            // btnNonTax
            // 
            this.btnNonTax.Location = new System.Drawing.Point(265, 83);
            this.btnNonTax.Name = "btnNonTax";
            this.btnNonTax.Size = new System.Drawing.Size(81, 73);
            this.btnNonTax.TabIndex = 23;
            this.btnNonTax.Text = "Non-Tax";
            this.btnNonTax.UseVisualStyleBackColor = true;
            // 
            // btnWinterClothing
            // 
            this.btnWinterClothing.Location = new System.Drawing.Point(700, 4);
            this.btnWinterClothing.Name = "btnWinterClothing";
            this.btnWinterClothing.Size = new System.Drawing.Size(81, 73);
            this.btnWinterClothing.TabIndex = 22;
            this.btnWinterClothing.Text = "Winter Clothing";
            this.btnWinterClothing.UseVisualStyleBackColor = true;
            // 
            // btnStoves
            // 
            this.btnStoves.Location = new System.Drawing.Point(613, 4);
            this.btnStoves.Name = "btnStoves";
            this.btnStoves.Size = new System.Drawing.Size(81, 73);
            this.btnStoves.TabIndex = 21;
            this.btnStoves.Text = "Stoves";
            this.btnStoves.UseVisualStyleBackColor = true;
            // 
            // btnSnowHardgoods
            // 
            this.btnSnowHardgoods.Location = new System.Drawing.Point(526, 4);
            this.btnSnowHardgoods.Name = "btnSnowHardgoods";
            this.btnSnowHardgoods.Size = new System.Drawing.Size(81, 73);
            this.btnSnowHardgoods.TabIndex = 20;
            this.btnSnowHardgoods.Text = "Snow Hardgoods";
            this.btnSnowHardgoods.UseVisualStyleBackColor = true;
            // 
            // btnOtherClothing
            // 
            this.btnOtherClothing.Location = new System.Drawing.Point(352, 4);
            this.btnOtherClothing.Name = "btnOtherClothing";
            this.btnOtherClothing.Size = new System.Drawing.Size(81, 73);
            this.btnOtherClothing.TabIndex = 16;
            this.btnOtherClothing.Text = "Other Clothing";
            this.btnOtherClothing.UseVisualStyleBackColor = true;
            // 
            // btnSleepingBags
            // 
            this.btnSleepingBags.Location = new System.Drawing.Point(439, 4);
            this.btnSleepingBags.Name = "btnSleepingBags";
            this.btnSleepingBags.Size = new System.Drawing.Size(81, 73);
            this.btnSleepingBags.TabIndex = 19;
            this.btnSleepingBags.Text = "Sleeping Bags";
            this.btnSleepingBags.UseVisualStyleBackColor = true;
            // 
            // btnFootwear
            // 
            this.btnFootwear.Location = new System.Drawing.Point(178, 4);
            this.btnFootwear.Name = "btnFootwear";
            this.btnFootwear.Size = new System.Drawing.Size(81, 73);
            this.btnFootwear.TabIndex = 18;
            this.btnFootwear.Text = "Footwear";
            this.btnFootwear.UseVisualStyleBackColor = true;
            // 
            // btnFurniture
            // 
            this.btnFurniture.Location = new System.Drawing.Point(178, 83);
            this.btnFurniture.Name = "btnFurniture";
            this.btnFurniture.Size = new System.Drawing.Size(81, 73);
            this.btnFurniture.TabIndex = 17;
            this.btnFurniture.Text = "Furniture";
            this.btnFurniture.UseVisualStyleBackColor = true;
            // 
            // btnPacks
            // 
            this.btnPacks.Location = new System.Drawing.Point(352, 83);
            this.btnPacks.Name = "btnPacks";
            this.btnPacks.Size = new System.Drawing.Size(81, 73);
            this.btnPacks.TabIndex = 14;
            this.btnPacks.Text = "Packs";
            this.btnPacks.UseVisualStyleBackColor = true;
            // 
            // btnFood
            // 
            this.btnFood.Location = new System.Drawing.Point(91, 83);
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(81, 73);
            this.btnFood.TabIndex = 14;
            this.btnFood.Text = "Food";
            this.btnFood.UseVisualStyleBackColor = true;
            // 
            // btnEmergency
            // 
            this.btnEmergency.Location = new System.Drawing.Point(91, 3);
            this.btnEmergency.Name = "btnEmergency";
            this.btnEmergency.Size = new System.Drawing.Size(81, 73);
            this.btnEmergency.TabIndex = 3;
            this.btnEmergency.Text = "Emergency";
            this.btnEmergency.UseVisualStyleBackColor = true;
            // 
            // btnAsIs
            // 
            this.btnAsIs.Location = new System.Drawing.Point(4, 3);
            this.btnAsIs.Name = "btnAsIs";
            this.btnAsIs.Size = new System.Drawing.Size(81, 73);
            this.btnAsIs.TabIndex = 0;
            this.btnAsIs.Text = "As-Is";
            this.btnAsIs.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Location = new System.Drawing.Point(822, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(87, 59);
            this.btnSettings.TabIndex = 14;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.SystemColors.Window;
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Controls.Add(this.summaryTax);
            this.pnlSummary.Controls.Add(this.summaryTotal);
            this.pnlSummary.Controls.Add(this.summarySubTotal);
            this.pnlSummary.Controls.Add(this.lblTotal);
            this.pnlSummary.Controls.Add(this.lblTax);
            this.pnlSummary.Controls.Add(this.lblSubtotal);
            this.pnlSummary.Location = new System.Drawing.Point(12, 389);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(518, 81);
            this.pnlSummary.TabIndex = 15;
            // 
            // summaryTax
            // 
            this.summaryTax.AutoSize = true;
            this.summaryTax.Location = new System.Drawing.Point(458, 35);
            this.summaryTax.Name = "summaryTax";
            this.summaryTax.Size = new System.Drawing.Size(36, 13);
            this.summaryTax.TabIndex = 5;
            this.summaryTax.Text = "0.00%";
            // 
            // summaryTotal
            // 
            this.summaryTotal.AutoSize = true;
            this.summaryTotal.Location = new System.Drawing.Point(458, 61);
            this.summaryTotal.Name = "summaryTotal";
            this.summaryTotal.Size = new System.Drawing.Size(34, 13);
            this.summaryTotal.TabIndex = 4;
            this.summaryTotal.Text = "$9.99";
            // 
            // summarySubTotal
            // 
            this.summarySubTotal.AutoSize = true;
            this.summarySubTotal.Location = new System.Drawing.Point(458, 10);
            this.summarySubTotal.Name = "summarySubTotal";
            this.summarySubTotal.Size = new System.Drawing.Size(34, 13);
            this.summarySubTotal.TabIndex = 3;
            this.summarySubTotal.Text = "$9.99";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(352, 61);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Location = new System.Drawing.Point(352, 35);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(25, 13);
            this.lblTax.TabIndex = 1;
            this.lblTax.Text = "Tax";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(352, 11);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(46, 13);
            this.lblSubtotal.TabIndex = 0;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 520);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.pnlCategories);
            this.Controls.Add(this.dgvCategoryItems);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnReturns);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.lsvCheckOutItems);
            this.Name = "SalesForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SalesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryItems)).EndInit();
            this.pnlCategories.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvCheckOutItems;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnReturns;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Item;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.DataGridView dgvCategoryItems;
        private System.Windows.Forms.Panel pnlCategories;
        private System.Windows.Forms.Button btnAsIs;
        private System.Windows.Forms.Button btnFurniture;
        private System.Windows.Forms.Button btnOtherClothing;
        private System.Windows.Forms.Button btnMiscCamp;
        private System.Windows.Forms.Button btnPacks;
        private System.Windows.Forms.Button btnFood;
        private System.Windows.Forms.Button btnEmergency;
        private System.Windows.Forms.Button btnClimbing;
        private System.Windows.Forms.Button btnWaterSports;
        private System.Windows.Forms.Button btnTents;
        private System.Windows.Forms.Button btnSocks;
        private System.Windows.Forms.Button btnSleepingPads;
        private System.Windows.Forms.Button btnNonTax;
        private System.Windows.Forms.Button btnWinterClothing;
        private System.Windows.Forms.Button btnStoves;
        private System.Windows.Forms.Button btnSnowHardgoods;
        private System.Windows.Forms.Button btnSleepingBags;
        private System.Windows.Forms.Button btnFootwear;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label summaryTax;
        private System.Windows.Forms.Label summaryTotal;
        private System.Windows.Forms.Label summarySubTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblSubtotal;
    }
}

