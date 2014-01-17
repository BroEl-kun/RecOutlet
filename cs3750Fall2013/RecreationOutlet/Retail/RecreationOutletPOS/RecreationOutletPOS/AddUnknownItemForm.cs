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
    public partial class AddUnknownItemForm : Form
    {
        /// <summary>
        /// Programmer: Nate Maurer
        /// Last Updated: 1/16/2013
        ///
        /// Constructor for the SalesForm calling this
        /// </summary>
        int listView;

        Combined combined;
        public AddUnknownItemForm(Combined inForm, int list)
        {
            this.combined = inForm;
            this.listView = list;
            InitializeComponent();
        }

        private void tbAddItemPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                long id = 0;
                string name = "Unknown";
                double inPrice = 0.0;
                int quantity = 1;
                

                try
                {
                    if (Regex.IsMatch(tbAddItemPrice.Text, @"[^\d{3\}(\.\d{2\})?]"))
                    {
                        MessageBox.Show("Invalid value entered into currency field. Please enter a currency value.", "Add Item",
                      MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    else
                    {
                        int.TryParse(tbQuantity.Text, out quantity);
                        Double.TryParse(tbAddItemPrice.Text, out inPrice);

                        if (combined != null)
                        {
                            if (listView == 1)
                            {
                                combined.addItem(id, name, inPrice, quantity, 0.00, inPrice);
                            }
                            else if (listView == 2)
                            {
                                combined.addItem2(id, name, inPrice, quantity, 0.00, inPrice);
                            }
                        }

                        this.Close();
                    }

                }
                catch (Exception ex)
                {

                }
            }
        }

        private void tbQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                long id = 0;
                string name = "Unknown";
                double inPrice = 0.0;
                int quantity = 1;


                try
                {
                    if (Regex.IsMatch(tbAddItemPrice.Text, @"[^\d{3\}(\.\d{2\})?]"))
                    {
                        MessageBox.Show("Invalid value entered into currency field. Please enter a currency value.", "Add Item",
                      MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    else
                    {
                        int.TryParse(tbQuantity.Text, out quantity);
                        Double.TryParse(tbAddItemPrice.Text, out inPrice);

                        if (combined != null)
                        {
                            if (listView == 1)
                            {
                                combined.addItem(id, name, inPrice, quantity, 0.00, inPrice);
                            }
                            else if (listView == 2)
                            {
                                combined.addItem2(id, name, inPrice, quantity, 0.00, inPrice);
                            }
                        }

                        this.Close();
                    }

                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
