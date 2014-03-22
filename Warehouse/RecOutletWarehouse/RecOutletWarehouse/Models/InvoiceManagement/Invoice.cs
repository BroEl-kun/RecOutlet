using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecOutletWarehouse.Models.InvoiceManagement
{
    public class Invoice
    {
        public long InvoiceID { get; set; }

        [Required]
        public long CustomerID { get; set; }

        public long ShippingID { get; set; }

        public long Attention { get; set; }

        public long PaymentDue { get; set; }

        public long SalesTaxDue { get; set; }

        public long DatePaid { get; set; }

        public long AmountPaid { get; set; }

        public long InvoiceNotes { get; set; }

        public long InvoiceCreatedBy { get; set; }

        public DateTime InvoiceCreatedDate { get; set; }

        [Required]
        public string Recipient { get; set; }
    }
}