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

        [Required(ErrorMessage = "Please supply the recipient's name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter the recipient's phone number")]
        public string CustomerPhone { get; set; }

        public string TaxExemptID { get; set; }

        public string CustomerPaymentTerms { get; set; }

        [Required(ErrorMessage = "Please supply the recipient's street address")]
        public string CustomerAddress { get; set; }

        public string CustomerAddress2 { get; set; }

        [Required(ErrorMessage = "Please supply the recipient's city")]
        public string CustomerCity { get; set; }

        [Required(ErrorMessage = "Please supply the recipient's state")]
        public string CustomerState { get; set; }

        [Required(ErrorMessage = "Please supply the recipient's ZIP code")]
        public string CustomerZip { get; set; }
    }
}