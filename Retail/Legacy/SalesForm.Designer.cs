﻿namespace RecreationOutletPOS
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
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnReturns = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.lsvCheckOutItems = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Discount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.summaryTax = new System.Windows.Forms.Label();
            this.summarySubTotal = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.summaryTotal = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.tbScanner = new System.Windows.Forms.TextBox();
            this.tbItemQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnPrice = new System.Windows.Forms.Button();
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
            this.btnSettings.TabIndex = 19;
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
            this.btnReports.TabIndex = 18;
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
            this.btnInventory.TabIndex = 17;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnReturns
            // 
            this.btnReturns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturns.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturns.Location = new System.Drawing.Point(143, 12);
            this.btnReturns.Name = "btnReturns";
            this.btnReturns.Size = new System.Drawing.Size(125, 59);
            this.btnReturns.TabIndex = 16;
            this.btnReturns.Text = "Returns";
            this.btnReturns.UseVisualStyleBackColor = true;
            this.btnReturns.Click += new System.EventHandler(this.btnReturns_Click);
            // 
            // btnSales
            // 
            this.btnSales.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSales.Enabled = false;
            this.btnSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSales.Location = new System.Drawing.Point(12, 12);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(125, 59);
            this.btnSales.TabIndex = 15;
            this.btnSales.Text = "Sales";
            this.btnSales.UseVisualStyleBackColor = false;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
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
            this.lsvCheckOutItems.TabIndex = 23;
            this.lsvCheckOutItems.UseCompatibleStateImageBehavior = false;
            this.lsvCheckOutItems.View = System.Windows.Forms.View.Details;
            this.lsvCheckOutItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvCheckOutItems_KeyDown);
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
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.SystemColors.Window;
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Controls.Add(this.summaryTax);
            this.pnlSummary.Controls.Add(this.summarySubTotal);
            this.pnlSummary.Controls.Add(this.lblSubtotal);
            this.pnlSummary.Controls.Add(this.summaryTotal);
            this.pnlSummary.Controls.Add(this.lblTax);
            this.pnlSummary.Controls.Add(this.lblTotal);
            this.pnlSummary.Location = new System.Drawing.Point(474, 403);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(292, 109);
            this.pnlSummary.TabIndex = 24;
            // 
            // summaryTax
            // 
            this.summaryTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryTax.Location = new System.Drawing.Point(134, 36);
            this.summaryTax.Name = "summaryTax";
            this.summaryTax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.summaryTax.Size = new System.Drawing.Size(153, 22);
            this.summaryTax.TabIndex = 5;
            this.summaryTax.Text = "$0.00";
            this.summaryTax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // summarySubTotal
            // 
            this.summarySubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summarySubTotal.Location = new System.Drawing.Point(130, 14);
            this.summarySubTotal.Name = "summarySubTotal";
            this.summarySubTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.summarySubTotal.Size = new System.Drawing.Size(157, 22);
            this.summarySubTotal.TabIndex = 3;
            this.summarySubTotal.Text = "$0.00";
            this.summarySubTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(8, 10);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(76, 22);
            this.lblSubtotal.TabIndex = 0;
            this.lblSubtotal.Text = "Subtotal";
            // 
            // summaryTotal
            // 
            this.summaryTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryTotal.Location = new System.Drawing.Point(134, 71);
            this.summaryTotal.Name = "summaryTotal";
            this.summaryTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.summaryTotal.Size = new System.Drawing.Size(153, 26);
            this.summaryTotal.TabIndex = 4;
            this.summaryTotal.Text = "$0.00";
            this.summaryTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(8, 36);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(41, 22);
            this.lblTax.TabIndex = 1;
            this.lblTax.Text = "Tax";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(8, 71);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(51, 22);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Location = new System.Drawing.Point(772, 150);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(137, 50);
            this.btnAddItem.TabIndex = 25;
            this.btnAddItem.Text = "Manual Item Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCheckOut.Location = new System.Drawing.Point(331, 463);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(137, 49);
            this.btnCheckOut.TabIndex = 27;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnClear.Location = new System.Drawing.Point(331, 403);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(137, 37);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItem.Location = new System.Drawing.Point(772, 343);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(137, 50);
            this.btnDeleteItem.TabIndex = 28;
            this.btnDeleteItem.Text = "Void Item";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // tbScanner
            // 
            this.tbScanner.Location = new System.Drawing.Point(773, 87);
            this.tbScanner.Name = "tbScanner";
            this.tbScanner.Size = new System.Drawing.Size(136, 20);
            this.tbScanner.TabIndex = 29;
            this.tbScanner.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbScanner_KeyPress);
            // 
            // tbItemQuantity
            // 
            this.tbItemQuantity.Location = new System.Drawing.Point(841, 113);
            this.tbItemQuantity.Name = "tbItemQuantity";
            this.tbItemQuantity.Size = new System.Drawing.Size(68, 20);
            this.tbItemQuantity.TabIndex = 30;
            this.tbItemQuantity.Text = "1";
            this.tbItemQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbItemQuantity_KeyPress);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(772, 116);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 31;
            this.lblQuantity.Text = "Quantity:";
            // 
            // btnDiscount
            // 
            this.btnDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDiscount.Location = new System.Drawing.Point(772, 215);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(137, 50);
            this.btnDiscount.TabIndex = 32;
            this.btnDiscount.Text = "Discount Override";
            this.btnDiscount.UseVisualStyleBackColor = true;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // btnPrice
            // 
            this.btnPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnPrice.Location = new System.Drawing.Point(772, 271);
            this.btnPrice.Name = "btnPrice";
            this.btnPrice.Size = new System.Drawing.Size(137, 50);
            this.btnPrice.TabIndex = 33;
            this.btnPrice.Text = "Price Override";
            this.btnPrice.UseVisualStyleBackColor = true;
            this.btnPrice.Click += new System.EventHandler(this.btnPrice_Click);
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 520);
            this.Controls.Add(this.btnPrice);
            this.Controls.Add(this.btnDiscount);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.tbItemQuantity);
            this.Controls.Add(this.tbScanner);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.lsvCheckOutItems);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnReturns);
            this.Controls.Add(this.btnSales);
            this.Name = "SalesForm";
            this.Text = "SalesForm";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SalesForm_KeyPress);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnReturns;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.ListView lsvCheckOutItems;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Item;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.ColumnHeader Discount;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label summaryTax;
        private System.Windows.Forms.Label summaryTotal;
        private System.Windows.Forms.Label summarySubTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.TextBox tbScanner;
        private System.Windows.Forms.TextBox tbItemQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.Button btnPrice;
        //private System.Windows.Forms.Button btnDiscount;
        //private System.Windows.Forms.Button btnPrice;
    }
}