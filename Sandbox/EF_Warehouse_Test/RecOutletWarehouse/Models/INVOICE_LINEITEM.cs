using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class INVOICE_LINEITEM
    {
        public int InvoiceLineItemID { get; set; }
        public long InvoiceID { get; set; }
        public int RecRPC { get; set; }
        public decimal InvoicePrice { get; set; }
        public short InvoiceItemQuantity { get; set; }
    }
}
