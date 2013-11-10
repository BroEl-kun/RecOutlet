using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecOutletWarehouse.Models.ItemManagement {
    public class ProductLine {

        public int ProductLineID { get; set; }

        public string ProductLineName { get; set; }

        public short VendorID { get; set; }

        public short RepID { get; set; }
    }
}