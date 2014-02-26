using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class EXCEPTION
    {
        public int ExceptionsID { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public int TransactionLineItemID { get; set; }
        public int PreviousTransactionLineItemID { get; set; }
        public Nullable<byte> OverrideCode { get; set; }
        public Nullable<byte> RefundCode { get; set; }
        public virtual OVERRIDE_CODE OVERRIDE_CODE { get; set; }
        public virtual REFUND_CODE REFUND_CODE { get; set; }
        public virtual TRANSACTION_LINEITEM TRANSACTION_LINEITEM { get; set; }
    }
}
