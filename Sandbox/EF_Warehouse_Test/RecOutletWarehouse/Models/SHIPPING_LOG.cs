using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class SHIPPING_LOG
    {
        public SHIPPING_LOG()
        {
            this.INVOICEs = new List<INVOICE>();
            this.PURCHASE_ORDER = new List<PURCHASE_ORDER>();
        }

        public int ShippingID { get; set; }
        public long ID { get; set; }
        public string OrderType { get; set; }
        public Nullable<int> BackorderID { get; set; }
        public string ShippingNotes { get; set; }
        public decimal ShippingFrieghtCost { get; set; }
        public string Attention { get; set; }
        public Nullable<System.DateTime> EstimatedShipDate { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public string ShipSource { get; set; }
        public string TrackingNum { get; set; }
        public string FreightProvider { get; set; }
        public virtual BACKORDER BACKORDER { get; set; }
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
        public virtual INVOICE INVOICE { get; set; }
        public virtual ICollection<PURCHASE_ORDER> PURCHASE_ORDER { get; set; }
        public virtual PURCHASE_ORDER PURCHASE_ORDER1 { get; set; }
    }
}
