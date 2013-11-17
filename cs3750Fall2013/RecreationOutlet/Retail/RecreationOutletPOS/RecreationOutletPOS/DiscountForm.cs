/*using System;
using System.Collections;
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
    public partial class DiscountForm : Form
    {
        /// <summary>
        /// Programmer: Nate Maurer
        /// Last Updated: 11/11/2013
        ///
        /// Constructor for the SalesForm calling this
        /// </summary>
        /// 
        SalesForm salesForm;
        ListViewItem lvi;

        public DiscountForm(SalesForm inForm, ListViewItem lvi)
        {
            this.salesForm = inForm;

            InitializeComponent();

            this.lvi = lvi;
        }

        private void DiscountForm_Load(object sender, EventArgs e)
        {

            tbDiscountPrice.Focus();
        }

        private void tbDiscountPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                    lvi.SubItems[4].Text = "-$" + tbDiscountPrice.Text;
                    string inPrice = lvi.SubItems[4].Text;
                    salesForm.discountItem(inPrice);
                    this.Close();
            }

        }
    }
}*/
