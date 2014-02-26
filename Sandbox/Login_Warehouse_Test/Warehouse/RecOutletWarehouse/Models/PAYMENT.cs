using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class PAYMENT
    {
        public short PaymentID { get; set; }
        public byte PaymentTypeID { get; set; }
        public int TransactionID { get; set; }
        public decimal PaymentAmount { get; set; }
        public virtual PAYMENT_TYPE PAYMENT_TYPE { get; set; }
        public virtual STORE_TRANSACTION STORE_TRANSACTION { get; set; }
    }
}
