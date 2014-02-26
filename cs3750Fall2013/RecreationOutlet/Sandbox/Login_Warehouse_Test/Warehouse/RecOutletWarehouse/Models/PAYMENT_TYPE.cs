using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class PAYMENT_TYPE
    {
        public PAYMENT_TYPE()
        {
            this.PAYMENTs = new List<PAYMENT>();
        }

        public byte PaymentTypeID { get; set; }
        public string PaymentTypeName { get; set; }
        public virtual ICollection<PAYMENT> PAYMENTs { get; set; }
    }
}
