using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class STORE_TRANSACTION
    {
        public STORE_TRANSACTION()
        {
            this.TRANSACTION_LINEITEM = new List<TRANSACTION_LINEITEM>();
        }

        public int TransactionID { get; set; }
        public byte StoreID { get; set; }
        public short EmployeeID { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public string TerminalID { get; set; }
        public decimal TransTotal { get; set; }
        public decimal TransTax { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public short PaymentID { get; set; }
        public int PreviousTransactionID { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual LOCATION LOCATION { get; set; }
        public virtual PAYMENT PAYMENT { get; set; }
        public virtual ICollection<TRANSACTION_LINEITEM> TRANSACTION_LINEITEM { get; set; }
    }
}
