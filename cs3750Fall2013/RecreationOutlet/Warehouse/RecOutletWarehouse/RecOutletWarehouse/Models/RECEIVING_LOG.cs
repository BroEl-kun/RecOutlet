using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class RECEIVING_LOG
    {
        public RECEIVING_LOG()
        {
            this.BACKORDERs = new List<BACKORDER>();
        }

        public int ReceivingID { get; set; }
        public Nullable<int> POLineItemID { get; set; }
        public Nullable<byte> QtyTypeID { get; set; }
        public System.DateTime ReceiveDate { get; set; }
        public string ReceivingNotes { get; set; }
        public Nullable<short> ReceivedQty { get; set; }
        public virtual ICollection<BACKORDER> BACKORDERs { get; set; }
        public virtual PO_LINEITEM PO_LINEITEM { get; set; }
    }
}
