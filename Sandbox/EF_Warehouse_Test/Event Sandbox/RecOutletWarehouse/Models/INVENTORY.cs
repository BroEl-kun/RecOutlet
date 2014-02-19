using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class INVENTORY
    {
        public long InventoryID { get; set; }
        public byte LocationID { get; set; }
        public long RecRPC { get; set; }
        public byte QtyTypeID { get; set; }
        public short QtyOnHand { get; set; }
        public short QtyThreshold { get; set; }
        public virtual ITEM ITEM { get; set; }
        public virtual LOCATION LOCATION { get; set; }
        public virtual QTY_TYPE QTY_TYPE { get; set; }
    }
}
