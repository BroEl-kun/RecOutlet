using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class PRODUCT_LINE
    {
        public PRODUCT_LINE()
        {
            this.ITEMs = new List<ITEM>();
        }

        public int ProductLineID { get; set; }
        public string ProductLineName { get; set; }
        public short VendorID { get; set; }
        public short RepID { get; set; }
        public virtual ICollection<ITEM> ITEMs { get; set; }
        public virtual SALES_REP SALES_REP { get; set; }
        public virtual VENDOR VENDOR { get; set; }
    }
}
