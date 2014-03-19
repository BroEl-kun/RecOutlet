using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecOutletWarehouse.Models.VendorManagement {
    public class SalesRep {

        [HiddenInput]
        public short SalesRepID { get; set; }

        //none of the following are required--custom validation will be needed

        public string SalesRepName { get; set; }

        public string SalesRepPhone { get; set; }

        public string SalesRepEmail { get; set; }

    }
}