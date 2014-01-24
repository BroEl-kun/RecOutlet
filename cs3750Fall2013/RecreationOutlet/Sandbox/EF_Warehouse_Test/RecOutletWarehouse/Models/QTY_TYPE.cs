using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class QTY_TYPE
    {
        public QTY_TYPE()
        {
            this.PO_LINEITEM = new List<PO_LINEITEM>();
            this.RECEIVING_LOG = new List<RECEIVING_LOG>();
        }

        public byte QtyTypeID { get; set; }
        public string QtyTypeDescription { get; set; }
        public virtual ICollection<PO_LINEITEM> PO_LINEITEM { get; set; }
        public virtual ICollection<RECEIVING_LOG> RECEIVING_LOG { get; set; }
    }
}
