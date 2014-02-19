using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class INVOICE_CUSTOMER
    {
        public INVOICE_CUSTOMER()
        {
            this.INVOICEs = new List<INVOICE>();
        }

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> TaxExemptID { get; set; }
        public string CustomerPaymentTerms { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerState { get; set; }
        public string CustomerZip { get; set; }
        public string CustomerPhone { get; set; }
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
    }
}
