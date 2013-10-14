using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;


namespace RecreationOutletPOS
{
    public partial class AddItemForm : Form
    {
        SalesForm mainForm;

        private string searchTerm = "";
        

        public AddItemForm(SalesForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void AddItemForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.ITEM' table. You can move, or remove it, as needed.
            this.iTEMTableAdapter.Fill(this.masterDataSet.ITEM);
            
        }



        private void tbItemSearch_TextChanged(object sender, EventArgs e)
        {
            searchTerm = tbItemSearch.Text;

            DataSet ds = new DataSet();

            ManualItemAddition dt = new ManualItemAddition();
            ds = dt.showData(searchTerm);

            lvData.Items.Clear();

            if (ds.Tables["Results"].Rows.Count != 0)
            {
                foreach (DataRow row in ds.Tables["Results"].Rows)
                {
                    ListViewItem li = new ListViewItem();
                    //li.SubItems.Add(row["ItemID"].ToString());
                    li.SubItems.Add(row["Description"].ToString());
                    li.SubItems.Add(row["SellPrice"].ToString());
                    lvData.Items.Add(li);
                }
            }
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
                string name = lvi.SubItems[1].Text;
                double price = Convert.ToDouble(lvi.SubItems[2].Text.Replace("$",""));
                this.Close();
                mainForm.addItem(1, name, price, 1, 0.00, price);
            }
            else
            {
                MessageBox.Show("Please select an item to add.", "Manual Item Addition",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
