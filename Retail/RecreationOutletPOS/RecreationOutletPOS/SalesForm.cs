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
        
        /// <summary>
        /// Programmer: Nate Maurer
        /// Last Modified: 10/12/2013 
        /// 
        /// Modified to create private double variables for the priceTotal function.
        /// </summary>
        /// 

        private double cost = 0; //Nate wrote this.
        private double tax = 0; //Nate wrote this.
        private double total = 0; //Nate wrote this.
            
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
        /// </summary>
        /// 
        /// <summary>
        /// Programmer: Nate Maurer
        /// Last Modified: 10/12/2013 
        /// 
        /// Modified to work more directly with the priceTotal method.
        /// </summary>
        public void addItem(int id, String item, double price, int quantity, double discount, double total)
        {
            ListViewItem lvi = new ListViewItem(id.ToString());
            lvi.SubItems.Add(item);
            lvi.SubItems.Add("$" + price);
            lvi.SubItems.Add(quantity.ToString());
            lvi.SubItems.Add("-$" + discount.ToString());
            lvi.SubItems.Add("$" + total);
            lsvCheckOutItems.Items.Add(lvi);

            priceTotal(total); //Nate wrote this.
        }

        /// <summary>
        /// Programmer: Nate Maurer
        /// Last Updated: 10/12/2013 
        /// 
        /// Calculates the sub-total, sales tax, and total cost of the purchase.
        /// </summary>
        private void priceTotal(double price){

            cost += price;
            tax = cost * .0645;
            total = cost + tax;

            summarySubTotal.Text = "$" + cost.ToString();
            summaryTax.Text = "$" + tax.ToString();
            summaryTotal.Text = "$" + total.ToString();

        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            lsvCheckOutItems.Items.RemoveAt(lsvCheckOutItems.SelectedIndices[0]);
            priceTotal(total);
        }
    }
}
