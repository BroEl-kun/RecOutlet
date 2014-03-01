using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecOutletWarehouse.Models
{
    public partial class ITEM_DEPARTMENT
    {
        public ITEM_DEPARTMENT()
        {
            this.ITEMs = new List<ITEM>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public byte DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
        public virtual ICollection<ITEM> ITEMs { get; set; }
    }
}
