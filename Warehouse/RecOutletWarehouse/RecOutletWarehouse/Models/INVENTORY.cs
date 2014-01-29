using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class INVENTORY
    {
        public byte StoreID { get; set; }
        public long RecRPC { get; set; }
        public short QtyOnHand { get; set; }
        public short QtyThreshold { get; set; }
        public virtual ITEM ITEM { get; set; }
        public virtual LOCATION LOCATION { get; set; }
    }
}
