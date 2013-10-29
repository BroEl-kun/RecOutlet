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

//So we'll need the po line items but what they will really be putting in is the PO_ID then we will get all the line items from the PO (perhaps using his PurchaseOrder getter/setter)
//then they will need to put in the quantity, employee id, etc.
//another method will then calc the dif between ordered and received and input into the database for backordered.