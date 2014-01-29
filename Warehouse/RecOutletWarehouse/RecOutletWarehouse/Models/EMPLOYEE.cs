using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class EMPLOYEE
    {
        public EMPLOYEE()
        {
            this.INVOICEs = new List<INVOICE>();
            this.LOCATIONs = new List<LOCATION>();
            this.PURCHASE_ORDER = new List<PURCHASE_ORDER>();
            this.STORE_TRANSACTION = new List<STORE_TRANSACTION>();
        }

        public short EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Username { get; set; }
        public string PIN { get; set; }
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
        public virtual ICollection<LOCATION> LOCATIONs { get; set; }
        public virtual ICollection<PURCHASE_ORDER> PURCHASE_ORDER { get; set; }
        public virtual ICollection<STORE_TRANSACTION> STORE_TRANSACTION { get; set; }
    }
}
