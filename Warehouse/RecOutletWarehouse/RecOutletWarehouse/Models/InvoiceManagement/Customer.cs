using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecOutletWarehouse.Models.InvoiceManagement
{
    public class Customer
    {

        public byte CustomerID { get; set; }

        [Required]
        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string TaxExemptID { get; set; }

        public string CustomerPaymentTerms { get; set; }

        public string CustomerAddress { get; set; }
    }
}