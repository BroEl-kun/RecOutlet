using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class LOCATION
    {
        public LOCATION()
        {
            this.INVENTORies = new List<INVENTORY>();
            this.PAYMENTs = new List<PAYMENT>();
        }

        public byte StoreID { get; set; }
        public string StoreName { get; set; }
        public short ManagerId { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual ICollection<INVENTORY> INVENTORies { get; set; }
        public virtual ICollection<PAYMENT> PAYMENTs { get; set; }
    }
}
