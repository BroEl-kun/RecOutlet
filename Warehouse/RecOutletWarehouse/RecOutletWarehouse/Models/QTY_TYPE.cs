using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class QTY_TYPE
    {
        public QTY_TYPE()
        {
            this.MERCHANDISE_TRANSFER = new List<MERCHANDISE_TRANSFER>();
            this.PO_LINEITEM = new List<PO_LINEITEM>();
        }

        public byte QtyTypeID { get; set; }
        public string QtyTypeDescription { get; set; }
        public virtual ICollection<MERCHANDISE_TRANSFER> MERCHANDISE_TRANSFER { get; set; }
        public virtual ICollection<PO_LINEITEM> PO_LINEITEM { get; set; }
    }
}
