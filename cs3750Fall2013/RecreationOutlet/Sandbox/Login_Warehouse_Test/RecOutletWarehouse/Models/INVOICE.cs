using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class INVOICE
    {
        public INVOICE()
        {
            this.INVOICE_LINEITEM = new List<INVOICE_LINEITEM>();
            this.SHIPPING_LOG = new List<SHIPPING_LOG>();
        }

        public long InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public short InvoiceCreatedBy { get; set; }
        public System.DateTime InvoiceCreatedDate { get; set; }
        public string Attention { get; set; }
        public decimal TotalSalesTax { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountPaid { get; set; }
        public Nullable<System.DateTime> LastPaymentReceived { get; set; }
        public string InvoiceNotes { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual INVOICE_CUSTOMER INVOICE_CUSTOMER { get; set; }
        public virtual ICollection<INVOICE_LINEITEM> INVOICE_LINEITEM { get; set; }
        public virtual ICollection<SHIPPING_LOG> SHIPPING_LOG { get; set; }
    }
}
