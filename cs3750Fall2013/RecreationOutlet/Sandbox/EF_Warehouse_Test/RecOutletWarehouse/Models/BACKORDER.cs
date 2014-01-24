using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class BACKORDER
    {
        public BACKORDER()
        {
            this.RECEIVING_LOG = new List<RECEIVING_LOG>();
            this.SHIPPING_LOG = new List<SHIPPING_LOG>();
        }

        public int BackorderID { get; set; }
        public int POLineItemID { get; set; }
        public int ReceivingID { get; set; }
        public short BackorderQty { get; set; }
        public virtual ICollection<RECEIVING_LOG> RECEIVING_LOG { get; set; }
        public virtual ICollection<SHIPPING_LOG> SHIPPING_LOG { get; set; }
    }
}
