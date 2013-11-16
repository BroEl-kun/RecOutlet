using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ItemTableColumn = RecreationOutletPOS.Enum.ItemTableColumn;

namespace RecreationOutletPOS
{
    public partial class InventoryForm : Form
    {
        public string selectedInventory;
        public string selectedSearchColumn;
        SalesForm salesForm;
        
        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/28/2013
        /// 
        /// Constructor
        /// </summary>
        public InventoryForm(SalesForm inForm)
        {
            this.salesForm = inForm;
            InitializeComponent();

            // Sets the default value for the drop down boxes
            cmbInventoryFrom.SelectedIndex = 0;
            cmbSearchBy.SelectedIndex = 4;
        }

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
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/28/2013
        /// 
        /// Live search for the Inventory section of the POS
        /// </summary>
        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearchValue.Text;

            DataSet ds = new DataSet();

            InventorySearch dt = new InventorySearch();

            try
            {
                ds = dt.searchInventoryFor(selectedSearchColumn, searchTerm);

                lsvCurrentInventory.Items.Clear();

                if (ds.Tables["Results"].Rows.Count != 0)
                {
                    foreach (DataRow row in ds.Tables["Results"].Rows)
                    {
                        ListViewItem li = new ListViewItem(row["ItemID"].ToString());
                        
                        li.SubItems.Add(row[ItemTableColumn.REC_RPC.ToString()].ToString());
                        li.SubItems.Add(row[ItemTableColumn.ITEM_UPC.ToString()].ToString());
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

        private void btnSales_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
            this.Owner.Location = this.Location;
            this.Owner.Size = this.Size;
        }

        private void btnReturns_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesForm.showReturns();
        }
    }
}
