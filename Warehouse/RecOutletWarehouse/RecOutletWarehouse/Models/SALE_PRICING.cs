using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models
{
    public partial class SALE_PRICING
    {
        public byte EventTypeCode { get; set; }

        [Required(ErrorMessage = "Please provide an RPC")]
        public long RecRPC { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString="{0:C}", ApplyFormatInEditMode=true)]
        [Required(ErrorMessage = "Please provide a sale price")]
        public decimal SalePrice { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please provide a beginning effective date.")]
        public Nullable<System.DateTime> BeginDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please provide an ending effective date.")]
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Comments { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "Please provide an Event.")]
        public virtual EVENT_TYPE EVENT_TYPE { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "Please provide an item.")]
        public virtual ITEM ITEM { get; set; }
    }
}
