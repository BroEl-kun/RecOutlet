using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Aliases for the Enum's inner classes
using TransKey = RecreationOutletPOS.Enum.TransKey;
using PaymentType = RecreationOutletPOS.Enum.PaymentType;
using ReceiptFormat = RecreationOutletPOS.Enum.ReceiptFormat;
using PrinterCode = RecreationOutletPOS.Enum.PrinterCode;

namespace RecreationOutletPOS
{
    /// <summary>
    /// Programmer: Michael Vuong
    /// Last Updated: 11/17/2013
    /// 
    /// Represents an object capable of generating a receipt for a given transaction
    /// </summary>
    public class ReceiptGenerator
    {
        public Dictionary<TransKey, string> transDetails;
        public List<TransactionItem> transItems;
        public StringBuilder receiptBuilder;

        // The receipt paper will roughly fit about 50 characters per line  
        public const int RECEIPT_PAPER_LENGTH = 50;

        public string receipt;
        public int numberOfItemsSold = 0;

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/17/2013
        /// 
        /// Constructor
        /// </summary>
        /// <param name="transaction">Details about the current transaction</param>
        /// <param name="transItems">The items purchased for the current transaction</param>
        public ReceiptGenerator(Dictionary<TransKey, string> transDetails, TransactionList transItems)
        {
            this.transDetails = transDetails;
            this.transItems = transItems.transData;

            receiptBuilder = new StringBuilder();

            receiptBuilder = generateReceiptHeader();
            receiptBuilder = generateReceiptBody();
            //receipt = generateReceiptFooter(receipt);

            //receipt = generateSampleReceipt();

            receipt = receiptBuilder.ToString();
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
                    outfile.Write(receipt);
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
                RawPrinterHelper.SendStringToPrinter(printerName, receipt);
            }

            catch (Exception ex)
            {

            }
        }

        #region Receipt Creating Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/17/2013
        /// 
        /// Generates the header information for a receipt which contains Rec Outlet's
        /// basic contact/address/website information
        /// </summary>
        /// <returns>A receipt string containing the receipt header filled in</returns>
        private StringBuilder generateReceiptHeader()
        {
            try
            {
                receiptBuilder.Append(PrinterCode.CENTER_ALIGN.ToString());

                receiptBuilder.Append("Recreation Outlet \n");
                receiptBuilder.Append("2324 Washington Blvd. \n");
                receiptBuilder.Append("Ogden, UT 84401 \n");
                receiptBuilder.Append("(801)-409-9994 \n");
                receiptBuilder.Append("recreationoutlet.com \n\n");
            }

            catch (Exception ex)
            {

            }

            return receiptBuilder;
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/11/2013
        /// 
        /// Generates the body of the receipt containing information about the
        /// transaction (incuding items purchased)
        /// </summary>
        /// <returns>a receipt string with the body filled in</returns>
        private StringBuilder generateReceiptBody()
        {
            try
            {
                receiptBuilder.Append(ReceiptFormat.DASHED_HORIZ_LINE.ToString());
                receiptBuilder.Append(PrinterCode.LEFT_ALIGN.ToString()).Append("\n");

                receiptBuilder = addItemsToReceipt(receiptBuilder);

                receiptBuilder = addTransSummary(receiptBuilder);

                //// IF paymenttype == cash, execute
                ////receiptString += addTenderedCurrency(receiptString);

                //// IF cashback EXISTS in dict
                ////receiptString += addCashBack(receiptString);

                //receiptBuilder = addCashier(receiptBuilder);
                //receiptString += "POS: " + "\x9\x9" + transactionDetails[TransKey.TERMINAL_ID] +"\n";
                //receiptString += "Trans#: " + "\x9\x9" + transactionDetails[TransKey.TRANSACTION_ID] +"\n";
                //receiptString += "Trans. Time: " + "\x9" + transactionDetails[TransKey.TRANS_DATE] + "\n";     

                ////Barcode - Pg. 3-39 - 3-40
                //receiptString += "\n" + "\x1b\x62\x6\x2\x2" + "0123456789" + "\x1e\n";             
                //receiptString += "Barcode: " + "0123456789\n\n";

                //receiptString += "Refund within 7 Days of purchase \nwith receipt." + " Exchange/Credit \nwithin 30 days with receipt.\n\n";
            }

            catch (Exception ex)
            {

            }

            return receiptBuilder;
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

                receiptString += ReceiptFormat.SIGNATURE_LINE;
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

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/16/2013
        /// 
        /// Sample receipt taken from sample code from: 
        /// http://www.starmicronics.com/support/SDKDocumentation.aspx
        /// </summary>
        /// <returns></returns>
        private string generateSampleReceipt()
        {
            string buffer = "\x1b\x1d\x61\x1";             //Center Alignment - Refer to Pg. 3-29

            buffer = buffer + "\x5B" + "If loaded.. Logo1 goes here" + "\x5D\n";
            buffer = buffer + "\x1B\x1C\x70\x1\x0";          //Stored Logo Printing - Refer to Pg. 3-38
            buffer = buffer + "Star Clothing Boutique\n";
            buffer = buffer + "1150 King Georges Post Rd.\n";
            buffer = buffer + "Edison, NJ 08837\n\n";
            buffer = buffer + "\x1b\x1d\x61\x0";             //Left Alignment - Refer to Pg. 3-29
            buffer = buffer + "\x1b\x44\x2\x10\x22\x0";      //Setting Horizontal Tab - Pg. 3-27
            buffer = buffer + "Date: 12/31/2008 " + "\x9" + " Time: 9:10 PM";      //Moving Horizontal Tab - Pg. 3-26
            buffer = buffer + "\n------------------------------------------------ \n";
            buffer = buffer + "\x1b\x45";                    //Select Emphasized Printing - Pg. 3-14
            buffer = buffer + "SALE\n";
            buffer = buffer + "\x1b\x46";                    //Cancel Emphasized Printing - Pg. 3-14
            buffer = buffer + "300678566 " + "\x9" + "  PLAN T-SHIRT" + "\x9" + "         10.99\n";
            buffer = buffer + "300692003 " + "\x9" + "  BLACK DENIM" + "\x9" + "         29.99\n";
            buffer = buffer + "300651148 " + "\x9" + "  BLUE DENIM" + "\x9" + "         29.99\n";
            buffer = buffer + "300642980 " + "\x9" + "  STRIPE DRESS" + "\x9" + "         49.99\n";
            buffer = buffer + "300638471 " + "\x9" + "  BLACK BOOT" + "\x9" + "         35.99\n\n";
            buffer = buffer + "Subtotal " + "\x9" + "" + "\x9" + "        156.95";
            buffer = buffer + "Tax " + "\x9" + "" + "\x9" + "" + "         00.00";
            buffer = buffer + "\n------------------------------------------------ \n";
            buffer = buffer + "Total" + "\x6" + "" + "\x9" + "\x1b\x69\x1\x1" + "         $156.95\n";    //Character Expansion - Pg. 3-10
            buffer = buffer + "\x1b\x69\x0\x0";                                                          //Cancel Expansion - Pg. 3-10
            buffer = buffer + "\n------------------------------------------------ \n";
            buffer = buffer + "Charge\n" + "$159.95\n";
            buffer = buffer + "Visa XXXX-XXXX-XXXX-0123\n\n";
            buffer = buffer + "\x1b\x34" + "Refunds and Exchanges" + "\x1b\x35\n";                       //Specify/Cencel White/Black Invert - Pg. 3-16
            buffer = buffer + "Within " + "\x1b\x2d\x1" + "30 days" + "\x1b\x2d\x0" + " with receipt\n"; //Specify/Cancel Underline Printing - Pg. 3-15
            buffer = buffer + "And tags attached\n\n";
            buffer = buffer + "\x1b\x1d\x61\x1";             //Center Alignment - Refer to Pg. 3-29
            buffer = buffer + "\x1b\x62\x6\x2\x2" + " 12ab34cd56" + "\x1e\n";             //Barcode - Pg. 3-39 - 3-40
            buffer = buffer + "\x1b\x64\x02";                                            //Cut  - Pg. 3-41
            buffer = buffer + "\x7";                                                    //Open Cash Drawer

            return buffer;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/18/2013
        /// 
        /// Formats a line on the working receipt to conform to a specific
        /// total length
        /// </summary>
        /// <param name="workingLine">The working line to format, this is also the beginning part of the line</param>
        /// <param name="endItem">The item to append to the end of the working line</param>
        /// <returns>A formatted line, with the working line having the endItem appended to it</returns>
        private string formatLine(string workingLine, string endItem, int desiredLength)
        {
            int spacesToPad = 0;
            int endItemLength = 0;

            try
            {
                spacesToPad = desiredLength;

                // Get the end item length, so we know how many spaces to subtract from the
                // number of spaces we need to append to the working line
                endItemLength = endItem.Length;

                spacesToPad -= endItemLength;

                workingLine = workingLine.PadRight(spacesToPad, ' ');

                // The working line, now with the end item appended length should 
                // now be that of RECEIPT_PAPER_LENGTH
                workingLine += endItem;
            }

            catch (Exception ex)
            {

            }

            return workingLine;
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/17/2013
        /// 
        /// Adds a transaction item to the working receiptString
        /// </summary>
        /// <param name="receiptString">The working receipt string to add the transaction item to</param>
        /// <param name="item">The item to add to the working receipt string</param>
        /// <returns>The working receipt string with the given transaction item</returns>
        private StringBuilder addItemsToReceipt(StringBuilder receiptBuilder)
        {
            string receiptItem = string.Empty;
            string itemPrice = string.Empty;

            try
            {
                // Adds each item in the list into the receipt 
                foreach (TransactionItem item in transItems)
                {
                    receiptItem = item.getQuantity() + "  " + item.getName();

                    itemPrice = item.getPrice().ToString() + "\n";

                    receiptItem = formatLine(receiptItem, itemPrice, RECEIPT_PAPER_LENGTH);

                    receiptBuilder.Append(receiptItem);
                }
            }

            catch (Exception ex)
            {

            }

            return receiptBuilder;
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/17/2013
        /// 
        /// Adds the transaction summary to the receipt (subtotal, tax, total)
        /// </summary>
        /// <param name="receiptBuilder">The working receipt string to add the transaction summary to</param>
        /// <returns>The working receipt string with the transaction summary added to it</returns>
        private StringBuilder addTransSummary(StringBuilder receiptBuilder)
        {
            string transSummary = string.Empty;
            string offset = string.Empty;

            string subtotal = "Subtotal:";
            string tax = "Tax:";
            string total = "Total:";

            int subtotalLength = 0;

            try
            {
                // Add a spacing offset for the trans summary to right align the summary text
                offset = ReceiptFormat.TRANS_SUMMARY_OFFSET.ToString();

                subtotal = offset + subtotal;

                subtotalLength = subtotal.Length;

                tax = formatLine(offset, tax, subtotalLength);
                total = formatLine(offset, total, subtotalLength);

                transSummary += formatLine(subtotal, transDetails[TransKey.TRANS_SUBTOTAL] + "\n", RECEIPT_PAPER_LENGTH);
                transSummary += formatLine(tax, transDetails[TransKey.TRANS_TAX] + "\n", RECEIPT_PAPER_LENGTH);
                transSummary += formatLine(total, transDetails[TransKey.TRANS_TOTAL] + "\n", RECEIPT_PAPER_LENGTH);

                receiptBuilder.Append("\n");
                receiptBuilder.Append(transSummary);
            }

            catch (Exception)
            {

            }

            return receiptBuilder;
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/17/2013
        /// 
        /// Determines if the cashier is either a sales associate or a manager
        /// </summary>
        /// <returns>The ID of the cashier</returns>
        private StringBuilder addCashier(StringBuilder receiptBuilder)
        {
            string cashier = "Cashier: ";

            try
            {
                if (transDetails[TransKey.MANAGER_ID] != null)
                {
                    cashier += transDetails[TransKey.MANAGER_ID];
                }

                else
                {
                    cashier += transDetails[TransKey.EMPLOYEE_ID];
                }

                receiptBuilder.Append(cashier).Append("\n");
            }

            catch (Exception ex)
            {

            }

            return receiptBuilder;
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/17/2013
        /// 
        /// Adds credit card information to the receipt
        /// </summary>
        /// <param name="receiptString">The working receiptString to add the CC info to</param>
        /// <returns>The working receiptString with CC info added to it</returns>
        private StringBuilder addCreditCardInfo(StringBuilder receiptBuilder)
        {
            string creditCardInfo = string.Empty;
            bool cardPaymentUsed = false;

            try
            {
                cardPaymentUsed = (transDetails.ContainsKey(TransKey.CARD_NUMBER));

                if (cardPaymentUsed)
                {
                    //creditCardInfo += "Card Type: <CARD_TYPE> \n";
                    creditCardInfo += "Card: " + transDetails[TransKey.CARD_NUMBER] + "\n";
                    //creditCardInfo += "Authorization Code: <AUTHORIZATION_CODE> \n";
                    creditCardInfo += "Card Tender: " + transDetails[TransKey.TENDERED];
                }
            }

            catch (Exception ex)
            {

            }

            return receiptBuilder;
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
    }
}
