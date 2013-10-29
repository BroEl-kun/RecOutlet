using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecOutletWarehouse.Models
{
    public class ReceivingLog
    {   //may want to instead do unsigned integers
        public int ReceivingID { get; set; }

        public int POLineItemID { get; set; }

        public int BackorderID { get; set; }
        //byte = 8 bits 0-255
        public byte QtyTypeID { get; set; }

        public DateTime ReceiveDate { get; set; }

        public string ReceivingNotes { get; set; }
        //unsigned short 16 bits 0 to 65535
        public ushort ReceivedQty { get; set; }
    }
}