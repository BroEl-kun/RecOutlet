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
    public partial class CheckOutForm : Form
    {
        Dictionary<string, string> transaction;
        
        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/27/2013
        /// 
        /// Constructor
        /// </summary>
        /// <param name="transaction">The new transaction details to display</param>
        public CheckOutForm(Dictionary<string, string> transaction)
        {
            this.transaction = transaction;

            InitializeComponent();

            setCheckoutInfo(transaction);
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/27/2013
        /// 
        /// Sets the summary information from the sales screen to be re-displayed in the checkout screen 
        /// </summary>
        /// <param name="transaction">the dictionary to get the summary infor from the sales form screen</param>
        private void setCheckoutInfo(Dictionary<string, string> transaction)
        {
            try
            {
                summarySubTotal.Text = "$" + transaction["SummarySubtotal"];
                summaryTax.Text = "$" + transaction["SummaryTax"];
                summaryTotal.Text = "$" + transaction["TransTotal"];
            }

            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/27/2013
        /// 
        /// Confirms the checkout and inserts a new transaction record into the database
        /// </summary>
        private void btnConfirmCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Confirm transaction?", "Transaction",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (result == DialogResult.Yes)
                {
                    Transaction newTransaction = new Transaction(transaction);

                    MessageBox.Show("Transaction complete.\n" + newTransaction.rowsInserted.ToString() + " transaction(s) recorded.", "Transaction",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    this.Close();
                }
            }

            catch (Exception ex)
            {

            }
        }
    }
}
