using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Aliases for the Enum's inner classes
using ItemTableColumn = RecreationOutletPOS.Enum.ItemTableColumn;
using SqlResultSet = RecreationOutletPOS.Enum.SqlResultSet;
using ListViewColumn = RecreationOutletPOS.Enum.ListViewColumn;

namespace RecreationOutletPOS
{
    /// <summary>
    /// Programmer: Michael Vuong
    /// Last Updated: 11/21/2013
    /// 
    /// Inventory form used for searching inventory from other stores or warehouse
    /// </summary>
    public partial class InventoryForm : Form
    {
        public string selectedInventory;
        public string selectedSearchColumn;
        SalesForm salesForm;
        
        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/21/2013
        /// 
        /// Constructor
        /// </summary>
        public InventoryForm(SalesForm inForm)
        {
            InitializeComponent();

            this.salesForm = inForm;

            // Initialize the drop down box values
            setInventoryFromValues();
            setSearchByValues();

            // Sets the default value for the drop down boxes
            cmbInventoryFrom.SelectedIndex = 0;
            cmbSearchBy.SelectedIndex = 2;
        }

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

        #endregion
    }
}
