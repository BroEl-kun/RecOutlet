using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class STORE_TRANSACTION
    {
        public STORE_TRANSACTION()
        {
            this.TRANSACTION_LINE_ITEM = new List<TRANSACTION_LINE_ITEM>();
        }

        public int TransactionID { get; set; }
        public byte StoreID { get; set; }
        public short EmployeeID { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public string TerminalID { get; set; }
        public decimal TransTotal { get; set; }
        public decimal TransTax { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public string PaymentType { get; set; }
        public int PreviousTransactionID { get; set; }
        public virtual ICollection<TRANSACTION_LINE_ITEM> TRANSACTION_LINE_ITEM { get; set; }
    }
}
