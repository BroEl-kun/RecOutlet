using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class TAX_RATE
    {
        public byte TaxRateID { get; set; }
        public byte TaxTypeID { get; set; }
        public Nullable<byte> LocationID { get; set; }
        public decimal TaxRate { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public virtual LOCATION LOCATION { get; set; }
        public virtual TAX_TYPE TAX_TYPE { get; set; }
    }
}
