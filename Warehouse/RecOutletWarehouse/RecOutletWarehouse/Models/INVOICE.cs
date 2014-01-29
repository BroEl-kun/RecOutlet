using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class INVOICE
    {
        public INVOICE()
        {
            this.INVOICE_LINEITEM = new List<INVOICE_LINEITEM>();
        }

        public long InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public int ShippingID { get; set; }
        public string Attention { get; set; }
        public System.DateTime PaymentDue { get; set; }
        public decimal SalesTaxDue { get; set; }
        public System.DateTime DatePaid { get; set; }
        public decimal AmountPaid { get; set; }
        public string InvoiceNotes { get; set; }
        public short InvoiceCreatedBy { get; set; }
        public System.DateTime InvoiceCreatedDate { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual INVOICE_CUSTOMER INVOICE_CUSTOMER { get; set; }
        public virtual ICollection<INVOICE_LINEITEM> INVOICE_LINEITEM { get; set; }
        public virtual SHIPPING_LOG SHIPPING_LOG { get; set; }
    }
}
