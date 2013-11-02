using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models.ProductLine
{
    public class AddVendor
    {

        public int ProductLineID { get; set; }

        public string ProductLineName { get; set; }

        public int VendorID { get; set; }

        public int RepID { get; set; }
    }
}