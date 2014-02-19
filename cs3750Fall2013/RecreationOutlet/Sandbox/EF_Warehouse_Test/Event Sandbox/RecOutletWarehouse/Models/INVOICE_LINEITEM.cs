using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class INVOICE_LINEITEM
    {
        public int InvoiceLineItemID { get; set; }
        public long InvoiceID { get; set; }
        public long RecRPC { get; set; }
        public byte QtyTypeID { get; set; }
        public byte ItemQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        public virtual INVOICE INVOICE { get; set; }
        public virtual ITEM ITEM { get; set; }
        public virtual QTY_TYPE QTY_TYPE { get; set; }
    }
}
