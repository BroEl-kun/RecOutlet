using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class TRANSACTION_LINE_ITEM
    {
        public int TransactionLineItemID { get; set; }
        public int TransactionID { get; set; }
        public byte StoreID { get; set; }
        public int RecID { get; set; }
        public short Quantity { get; set; }
        public decimal SaleEach { get; set; }
        public short CommissionEmployeeID { get; set; }
        public Nullable<int> OverrideCode { get; set; }
        public Nullable<int> RefundCode { get; set; }
        public virtual STORE_TRANSACTION STORE_TRANSACTION { get; set; }
    }
}
