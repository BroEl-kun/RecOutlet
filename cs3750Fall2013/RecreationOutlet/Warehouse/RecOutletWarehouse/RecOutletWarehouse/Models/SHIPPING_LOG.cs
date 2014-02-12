using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class SHIPPING_LOG
    {
        public int ShippingID { get; set; }
        public long InvoiceID { get; set; }
        public string ShippingNotes { get; set; }
        public decimal ShippingFrieghtCost { get; set; }
        public string Attention { get; set; }
        public Nullable<System.DateTime> EstimatedShipDate { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public string ShipSource { get; set; }
        public string TrackingNum { get; set; }
        public string FreightProvider { get; set; }
        public virtual INVOICE INVOICE { get; set; }
    }
}
