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
    public partial class SalesForm : Form
    {
        public SalesForm()
        {
            InitializeComponent();
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
            AddItemForm addItemForm = new AddItemForm();
            addItemForm.ShowDialog();
        }

        /// <summary>
        /// Programmer: Aaron Sorensen
        /// Last Updated: 10/12/2013 
        /// 
        /// Adds an item to the ListView
        /// </summary>
        private void addItem(int id, String item, double price, int quantity, double discount, double total)
        {
            ListViewItem lvi = new ListViewItem(id.ToString());
            lvi.SubItems.Add(item);
            lvi.SubItems.Add("$" + price);
            lvi.SubItems.Add(quantity.ToString());
            lvi.SubItems.Add("-$" + discount.ToString());
            lvi.SubItems.Add("$" + total);
            lsvCheckOutItems.Items.Add(lvi);
        }
    }
}
