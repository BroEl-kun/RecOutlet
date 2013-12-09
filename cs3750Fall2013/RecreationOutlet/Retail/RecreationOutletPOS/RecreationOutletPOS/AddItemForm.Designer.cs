namespace RecreationOutletPOS
{
    /// <summary>
    /// Created By: Michael Vuong
    /// Last Updated: 10/11/2013 by Michael Vuong
    /// </summary>
    partial class AddItemForm
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
            this.pnlCategories = new System.Windows.Forms.Panel();
            this.rbtnImpulseMerchandise = new System.Windows.Forms.RadioButton();
            this.rbtnOutdoorSports = new System.Windows.Forms.RadioButton();
            this.rbtnOuterwear = new System.Windows.Forms.RadioButton();
            this.rbtnWinterClothing = new System.Windows.Forms.RadioButton();
            this.rbtnStoves = new System.Windows.Forms.RadioButton();
            this.rbtnSnowHardgoods = new System.Windows.Forms.RadioButton();
            this.rbtnPacks = new System.Windows.Forms.RadioButton();
            this.rbtnWaterSports = new System.Windows.Forms.RadioButton();
            this.rbtnFurniture = new System.Windows.Forms.RadioButton();
            this.rbtnFootwear = new System.Windows.Forms.RadioButton();
            this.rbtnFood = new System.Windows.Forms.RadioButton();
            this.rbtnClimbing = new System.Windows.Forms.RadioButton();
            this.rbtnEmergency = new System.Windows.Forms.RadioButton();
            this.rbtnAsIs = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.tbItemSearch = new System.Windows.Forms.TextBox();
            this.lblEnterSearch = new System.Windows.Forms.Label();
            this.lvData = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblQty = new System.Windows.Forms.Label();
            this.tbItemQuantity = new System.Windows.Forms.TextBox();
            this.pnlCategories.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCategories
            // 
            this.pnlCategories.AutoScroll = true;
            this.pnlCategories.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCategories.Controls.Add(this.rbtnImpulseMerchandise);
            this.pnlCategories.Controls.Add(this.rbtnOutdoorSports);
            this.pnlCategories.Controls.Add(this.rbtnOuterwear);
            this.pnlCategories.Controls.Add(this.rbtnWinterClothing);
            this.pnlCategories.Controls.Add(this.rbtnStoves);
            this.pnlCategories.Controls.Add(this.rbtnSnowHardgoods);
            this.pnlCategories.Controls.Add(this.rbtnPacks);
            this.pnlCategories.Controls.Add(this.rbtnWaterSports);
            this.pnlCategories.Controls.Add(this.rbtnFurniture);
            this.pnlCategories.Controls.Add(this.rbtnFootwear);
            this.pnlCategories.Controls.Add(this.rbtnFood);
            this.pnlCategories.Controls.Add(this.rbtnClimbing);
            this.pnlCategories.Controls.Add(this.rbtnEmergency);
            this.pnlCategories.Controls.Add(this.rbtnAsIs);
            this.pnlCategories.Location = new System.Drawing.Point(12, 273);
            this.pnlCategories.Name = "pnlCategories";
            this.pnlCategories.Size = new System.Drawing.Size(609, 165);
            this.pnlCategories.TabIndex = 15;
            // 
            // rbtnImpulseMerchandise
            // 
            this.rbtnImpulseMerchandise.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnImpulseMerchandise.Location = new System.Drawing.Point(523, 83);
            this.rbtnImpulseMerchandise.Name = "rbtnImpulseMerchandise";
            this.rbtnImpulseMerchandise.Size = new System.Drawing.Size(81, 73);
            this.rbtnImpulseMerchandise.TabIndex = 43;
            this.rbtnImpulseMerchandise.Text = "Impulse Merchandise";
            this.rbtnImpulseMerchandise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnImpulseMerchandise.UseVisualStyleBackColor = true;
            this.rbtnImpulseMerchandise.CheckedChanged += new System.EventHandler(this.rbtnDepartment_CheckedChanged);
            // 
            // rbtnOutdoorSports
            // 
            this.rbtnOutdoorSports.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnOutdoorSports.Location = new System.Drawing.Point(523, 4);
            this.rbtnOutdoorSports.Name = "rbtnOutdoorSports";
            this.rbtnOutdoorSports.Size = new System.Drawing.Size(81, 73);
            this.rbtnOutdoorSports.TabIndex = 42;
            this.rbtnOutdoorSports.Text = "Outdoor Sports";
            this.rbtnOutdoorSports.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnOutdoorSports.UseVisualStyleBackColor = true;
            this.rbtnOutdoorSports.CheckedChanged += new System.EventHandler(this.rbtnDepartment_CheckedChanged);
            // 
            // rbtnOuterwear
            // 
            this.rbtnOuterwear.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnOuterwear.Location = new System.Drawing.Point(437, 83);
            this.rbtnOuterwear.Name = "rbtnOuterwear";
            this.rbtnOuterwear.Size = new System.Drawing.Size(81, 73);
            this.rbtnOuterwear.TabIndex = 41;
            this.rbtnOuterwear.Text = "Outerwear";
            this.rbtnOuterwear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnOuterwear.UseVisualStyleBackColor = true;
            this.rbtnOuterwear.CheckedChanged += new System.EventHandler(this.rbtnDepartment_CheckedChanged);
            // 
            // rbtnWinterClothing
            // 
            this.rbtnWinterClothing.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnWinterClothing.Location = new System.Drawing.Point(437, 4);
            this.rbtnWinterClothing.Name = "rbtnWinterClothing";
            this.rbtnWinterClothing.Size = new System.Drawing.Size(81, 73);
            this.rbtnWinterClothing.TabIndex = 40;
            this.rbtnWinterClothing.Text = "Winter Clothing";
            this.rbtnWinterClothing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnWinterClothing.UseVisualStyleBackColor = true;
            this.rbtnWinterClothing.CheckedChanged += new System.EventHandler(this.rbtnDepartment_CheckedChanged);
            // 
            // rbtnStoves
            // 
            this.rbtnStoves.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnStoves.Location = new System.Drawing.Point(352, 83);
            this.rbtnStoves.Name = "rbtnStoves";
            this.rbtnStoves.Size = new System.Drawing.Size(81, 73);
            this.rbtnStoves.TabIndex = 39;
            this.rbtnStoves.Text = "Stoves";
            this.rbtnStoves.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnStoves.UseVisualStyleBackColor = true;
            this.rbtnStoves.CheckedChanged += new System.EventHandler(this.rbtnDepartment_CheckedChanged);
            // 
            // rbtnSnowHardgoods
            // 
            this.rbtnSnowHardgoods.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnSnowHardgoods.Location = new System.Drawing.Point(352, 4);
            this.rbtnSnowHardgoods.Name = "rbtnSnowHardgoods";
            this.rbtnSnowHardgoods.Size = new System.Drawing.Size(81, 73);
            this.rbtnSnowHardgoods.TabIndex = 38;
            this.rbtnSnowHardgoods.Text = "Snow Hardgoods";
            this.rbtnSnowHardgoods.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnSnowHardgoods.UseVisualStyleBackColor = true;
            this.rbtnSnowHardgoods.CheckedChanged += new System.EventHandler(this.rbtnDepartment_CheckedChanged);
            // 
            // rbtnPacks
            // 
            this.rbtnPacks.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPacks.Location = new System.Drawing.Point(265, 83);
            this.rbtnPacks.Name = "rbtnPacks";
            this.rbtnPacks.Size = new System.Drawing.Size(81, 73);
            this.rbtnPacks.TabIndex = 37;
            this.rbtnPacks.Text = "Packs";
            this.rbtnPacks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnPacks.UseVisualStyleBackColor = true;
            this.rbtnPacks.CheckedChanged += new System.EventHandler(this.rbtnDepartment_CheckedChanged);
            // 
            // rbtnWaterSports
            // 
            this.rbtnWaterSports.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnWaterSports.Location = new System.Drawing.Point(265, 4);
            this.rbtnWaterSports.Name = "rbtnWaterSports";
            this.rbtnWaterSports.Size = new System.Drawing.Size(81, 73);
            this.rbtnWaterSports.TabIndex = 36;
            this.rbtnWaterSports.Text = "Water Sports";
            this.rbtnWaterSports.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnWaterSports.UseVisualStyleBackColor = true;
            this.rbtnWaterSports.CheckedChanged += new System.EventHandler(this.rbtnDepartment_CheckedChanged);
            // 
            // rbtnFurniture
            // 
            this.rbtnFurniture.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnFurniture.Location = new System.Drawing.Point(178, 83);
            this.rbtnFurniture.Name = "rbtnFurniture";
            this.rbtnFurniture.Size = new System.Drawing.Size(81, 73);
            this.rbtnFurniture.TabIndex = 35;
            this.rbtnFurniture.Text = "Furniture";
            this.rbtnFurniture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnFurniture.UseVisualStyleBackColor = true;
            this.rbtnFurniture.CheckedChanged += new System.EventHandler(this.rbtnDepartment_CheckedChanged);
            // 
            // rbtnFootwear
            // 
            this.rbtnFootwear.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnFootwear.Location = new System.Drawing.Point(178, 4);
            this.rbtnFootwear.Name = "rbtnFootwear";
            this.rbtnFootwear.Size = new System.Drawing.Size(81, 73);
            this.rbtnFootwear.TabIndex = 34;
            this.rbtnFootwear.Text = "Footwear";
            this.rbtnFootwear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnFootwear.UseVisualStyleBackColor = true;
            this.rbtnFootwear.CheckedChanged += new System.EventHandler(this.rbtnDepartment_CheckedChanged);
            // 
            // rbtnFood
            // 
            this.rbtnFood.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnFood.Location = new System.Drawing.Point(91, 83);
            this.rbtnFood.Name = "rbtnFood";
            this.rbtnFood.Size = new System.Drawing.Size(81, 73);
            this.rbtnFood.TabIndex = 33;
            this.rbtnFood.Text = "Food";
            this.rbtnFood.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnFood.UseVisualStyleBackColor = true;
            this.rbtnFood.CheckedChanged += new System.EventHandler(this.rbtnDepartment_CheckedChanged);
            // 
            // rbtnClimbing
            // 
            this.rbtnClimbing.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnClimbing.Location = new System.Drawing.Point(4, 83);
            this.rbtnClimbing.Name = "rbtnClimbing";
            this.rbtnClimbing.Size = new System.Drawing.Size(81, 73);
            this.rbtnClimbing.TabIndex = 32;
            this.rbtnClimbing.Text = "Climbing";
            this.rbtnClimbing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnClimbing.UseVisualStyleBackColor = true;
            this.rbtnClimbing.CheckedChanged += new System.EventHandler(this.rbtnDepartment_CheckedChanged);
            // 
            // rbtnEmergency
            // 
            this.rbtnEmergency.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnEmergency.Location = new System.Drawing.Point(91, 4);
            this.rbtnEmergency.Name = "rbtnEmergency";
            this.rbtnEmergency.Size = new System.Drawing.Size(81, 73);
            this.rbtnEmergency.TabIndex = 31;
            this.rbtnEmergency.Text = "Emergency";
            this.rbtnEmergency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnEmergency.UseVisualStyleBackColor = true;
            this.rbtnEmergency.CheckedChanged += new System.EventHandler(this.rbtnDepartment_CheckedChanged);
            // 
            // rbtnAsIs
            // 
            this.rbtnAsIs.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnAsIs.Checked = true;
            this.rbtnAsIs.Location = new System.Drawing.Point(4, 4);
            this.rbtnAsIs.Name = "rbtnAsIs";
            this.rbtnAsIs.Size = new System.Drawing.Size(81, 73);
            this.rbtnAsIs.TabIndex = 23;
            this.rbtnAsIs.TabStop = true;
            this.rbtnAsIs.Text = "As Is";
            this.rbtnAsIs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnAsIs.UseVisualStyleBackColor = true;
            this.rbtnAsIs.CheckedChanged += new System.EventHandler(this.rbtnDepartment_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(12, 448);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(167, 48);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Location = new System.Drawing.Point(454, 448);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(167, 48);
            this.btnAddItem.TabIndex = 17;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // tbItemSearch
            // 
            this.tbItemSearch.Location = new System.Drawing.Point(12, 35);
            this.tbItemSearch.Name = "tbItemSearch";
            this.tbItemSearch.Size = new System.Drawing.Size(521, 20);
            this.tbItemSearch.TabIndex = 18;
            this.tbItemSearch.TextChanged += new System.EventHandler(this.tbItemSearch_TextChanged);
            // 
            // lblEnterSearch
            // 
            this.lblEnterSearch.AutoSize = true;
            this.lblEnterSearch.Location = new System.Drawing.Point(12, 19);
            this.lblEnterSearch.Name = "lblEnterSearch";
            this.lblEnterSearch.Size = new System.Drawing.Size(93, 13);
            this.lblEnterSearch.TabIndex = 19;
            this.lblEnterSearch.Text = "Enter search term:";
            // 
            // lvData
            // 
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Item,
            this.Price});
            this.lvData.FullRowSelect = true;
            this.lvData.HideSelection = false;
            this.lvData.LabelWrap = false;
            this.lvData.Location = new System.Drawing.Point(12, 62);
            this.lvData.MinimumSize = new System.Drawing.Size(64, 4);
            this.lvData.MultiSelect = false;
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(609, 205);
            this.lvData.TabIndex = 20;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // Item
            // 
            this.Item.Text = "Item";
            this.Item.Width = 420;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 128;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(539, 19);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(49, 13);
            this.lblQty.TabIndex = 21;
            this.lblQty.Text = "Quantity:";
            // 
            // tbItemQuantity
            // 
            this.tbItemQuantity.Location = new System.Drawing.Point(539, 35);
            this.tbItemQuantity.Name = "tbItemQuantity";
            this.tbItemQuantity.Size = new System.Drawing.Size(82, 20);
            this.tbItemQuantity.TabIndex = 22;
            this.tbItemQuantity.Text = "1";
            this.tbItemQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbItemQuantity_KeyPress);
            // 
            // AddItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 508);
            this.Controls.Add(this.tbItemQuantity);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.lvData);
            this.Controls.Add(this.lblEnterSearch);
            this.Controls.Add(this.tbItemSearch);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlCategories);
            this.Name = "AddItemForm";
            this.Text = "Manual Item Addition";
            this.Load += new System.EventHandler(this.AddItemForm_Load);
            this.pnlCategories.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCategories;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.TextBox tbItemSearch;
        private System.Windows.Forms.Label lblEnterSearch;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.ColumnHeader Item;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox tbItemQuantity;
        private System.Windows.Forms.RadioButton rbtnAsIs;
        private System.Windows.Forms.RadioButton rbtnEmergency;
        private System.Windows.Forms.RadioButton rbtnFood;
        private System.Windows.Forms.RadioButton rbtnClimbing;
        private System.Windows.Forms.RadioButton rbtnFurniture;
        private System.Windows.Forms.RadioButton rbtnFootwear;
        private System.Windows.Forms.RadioButton rbtnPacks;
        private System.Windows.Forms.RadioButton rbtnWaterSports;
        private System.Windows.Forms.RadioButton rbtnStoves;
        private System.Windows.Forms.RadioButton rbtnSnowHardgoods;
        private System.Windows.Forms.RadioButton rbtnOuterwear;
        private System.Windows.Forms.RadioButton rbtnWinterClothing;
        private System.Windows.Forms.RadioButton rbtnImpulseMerchandise;
        private System.Windows.Forms.RadioButton rbtnOutdoorSports;
    }
}