using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class ITEM_CATEGORY
    {
        public ITEM_CATEGORY()
        {
            this.ITEMs = new List<ITEM>();
        }

        public byte CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual ICollection<ITEM> ITEMs { get; set; }
    }
}
