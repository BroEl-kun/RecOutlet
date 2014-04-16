using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecOutletWarehouse.Utilities {
    /// <summary>
    /// This is a supplemental model class (not associated with a database table)
    /// that is used on the ItemManagement PrintLabels View/Controller method 
    /// </summary>
    public class LabelPrinting {
        public long RPC { get; set; }
        public string UPC { get; set; }
        public string ItemName { get; set; }
        public short LabelQty { get; set; }
        public string LabelType { get; set; }

    }
}