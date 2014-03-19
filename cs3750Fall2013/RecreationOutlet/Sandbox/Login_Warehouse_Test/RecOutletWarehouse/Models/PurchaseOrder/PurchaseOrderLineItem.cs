using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models.PurchaseOrder {
    public class PurchaseOrderLineItem {

        //NOTE: These Variables are NOT REQUIRED; there will be custom validation
        //(e.g. a line item must be either COMPLETE or EMPTY to be accepted)

        public int POLineItem { get; set; }

        public string POID { get; set; } //again this is a string here

        public long RecRPC { get; set; }

        public short QtyOrdered { get; set; }

        public short QtyTypeId { get; set; } //TODO: figure out if this is necessary
       // public byte QtyTypeId { get; set; } //TODO: figure out if this is necessary\
        //public ushort QtyTypeId { get; set; } //TODO: figure out if this is necessary

        public decimal WholesaleCost { get; set; }

    }
}