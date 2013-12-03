using System;
using System.Collections;
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

        //Constructor for combined form -Aaron
        Combined combined;
        public DiscountForm(Combined inForm, int selectedItem)
        {
            this.combined = inForm;
            this.selectedItem = selectedItem;

            InitializeComponent();
        }
        //--------------------------------------

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
                    if (Regex.IsMatch(tbDiscountPrice.Text, @"[^\d{3\}(\.\d{2\})?]"))
                    {
                        MessageBox.Show("Invalid value entered into currency field. Please enter a currency value.", "Discount",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    else
                    {
                        Double.TryParse(tbDiscountPrice.Text, out inPrice);
                        if (salesForm != null)
                        {
                            salesForm.discountItem(0, inPrice, selectedItem);
                        }
                        else if (combined != null)
                        {
                            combined.discountItem(0, inPrice, selectedItem);
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }

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
                    if (Regex.IsMatch(tbDiscountPerc.Text, @"[^\d{2\}(\.\d{2\})?]"))
                    {
                        MessageBox.Show("Invalid value entered into percentage field. Please enter a percentage value.", "Discount",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                   {
                        Double.TryParse(tbDiscountPerc.Text, out inPercent);
                        if (salesForm != null)
                        {
                            salesForm.discountItem(1, inPercent, selectedItem);
                        }
                        else if (combined != null)
                        {
                            combined.discountItem(1, inPercent, selectedItem);
                        }
                    }
                }
                catch (Exception ex)
                {
                   // MessageBox.Show("Invalid value entered into percentage field. Please enter a percentage value.", "Discount",
                    //MessageBoxButtons.OK, MessageBoxIcon.Asterisk); //For now, keep this here for functionality sake
                }

                if (salesForm != null)
                {
                    salesForm.discountItem(1, inPercent, selectedItem); //For now, keep this here for functionality sake
                }
                else if (combined != null)
                {
                    combined.discountItem(1, inPercent, selectedItem); //For now, keep this here for functionality sake
                }

                this.Close();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
