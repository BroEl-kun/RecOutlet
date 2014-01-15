﻿namespace RecreationOutletPOS
{
    partial class ReturnsForm
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
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnConfirmReturn = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.summaryReturnTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lsvCheckOutItems = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Discount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSales = new System.Windows.Forms.Button();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(822, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(87, 59);
            this.btnSettings.TabIndex = 24;
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
            this.btnReports.TabIndex = 23;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // btnInventory
            // 
            this.btnInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.Location = new System.Drawing.Point(274, 12);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(125, 59);
            this.btnInventory.TabIndex = 22;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnReturns
            // 
            this.btnReturns.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnReturns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturns.Enabled = false;
            this.btnReturns.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturns.Location = new System.Drawing.Point(143, 12);
            this.btnReturns.Name = "btnReturns";
            this.btnReturns.Size = new System.Drawing.Size(125, 59);
            this.btnReturns.TabIndex = 21;
            this.btnReturns.Text = "Returns";
            this.btnReturns.UseVisualStyleBackColor = false;
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItem.Location = new System.Drawing.Point(772, 249);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(137, 50);
            this.btnDeleteItem.TabIndex = 34;
            this.btnDeleteItem.Text = "Delete Item";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnConfirmReturn
            // 
            this.btnConfirmReturn.Location = new System.Drawing.Point(772, 457);
            this.btnConfirmReturn.Name = "btnConfirmReturn";
            this.btnConfirmReturn.Size = new System.Drawing.Size(137, 49);
            this.btnConfirmReturn.TabIndex = 33;
            this.btnConfirmReturn.Text = "Confirm Return";
            this.btnConfirmReturn.UseVisualStyleBackColor = true;
            this.btnConfirmReturn.Click += new System.EventHandler(this.btnConfirmReturn_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(772, 399);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(137, 37);
            this.btnClear.TabIndex = 32;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Location = new System.Drawing.Point(772, 179);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(137, 50);
            this.btnAddItem.TabIndex = 31;
            this.btnAddItem.Text = "Manual Item Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.SystemColors.Window;
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Controls.Add(this.summaryReturnTotal);
            this.pnlSummary.Controls.Add(this.lblTotal);
            this.pnlSummary.Location = new System.Drawing.Point(474, 399);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(292, 109);
            this.pnlSummary.TabIndex = 30;
            // 
            // summaryReturnTotal
            // 
            this.summaryReturnTotal.AutoSize = true;
            this.summaryReturnTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryReturnTotal.Location = new System.Drawing.Point(192, 71);
            this.summaryReturnTotal.Name = "summaryReturnTotal";
            this.summaryReturnTotal.Size = new System.Drawing.Size(55, 22);
            this.summaryReturnTotal.TabIndex = 4;
            this.summaryReturnTotal.Text = "$0.00";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(8, 71);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(110, 22);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Return Total";
            // 
            // lsvCheckOutItems
            // 
            this.lsvCheckOutItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Item,
            this.Price,
            this.Quantity,
            this.Discount,
            this.Total});
            this.lsvCheckOutItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvCheckOutItems.FullRowSelect = true;
            this.lsvCheckOutItems.HideSelection = false;
            this.lsvCheckOutItems.Location = new System.Drawing.Point(12, 87);
            this.lsvCheckOutItems.MultiSelect = false;
            this.lsvCheckOutItems.Name = "lsvCheckOutItems";
            this.lsvCheckOutItems.Size = new System.Drawing.Size(754, 306);
            this.lsvCheckOutItems.TabIndex = 29;
            this.lsvCheckOutItems.UseCompatibleStateImageBehavior = false;
            this.lsvCheckOutItems.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 74;
            // 
            // Item
            // 
            this.Item.Text = "Item";
            this.Item.Width = 322;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 91;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Qty";
            this.Quantity.Width = 67;
            // 
            // Discount
            // 
            this.Discount.Text = "Discount";
            this.Discount.Width = 89;
            // 
            // Total
            // 
            this.Total.Text = "Total";
            this.Total.Width = 107;
            // 
            // btnSales
            // 
            this.btnSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.Location = new System.Drawing.Point(12, 12);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(125, 59);
            this.btnSales.TabIndex = 35;
            this.btnSales.Text = "Sales";
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // ReturnsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 520);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnConfirmReturn);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.lsvCheckOutItems);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnReturns);
            this.Name = "ReturnsForm";
            this.Text = "ReturnsForm";
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnReturns;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnConfirmReturn;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label summaryReturnTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ListView lsvCheckOutItems;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Item;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Discount;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.Button btnSales;
    }
}