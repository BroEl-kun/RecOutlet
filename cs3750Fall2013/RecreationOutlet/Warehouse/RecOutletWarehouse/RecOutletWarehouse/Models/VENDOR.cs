using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class VENDOR
    {
//        public VENDOR()
//        {
//            this.PRODUCT_LINE = new List<PRODUCT_LINE>();
//            this.PURCHASE_ORDER = new List<PURCHASE_ORDER>();
//        }

        public short VendorID { get; set; }
        public string VendorName { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public string AltPhone { get; set; }
        public string VendorAddress { get; set; }
        public string VendorState { get; set; }
        public string VendorZip { get; set; }
        public string VendorWebsite { get; set; }
        //public virtual ICollection<PRODUCT_LINE> PRODUCT_LINE { get; set; }
        //public virtual ICollection<PURCHASE_ORDER> PURCHASE_ORDER { get; set; }
    }
}
