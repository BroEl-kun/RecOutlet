using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class EMPLOYEE
    {
        public EMPLOYEE()
        {
            this.LOCATIONs = new List<LOCATION>();
            this.PURCHASE_ORDER = new List<PURCHASE_ORDER>();
        }

        public short EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Username { get; set; }
        public string PIN { get; set; }
        public virtual ICollection<LOCATION> LOCATIONs { get; set; }
        public virtual ICollection<PURCHASE_ORDER> PURCHASE_ORDER { get; set; }
    }
}
