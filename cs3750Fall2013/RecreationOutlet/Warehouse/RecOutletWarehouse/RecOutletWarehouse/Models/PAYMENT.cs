using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class PAYMENT
    {
        public PAYMENT()
        {
            this.STORE_TRANSACTION = new List<STORE_TRANSACTION>();
        }

        public short PaymentID { get; set; }
        public byte PaymentTypeID { get; set; }
        public byte StoreID { get; set; }
        public decimal PaymentAmount { get; set; }
        public virtual LOCATION LOCATION { get; set; }
        public virtual PAYMENT_TYPE PAYMENT_TYPE { get; set; }
        public virtual ICollection<STORE_TRANSACTION> STORE_TRANSACTION { get; set; }
    }
}
