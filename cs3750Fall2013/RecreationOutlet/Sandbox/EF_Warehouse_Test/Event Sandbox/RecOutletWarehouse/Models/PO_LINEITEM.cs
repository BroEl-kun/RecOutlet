using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class PO_LINEITEM
    {
        public PO_LINEITEM()
        {
            this.RECEIVING_LOG = new List<RECEIVING_LOG>();
        }

        public int POLineItemID { get; set; }
        public long POID { get; set; }
        public long RecRPC { get; set; }
        public byte QtyTypeID { get; set; }
        public decimal WholesaleCost { get; set; }
        public short QtyOrdered { get; set; }
        public virtual ITEM ITEM { get; set; }
        public virtual PURCHASE_ORDER PURCHASE_ORDER { get; set; }
        public virtual QTY_TYPE QTY_TYPE { get; set; }
        public virtual ICollection<RECEIVING_LOG> RECEIVING_LOG { get; set; }
    }
}
