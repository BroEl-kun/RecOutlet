using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models.VendorManagement
{
    public class Vendor
    {

        public int VendorId { get; set; }

        [Required(ErrorMessage="Please supply the vendor's name")]
        public string VendorName { get; set; }

        public string ContactName { get; set; }

        [Required(ErrorMessage="Please enter the phone number of your liaison with this vendor")]
        public string ContactPhone { get; set; }

        public string ContactFax { get; set; }

        public string AltPhone { get; set; }

        [Required(ErrorMessage="Please supply the vendor's street address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please supply the vendor's City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please supply the vendor's State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please supply the vendor's Zip")]
        public int Zip { get; set; }

        [DataType(DataType.Url, ErrorMessage="Please enter a valid Internet URL")]
        public string Website { get; set; }
    }
}