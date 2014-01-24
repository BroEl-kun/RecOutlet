using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class INVOICE_CUSTOMER
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> CustomerPhoneNumber { get; set; }
        public Nullable<int> TaxExemptID { get; set; }
        public string CustomerPaymentTerms { get; set; }
        public string CustomerAddress { get; set; }
    }
}
