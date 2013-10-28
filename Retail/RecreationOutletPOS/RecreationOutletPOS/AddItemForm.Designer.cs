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
            this.components = new System.ComponentModel.Container();
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
            this.iTEMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDataSet = new RecreationOutletPOS.masterDataSet();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.tbItemSearch = new System.Windows.Forms.TextBox();
            this.lblEnterSearch = new System.Windows.Forms.Label();
            this.iTEMTableAdapter = new RecreationOutletPOS.masterDataSetTableAdapters.ITEMTableAdapter();
            this.lvData = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblQty = new System.Windows.Forms.Label();
            this.tbItemQuantity = new System.Windows.Forms.TextBox();
            this.pnlCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iTEMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataSet)).BeginInit();
            this.SuspendLayout();
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
            this.pnlCategories.Location = new System.Drawing.Point(12, 273);
            this.pnlCategories.Name = "pnlCategories";
            this.pnlCategories.Size = new System.Drawing.Size(609, 178);
            this.pnlCategories.TabIndex = 15;
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
            // iTEMBindingSource
            // 
            this.iTEMBindingSource.DataMember = "ITEM";
            this.iTEMBindingSource.DataSource = this.masterDataSetBindingSource;
            // 
            // masterDataSetBindingSource
            // 
            this.masterDataSetBindingSource.DataSource = this.masterDataSet;
            this.masterDataSetBindingSource.Position = 0;
            // 
            // masterDataSet
            // 
            this.masterDataSet.DataSetName = "masterDataSet";
            this.masterDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(452, 457);
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
            this.btnAddItem.Location = new System.Drawing.Point(12, 457);
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
            // iTEMTableAdapter
            // 
            this.iTEMTableAdapter.ClearBeforeFill = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.iTEMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCategories;
        private System.Windows.Forms.Button btnMiscCamp;
        private System.Windows.Forms.Button btnWaterSports;
        private System.Windows.Forms.Button btnTents;
        private System.Windows.Forms.Button btnClimbing;
        private System.Windows.Forms.Button btnSocks;
        private System.Windows.Forms.Button btnSleepingPads;
        private System.Windows.Forms.Button btnNonTax;
        private System.Windows.Forms.Button btnWinterClothing;
        private System.Windows.Forms.Button btnStoves;
        private System.Windows.Forms.Button btnSnowHardgoods;
        private System.Windows.Forms.Button btnOtherClothing;
        private System.Windows.Forms.Button btnSleepingBags;
        private System.Windows.Forms.Button btnFootwear;
        private System.Windows.Forms.Button btnFurniture;
        private System.Windows.Forms.Button btnPacks;
        private System.Windows.Forms.Button btnFood;
        private System.Windows.Forms.Button btnEmergency;
        private System.Windows.Forms.Button btnAsIs;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.TextBox tbItemSearch;
        private System.Windows.Forms.Label lblEnterSearch;
        private System.Windows.Forms.BindingSource masterDataSetBindingSource;
        private masterDataSet masterDataSet;
        private System.Windows.Forms.BindingSource iTEMBindingSource;
        private masterDataSetTableAdapters.ITEMTableAdapter iTEMTableAdapter;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.ColumnHeader Item;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox tbItemQuantity;
    }
}