using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecOutletWarehouse.Models.ItemManagement {
    public class LabelPrinting {
        public string RPC { get; set; }
        public string UPC { get; set; }
        public string ItemName { get; set; }
        public short LabelQty { get; set; }
        public string LabelType { get; set; }

    }
}