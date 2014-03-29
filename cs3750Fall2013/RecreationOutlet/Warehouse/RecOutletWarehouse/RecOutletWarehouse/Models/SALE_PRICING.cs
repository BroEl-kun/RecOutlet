using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models
{
    public partial class SALE_PRICING
    {
        public byte EventTypeCode { get; set; }
        public long RecRPC { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString="{0:C}", ApplyFormatInEditMode=true)]
        public decimal SalePrice { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> BeginDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Comments { get; set; }

        [JsonIgnore]
        public virtual EVENT_TYPE EVENT_TYPE { get; set; }

        [JsonIgnore]
        public virtual ITEM ITEM { get; set; }
    }
}
