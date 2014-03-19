using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecOutletWarehouse.Models.ItemManagement {
    public class SubCategory {
        public byte SubcategoryID { get; set; }

        [Required]
        public string SubcategoryName { get; set; }
    }
}