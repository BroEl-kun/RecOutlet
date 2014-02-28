using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecOutletWarehouse.Models
{
    public partial class EVENT_TYPE
    {
        public EVENT_TYPE()
        {
            this.SALE_PRICING = new List<SALE_PRICING>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte EventTypeCode { get; set; }
        public string EventDescription { get; set; }

        [JsonIgnore]
        public virtual ICollection<SALE_PRICING> SALE_PRICING { get; set; }
    }
}
