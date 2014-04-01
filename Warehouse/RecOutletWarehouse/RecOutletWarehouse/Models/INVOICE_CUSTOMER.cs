using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models
{
    public partial class INVOICE_CUSTOMER
    {
        public INVOICE_CUSTOMER()
        {
            this.INVOICEs = new List<INVOICE>();
        }

        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Please provide a customer name.")]
        [MaxLength(100, ErrorMessage = "The name you entered is too long.")]
        public string CustomerName { get; set; }

        public Nullable<int> TaxExemptID { get; set; }

        public string CustomerPaymentTerms { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        [MaxLength(50, ErrorMessage = "The address you entered is too long.")]
        public string CustomerAddress { get; set; }

        [MaxLength(50, ErrorMessage = "The address you entered is too long.")]
        public string CustomerAddress2 { get; set; }

        [Required(ErrorMessage = "Please enter a city.")]
        [MaxLength(50, ErrorMessage = "The city you entered is too long.")]
        public string CustomerCity { get; set; }

        [Required(ErrorMessage = "Please enter a two-letter state code.")]
        [MaxLength(2, ErrorMessage = "Enter the two-letter state code.")]
        public string CustomerState { get; set; }

        [Required(ErrorMessage = "Please enter a ZIP code.")]
        [MaxLength(10, ErrorMessage = "The ZIP you entered is too long.")]
        public string CustomerZip { get; set; }

        [Required(ErrorMessage = "Please enter a country.")]
        [MaxLength(50, ErrorMessage = "The country you entered is too long.")]
        public string CustomerCountry { get; set; }

        [Required(ErrorMessage = "Please provide a phone number.")]
        [MaxLength(15, ErrorMessage = "The phone number you entered is too long.")]
        public string CustomerPhone { get; set; }

        public virtual ICollection<INVOICE> INVOICEs { get; set; }
    }
}
