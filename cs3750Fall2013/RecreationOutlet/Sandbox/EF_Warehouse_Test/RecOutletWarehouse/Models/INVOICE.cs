using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class INVOICE
    {
        public INVOICE()
        {
            this.SHIPPING_LOG1 = new List<SHIPPING_LOG>();
        }

        public long InvoiceID { get; set; }
        public string CustomerID { get; set; }
        public int ShippingID { get; set; }
        public string Attention { get; set; }
        public System.DateTime PaymentDue { get; set; }
        public decimal SalesTaxDue { get; set; }
        public System.DateTime DatePaid { get; set; }
        public decimal AmountPaid { get; set; }
        public string InvoiceNotes { get; set; }
        public string InvoiceCreatedBy { get; set; }
        public System.DateTime InvoiceCreatedDate { get; set; }
        public virtual SHIPPING_LOG SHIPPING_LOG { get; set; }
        public virtual ICollection<SHIPPING_LOG> SHIPPING_LOG1 { get; set; }
    }
}
