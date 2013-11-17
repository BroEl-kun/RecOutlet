/*using System;
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
    public partial class PriceOverideForm : Form
    {

        /// <summary>
        /// Programmer: Nate Maurer
        /// Last Updated: 11/14/2013
        ///
        /// Constructor for the SalesForm calling this
        /// </summary>
        SalesForm salesForm;
        ListViewItem lvi;
        
        public PriceOverideForm(SalesForm inForm, ListViewItem lvi)
        {
             this.salesForm = inForm;

             InitializeComponent();

             this.lvi = lvi;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPriceOveride_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                lvi.SubItems[2].Text = "-$" + txtPriceOveride.Text;
                string inPrice = lvi.SubItems[2].Text;
                salesForm.overideItemPrice(inPrice);
                this.Close();
            }
        }
    }
}*/
