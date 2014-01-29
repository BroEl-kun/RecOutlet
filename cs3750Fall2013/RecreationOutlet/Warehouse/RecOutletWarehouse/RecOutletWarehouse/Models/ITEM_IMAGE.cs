using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class ITEM_IMAGE
    {
        public int ItemImageID { get; set; }
        public long RecRPC { get; set; }
        public string ItemPath { get; set; }
        public virtual ITEM ITEM { get; set; }
    }
}
