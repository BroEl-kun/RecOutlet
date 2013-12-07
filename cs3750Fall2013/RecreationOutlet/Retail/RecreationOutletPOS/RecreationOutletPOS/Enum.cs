using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecreationOutletPOS
{
    /// <summary>
    /// Programmer: Michael Vuong
    /// Last Updated: 11/18/2013
    ///
    /// Contains various enum classes used throughout the program
    /// </summary>
    public class Enum
    {
        #region General Use Enums

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/18/2013
        /// 
        /// Represents the keys that are used in a transaction dictionary
        /// </summary>
        public sealed class TransKey
        {
            private readonly String transactionKey;

            public static readonly TransKey TRANS_TYPE = new TransKey("TransType");
            public static readonly TransKey TRANS_ID = new TransKey("TransactionID");
            public static readonly TransKey STORE_ID = new TransKey("StoreID");
            public static readonly TransKey EMPLOYEE_ID = new TransKey("EmployeeID");
            public static readonly TransKey TRANS_DATE = new TransKey("TransDate");
            public static readonly TransKey TERMINAL_ID = new TransKey("TerminalID");
            public static readonly TransKey MANAGER_ID = new TransKey("ManagerID");
            public static readonly TransKey PAYMENT_TYPE = new TransKey("PaymentType");
            public static readonly TransKey PREVIOUS_TRANS_ID = new TransKey("PreviousTransactionID");
            public static readonly TransKey CARD_NUMBER = new TransKey("Card Number");
            public static readonly TransKey TENDERED = new TransKey("Tendered");
            public static readonly TransKey CHANGE = new TransKey("Change");

            public static readonly TransKey TRANS_SUBTOTAL = new TransKey("TransSubtotal");
            public static readonly TransKey TRANS_TAX = new TransKey("TransTax");
            public static readonly TransKey TRANS_TOTAL = new TransKey("TransTotal");

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/14/2013
            /// 
            /// Constructor
            /// </summary>
            /// <param name="paymentType">the transaction key string to set</param>
            public TransKey(String transactionKey)
            {
                this.transactionKey = transactionKey;
            }

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/14/2013
            /// 
            /// Overridden to return the string class property
            /// </summary>
            /// <returns>The string value for the enum object calling this</returns>
            public override String ToString()
            {
                return transactionKey;
            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/14/2013
        /// 
        /// Used in conjunction with the TransactionKey enum class for it's PAYMENT_TYPE enum
        /// </summary>
        public sealed class PaymentType
        {
            private readonly String paymentType;

            public static readonly PaymentType CASH = new PaymentType("Cash");
            public static readonly PaymentType CREDIT = new PaymentType("Credit");
            public static readonly PaymentType DEBIT = new PaymentType("Debit");

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/14/2013
            /// 
            /// Constructor
            /// </summary>
            /// <param name="paymentType"></param>
            public PaymentType(String paymentType)
            {
                this.paymentType = paymentType;
            }

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/14/2013
            /// 
            /// Overridden to return the string class property
            /// </summary>
            /// <returns>The string value for the enum object calling this</returns>
            public override String ToString()
            {
                return paymentType;
            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 12/7/2013
        /// 
        /// 
        /// </summary>
        public sealed class ReportType
        {
            private readonly String reportType;

            public static readonly ReportType TRANSACTIONS = new ReportType("Transactions Report");
            public static readonly ReportType COMMISSIONS = new ReportType("Commissions Report");

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 12/7/2013
            /// 
            /// ReportTypeonstructor
            /// </summary>
            /// <param name="reportType"></param>
            public ReportType(String reportType)
            {
                this.reportType = reportType;
            }

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 12/7/2013
            /// 
            /// Overridden to return the string class property
            /// </summary>
            /// <returns>The string value for the enum object calling this</returns>
            public override String ToString()
            {
                return reportType;
            }
        }

        #endregion

        #region ListView Enums

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/21/2013
        /// 
        /// Represents the ListView columns NAMES used in the POS
        /// </summary>
        public sealed class ListViewColumn
        {
            private readonly String columnName;

            public static readonly ListViewColumn ITEM_ID = new ListViewColumn("ItemID");

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/20/2013
            /// 
            /// Constructor
            /// </summary>
            /// <param name="columnName"></param>
            public ListViewColumn(String columnName)
            {
                this.columnName = columnName;
            }

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/21/2013
            /// 
            /// Overridden to return the string class property
            /// </summary>
            /// <returns>The string value for the enum object calling this</returns>
            public override String ToString()
            {
                return columnName;
            }
        }

        #endregion

        #region Database Table Enums

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/21/2013
        /// 
        /// Represents the different result set names to store SQL Query results 
        /// FORMAT: TABLENAME_ResultSet
        /// </summary>
        public sealed class SqlResultSet
        {
            private readonly String resultSet;

            public static readonly SqlResultSet ITEM_RESULTSET = new SqlResultSet("ITEM_ResultSet");

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/14/2013
            /// 
            /// Constructor
            /// </summary>
            /// <param name="resultSet"></param>
            public SqlResultSet(String resultSet)
            {
                this.resultSet = resultSet;
            }

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/14/2013
            /// 
            /// Overridden to return the string class property
            /// </summary>
            /// <returns>The string value for the enum object calling this</returns>
            public override String ToString()
            {
                return resultSet;
            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/21/2013
        /// 
        /// Represents the the ITEM table's and contains enums for each column
        /// </summary>
        public sealed class ItemTableColumn
        {
            private readonly String tableColumnName;

            public static readonly ItemTableColumn REC_RPC = new ItemTableColumn("RecRPC");
            public static readonly ItemTableColumn ITEM_UPC = new ItemTableColumn("ItemUPC");
            public static readonly ItemTableColumn NAME = new ItemTableColumn("Name");
            public static readonly ItemTableColumn DESCRIPTION = new ItemTableColumn("Description");
            public static readonly ItemTableColumn SELL_PRICE = new ItemTableColumn("SellPrice");
            public static readonly ItemTableColumn DEPARTMENT_ID = new ItemTableColumn("DepartmentID");
            public static readonly ItemTableColumn CATEGORY_ID = new ItemTableColumn("CategoryID");
            public static readonly ItemTableColumn TAX_RATE_ID = new ItemTableColumn("TaxRateID");
            public static readonly ItemTableColumn PRODUCT_LINE_ID = new ItemTableColumn("ProductLineID");
            public static readonly ItemTableColumn SEASON_CODE = new ItemTableColumn("SeasonCode");
            public static readonly ItemTableColumn RESTRICTED_AGE = new ItemTableColumn("RestrictedAge");
            public static readonly ItemTableColumn ITEM_CREATED_BY = new ItemTableColumn("ItemCreatedBy");
            public static readonly ItemTableColumn ITEM_CREATED_DATE = new ItemTableColumn("ItemCreatedDate");
            public static readonly ItemTableColumn LEGACY_ID = new ItemTableColumn("LegacyID");
            public static readonly ItemTableColumn MSRP = new ItemTableColumn("MSRP");

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/14/2013
            /// 
            /// Constructor
            /// </summary>
            /// <param name="tableColumnName">The ITEM column name</param>
            public ItemTableColumn(String tableColumnName)
            {
                this.tableColumnName = tableColumnName;
            }

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/21/2013
            /// 
            /// Creats a list of Item table columns enums in the form of a List
            /// </summary>
            /// <returns>the Item table columns enums in the form of a List</returns>
            public static List<ItemTableColumn> getItemTableColumns()
            {
                List<ItemTableColumn> itemTableColumns = new List<ItemTableColumn>();
                
                try
                {
                    itemTableColumns.Add(ItemTableColumn.REC_RPC);
                    itemTableColumns.Add(ItemTableColumn.ITEM_UPC);
                    itemTableColumns.Add(ItemTableColumn.NAME);
                    itemTableColumns.Add(ItemTableColumn.DESCRIPTION);
                    itemTableColumns.Add(ItemTableColumn.SELL_PRICE);
                    itemTableColumns.Add(ItemTableColumn.DEPARTMENT_ID);
                    itemTableColumns.Add(ItemTableColumn.CATEGORY_ID);
                    itemTableColumns.Add(ItemTableColumn.TAX_RATE_ID);
                    itemTableColumns.Add(ItemTableColumn.PRODUCT_LINE_ID);
                    itemTableColumns.Add(ItemTableColumn.SEASON_CODE);
                    itemTableColumns.Add(ItemTableColumn.RESTRICTED_AGE);
                    itemTableColumns.Add(ItemTableColumn.ITEM_CREATED_BY);
                    itemTableColumns.Add(ItemTableColumn.ITEM_CREATED_DATE);
                    itemTableColumns.Add(ItemTableColumn.LEGACY_ID);
                    itemTableColumns.Add(ItemTableColumn.MSRP);
                }

                catch (Exception ex)
                {
                   
                }

                return itemTableColumns;
            }

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/14/2013
            /// 
            /// Overridden to return the string class property
            /// </summary>
            /// <returns>The string value for the enum object calling this</returns>
            public override String ToString()
            {
                return tableColumnName;
            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 12/4/2013
        /// 
        /// Represents the different departments to categorize items in the database
        /// </summary>
        public sealed class Department
        {
            private readonly String department;

            private static readonly Department CLIMBING = new Department("Climbing");
            private static readonly Department WINTER_CLOTHING = new Department("Winter Clothing");
            private static readonly Department FOOTWEAR = new Department("Footwear");
            private static readonly Department PACKS = new Department("Packs");
            private static readonly Department EMERGENCY = new Department("Emergency");
            private static readonly Department SNOW_HARDGOODS = new Department("Snow Hardgoods");
            private static readonly Department MENS_OUTERWEAR = new Department("Men's Outerwear");
            private static readonly Department STOVES = new Department("Stoves");
            private static readonly Department WATER_SPORTS = new Department("Water Sports");
            private static readonly Department FURNITURE = new Department("Furniture");
            private static readonly Department OUTDOOR_SPORTS = new Department("Outdoor Sports");
            private static readonly Department IMPULSE_MERCHANDISE = new Department("Impulse Merchandise");
            private static readonly Department FOOD = new Department("Food");

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 12/4/2013
            /// 
            /// Constructor
            /// </summary>
            /// <param name="department"></param>
            public Department(String department)
            {
                this.department = department;
            }

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 12/4/2013
            /// 
            /// Overridden to return the string class property
            /// </summary>
            /// <returns>The string value for the enum object calling this</returns>
            public override String ToString()
            {
                return department;
            }
        }

        #endregion

        #region Receipt/Receipt Printer Enums

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/14/2013
        /// 
        /// Represents the various GUI components that will be used to format a receipt
        /// </summary>
        public sealed class ReceiptFormat
        {
            private readonly String receiptFormat;

            public static readonly ReceiptFormat PRINTER_NAME = new ReceiptFormat("Star TSP100 Cutter (TSP143)");

            public static readonly ReceiptFormat DASHED_HORIZ_LINE = new ReceiptFormat("------------------------------------------------\n");
            public static readonly ReceiptFormat SIGNATURE_LINE = new ReceiptFormat("x_______________________________________\n");


            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/14/2013
            /// 
            /// Constructor
            /// </summary>
            /// <param name="receiptGUI">the gui component to display on the receipt</param>
            public ReceiptFormat(String receiptGUI)
            {
                this.receiptFormat = receiptGUI;
            }

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/14/2013
            /// 
            /// Overridden to return the string class property
            /// </summary>
            /// <returns>The string value for the enum object calling this</returns>
            public override String ToString()
            {
                return receiptFormat;
            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/14/2013
        /// 
        /// Represents the various codes the receipt printer recognizes
        /// </summary>
        public sealed class PrinterCode
        {
            private readonly String printerCode;

            public static readonly PrinterCode CENTER_ALIGN = new PrinterCode("\x1b\x1d\x61\x1");
            public static readonly PrinterCode LEFT_ALIGN = new PrinterCode("\x1b\x1d\x61\x0");
            public static readonly PrinterCode HORIZ_TAB = new PrinterCode("\x1b\x44\x2\x10\x22\x0");

            public static readonly PrinterCode TEXT_EMPHASIZE_BEGIN = new PrinterCode("\x1b\x45");
            public static readonly PrinterCode TEXT_EMPHASIZE_END = new PrinterCode("\x1b\x46");

            public static readonly PrinterCode BARCODE_BEGIN = new PrinterCode("\x1b\x62\x6\x2\x2");
            public static readonly PrinterCode BARCODE_END = new PrinterCode("\x1e");

            public static readonly PrinterCode CUT_RECEIPT = new PrinterCode("\x1b\x64\x02");
            public static readonly PrinterCode OPEN_DRAWER = new PrinterCode("\x7");

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/14/2013
            /// 
            /// Constructor
            /// </summary>
            /// <param name="printerCode"></param>
            public PrinterCode(String printerCode)
            {
                this.printerCode = printerCode;
            }

            /// <summary>
            /// Programmer: Michael Vuong
            /// Last Updated: 11/14/2013
            /// 
            /// Overridden to return the string class property
            /// </summary>
            /// <returns>The string value for the enum object calling this</returns>
            public override String ToString()
            {
                return printerCode;
            }
        }

        #endregion
    }
}
