using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models
{
    public partial class SALE_PRICING
    {
        public byte EventTypeCode { get; set; }
        public long RecRPC { get; set; }
        public decimal SalePrice { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> BeginDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Comments { get; set; }
        public virtual EVENT_TYPE EVENT_TYPE { get; set; }
        public virtual ITEM ITEM { get; set; }
    }
}
