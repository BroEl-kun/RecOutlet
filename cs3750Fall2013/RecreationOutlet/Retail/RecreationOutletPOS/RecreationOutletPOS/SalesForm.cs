﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecreationOutletPOS
{
    public partial class SalesForm : Form
    {
        public SalesForm()
        {
            InitializeComponent();
        }

        public void SalesForm_Load(Object sender, EventArgs e)
        {
            summarySubTotal.Text = "$0.00";
            summaryTax.Text = "$0.00";
            summaryTotal.Text = "$0.00";

            recalculate();
        }

        

        private double cost = 0; //Nate wrote this.
        private double tax = 0; //Nate wrote this.
        private double total = 0; //Nate wrote this.

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/11/2013 
        /// 
        /// Brings up a MODAL dialog to manually add an item from a select category list
        /// </summary>
        /// <param name="sender">the form component that called this method</param>
        /// <param name="e">Associated events tied to the sender?</param>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItemForm addItemForm = new AddItemForm(this);
            addItemForm.ShowDialog();
        }

        /// <summary>
        /// Programmer: Aaron Sorensen
        /// Last Updated: 10/12/2013 
        /// 
        /// Adds an item to the ListView
        /// </summary>
        /// 
        /// <summary>
        /// Programmer: Nate Maurer
        /// Last Modified: 10/12/2013 
        /// 
        /// Modified to work more directly with the priceTotal method.
        /// </summary>
        public void addItem(int id, String item, double price, int quantity, double discount, double total)
        {
            ListViewItem lvi = new ListViewItem(id.ToString());
            lvi.SubItems.Add(item);
            lvi.SubItems.Add("$" + price);
            lvi.SubItems.Add(quantity.ToString());
            lvi.SubItems.Add("-$" + discount.ToString());
            lvi.SubItems.Add("$" + total);
            lsvCheckOutItems.Items.Add(lvi);

            //priceTotal(total); //Nate wrote this.
            recalculate();
        }

        /// <summary>
        /// Programmer: Nate Maurer
        /// Last Updated: 10/12/2013 
        /// 
        /// Calculates the sub-total, sales tax, and total cost of the purchase.
        /// </summary>
        private void priceTotal(double price)
        {
            cost += price;
            tax = cost * .0645;
            total = cost + tax;

            summarySubTotal.Text = "$" + cost.ToString();
            summaryTax.Text = "$" + tax.ToString();
            summaryTotal.Text = "$" + total.ToString();
        }


        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/14/2013 
        /// 
        /// Recalculates costs from the items in the listview.
        /// This takes the values from the listview and places
        /// the total in the summary labels.
        /// </summary>
        private void recalculate()
        {
            Decimal itemCost = 0.0M;
            Decimal taxRate = 0.0645M;
            Decimal appliedTax = 0.0M;
            Decimal itemTotalCost = 0.0M;

            try
            {
                for (int i = 0; i < lsvCheckOutItems.Items.Count; i++)
                {
                    string costStr = lsvCheckOutItems.Items[i].SubItems[2].Text;
                    costStr = costStr.Replace("$", "");

                    itemCost += Convert.ToDecimal(costStr);
                }
                appliedTax = itemCost * taxRate;
                itemTotalCost = itemCost + appliedTax;

                itemCost = Decimal.Round(itemCost, 2);
                appliedTax = Decimal.Round(appliedTax, 2);
                itemTotalCost = Decimal.Round(itemTotalCost, 2);

                summarySubTotal.Text = "$" + itemCost.ToString();
                summaryTax.Text = "$" + appliedTax.ToString();
                summaryTotal.Text = "$" + itemTotalCost.ToString();
            }
            catch (Exception ex)
            {
            }
        }


        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (lsvCheckOutItems.SelectedItems.Count > 0)
            {
                if (lsvCheckOutItems.Items.Count > 0)
                {
                    lsvCheckOutItems.Items.RemoveAt(lsvCheckOutItems.SelectedIndices[0]);
                }
                else
                {
                    MessageBox.Show("There's nothing to delete.", "Item Deletion",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                recalculate();
                // NOTE: Must recalculate price here
            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/14/2013
        /// 
        /// Processes the checkout, adds a transaction to the db and updates the inventory count
        /// </summary>
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> transaction = new Dictionary<string, string>();

            int transactionID = 001;
            int storeID = 1;
            int employeeID = 123;
            DateTime transDate = DateTime.Now;
            string terminalID = "t0";
            Decimal transTotal;
            Decimal transTax = 25;
            int managerID = 1;
            string paymentType = "Cash";
            int previousTransactionID = 0;

            summaryTotal.Text = summaryTotal.Text.Replace("$", string.Empty);

            try
            {
                Decimal.TryParse(summaryTotal.Text, out transTotal);

                transaction.Add("TransactionID", transactionID.ToString());
                transaction.Add("StoreID", storeID.ToString());
                transaction.Add("EmployeeID", employeeID.ToString());
                transaction.Add("TransDate", transDate.ToString());
                transaction.Add("TerminalID", terminalID);
                transaction.Add("TransTotal", transTotal.ToString());
                transaction.Add("TransTax", transTax.ToString());
                transaction.Add("ManagerID", managerID.ToString());
                transaction.Add("PaymentType", paymentType);
                transaction.Add("PreviousTransactionID", previousTransactionID.ToString());

                Transaction newTransaction = new Transaction(transaction);

            }

            catch (Exception ex)
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (lsvCheckOutItems.Items.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to clear the transaction?", "Transaction Clear",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    lsvCheckOutItems.Items.Clear();
                }
                recalculate();
            }
        }
    }
}
