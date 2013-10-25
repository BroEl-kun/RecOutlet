using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models.PurchaseOrder {
    public class PurchaseOrder {

        //this is a string because we can't guarantee the client will enter as an int
        public string PurchaseOrderId { get; set; }
        
        public int VendorId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime EstShipDate { get; set; }

        public decimal FreightCost { get; set; }

        public string Terms { get; set; }

        public string Comments { get; set; }
    }
}