using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecOutletWarehouse.Models
{
    public partial class ITEM_CATEGORY
    {
        public ITEM_CATEGORY()
        {
            this.ITEMs = new List<ITEM>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual ICollection<ITEM> ITEMs { get; set; }
    }
}
