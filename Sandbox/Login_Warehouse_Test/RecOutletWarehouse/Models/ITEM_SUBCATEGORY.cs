using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class ITEM_SUBCATEGORY
    {
        public ITEM_SUBCATEGORY()
        {
            this.ITEMs = new List<ITEM>();
        }

        public short SubcategoryID { get; set; }
        public string SubcategoryName { get; set; }
        public virtual ICollection<ITEM> ITEMs { get; set; }
    }
}
