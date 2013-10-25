using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models.PurchaseOrder {
    public class PurchaseOrderLineItem {

        public int POLineItem { get; set; }

        public string POID { get; set; } //again this is a string here

        public int RecRPC { get; set; }

        public int QtyTypeId { get; set; } //TODO: figure out if this is necessary

        public decimal WholesaleCost { get; set; }

    }
}