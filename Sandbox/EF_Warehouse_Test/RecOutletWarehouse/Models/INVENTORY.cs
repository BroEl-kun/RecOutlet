using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class INVENTORY
    {
        public byte StoreID { get; set; }
        public int RecID { get; set; }
        public short QtyOnHand { get; set; }
        public short QtyThreshold { get; set; }
        public virtual LOCATION LOCATION { get; set; }
    }
}
