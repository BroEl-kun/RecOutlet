using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class OVERRIDE_CODE
    {
        public OVERRIDE_CODE()
        {
            this.EXCEPTIONS = new List<EXCEPTION>();
        }

        public byte OverrideCode { get; set; }
        public string OverrideReason { get; set; }
        public virtual ICollection<EXCEPTION> EXCEPTIONS { get; set; }
    }
}
