using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class TRANSACTION_LINEITEM
    {
        public TRANSACTION_LINEITEM()
        {
            this.EXCEPTIONS = new List<EXCEPTION>();
        }

        public int TransactionLineItemID { get; set; }
        public int TransactionID { get; set; }
        public long RecRPC { get; set; }
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        public short CommissionEmployeeID { get; set; }
        public decimal ItemTaxTotal { get; set; }
        public decimal ItemTotal { get; set; }
        public virtual ICollection<EXCEPTION> EXCEPTIONS { get; set; }
        public virtual ITEM ITEM { get; set; }
        public virtual STORE_TRANSACTION STORE_TRANSACTION { get; set; }
    }
}
