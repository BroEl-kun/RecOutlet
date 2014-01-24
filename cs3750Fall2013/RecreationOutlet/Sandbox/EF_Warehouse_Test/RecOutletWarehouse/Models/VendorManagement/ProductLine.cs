using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecOutletWarehouse.Models.VendorManagement {
    public class ProductLine {

        public int ProductLineID { get; set; }

        [Required]
        public string ProductLineName { get; set; }

        [Required]
        public string Vendor { get; set; }

        //the following requires custom validation
        public string SalesRep { get; set; }
    }
}