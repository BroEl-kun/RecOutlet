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
using PaymentType = RecreationOutletPOS.Enum.PaymentType;

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

        private SalesForm parent;

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/20/2013
        /// 
        /// Constructor
        /// </summary>
        /// <param name="transaction">The new transaction details to display</param>
        public CheckOutForm(SalesForm parent, Dictionary<TransKey, string> transaction, TransactionList transItems)
        {
            InitializeComponent();

            this.transaction = transaction;
            this.transItems = transItems;

            ccField.Width = 0;

            txtCashTender.Visible = false;

            lblSwipe.Visible = false;
            lblTenderPrompt.Visible = false;

            setCheckoutInfo(transaction);

            this.parent = parent;
        }

        //Constructor for combined form -Aaron
        Combined combined;
        public CheckOutForm(Combined parent, Dictionary<TransKey, string> transaction, TransactionList transItems)
        {
            InitializeComponent();

            this.transaction = transaction;
            this.transItems = transItems;

            ccField.Width = 0;

            txtCashTender.Visible = false;

            lblSwipe.Visible = false;
            lblTenderPrompt.Visible = false;

            setCheckoutInfo(transaction);

            this.combined = parent;
        }
        //------------------------------------

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
        /// Last Updated: 11/20/2013
        /// 
        /// Confirms the checkout and inserts a new transaction record into the database
        /// </summary>
        private void btnConfirmCheckOut_Click(object sender, EventArgs e)
        {
            bool isValidTransaction = false;

            try
            {
                if (radChecked == 1)
                {
                    isValidTransaction = isValidTender();

                    // NOTE- Search for alternative method later, this is bad!
                    // These ifs are in the case an error is made in the cash tendering
                    if (transaction.ContainsKey(TransKey.PAYMENT_TYPE))
                    {
                        transaction.Remove(TransKey.PAYMENT_TYPE);
                    }

                    if (transaction.ContainsKey(TransKey.TENDERED))
                    {
                        transaction.Remove(TransKey.TENDERED);
                    }

                    transaction.Add(TransKey.PAYMENT_TYPE, PaymentType.CASH.ToString());
                    transaction.Add(TransKey.TENDERED, txtCashTender.Text);
                }

                else
                {
                    //Card Checkout
                    if (PAN == null)
                    {
                        MessageBox.Show("Please Scan Card");
                        return;
                    }

                    isValidTransaction = true;

                    // NOTE- Search for alternative method later, this is bad!
                    // These ifs are in the case an error is made in the cash tendering
                    if (transaction.ContainsKey(TransKey.PAYMENT_TYPE))
                    {
                        transaction.Remove(TransKey.PAYMENT_TYPE);
                    }

                    if (transaction.ContainsKey(TransKey.TENDERED))
                    {
                        transaction.Remove(TransKey.TENDERED);
                    }

                    if (transaction.ContainsKey(TransKey.CARD_NUMBER))
                    {
                        transaction.Remove(TransKey.CARD_NUMBER);
                    }

                    transaction.Add(TransKey.PAYMENT_TYPE, PaymentType.CREDIT.ToString());
                    transaction.Add(TransKey.TENDERED, transaction[TransKey.TRANS_TOTAL]);
                    transaction.Add(TransKey.CARD_NUMBER, ccEnd);
                }
                
                DialogResult result = MessageBox.Show("Confirm transaction?", "Transaction",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (result == DialogResult.Yes)
                {
                    if (isValidTransaction)
                    {
                        Transaction newTransaction = new Transaction(transaction);

                        ReceiptGenerator receiptGenerator = new ReceiptGenerator(newTransaction.transactionDetails, transItems);

                        receiptGenerator.printReceiptToFile();
                        //receiptGenerator.printToPrinter();

                        MessageBox.Show("Transaction complete.\n" + newTransaction.rowsInserted.ToString() + " transaction(s) recorded.", "Transaction",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        this.Close();
                        //parent.voidTransaction();
                        combined.voidTransaction();
                    }

                    else
                    {
                        MessageBox.Show("The entered cash tender is invalid or is less than the total", 
                                        "Item Void", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }

            catch (Exception ex)
            {
                string x = ex.Message;
            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/20/2013
        /// 
        /// Checks if the tender given for cash is valid
        /// </summary>
        /// <returns>Whether this transaction is valid or not</returns>
        private bool isValidTender()
        {
            bool validTender = false;

            double tenderInput = 0.0;
            double total = 0.0;

            Decimal cashTender;
            Decimal transTotal;
            Decimal difference; 

            try
            {
                Double.TryParse(txtCashTender.Text, out tenderInput);
                Double.TryParse(transaction[TransKey.TRANS_TOTAL], out total);

                cashTender = new Decimal(tenderInput);
                transTotal = new Decimal(total);

                difference = cashTender - transTotal;

                if (difference >= 0)
                {
                    validTender = true;
                }
            }

            catch (Exception ex)
            {

            }

            return validTender;
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

        /// <summary>
        /// Programmer: Aaron Sorensen
        /// Last Updated: 11/20/2013
        /// 
        /// Runs when hidden textfield loses focus
        /// </summary>
        private void ccFocus(object sender, EventArgs e)
        {
            radCredit.Checked = false;
            lblSwipe.Visible = false;
        }

        /// <summary>
        /// Programmer: Aaron Sorensen
        /// Last Updated: 11/20/2013 (By Michael Vuong)
        /// 
        /// Controls radio buttons
        /// </summary>
        private void radCash_CheckedChanged(object sender, EventArgs e)
        {
            if (radCash.Checked)
            {
                radChecked = 1;

                txtCashTender.Visible = true;
                txtCashTender.Focus();

                lblSwipe.Visible = false;
                lblTenderPrompt.Visible = true;
            }
        }

        /// <summary>
        /// Programmer: Aaron Sorensen
        /// Last Updated: 11/20/2013 (By Michael Vuong)
        /// 
        /// Controls the radio buttons
        /// </summary>
        private void radCredit_CheckedChanged(object sender, EventArgs e)
        {
            if (radCredit.Checked)
            {
                radChecked = 2;
                
                ccField.Focus();

                lblSwipe.Visible = true;
                lblTenderPrompt.Visible = false;

                txtCashTender.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCashTender_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
