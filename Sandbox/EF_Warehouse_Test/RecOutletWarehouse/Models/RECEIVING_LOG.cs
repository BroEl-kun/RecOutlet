using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class RECEIVING_LOG
    {
        public int ReceivingID { get; set; }
        public Nullable<int> POLineItemID { get; set; }
        public Nullable<int> BackorderID { get; set; }
        public Nullable<byte> QtyTypeID { get; set; }
        public System.DateTime ReceiveDate { get; set; }
        public string ReceivingNotes { get; set; }
        public Nullable<short> ReceivedQty { get; set; }
        public virtual BACKORDER BACKORDER { get; set; }
        public virtual PO_LINEITEM PO_LINEITEM { get; set; }
        public virtual QTY_TYPE QTY_TYPE { get; set; }
    }
}
