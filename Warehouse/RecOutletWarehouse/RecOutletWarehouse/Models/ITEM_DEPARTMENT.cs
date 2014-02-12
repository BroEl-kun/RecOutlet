using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class ITEM_DEPARTMENT
    {
        public ITEM_DEPARTMENT()
        {
            this.ITEMs = new List<ITEM>();
        }

        public byte DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
        public virtual ICollection<ITEM> ITEMs { get; set; }
    }
}
