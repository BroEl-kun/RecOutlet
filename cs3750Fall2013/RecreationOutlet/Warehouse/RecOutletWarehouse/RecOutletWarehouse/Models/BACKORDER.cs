using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class BACKORDER
    {
        public int BackorderID { get; set; }
        public int ReceivingID { get; set; }
        public short BackorderQty { get; set; }
        public virtual RECEIVING_LOG RECEIVING_LOG { get; set; }
    }
}
