using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecOutletWarehouse.Models.ItemManagement {
    public class Category {

        public byte CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}