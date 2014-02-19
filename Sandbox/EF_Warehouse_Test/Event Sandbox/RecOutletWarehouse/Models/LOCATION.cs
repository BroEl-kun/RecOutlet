using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class LOCATION
    {
        public LOCATION()
        {
            this.INVENTORies = new List<INVENTORY>();
            this.STORE_TRANSACTION = new List<STORE_TRANSACTION>();
            this.TAX_RATE = new List<TAX_RATE>();
        }

        public byte LocationID { get; set; }
        public short ManagerId { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual ICollection<INVENTORY> INVENTORies { get; set; }
        public virtual ICollection<STORE_TRANSACTION> STORE_TRANSACTION { get; set; }
        public virtual ICollection<TAX_RATE> TAX_RATE { get; set; }
    }
}
