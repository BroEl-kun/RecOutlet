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
    /// Last Updated: 11/20/2013
    /// 
    /// Represents an object capable of generating a receipt for a given transaction
    /// </summary>
    public class ReceiptGenerator
    {
        public Dictionary<TransKey, string> transDetails;
        public List<TransactionItem> transItems;
        public StringBuilder receiptBuilder;

        // The receipt paper will roughly fit about 49 characters per line  
        public const int RECEIPT_PAPER_LENGTH = 49;

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
            receiptBuilder = generateReceiptFooter();

            receipt = receiptBuilder.ToString();
        }

        #region Receipt Creating Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/20/2013
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
        /// Last Updated: 11/20/2013
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

                receiptBuilder = addCreditCardInfo(receiptBuilder);
                receiptBuilder = addTransSummary(receiptBuilder);
                receiptBuilder = addTenderedCurrency(receiptBuilder);
                receiptBuilder = addTransRecordInfo(receiptBuilder);

                ////Barcode - Pg. 3-39 - 3-40
                //receiptString += "\n" + "\x1b\x62\x6\x2\x2" + "0123456789" + "\x1e\n";             
                //receiptString += "Barcode: " + "0123456789\n\n";
            }

            catch (Exception ex)
            {

            }

            return receiptBuilder;
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/20/2013
        /// 
        /// Generates the footer of the receipt
        /// </summary>
        /// <returns></returns>
        private StringBuilder generateReceiptFooter()
        {
            string itemsSold = "Item(s) sold: ";

            string refundExchange = "\nRefund within 7 Days of purchase with receipt.\n" +
                                    "Exchange/Credit within 30 days \nwith receipt.\n\n";


            try
            {
                receiptBuilder.Append(PrinterCode.CENTER_ALIGN.ToString());
                receiptBuilder.Append("\n");

                receiptBuilder = addCreditCardInfo(receiptBuilder);

                itemsSold = formatLine(itemsSold, transItems.Count.ToString(), RECEIPT_PAPER_LENGTH);

                receiptBuilder.Append(itemsSold).Append("\n");

                receiptBuilder.Append(refundExchange);

                receiptBuilder.Append(PrinterCode.TEXT_EMPHASIZE_BEGIN.ToString());
                receiptBuilder.Append("Thank You!");
                receiptBuilder.Append(PrinterCode.TEXT_EMPHASIZE_END.ToString());

                receiptBuilder.Append(PrinterCode.OPEN_DRAWER.ToString());

                receiptBuilder.Append(PrinterCode.CUT_RECEIPT.ToString());
            }

            catch (Exception ex)
            {

            }

            return receiptBuilder;
        }

        #endregion

        #region Receipt Helper Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/20/2013
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

                    itemPrice = item.getPrice().ToString();

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
        /// Last Updated: 11/20/2013
        /// 
        /// Adds the transaction summary to the receipt (subtotal, tax, total)
        /// </summary>
        /// <param name="receiptBuilder">The working receipt string to add the transaction summary to</param>
        /// <returns>The working receipt string with the transaction summary added to it</returns>
        private StringBuilder addTransSummary(StringBuilder receiptBuilder)
        {
            string transSummary = string.Empty;

            string subtotal = "Subtotal:";
            string tax = "Tax:";
            string total = "Total:";

            try
            {
                transSummary += formatLine(subtotal, transDetails[TransKey.TRANS_SUBTOTAL], RECEIPT_PAPER_LENGTH);
                transSummary += formatLine(tax, transDetails[TransKey.TRANS_TAX], RECEIPT_PAPER_LENGTH);
                transSummary += formatLine(total, transDetails[TransKey.TRANS_TOTAL], RECEIPT_PAPER_LENGTH);

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
        /// Last Updated: 11/20/2013
        /// 
        /// Adds the transaction record information that includes: date of purchase,
        /// time of purchase, and the transaction number
        /// </summary>
        /// <param name="receiptBuilder">The working receipt string to add the transaction summary to</param>
        /// <returns>The working receipt string with the transaction record info added to it</returns>
        private StringBuilder addTransRecordInfo(StringBuilder receiptBuilder)
        {
            string transRecords = string.Empty;
            string cashierID = string.Empty;

            string store = "Store: ";
            string cashier = "Cashier: ";
            string register = "Register: ";
            string datetime = "Date: ";
            string transID = "Trans #: ";

            try
            {
                if (transDetails[TransKey.MANAGER_ID] != null)
                {
                    cashierID = transDetails[TransKey.MANAGER_ID];
                }

                else
                {
                    cashierID = transDetails[TransKey.EMPLOYEE_ID];
                }
                
                store = formatLine(store, transDetails[TransKey.STORE_ID], RECEIPT_PAPER_LENGTH);
                register = formatLine(register, transDetails[TransKey.TERMINAL_ID], RECEIPT_PAPER_LENGTH);
                cashier = formatLine(cashier, cashierID, RECEIPT_PAPER_LENGTH);
                datetime = formatLine(datetime, transDetails[TransKey.TRANS_DATE], RECEIPT_PAPER_LENGTH);
                transID = formatLine(transID, transDetails[TransKey.TRANS_ID], RECEIPT_PAPER_LENGTH);

                receiptBuilder.Append("\n");

                receiptBuilder.Append(store);
                receiptBuilder.Append(register);
                receiptBuilder.Append(cashier);
                receiptBuilder.Append(datetime);
                receiptBuilder.Append(transID);
            }

            catch (Exception ex)
            {

            }

            return receiptBuilder;
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/20/2013
        /// 
        /// Adds credit card information to the receipt
        /// </summary>
        /// <param name="receiptString">The working receiptString to add the CC info to</param>
        /// <returns>The working receiptString with CC info added to it</returns>
        private StringBuilder addCreditCardInfo(StringBuilder receiptBuilder)
        {
            string creditCardInfo = string.Empty;

            string card = "Card: ";
            string cardTender = "Card Tender: ";

            bool isCardPayment = false;

            try
            {
                isCardPayment = (transDetails[TransKey.PAYMENT_TYPE] == PaymentType.CREDIT.ToString() &&
                                   transDetails.ContainsKey(TransKey.CARD_NUMBER));

                if (isCardPayment)
                {
                    receiptBuilder.Append("\n");

                    card = formatLine(card, transDetails[TransKey.CARD_NUMBER], RECEIPT_PAPER_LENGTH);
                    cardTender = formatLine(cardTender, transDetails[TransKey.TENDERED], RECEIPT_PAPER_LENGTH);

                    receiptBuilder.Append(card);
                    receiptBuilder.Append(cardTender);
                }
            }

            catch (Exception ex)
            {

            }

            return receiptBuilder;
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/20/2013
        /// 
        /// Adds the tendered currency to the working receiptString
        /// </summary>
        /// <param name="receiptString">The working receiptString to add the tendered currency to</param>
        /// <returns>The working receiptString with the tendered currency added to it</returns>
        private StringBuilder addTenderedCurrency(StringBuilder receiptBuilder)
        {
            string tendered = "Tendered: ";
            string change = "Change: ";

            double tender = 0.0;
            double transTotal = 0.0;

            bool isCashTransaction = false;

            Decimal tenderReceived;
            Decimal calculatedChange;
            Decimal total;

            try
            {
                isCashTransaction = (transDetails[TransKey.PAYMENT_TYPE] == PaymentType.CASH.ToString());

                if (isCashTransaction)
                {

                    receiptBuilder.Append("\n");

                    Double.TryParse(transDetails[TransKey.TENDERED], out tender);
                    Double.TryParse(transDetails[TransKey.TRANS_TOTAL], out transTotal);

                    tenderReceived = new Decimal(tender);
                    total = new Decimal(transTotal);

                    tendered = formatLine(tendered, transDetails[TransKey.TENDERED], RECEIPT_PAPER_LENGTH);
                    receiptBuilder.Append(tendered);

                    calculatedChange = tenderReceived - total;

                    change = formatLine(change, calculatedChange.ToString(), RECEIPT_PAPER_LENGTH);

                    receiptBuilder.Append(change);
                }
            }

            catch (Exception ex)
            {

            }

            return receiptBuilder;
        }

        #endregion

        #region Receipt Printing Methods

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

        #endregion

        #region Helper Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/20/2013
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
                workingLine += endItem + "\n";
            }

            catch (Exception ex)
            {

            }

            return workingLine;
        }

        #endregion
    }
}
