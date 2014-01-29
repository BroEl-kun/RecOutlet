using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class REFUND_CODE
    {
        public REFUND_CODE()
        {
            this.EXCEPTIONS = new List<EXCEPTION>();
        }

        public byte RefundCode { get; set; }
        public string RefundReason { get; set; }
        public virtual ICollection<EXCEPTION> EXCEPTIONS { get; set; }
    }
}
