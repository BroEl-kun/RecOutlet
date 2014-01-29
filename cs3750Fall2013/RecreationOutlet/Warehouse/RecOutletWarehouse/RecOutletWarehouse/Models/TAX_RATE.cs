using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class TAX_RATE
    {
        public TAX_RATE()
        {
            this.ITEMs = new List<ITEM>();
        }

        public byte TaxRateID { get; set; }
        public string TaxRateType { get; set; }
        public decimal TaxRate { get; set; }
        public virtual ICollection<ITEM> ITEMs { get; set; }
    }
}
