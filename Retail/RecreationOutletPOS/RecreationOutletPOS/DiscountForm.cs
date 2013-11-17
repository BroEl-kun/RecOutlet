using System;
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
        int selectedItem;

        public DiscountForm(SalesForm inForm, int selectedItem)
        {
            this.salesForm = inForm;
            this.selectedItem = selectedItem;

            InitializeComponent();
        }

        private void DiscountForm_Load(object sender, EventArgs e)
        {
            tbDiscountPrice.Focus();
        }

        private void tbDiscountPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                double inPrice = 0.0;

                try
                {
                    Double.TryParse(tbDiscountPrice.Text, out inPrice);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid value entered into currency field. Please enter a currency value.", "Discount",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                salesForm.discountItem(0, inPrice, selectedItem);
                this.Close();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void tbDiscountPerc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                double inPercent = 0.0;

                try
                {
                    Double.TryParse(tbDiscountPerc.Text, out inPercent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid value entered into percentage field. Please enter a percentage value.", "Discount",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                salesForm.discountItem(1, inPercent, selectedItem);
                this.Close();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
