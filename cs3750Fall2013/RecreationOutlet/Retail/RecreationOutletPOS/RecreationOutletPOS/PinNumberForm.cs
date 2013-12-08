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
    /// <summary>
    /// Programmer: Nate Maurer
    /// Last Updated: 12/7/2013
    ///
    /// Constructor for the PriceOverideForm calling this.
    /// </summary>
    public partial class PinNumberForm : Form
    {
        PriceOverideForm poForm;
        int pinNumber = 1234;
        bool confirmed = false;

        public PinNumberForm(PriceOverideForm inForm)
        {
            this.poForm = inForm;
            InitializeComponent();
        }

        private void tbPinNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int inNumber = 0;

                try
                {
                    if (Regex.IsMatch(tbPinNumber.Text, @"[/\b\d{4}\b/]"))
                    {
                        int.TryParse(tbPinNumber.Text, out inNumber);

                        if (inNumber == pinNumber)
                        {

                            confirmed = true;
                            poForm.Confirmed(confirmed);
                            this.Close();

                        }
                        else
                        {

                            MessageBox.Show("Unauthorized PIN", "PIN Number",
                      MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        }
                        
                    }

                    else
                    {
                        MessageBox.Show("Invalid entry. Please enter a four-digit number.", "PIN Number",
                      MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {

                }
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
        private void PinNumberForm_Load(object sender, EventArgs e)
        {

        }
}
}
