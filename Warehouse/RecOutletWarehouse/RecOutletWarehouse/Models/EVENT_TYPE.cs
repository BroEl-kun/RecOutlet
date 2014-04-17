using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Please provide an Event Type.")]
        public byte EventTypeCode { get; set; }

        [Required(ErrorMessage = "Please provide an Event Description.")]
        public string EventDescription { get; set; }

        [JsonIgnore]
        public virtual ICollection<SALE_PRICING> SALE_PRICING { get; set; }
    }
}
