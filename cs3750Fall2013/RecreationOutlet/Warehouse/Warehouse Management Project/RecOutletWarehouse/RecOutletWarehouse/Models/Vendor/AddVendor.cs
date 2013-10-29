using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models.AddVendor
{
    public class AddVendor
    {

        public int VendorID { get; set; }

        public string VendorName { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public string ContactFax { get; set; }

        public string AltPhone { get; set; }

        public string Address { get; set; }

        public string Website { get; set; }
    }
}