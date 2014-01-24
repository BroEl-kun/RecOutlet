using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecOutletWarehouse.Models.ItemManagement {
    public class SubCategory {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte SubcategoryID { get; set; }

        [Required]
        public string SubcategoryName { get; set; }
    }
}