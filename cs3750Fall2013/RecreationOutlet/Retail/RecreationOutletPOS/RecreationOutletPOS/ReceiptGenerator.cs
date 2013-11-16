using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Aliases for the Enum's inner classes
using TransKey = RecreationOutletPOS.Enum.TransKey;
using PaymentType = RecreationOutletPOS.Enum.PaymentType;

namespace RecreationOutletPOS
{
    /// <summary>
    /// Programmer: Michael Vuong
    /// Last Updated: 11/11/2013
    /// 
    /// Represents an object capable of generating a receipt for a given transaction
    /// </summary>
    class ReceiptGenerator
    {
        public Transaction transaction;
        public TransactionList transItems;

        public string Receipt;
        
        // Formatting variables
        public const string horizontal_line_double = "==================================\n";
        public const string horizontal_line_single = "----------------------------------\n";
        public const string signature_line = "__________________________________\n";

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/11/2013
        /// 
        /// Constructor
        /// </summary>
        /// <param name="transaction">Details about the current transaction</param>
        /// <param name="transItems">The items purchased for the current transaction</param>
        public ReceiptGenerator(Transaction transaction, TransactionList transItems)
        {
            this.transaction = transaction;
            this.transItems = transItems;

            Receipt = generateReceiptHeader();
            Receipt = generateReceiptBody(transaction.transactionDetails, Receipt);
            Receipt = generateReceiptFooter(Receipt);
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/11/2013
        /// 
        /// Prints the receipt to a textfile
        /// </summary>
        /// <param name="transaction">The current transaction details to display onto the receipt</param>
        /// <param name="transItems">The items of purchase on the current transaction</param>
        public void printReceiptToFile()
        {
            string mydocpath;

            try
            {
                mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                mydocpath += @"\ReceiptOutput.txt";

                using (StreamWriter outfile = new StreamWriter(mydocpath))
                {
                    outfile.Write(Receipt);
                }
            }

            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/11/2013
        /// 
        /// Prints the receipt to the Star TSP100 Cutter thermal receipt printer
        /// </summary>
        /// <param name="transaction">The current transaction details to display onto the receipt</param>
        /// <param name="transItems">The items of purchase on the current transaction</param>
        public void printToPrinter()
        {
            string printerName = "Star TSP100 Cutter (TSP143)";
            
            try
            {
                RawPrinterHelper.SendStringToPrinter(printerName, Receipt);
            }

            catch (Exception ex)
            {

            }
        }

        #region Receipt Creating Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/11/2013
        /// 
        /// Generates the header information for a receipt
        /// </summary>
        /// <returns>A receipt string containing the receipt header filled in</returns>
        private string generateReceiptHeader()
        {
            string receiptString = string.Empty;

            try
            {
                receiptString += "Recreation Outlet" + "\n";
                receiptString += "2324 Washington Blvd." + "\n";
                receiptString += "Ogden, UT 84401" + "\n";
                receiptString += "(801)-409-9994"  + "\n" + "\n";

                receiptString += "recreationoutlet.com" + "\n";

                receiptString += horizontal_line_double;
            }

            catch(Exception ex)
            {

            }

            return receiptString;
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/11/2013
        /// 
        /// Generates the body of the receipt containing information about the
        /// transaction (incuding items purchased)
        /// </summary>
        /// <returns>a receipt string with the body filled in</returns>
        private string generateReceiptBody(Dictionary<TransKey, string> transactionDetails, string receiptString)
        {
            try
            {
                receiptString += horizontal_line_single;

                // Adds each item in the transItem.transData list into the receipt 
                foreach (TransactionItem item in transItems.transData)
                {
                    receiptString = addItemToReceipt(receiptString, item);
                }

                // IF paymenttype == credit or debit, execute
                //if (transactionDetails[TransKey.PAYMENT_TYPE] == PaymentType.CREDIT.ToString() || transactionDetails["PaymentType"] == "Debit")
                //{
                //    receiptString = addCreditCardInfo(receiptString);
                //}

                receiptString += horizontal_line_single;

                receiptString += "Subtotal: " + "\x9\x9" + transactionDetails[TransKey.TRANS_SUBTOTAL] +"\n";
                receiptString += "Taxes: " + "\x9\x9" + transactionDetails[TransKey.TRANS_TAX] + "\n";
                receiptString += "Trans. Total: " + "\x9\x9" + transactionDetails[TransKey.TRANS_TOTAL] +"\n";
                
                //// IF paymenttype == cash, execute
                ////receiptString += addTenderedCurrency(receiptString);
                
                //// IF cashback EXISTS in dict
                ////receiptString += addCashBack(receiptString);

                receiptString += horizontal_line_single;

                receiptString = addCashier(receiptString);
                receiptString += "POS: " + "\x9\x9" + transactionDetails[TransKey.TERMINAL_ID] +"\n";
                receiptString += "Trans#: " + "\x9\x9" + transactionDetails[TransKey.TRANSACTION_ID] +"\n";
                receiptString += "Trans. Time: " + "\x9" + transactionDetails[TransKey.TRANS_DATE] + "\n";     
                
                receiptString += horizontal_line_single;

                ////Barcode - Pg. 3-39 - 3-40
                //receiptString += "\n" + "\x1b\x62\x6\x2\x2" + "0123456789" + "\x1e\n";             
                //receiptString += "Barcode: " + "0123456789\n\n";

                receiptString += "Refund within 7 Days of purchase \nwith receipt." +
                                 " Exchange/Credit \nwithin 30 days with receipt.\n\n";
            }

            catch (Exception ex)
            {
                
            }

            return receiptString;
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/11/2013
        /// 
        /// Generates the footer of the receipt
        /// </summary>
        /// <returns></returns>
        private string generateReceiptFooter(string receiptString)
        {
            try
            {
                receiptString += "\x1b\x1d\x61\x1";             //Center Alignment - Refer to Pg. 3-29

                // IF paymenttype = credit/debit, execute next 3 lines
                receiptString += "I agree to pay above total amount \n according to the card issuer agreement\n\n";

                receiptString += signature_line;
                receiptString += "signature\n\n";

                receiptString += "\x1b\x45";                    //Select Emphasized Printing - Pg. 3-14
                receiptString += "Thank You!\n";
                receiptString += "\x1b\x46";                    //Cancel Emphasized Printing - Pg. 3-14

                receiptString += "\x7";                         //Open Cash Drawer

                receiptString += "\x1b\x64\x02";                                            //Cut  - Pg. 3-41
            }

            catch (Exception ex)
            {

            }

            return receiptString;
        }

        #region Helper Generator Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/11/2013
        /// 
        /// ***INCOMPLETE***
        /// Determines if the cashier is either a sales associate or a manager
        /// </summary>
        /// <returns>The ID of the cashier</returns>
        private string addCashier(string receiptString)
        {
            string cashier = "Associate 1";

            try
            {
                receiptString += "Cashier: " + cashier + "\x9\x9" + "\n";

                /*
                 * IF (ManagerID != null)
                 *    THEN RETURN manager ID
                 * ELSE
                 *    RETURN employee ID
                */
            }

            catch (Exception ex)
            {

            }

            return receiptString;
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/11/2013
        /// 
        /// Adds credit card information to the receipt
        /// </summary>
        /// <param name="receiptString">The working receiptString to add the CC info to</param>
        /// <returns>The working receiptString with CC info added to it</returns>
        private string addCreditCardInfo(string receiptString)
        {
            try
            {
                receiptString += "\nCard Type:" + "\x9\x9" + "<CARD_TYPE>" + "\n";
                receiptString += "Credit Card: " + "\x9\x9" + "<CREDIT_CARD_NUM>" + "\n";
                receiptString += "Authorization Code: " + "\x9\x9" + "<AUTHORIZATION_CODE>" + "\n";
                //receiptString += "Credit Card Total: " + "\x9\x9" + transaction.transactionDetails[TransKey.CA] + "\n";
            }

            catch (Exception ex)
            {

            }

            return receiptString;
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/11/2013
        /// 
        /// Adds the tendered currency to the working receiptString
        /// </summary>
        /// <param name="receiptString">The working receiptString to add the tendered currency to</param>
        /// <returns>The working receiptString with the tendered currency added to it</returns>
        private string addTenderedCurrency(string receiptString)
        {
            try
            {
                receiptString += "Tender. Recieved: " + "\x9\x9" + "<tender recieved>\n";

                //CHANGE = Tendered - Total
                receiptString += "Change: " + "\x9\x9" + "$0.00\n";
            }

            catch (Exception ex)
            {

            }

            return receiptString;
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/11/2013
        /// 
        /// Adds a cashback value to the working receipt string
        /// </summary>
        /// <param name="receiptString">The working receipt string to add the cashback value to</param>
        /// <returns>The working receipt string with the cashback value added to it</returns>
        private string addCashBack(string receiptString)
        {
            try
            {
                receiptString += "Cash Back: " + "\x9\x9" + "$0.00\n";
            }

            catch (Exception ex)
            {

            }

            return receiptString;
        }

        #endregion

        #endregion

        #region Helper Methods
        
        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/11/2013
        /// 
        /// Adds a transaction item to the working receiptString
        /// </summary>
        /// <param name="receiptString">The working receipt string to dd the transaction item to</param>
        /// <param name="item">The item to add to the working receipt string</param>
        /// <returns>The working receipt string with the given transaction item</returns>
        private string addItemToReceipt(string receiptString, TransactionItem item)
        {
            try
            {
                receiptString += item.getQuantity().ToString() + "x\x9";
                receiptString += item.getName() + "\x9";  
                receiptString += "      " + item.getPrice() + "\n";
            }

            catch (Exception ex)
            {

            }

            return receiptString;
        }

        #endregion
    }
}
