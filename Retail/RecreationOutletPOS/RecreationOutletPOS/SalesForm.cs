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

// Aliases for the Enum's inner classes
using TransKey = RecreationOutletPOS.Enum.TransKey;

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

            this.KeyPreview = true;
        }

        public void SalesForm_Load(Object sender, EventArgs e)
        {
            summarySubTotal.Text = "$0.00";
            summaryTax.Text = "$0.00";
            summaryTotal.Text = "$0.00";

            updateListView();
        }



        #region Functions
        //----------------------------------------------------------
        // Functions
        //----------------------------------------------------------
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
                    lvi.SubItems.Add("$" + t.getPrice().ToString());
                    lvi.SubItems.Add(t.getQuantity().ToString());
                    lvi.SubItems.Add("- $" + t.getDiscount().ToString());
                    lvi.SubItems.Add("$" + t.getTotal().ToString());
                    lsvCheckOutItems.Items.Add(lvi);
                }

                summarySubTotal.Text = String.Format("{0:C2}", tList.getSubtotal()) + "\n";
                summaryTax.Text = String.Format("{0:C2}", tList.getTax()) + "\n";
                summaryTotal.Text = String.Format("{0:C2}", tList.getTotal()) + "\n";
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Programmer: Nate Maurer
        /// Last Updated: 11/16/2013
        /// 
        /// Applies the discount to the class and updates the listview.
        /// 
        /// Modified By: Jaed Norberg on 11/17/2013
        /// -   Added functionality for percentage-based discounts.
        /// </summary>
        public void discountItem(int type, double inPrice, int selectedItem)
        {
            TransactionItem t = tList.transData[selectedItem];

            try
            {
                if (type == 0)
                {
                    t.setDiscount(inPrice);
                    t.updateTotal();
                    tList.recalculate();
                }
                if (type == 1)
                {
                    t.setDiscount(t.getPrice() * (inPrice/100));
                    t.updateTotal();
                }

                tList.recalculate();
                updateListView();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Programmer: Nate Maurer
        /// Last Updated: 11/16/2013
        /// 
        /// Applies the overidden price to the class and updates the listview.
        /// </summary>
        public void overideItemPrice(double inPrice, int selectedItem)
        {
            TransactionItem t = tList.transData[selectedItem];

            try
            {
                t.setPrice(inPrice);
                t.updateTotal();
                tList.recalculate();
                updateListView();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion


        #region Button Click Handling

        //----------------------------------------------------------
        // Button Click Handling
        //----------------------------------------------------------

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

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (lsvCheckOutItems.SelectedItems.Count > 0)
            {
                int currentItem = lsvCheckOutItems.SelectedIndices[0];

                tList.deleteItem(currentItem, 1);
                updateListView();
            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/16/2013
        /// 
        /// Processes the checkout, adds a transaction to the db and updates the inventory count
        /// </summary>
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Dictionary<TransKey, string> transaction = new Dictionary<TransKey, string>();

            // NOTE- this harcoded code needs to be changed 
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

                    transaction.Add(TransKey.TRANSACTION_ID, transactionID.ToString());
                    transaction.Add(TransKey.STORE_ID, storeID.ToString());
                    transaction.Add(TransKey.EMPLOYEE_ID, employeeID.ToString());
                    transaction.Add(TransKey.TRANS_DATE, transDate.ToString());
                    transaction.Add(TransKey.TERMINAL_ID, terminalID);
                    transaction.Add(TransKey.TRANS_TOTAL, transTotal.ToString());
                    transaction.Add(TransKey.TRANS_TAX, transTax.ToString());
                    transaction.Add(TransKey.MANAGER_ID, managerID.ToString());
                    transaction.Add(TransKey.PAYMENT_TYPE, paymentType);
                    transaction.Add(TransKey.PREVIOUS_TRANS_ID, previousTransactionID.ToString());
                    transaction.Add(TransKey.TRANS_SUBTOTAL, subtotal);

                    CheckOutForm checkOutForm = new CheckOutForm(transaction, tList);
                    checkOutForm.ShowDialog();

                    tList.transData.Clear();

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

                updateListView();
            }
        }

        /// <summary>
        /// Programmer: Nate Maurer
        /// Last Updated: 11/11/2013
        /// 
        /// Opens up the form to manually add a discount.
        /// </summary>
        private void btnDiscount_Click(object sender, EventArgs e)
        {
            if (lsvCheckOutItems.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lsvCheckOutItems.SelectedItems[0];
                DiscountForm discountForm = new DiscountForm(this, lvi.Index);
                discountForm.ShowDialog();
            }

            else
            {
                MessageBox.Show("Please select an item to add a discount for.", "Discount",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        /// <summary>
        /// Programmer: Nate Maurer
        /// Last Updated: 11/14/2013
        /// 
        /// Opens up the form to manually change the price of an item.
        /// </summary>
        private void btnPrice_Click(object sender, EventArgs e)
        {
            if (lsvCheckOutItems.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lsvCheckOutItems.SelectedItems[0];
                PriceOverideForm priceOverideForm = new PriceOverideForm(this, lvi.Index);
                priceOverideForm.ShowDialog();
            }

            else
            {
                MessageBox.Show("Please select an item to change a price for.", "Change Price",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        #endregion


        #region Key Press Handling

        //----------------------------------------------------------
        // Key Press Handling
        //----------------------------------------------------------


        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 11/18/2013 
        /// 
        /// Intercepts all keypresses in order to determine which component
        /// receives focus.
        /// There are two potential implementations:
        ///     - Check for specific key (an example being a digit or delimiting character)
        ///     - Check against banned keys (an example being that the delete key is a hotkey for the listview, and shouldn't shift focus)
        private void SalesForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // make a list of banned characters

            /*char[] bannedChars = new char[]
            {
                (char)Keys.Delete
            };

            bool flag = true;

            for (int i = 0; i < bannedChars.Length; i++)
            {
                if (e.KeyChar == bannedChars[i])
                    flag = false;
            }

            if (flag)
                tbScanner.Focus();*/

            if (e.KeyChar == (Char)Keys.A)
                tbScanner.Focus();
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
                    // Barcodes using a CODABAR standard will have extra delimiting characters
                    string newText = tbScanner.Text;
                    newText = newText.Trim('A');
                    newText = newText.Trim('D');

                    string ID = newText;
                    ds = dt.retrieveItem(ID);

                    if (tbItemQuantity.Text != "")
                        int.TryParse(tbItemQuantity.Text, out quantity);

                    if (quantity < 1)
                        quantity = 1;

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
                            tbItemQuantity.Text = "1";
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
        #endregion


        #region Tab Handling
        //----------------------------------------------------------
        // Tab Handling
        //----------------------------------------------------------

        private void btnSales_Click(object sender, EventArgs e)
        {

        }

        private void btnReports_Click(object sender, EventArgs e)
        {

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
        #endregion


        #region Listview Input
        //----------------------------------------------------------
        // Listview Input
        //----------------------------------------------------------
        private void lsvCheckOutItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //lsvCheckOutItems.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //lsvCheckOutItems.Sort();
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
                    }
                    break;
            }
        }
        #endregion
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