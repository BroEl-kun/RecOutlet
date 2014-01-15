using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecOutletWarehouse.Models.ItemManagement {
    public class Department {
        [Required]
        public byte DepartmentID { get; set; }

        [Required]
        public string DepartmentName { get; set; }
    }
}