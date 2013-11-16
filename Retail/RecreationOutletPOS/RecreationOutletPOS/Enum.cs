using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecreationOutletPOS
{
    /// <summary>
    /// Programmer: Michael Vuong
    /// Last Updated: 11/14/2013
    ///
    /// Contains various enum classes used throughout the program
    /// </summary>
    public class Enum
    {
        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/14/2013
        /// 
        /// Represents the keys that are used in a transaction dictionary
        /// </summary>
        public sealed class TransKey
        {
            private readonly String transactionKey;

            public static readonly TransKey TRANSACTION_ID = new TransKey("TransactionID");
            public static readonly TransKey STORE_ID = new TransKey("StoreID");
            public static readonly TransKey EMPLOYEE_ID = new TransKey("EmployeeID");
            public static readonly TransKey TRANS_DATE = new TransKey("TransDate");
            public static readonly TransKey TERMINAL_ID = new TransKey("TerminalID");
            public static readonly TransKey MANAGER_ID = new TransKey("ManagerID");
            public static readonly TransKey PAYMENT_TYPE = new TransKey("PaymentType");
            public static readonly TransKey PREVIOUS_TRANS_ID = new TransKey("PreviousTransactionID");
            
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
        /// Last Updated: 11/16/2013
        /// 
        /// Represents the the ITEM table's and contains enums for each column
        /// </summary>
        public sealed class ItemTableColumn
        {
            private readonly String tableColumnName;

            public static readonly ItemTableColumn REC_RPC = new ItemTableColumn("RecRPC");
            public static readonly ItemTableColumn ITEM_UPC = new ItemTableColumn("ItemUPC");
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
            /// <param name="tableColumnName"></param>
            public ItemTableColumn(String tableColumnName)
            {
                this.tableColumnName = tableColumnName;
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


    }
}
