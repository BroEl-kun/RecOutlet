using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class TAX_TYPE
    {
        public TAX_TYPE()
        {
            this.ITEMs = new List<ITEM>();
            this.TAX_RATE = new List<TAX_RATE>();
        }

        public byte TaxTypeID { get; set; }
        public string TaxTypeName { get; set; }
        public virtual ICollection<ITEM> ITEMs { get; set; }
        public virtual ICollection<TAX_RATE> TAX_RATE { get; set; }
    }
}
