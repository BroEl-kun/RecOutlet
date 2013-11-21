using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Aliases for the Enum's inner classes
using TransKey = RecreationOutletPOS.Enum.TransKey;

namespace RecreationOutletPOS
{
    public partial class CheckOutForm : Form
    {
        public Dictionary<TransKey, string> transaction;
        public TransactionList transItems;
        private int radChecked = 0;
        private String PAN;     //Primary Account Number
        private String lName;
        private String fName;
        private String ccNum;
        private String ccEnd;   //Last 4 of CC Number

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/16/2013
        /// 
        /// Constructor
        /// </summary>
        /// <param name="transaction">The new transaction details to display</param>
        public CheckOutForm(Dictionary<TransKey, string> transaction, TransactionList transItems)
        {
            InitializeComponent();

            this.transaction = transaction;
            this.transItems = transItems;

            //ccField.Width = 0;
            lblSwipe.Visible = false;
            setCheckoutInfo(transaction);
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/27/2013
        /// 
        /// Sets the summary information from the sales screen to be re-displayed in the checkout screen 
        /// </summary>
        /// <param name="transaction">the dictionary to get the summary infor from the sales form screen</param>
        private void setCheckoutInfo(Dictionary<TransKey, string> transaction)
        {
            try
            {
                summarySubTotal.Text = "$" + transaction[TransKey.TRANS_SUBTOTAL];
                summaryTax.Text = "$" + transaction[TransKey.TRANS_TAX];
                summaryTotal.Text = "$" + transaction[TransKey.TRANS_TOTAL];
            }

            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/16/2013
        /// 
        /// Confirms the checkout and inserts a new transaction record into the database
        /// </summary>
        private void btnConfirmCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (radChecked == 1)
                {
                    //Cash Checkout
                }

                else
                {
                    //Card Checkout
                    if (PAN == null)
                    {
                        MessageBox.Show("Please Scan Card");
                        return;
                    }
                }
                
                DialogResult result = MessageBox.Show("Confirm transaction?", "Transaction",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (result == DialogResult.Yes)
                {
                    Transaction newTransaction = new Transaction(transaction);

                    ReceiptGenerator receiptGenerator = new ReceiptGenerator(newTransaction.transactionDetails, transItems);

                    receiptGenerator.printReceiptToFile();
                    //receiptGenerator.printToPrinter();

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
        private void readCard(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                    String rawString = ccField.Text;
                    rawString = rawString.Replace(" ", "");

                    char[] delimiterChars = { '%', '^', '/', '?', ';', '=' };

                    string[] parsed = rawString.Split(delimiterChars);

                    if (parsed.Length != 9)
                    {
                        MessageBox.Show("Card Read Failed");
                        ccField.Text = "";
                        return;
                    }

                    PAN = parsed[1];
                    lName = parsed[2];
                    fName = parsed[3];
                    ccNum = parsed[6];
                    ccEnd = ccNum.Substring(ccNum.Length - 4);

                    MessageBox.Show("Card read success!");

                    ccField.Text = "";
                    return;
                }
        }

        //Runs when hidden textfield loses focus
        private void ccFocus(object sender, EventArgs e)
        {
            radCredit.Checked = false;
            lblSwipe.Visible = false;
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
                lblSwipe.Visible = false;
            }
        }

        private void radCredit_CheckedChanged(object sender, EventArgs e)
        {
            if (radCredit.Checked)
            {
                radChecked = 2;
                ccField.Focus();
                lblSwipe.Visible = true;
            }
        }
    }
}
