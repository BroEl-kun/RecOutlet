using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        int selectedItem;
        
        public PriceOverideForm(SalesForm inForm, int selectedItem)
        {
             this.salesForm = inForm;
             this.selectedItem = selectedItem;

             InitializeComponent();
        }

        private void txtPriceOveride_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                double inPrice = 0.0;

                try
                {
                    if (Regex.IsMatch(txtPriceOveride.Text, @"[^\d{3\}(\.\d{2\})?]"))
                    {
                        MessageBox.Show("Invalid value entered into currency field. Please enter a currency value.", "Price Override",
                      MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    else
                    {
                        Double.TryParse(txtPriceOveride.Text, out inPrice);
                        salesForm.overideItemPrice(inPrice, selectedItem); 
                    }
                }
                catch (Exception ex)
                {
                   // MessageBox.Show("Invalid value entered into currency field. Please enter a currency value.", "Price Override",
                     //   MessageBoxButtons.OK, MessageBoxIcon.Asterisk);  //kept here for now for functionality sake
                }


                //salesForm.overideItemPrice(inPrice, selectedItem);  //kept here for now for functionality sake
                this.Close();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
