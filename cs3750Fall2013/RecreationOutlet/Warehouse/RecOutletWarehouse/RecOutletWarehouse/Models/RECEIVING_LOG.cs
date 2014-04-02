using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models
{
    public partial class RECEIVING_LOG
    {
        public int ReceivingID { get; set; }
        public Nullable<int> POLineItemID { get; set; }
        public Nullable<byte> QtyTypeID { get; set; }

        [Required(ErrorMessage="Please select a date")]
        public System.DateTime ReceiveDate { get; set; }
        public string ReceivingNotes { get; set; }
        //If we have a receiving log, we should have an amount...
        //public Nullable<int> ReceivedQty { get; set; }

        [Required(ErrorMessage="Must enter an amount")]
        public int ReceivedQty { get; set; }
        public virtual PO_LINEITEM PO_LINEITEM { get; set; }
    }
}
