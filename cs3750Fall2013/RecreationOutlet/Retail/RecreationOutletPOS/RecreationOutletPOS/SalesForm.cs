using System;
using System.Collections;
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
        TransactionList tList = new TransactionList();
        ReturnsForm rForm;
        InventoryForm iForm;
        
        public SalesForm()
        {
            rForm = new ReturnsForm(this);
            iForm = new InventoryForm(this);
            InitializeComponent();
        }

        public void SalesForm_Load(Object sender, EventArgs e)
        {
            summarySubTotal.Text = "$0.00";
            summaryTax.Text = "$0.00";
            summaryTotal.Text = "$0.00";

            recalculate();
        }


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
        /// 
        /// Modified by Jaed Norberg on 10/20/2013
        ///     - Converted listview operations into class operations
        ///         (all previous operations were moved to the updateListView function)
        /// </summary>
        public void addItem(int id, String item, double price, int quantity, double discount, double total)
        {
            tList.addItem(id, item, price, quantity, discount);
            updateListView();
            recalculate();
        }


        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/27/2013  (by Michael Vuong)
        /// 
        /// Recalculates costs from the items in the listview.
        /// This takes the values from the listview and places
        /// the total in the summary labels.
        /// 
        /// Modified by Jaed Norberg on 10/20/2013
        ///     - Changed listview operations to class operations
        /// </summary>
        private void recalculate()
        {
            Decimal itemCost = 0.0M;
            Decimal taxRate = 0.0645M;
            Decimal appliedTax = 0.0M;
            Decimal itemTotalCost = 0.0M;

            try
            {
                // Get the total value based on all items in the transaction
                foreach (TransactionItem t in tList.transData)
                {
                    double costStr = t.getTotal();
                    int qtyStr = t.getQuantity();
                    itemCost += Convert.ToDecimal(costStr);
                }

                // Calculate tax
                appliedTax = itemCost * taxRate;
                itemTotalCost = itemCost + appliedTax;

                itemCost = Decimal.Round(itemCost, 2);
                appliedTax = Decimal.Round(appliedTax, 2);
                itemTotalCost = Decimal.Round(itemTotalCost, 2);

                // Set the label values
                summarySubTotal.Text = "$" + itemCost.ToString();
                summaryTax.Text = "$" + appliedTax.ToString();
                summaryTotal.Text = "$" + itemTotalCost.ToString();
            }
            catch (Exception ex)
            {
            }
        }


        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/27/2013 (by Michael Vuong)
        /// 
        /// Updates the listview by pulling from the
        /// active TransactionList class.
        /// </summary>
        private void updateListView()
        {
            try
            {
                lsvCheckOutItems.Items.Clear();
                foreach (TransactionItem t in tList.transData)
                {
                    ListViewItem lvi = new ListViewItem(t.getID().ToString());
                    lvi.SubItems.Add(t.getName());
                    lvi.SubItems.Add("$" + t.getPrice());
                    lvi.SubItems.Add(t.getQuantity().ToString());
                    lvi.SubItems.Add("-$" + t.getDiscount().ToString());
                    lvi.SubItems.Add("$" + t.getTotal());
                    lsvCheckOutItems.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
            }
        }



        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (lsvCheckOutItems.SelectedItems.Count > 0)
            {
                int currentItem = lsvCheckOutItems.SelectedIndices[0];

                tList.deleteItem(currentItem, 1);
                updateListView();
                recalculate();
            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/27/2013
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

            string subtotal = summarySubTotal.Text.Replace("$", string.Empty);
            string tax = summaryTax.Text.Replace("$", string.Empty); 
            string newTotalText = summaryTotal.Text.Replace("$", string.Empty);
            
            if (lsvCheckOutItems.Items.Count > 0)
            {
                try
                {
                    Decimal.TryParse(newTotalText, out transTotal);

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
                    transaction.Add("SummarySubtotal", subtotal);
                    transaction.Add("SummaryTax", tax);

                    CheckOutForm checkOutForm = new CheckOutForm(transaction);
                    checkOutForm.ShowDialog();

                    tList.transData.Clear();

                    recalculate();
                    updateListView();
                }

                catch (Exception ex)
                {

                }
            }

            else
            {
                MessageBox.Show("There are no items to checkout.", "Transaction",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                    tList.clearData();
                }

                recalculate();
                updateListView();
            }
        }


        private void lsvCheckOutItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //lsvCheckOutItems.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //lsvCheckOutItems.Sort();
        }


        /// <summary>
        /// Programmer: Michael Vuong, Aaron Sorensen
        /// Last Updated: 10/27/2013
        /// 
        /// Opens up the Returns section of the POS
        /// </summary>
        private void btnReturns_Click(object sender, EventArgs e)
        {
            rForm.Owner = this;
            rForm.Size = this.Size;
            this.Hide();
            rForm.Show();
            rForm.Location = this.Location;
        }

        /// <summary>
        /// Programmer: Michael Vuong, Aaron Sorensen
        /// Last Updated: 10/27/2013
        /// 
        /// Opens up the Inventory section of the POS
        /// </summary>
        private void btnInventory_Click(object sender, EventArgs e)
        {
            iForm.Owner = this;
            iForm.Size = this.Size;
            this.Hide();
            iForm.Show();
            iForm.Location = this.Location;
        }


        private void btnReturns_Click_1(object sender, EventArgs e)
        {
            
        }

        
        private void lsvCheckOutItems_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (lsvCheckOutItems.SelectedItems.Count > 0)
                    {
                        int currentItem = lsvCheckOutItems.SelectedIndices[0];

                        tList.deleteItem(currentItem, 1);
                        updateListView();
                        recalculate();
                    }
                    break;
            }
        }


        //----------------------------------------------------------
        // Key Press Handling
        //----------------------------------------------------------
        private void SalesForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void tbScanner_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enter key is pressed
            //      Carries out item addition by entering an ID or scanning
            //      a barcode in the scanner text field.
            if (e.KeyChar == 13)
            {
                DataSet ds;
                ManualItemAddition dt = new ManualItemAddition();

                int quantity = 1;

                try
                {
                    string ID = tbScanner.Text;
                    ds = dt.retrieveItem(ID);

                    if (tbItemQuantity.Text != "")
                        int.TryParse(tbItemQuantity.Text, out quantity);

                    if (ds.Tables["Results"].Rows.Count != 0)
                    {
                        foreach (DataRow row in ds.Tables["Results"].Rows)
                        {
                            int id;
                            string name;
                            double price;

                            int.TryParse(row["ItemID"].ToString(), out id);
                            name = (row["Description"].ToString());
                            double.TryParse(row["SellPrice"].ToString(), out price);

                            addItem(id, name, price, quantity, 0.00, price);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The request didn't return anything.", "Item Scan",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error processing the request.", "Item Scan",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                tbScanner.Text = "";
            }
        }

        private void tbItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void SalesForm_Load_1(object sender, EventArgs e)
        {
            
        }


        //----------------------------------------------------------
        // Tabs
        //----------------------------------------------------------
        private void btnSales_Click(object sender, EventArgs e)
        {

        }

        private void btnReports_Click(object sender, EventArgs e)
        {

        }

        private void btnSales_Click_1(object sender, EventArgs e)
        {

        }

        public void showReturns()
        {
            rForm.Owner = this;
            rForm.Size = this.Size;
            this.Hide();
            rForm.Show();
            rForm.Location = this.Location;
        }

        public void showInventory()
        {
            iForm.Owner = this;
            iForm.Size = this.Size;
            this.Hide();
            iForm.Show();
            iForm.Location = this.Location;
        }

        private void btnSales_Click_2(object sender, EventArgs e)
        {

        }
    }





    // Implements the manual sorting of items by columns.
    // This code is thanks to Microsoft's documentation.
    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            int result;
            result = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

            return result;
        }
    }
}
