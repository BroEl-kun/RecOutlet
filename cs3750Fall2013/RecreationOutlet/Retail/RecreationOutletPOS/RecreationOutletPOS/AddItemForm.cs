using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

using Department = RecreationOutletPOS.Enum.Department;

namespace RecreationOutletPOS
{
    public partial class AddItemForm : Form
    {
        int listView;
        
        private string searchTerm = "";

        Combined combined;
        public AddItemForm(Combined inForm, int list)
        {
            this.combined = inForm;
            this.listView = list;

            InitializeComponent();
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/14/2013
        /// 
        /// Form loading. Initializes the listview by pulling data from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItemForm_Load(object sender, EventArgs e)
        {
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

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/14/2013
        /// 
        /// Refreshes the listview if text changes.
        /// </summary>
        private void tbItemSearch_TextChanged(object sender, EventArgs e)
        {
            refreshResults();
        }

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/14/2013
        /// 
        /// Closes the form.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/14/2013
        /// 
        /// Accepts user input and hands it back to the main form.
        /// </summary>
        private void btnAddItem_Click(object sender, EventArgs e)
        {   
            if (lvData.SelectedItems.Count > 0)
            {
                if (tbItemQuantity.Text == "0")
                {
                    MessageBox.Show("Please enter a non-zero value into the quantity field.", "Quantity",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                else{
                
                    ListViewItem lvi = lvData.SelectedItems[0];
                    long id = 0;
                    int quantity = 1;

                    try
                    {
                        long.TryParse(lvi.SubItems[0].Text, out id);

                        if (tbItemQuantity.Text != "")
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
            }

            else
            {
                MessageBox.Show("Please select an item to add.", "Item Search",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/14/2013
        /// 
        /// Catches all non-digit inputs.
        /// </summary>
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

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 12/08/2013
        /// 
        /// Refreshes the listview if the user selects another department radio button.
        /// </summary>
        private void rbtnDepartment_CheckedChanged(object sender, EventArgs e)
        {
            refreshResults();
        }

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/14/2013
        /// 
        /// Refreshes the listview. This calls a live database selection.
        /// </summary>
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
