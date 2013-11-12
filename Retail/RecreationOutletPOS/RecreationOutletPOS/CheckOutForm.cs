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
        public Dictionary<string, string> transaction;
        public TransactionList transItems;
        private int radChecked = 0;
        String PAN;    //Primary Account Number
        String lName;
        String fName;
        String ccNum;

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/27/2013
        /// 
        /// Constructor
        /// </summary>
        /// <param name="transaction">The new transaction details to display</param>
        public CheckOutForm(Dictionary<string, string> transaction, TransactionList transItems)
        {
            this.transaction = transaction;
            this.transItems = transItems;

            InitializeComponent();
            //ccField.Width = 0;
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
            if (radChecked == 1)
            {
                //Cash Checkout
            }
            else
            {
                //Card Checkout
                cardCheckout();
            }
            try

            {
                DialogResult result = MessageBox.Show("Confirm transaction?", "Transaction",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (result == DialogResult.Yes)
                {
                    Transaction newTransaction = new Transaction(transaction);

                    ReceiptGenerator receiptGenerator = new ReceiptGenerator(newTransaction, transItems);

                    //receiptGenerator.printReceiptToFile();
                    receiptGenerator.printToPrinter();

                    MessageBox.Show("Transaction complete.\n" + newTransaction.rowsInserted.ToString() + " transaction(s) recorded.", "Transaction",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    this.Close();
                }
            }

            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Programmer: Aaron Sorensen
        /// Last Updated: 11/11/2013
        /// 
        /// Runs credit card checkout
        /// </summary>
        private void cardCheckout()
        {
            
        }

        /// <summary>
        /// Programmer: Aaron Sorensen
        /// Last Updated: 11/11/2013
        /// 
        /// Parses input from the card reader from hidden textField
        /// </summary>
        private void readCard(object sender, EventArgs e)
        {
            if (ccField.Text.Length > 10)
            {
                char[] delimiterChars = { '%', '^', '/', '?', ';', '=' };
                String rawString = ccField.Text;

                rawString = rawString.Replace(" ", "");
                string[] parsed = rawString.Split(delimiterChars);

                PAN = parsed[1];
                lName = parsed[2];
                fName = parsed[3];
                ccNum = parsed[6];
                
                MessageBox.Show("PAN: " + PAN + "\n" + "Last Name: " + lName + "\n" + "First Name: "  + fName + "\n" + "ccNum: "  + ccNum);
            }
            else
            {
                ccField.Text = "";
            }
        }

        /// <summary>
        /// Programmer: Aaron Sorensen
        /// Last Updated: 11/11/2013
        /// 
        /// Controls radio buttons
        /// </summary>
        private void radCash_CheckedChanged(object sender, EventArgs e)
        {
            if (radCash.Checked)
            {
                radChecked = 1;
            }
        }

        private void radCredit_CheckedChanged(object sender, EventArgs e)
        {
            if (radCredit.Checked)
            {
                radChecked = 2;
                ccField.Focus();
            }
        }

        private void readCard()
        {

        }
    }
}
