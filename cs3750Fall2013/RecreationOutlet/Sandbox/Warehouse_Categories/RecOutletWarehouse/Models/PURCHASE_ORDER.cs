using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class PURCHASE_ORDER
    {
        public PURCHASE_ORDER()
        {
            this.PO_LINEITEM = new List<PO_LINEITEM>();
        }

        public long POID { get; set; }
        public short VendorID { get; set; }
        public short POCreatedBy { get; set; }
        public Nullable<System.DateTime> POOrderDate { get; set; }
        public Nullable<System.DateTime> POEstimatedShipDate { get; set; }
        public System.DateTime POCreatedDate { get; set; }
        public string POFreightCost { get; set; }
        public string POTerms { get; set; }
        public string POComments { get; set; }
        public Nullable<int> ShippingID { get; set; }
        public Nullable<System.DateTime> POCancelIfNotReceivedBy { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual ICollection<PO_LINEITEM> PO_LINEITEM { get; set; }
        public virtual VENDOR VENDOR { get; set; }
    }
}
