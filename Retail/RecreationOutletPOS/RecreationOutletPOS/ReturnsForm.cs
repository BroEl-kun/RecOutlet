using System;
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
    /// <summary>
    /// Programmer: Michael Vuong
    /// Last Updated: 10/23/2013
    /// 
    /// Represents the Returns section for the POS
    /// </summary>
    public partial class ReturnsForm : Form
    {
        TransactionList tList = new TransactionList();
        InventoryForm iForm;

        public ReturnsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Programmer: Aaron Sorensen
        /// Last Updated: 10/23/2013
        /// 
        /// Switch to SalesForm (Work in progress)
        /// </summary>
        private void btnSales_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
            this.Owner.Location = this.Location;
            this.Owner.Size = this.Size;
        }

        private void btnReturns_Click(object sender, EventArgs e)
        {

        }

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
                foreach (TransactionItem t in tList.transData)
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

        private void btnConfirmReturn_Click(object sender, EventArgs e)
        {

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

        private void btnInventory_Click(object sender, EventArgs e)
        {
            this.Hide();
            iForm.Show();
            iForm.Location = this.Location;
            iForm.Size = this.Size;
        }
    }
}
