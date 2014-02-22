using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class MERCHANDISE_TRANSFER
    {
        public long TransferID { get; set; }
        public long RecRPC { get; set; }
        public byte ToLocationID { get; set; }
        public byte FromLocationID { get; set; }
        public System.DateTime TansferDate { get; set; }
        public string TansferComments { get; set; }
        public short TransferCreatedBy { get; set; }
        public System.DateTime TransferCreatedDate { get; set; }
        public short Quantity { get; set; }
        public byte QtyTypeID { get; set; }
        public virtual ITEM ITEM { get; set; }
        public virtual QTY_TYPE QTY_TYPE { get; set; }
    }
}
