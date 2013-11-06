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
                        
                        li.SubItems.Add(row["RecRPC"].ToString());
                        li.SubItems.Add(row["ItemUPC"].ToString());
                        li.SubItems.Add(row["Description"].ToString());
                        li.SubItems.Add(row["SellPrice"].ToString());
                        li.SubItems.Add(row["DepartmentID"].ToString());
                        li.SubItems.Add(row["CategoryID"].ToString());
                        li.SubItems.Add(row["TaxRateID"].ToString());
                        li.SubItems.Add(row["ProductLineID"].ToString());
                        li.SubItems.Add(row["SeasonCode"].ToString());
                        li.SubItems.Add(row["RestrictedAge"].ToString());
                        li.SubItems.Add(row["CreatedBy"].ToString());
                        li.SubItems.Add(row["CreatedDate"].ToString());
                        li.SubItems.Add(row["LegacyID"].ToString());
                        li.SubItems.Add(row["MSRP"].ToString());

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

        private void btnSales_Click_1(object sender, EventArgs e)
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

        private void btnSales_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
            this.Owner.Location = this.Location;
            this.Owner.Size = this.Size;
        }

        private void btnReturns_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            salesForm.showReturns();
        }

        private void btnSales_Click_3(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
            this.Owner.Location = this.Location;
            this.Owner.Size = this.Size;
        }


    }
}
