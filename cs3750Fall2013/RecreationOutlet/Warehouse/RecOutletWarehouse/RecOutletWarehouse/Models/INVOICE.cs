using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime InvoiceCreatedDate { get; set; }

        public string Attention { get; set; }
        public decimal TotalSalesTax { get; set; }
        public decimal TotalAmount { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TotalAmountPaid { get; set; }

        public Nullable<System.DateTime> LastPaymentReceived { get; set; }
        public string InvoiceNotes { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual INVOICE_CUSTOMER INVOICE_CUSTOMER { get; set; }
        public virtual ICollection<INVOICE_LINEITEM> INVOICE_LINEITEM { get; set; }
        public virtual ICollection<SHIPPING_LOG> SHIPPING_LOG { get; set; }
    }
}
