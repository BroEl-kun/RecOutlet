using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



// Aliases for the Enum's inner classes
using TransKey = RecreationOutletPOS.Enum.TransKey;
using ItemTableColumn = RecreationOutletPOS.Enum.ItemTableColumn;
using SqlResultSet = RecreationOutletPOS.Enum.SqlResultSet;
using ListViewColumn = RecreationOutletPOS.Enum.ListViewColumn;

namespace RecreationOutletPOS
{
    public partial class Combined : Form
    {
        TransactionList tList = new TransactionList();  //list for sales
        TransactionList tList2 = new TransactionList(); //list for returns

        public string selectedInventory;
        public string selectedSearchColumn;

        // keyboard event handling
        bool modifierKeyHandled = false;



        public Combined()
        {
            InitializeComponent();
            setTab(btnSales, grpSales);

            this.KeyPreview = true;

            //Inventory form
            // Initialize the drop down box values
            setInventoryFromValues();
            setSearchByValues();

            // Sets the default value for the drop down boxes
            cmbInventoryFrom.SelectedIndex = 0;
            cmbSearchBy.SelectedIndex = 2;
        }

        public void Combined_Load(Object sender, EventArgs e)
        {
            //Salesform constructor
            summarySubTotal.Text = "$0.00";
            summaryTax.Text = "$0.00";
            summaryTotal.Text = "$0.00";

            updateListView();

            //Inventoryform
            
        }



        #region Form Events and Hotkeys


        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 12/4/2013 
        /// 
        /// Intercepts key combinations before executing the KeyPress event.
        private void Combined_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                if (e.KeyCode == Keys.D1)
                    setTab(btnSales, grpSales);
                if (e.KeyCode == Keys.D2)
                    setTab(btnReturns, grpReturns);
                if (e.KeyCode == Keys.D3)
                    setTab(btnInventory, grpInventory);
                if (e.KeyCode == Keys.D4)
                    setTab(btnReports, grpReports);

                modifierKeyHandled = true;
            }
        }

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 12/4/2013 
        /// 
        /// Intercepts all keypresses in order to determine which component
        /// receives focus.
        private void Combined_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (modifierKeyHandled)
            {
                e.Handled = true;
                modifierKeyHandled = false;
            }

            // number keys will focus the scanner textbox by default
            if (tbScanner.Visible)
            {
                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                {
                    if (!tbItemQuantity.Focused && !tbScanner.Focused)
                    {
                        tbScanner.Text = e.KeyChar.ToString();
                        tbScanner.GotFocus += delegate { tbScanner.Select(tbScanner.Text.Length, tbScanner.Text.Length); };
                        tbScanner.Focus();
                    }
                }
            }
        }

        #endregion



        #region *** Tab Handling ***

        private void btnSales_MouseClick(object sender, MouseEventArgs e)
        {
            setTab(btnSales, grpSales);
        }

        private void btnReturns_MouseClick(object sender, MouseEventArgs e)
        {
            setTab(btnReturns, grpReturns);
        }

        private void btnInventory_MouseClick(object sender, MouseEventArgs e)
        {
            setTab(btnInventory, grpInventory);
        }

        private void btnReports_MouseClick(object sender, MouseEventArgs e)
        {
            setTab(btnReports, grpReports);
        }

        private void setTab(Button b, GroupBox g)
        {
            //enableButtons
            btnSales.Enabled = true;
            btnSales.UseVisualStyleBackColor = true;
            btnReturns.Enabled = true;
            btnReturns.UseVisualStyleBackColor = true;
            btnInventory.Enabled = true;
            btnInventory.UseVisualStyleBackColor = true;
            btnReports.Enabled = true;
            btnReports.UseVisualStyleBackColor = true;

            //hideGroups
            grpSales.Visible = false;
            grpReturns.Visible = false;
            grpInventory.Visible = false;
            grpReports.Visible = false;

            //setTab
            b.Enabled = false;
            b.BackColor = SystemColors.ControlDark;
            g.Visible = true;
        }

        #endregion


        #region --- Sales Forms Content ---

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
                    t.setDiscount(Math.Round(inPrice,2));
                    t.updateTotal();
                    tList.recalculate();
                }
                if (type == 1)
                {
                    double calc = Math.Round((t.getPrice() * (inPrice / 100)), 2);
                    t.setDiscount(calc);
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

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 11/20/2013
        /// 
        /// Deletes the selected item with the supplied amount.
        /// </summary>
        public void voidItem(int item, int amount)
        {
            tList.deleteItem(item, amount);
            updateListView();
        }

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 11/20/2013
        /// 
        /// Clears the entire list and voids the transaction.
        /// </summary>
        public void voidTransaction()
        {
            tList.clearData();
            updateListView();
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
            AddItemForm addItemForm = new AddItemForm(this, 1);
            addItemForm.ShowDialog();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (lsvCheckOutItems.SelectedItems.Count > 0)
            {
                int currentItem = lsvCheckOutItems.SelectedIndices[0];

                DeleteItem voidForm = new DeleteItem(this, currentItem);
                voidForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select an item to void.", "Item Void",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/18/2013
        /// 
        /// Processes the checkout, adds a transaction to the db and updates the inventory count
        /// </summary>
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Dictionary<TransKey, string> transaction = new Dictionary<TransKey, string>();

            // NOTE- this harcoded code needs to be changed 
            int transactionID = 001;

            // Needs to remain hardcoded for now
            int storeID = 01;
            int employeeID = 123;
            int managerID = 999;
            int previousTransactionID = 0;
            string terminalID = "Reg 001";

            Decimal transTotal;

            string subtotal = summarySubTotal.Text.Replace("$", string.Empty);
            string tax = summaryTax.Text.Replace("$", string.Empty);
            string newTotalText = summaryTotal.Text.Replace("$", string.Empty);

            // Gets rid of the random newline characters at the ends
            subtotal = subtotal.Substring(0, subtotal.Length - 1);
            tax = tax.Substring(0, tax.Length - 1);
            newTotalText = newTotalText.Substring(0, newTotalText.Length - 1);

            if (lsvCheckOutItems.Items.Count > 0)
            {
                try
                {
                    Decimal.TryParse(newTotalText, out transTotal);

                    transaction.Add(TransKey.TRANS_ID, transactionID.ToString());
                    transaction.Add(TransKey.STORE_ID, storeID.ToString());
                    transaction.Add(TransKey.EMPLOYEE_ID, employeeID.ToString());
                    transaction.Add(TransKey.TRANS_DATE, DateTime.Now.ToString());
                    transaction.Add(TransKey.TERMINAL_ID, terminalID);
                    transaction.Add(TransKey.TRANS_TOTAL, transTotal.ToString());
                    transaction.Add(TransKey.TRANS_TAX, tax.ToString());
                    transaction.Add(TransKey.MANAGER_ID, managerID.ToString());
                    transaction.Add(TransKey.PREVIOUS_TRANS_ID, previousTransactionID.ToString());
                    transaction.Add(TransKey.TRANS_SUBTOTAL, subtotal);

                    CheckOutForm checkOutForm = new CheckOutForm(this, transaction, tList);
                    checkOutForm.ShowDialog();

                    //tList.clearData();

                    //updateListView();
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
                    tbItemQuantity.Text = "1";
                    voidTransaction();
                }
            }
            else
            {
                MessageBox.Show("There is nothing to clear.", "Transaction Clear",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

                            int.TryParse(row["RecRPC"].ToString(), out id);
                            name = (row["Name"].ToString());
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
        #endregion

        #endregion 

        #region --- Returns Form Content ---

        private void btnAddItem_Click2(object sender, EventArgs e)
        {
            AddItemForm addItemForm = new AddItemForm(this, 2);
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
        public void addItem2(int id, String item, double price, int quantity, double discount, double total)
        {
            tList2.addItem(id, item, price, quantity, discount);
            updateListView2();
            recalculate();
        }

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/14/2013 
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
            Decimal itemTotalCost = 0.0M;

            try
            {
                foreach (TransactionItem t in tList2.transData)
                {
                    double costStr = t.getTotal();
                    int qtyStr = t.getQuantity();
                    itemTotalCost += Convert.ToDecimal(costStr * qtyStr);
                }

                itemTotalCost = Decimal.Round(itemTotalCost, 2);

                summaryReturnTotal.Text = "$" + itemTotalCost.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/14/2013 
        /// 
        /// Updates the listview by pulling from the
        /// active TransactionList class.
        /// </summary>
        private void updateListView2()
        {
            try
            {
                listView1.Items.Clear();
                foreach (TransactionItem t in tList2.transData)
                {
                    ListViewItem lvi = new ListViewItem(t.getID().ToString());
                    lvi.SubItems.Add(t.getName());
                    lvi.SubItems.Add("$" + t.getPrice());
                    lvi.SubItems.Add(t.getQuantity().ToString());
                    lvi.SubItems.Add("-$" + t.getDiscount().ToString());
                    lvi.SubItems.Add("$" + t.getTotal());
                    listView1.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnConfirmReturn_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteItem_ClickRet(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int currentItem = listView1.SelectedIndices[0];

                tList2.deleteItem(currentItem, 1);

                foreach (ListViewItem eachItem in listView1.SelectedItems)
                {
                    listView1.Items.Remove(eachItem);
                }
                //updateListView();
                recalculate();
            }
        }

        #endregion 

        #region --- Inventory Form Content ---

        #region Dropdown Populating Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/21/2013
        /// 
        /// Populates the Search By dropdown box 
        /// </summary>
        private void setSearchByValues()
        {
            List<ItemTableColumn> searchByValues = ItemTableColumn.getItemTableColumns();
            
            try
            {
                foreach (ItemTableColumn columnEnum in searchByValues)
                {
                    cmbSearchBy.Items.Add(columnEnum.ToString());
                }
            }

            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/21/2013
        /// 
        /// NOTE- hardcoded store names for now, this should be changed later when its
        /// possible to retrieve store names and their inventory
        /// 
        /// Populates the Inventory From dropdown box
        /// </summary>
        private void setInventoryFromValues()
        {
            List<string> inventoryLocations = new List<string>();

            try
            {
                inventoryLocations.Add("<This Store>");
                inventoryLocations.Add("Store 1");
                inventoryLocations.Add("Store 2");
                inventoryLocations.Add("Warehouse");
                
                foreach (string location in inventoryLocations)
                {
                    cmbInventoryFrom.Items.Add(location);
                }
            }

            catch (Exception ex)
            {
                
            }
        }

        #endregion

        #region Event Handling

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/28/2013
        /// 
        /// Sets what inventory to search from 
        /// </summary>
        private void cmbInventoryFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedInventory = cmbInventoryFrom.Text;
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/28/2013
        /// 
        /// Determines what specific item detail to search in
        /// </summary>
        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSearchColumn = cmbSearchBy.Text;

            searchDatabase();
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/26/2013
        /// 
        /// Live search for the Inventory section of the POS
        /// </summary>
        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {
            searchDatabase();
        }

        #region Helper Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/26/2013
        /// 
        /// Searches the database using the Search textbox's value as the search criteria and
        /// the Selected Search By value as the column to search in
        /// </summary>
        private void searchDatabase()
        {
            string searchTerm = txtSearchValue.Text;

            DataSet ds = new DataSet();

            InventorySearch dt = new InventorySearch();

            try
            {
                ds = dt.searchInventoryFor(selectedSearchColumn, searchTerm);

                lsvCurrentInventory.Items.Clear();

                if (ds.Tables[SqlResultSet.ITEM_RESULTSET.ToString()].Rows.Count != 0)
                {
                    foreach (DataRow row in ds.Tables[SqlResultSet.ITEM_RESULTSET.ToString()].Rows)
                    {
                        ListViewItem li = new ListViewItem(row[ListViewColumn.ITEM_ID.ToString()].ToString());

                        li.SubItems.Add(row[ItemTableColumn.REC_RPC.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.ITEM_UPC.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.NAME.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.DESCRIPTION.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.SELL_PRICE.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.DEPARTMENT_ID.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.CATEGORY_ID.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.TAX_RATE_ID.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.PRODUCT_LINE_ID.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.SEASON_CODE.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.RESTRICTED_AGE.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.ITEM_CREATED_BY.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.ITEM_CREATED_DATE.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.LEGACY_ID.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.MSRP.ToString()].ToString());

                        lsvCurrentInventory.Items.Add(li);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        private void InventoryForm_Load(object sender, EventArgs e)
        {

        }

        #endregion

        private void txtSearchValue_TextChanged_1(object sender, EventArgs e)
        {

        }

        #endregion 
    }
}
