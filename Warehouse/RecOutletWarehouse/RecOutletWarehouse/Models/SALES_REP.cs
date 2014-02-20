using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class SALES_REP
    {
        public SALES_REP() {
            this.PRODUCT_LINE = new List<PRODUCT_LINE>();
        }

        public short RepID { get; set; }
        public string SalesRepName { get; set; }
        public string SalesRepPhone { get; set; }
        public string SalesRepEmail { get; set; }

        [JsonIgnore]
        public virtual ICollection<PRODUCT_LINE> PRODUCT_LINE { get; set; }
    }
}
