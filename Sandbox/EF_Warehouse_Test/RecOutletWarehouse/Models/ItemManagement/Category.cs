using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecOutletWarehouse.Models.ItemManagement {
    public class Category {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}