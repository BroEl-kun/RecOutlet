using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

// Alias to user the Enum's inner classes
using Department = RecreationOutletPOS.Enum.Department;

namespace RecreationOutletPOS
{
    public partial class AddItemForm : Form
    {
        int listView;
        
        private string searchTerm = "";

        //Constuctor for combined form -Aaron
        Combined combined;
        public AddItemForm(Combined inForm, int list)
        {
            this.combined = inForm;
            this.listView = list;

            InitializeComponent();
        }
        //------------------------------------

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/14/2013
        /// 
        /// NOTE- this.iTEMTableAdapter.Fill(this.masterDataSet.ITEM); was commented to get the program to work with
        /// the new connection string established
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItemForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.ITEM' table. You can move, or remove it, as needed.
            //this.iTEMTableAdapter.Fill(this.masterDataSet.ITEM);


            DataSet ds;
            ItemSearch dt = new ItemSearch();

            try
            {
                ds = dt.showData(searchTerm, 0);

                lvData.Items.Clear();

                if (ds.Tables["Results"].Rows.Count != 0)
                {
                    foreach (DataRow row in ds.Tables["Results"].Rows)
                    {
                        Decimal newPrice = Convert.ToDecimal(row["SellPrice"]);
                        newPrice = Decimal.Round(newPrice, 2, MidpointRounding.AwayFromZero);

                        ListViewItem li = new ListViewItem(row["RecRPC"].ToString());
                        li.SubItems.Add(row["Name"].ToString());
                        li.SubItems.Add(newPrice.ToString());
                        lvData.Items.Add(li);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void tbItemSearch_TextChanged(object sender, EventArgs e)
        {
            refreshResults();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (lvData.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvData.SelectedItems[0];
                long id = 0;
                int quantity = 1;

                try
                {
                    long.TryParse(lvi.SubItems[0].Text, out id);

                    if (tbItemQuantity.Text != "" && tbItemQuantity.Text != "0")
                        int.TryParse(tbItemQuantity.Text, out quantity);
                }
                catch (Exception ex) { }

                string name = lvi.SubItems[1].Text;
                double price = Convert.ToDouble(lvi.SubItems[2].Text.Replace("$",""));
                this.Close();

                // Determine which form called this form
                // Programmer: Michael Vuong
                // Last Updated: 10/27/2013
                if (combined != null)
                {
                    //Check which group called this form
                    if (listView == 1)
                    {
                        combined.addItem(id, name, price, quantity, 0.00, price);
                    }
                    else if (listView == 2)
                    {
                        combined.addItem2(id, name, price, quantity, 0.00, price);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to add.", "Item Search",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        int zero = 0;

        private void tbItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

        }


        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 12/05/2013
        ///
        /// Retrieves the selected departments by cycling through
        /// the buttons and seeing which ones are active.
        /// It returns the department ID for the selected button.
        /// </summary>
        private int retrieveDepartments()
        {
            int selectedDepartment = 0;

            if (rbtnAsIs.Checked)
                selectedDepartment = 0;

            if (rbtnEmergency.Checked)
                selectedDepartment = 9;

            if (rbtnFootwear.Checked)
                selectedDepartment = 7;

            if (rbtnWaterSports.Checked)
                selectedDepartment = 14;

            if (rbtnSnowHardgoods.Checked)
                selectedDepartment = 10;

            if (rbtnWinterClothing.Checked)
                selectedDepartment = 5;

            if (rbtnOutdoorSports.Checked)
                selectedDepartment = 40;

            if (rbtnClimbing.Checked)
                selectedDepartment = 2;

            if (rbtnFood.Checked)
                selectedDepartment = 90;

            if (rbtnFurniture.Checked)
                selectedDepartment = 15;

            if (rbtnPacks.Checked)
                selectedDepartment = 8;

            if (rbtnStoves.Checked)
                selectedDepartment = 12;

            if (rbtnOuterwear.Checked)
                selectedDepartment = 11;

            if (rbtnImpulseMerchandise.Checked)
                selectedDepartment = 82;


            return selectedDepartment;
        }

        private void rbtnDepartment_CheckedChanged(object sender, EventArgs e)
        {
            refreshResults();
        }


        private void refreshResults()
        {
            searchTerm = tbItemSearch.Text;

            DataSet ds = new DataSet();

            ItemSearch dt = new ItemSearch();

            try
            {
                ds = dt.showData(searchTerm, retrieveDepartments());

                lvData.Items.Clear();

                if (ds.Tables["Results"].Rows.Count != 0)
                {
                    foreach (DataRow row in ds.Tables["Results"].Rows)
                    {
                        Decimal newPrice = Convert.ToDecimal(row["SellPrice"]);
                        newPrice = Decimal.Round(newPrice, 2, MidpointRounding.AwayFromZero);

                        ListViewItem li = new ListViewItem(row["RecRPC"].ToString());
                        li.SubItems.Add(row["Name"].ToString());
                        li.SubItems.Add(newPrice.ToString ());
                        lvData.Items.Add(li);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
