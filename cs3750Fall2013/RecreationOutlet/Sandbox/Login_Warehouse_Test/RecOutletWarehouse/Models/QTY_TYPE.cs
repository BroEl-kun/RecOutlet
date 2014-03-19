using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class QTY_TYPE
    {
        public QTY_TYPE()
        {
            this.INVENTORies = new List<INVENTORY>();
            this.INVOICE_LINEITEM = new List<INVOICE_LINEITEM>();
            this.MERCHANDISE_TRANSFER = new List<MERCHANDISE_TRANSFER>();
            this.PO_LINEITEM = new List<PO_LINEITEM>();
        }

        public byte QtyTypeID { get; set; }
        public string QtyTypeDescription { get; set; }
        public virtual ICollection<INVENTORY> INVENTORies { get; set; }
        public virtual ICollection<INVOICE_LINEITEM> INVOICE_LINEITEM { get; set; }
        public virtual ICollection<MERCHANDISE_TRANSFER> MERCHANDISE_TRANSFER { get; set; }
        public virtual ICollection<PO_LINEITEM> PO_LINEITEM { get; set; }
    }
}
