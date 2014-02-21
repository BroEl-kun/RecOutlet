using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class RECEIVING_LOG
    {
        public int ReceivingID { get; set; }
        public Nullable<int> POLineItemID { get; set; }
        public Nullable<byte> QtyTypeID { get; set; }
        public System.DateTime ReceiveDate { get; set; }
        public string ReceivingNotes { get; set; }
        public Nullable<int> ReceivedQty { get; set; }
        public virtual PO_LINEITEM PO_LINEITEM { get; set; }
    }
}
