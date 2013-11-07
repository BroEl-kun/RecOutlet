using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RecOutletWarehouse.Models.PurchaseOrder {
    public class PurchaseOrder {

        //this is a string because we can't guarantee the client will enter as an int
        public string PurchaseOrderId { get; set; }
        
        public string Vendor { get; set; } //string to accept either an ID or a Name

        public int CreatedBy { get; set; }

        [DataType(DataType.Date)] //Preferable to [DisplayFormat...]
        public DateTime OrderDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EstShipDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal FreightCost { get; set; }

        public string Terms { get; set; }

        public string Comments { get; set; }

    }
}