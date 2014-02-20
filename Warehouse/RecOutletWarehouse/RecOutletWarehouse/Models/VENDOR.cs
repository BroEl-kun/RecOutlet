using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models
{
    public partial class VENDOR
    {
        public VENDOR() {
            this.PRODUCT_LINE = new List<PRODUCT_LINE>();
            this.PURCHASE_ORDER = new List<PURCHASE_ORDER>();
        }

        public short VendorID { get; set; }

        [Required(ErrorMessage="Please provide a vendor name.")]
        public string VendorName { get; set; }

        public string ContactName { get; set; }

        [Required(ErrorMessage="Please provide the phone number of the vendor or contact person.")]
        public string ContactPhone { get; set; }

        public string ContactFax { get; set; }
        
        public string AltPhone { get; set; }
        
        public string VendorAddress { get; set; }
        
        [MaxLength(2,ErrorMessage="Enter the two-letter state code.")]
        public string VendorState { get; set; }
        
        public string VendorZip { get; set; }
        
        public string VendorWebsite { get; set; }

        // Properties ignored by JSON; [JsonIgnore] required to keep WebAPI controllers working
        // (Because JSON can't assign values to these types of variables and will crash if you
        // try to assign these values to JSON properties)
        [JsonIgnore]
        public virtual ICollection<PRODUCT_LINE> PRODUCT_LINE { get; set; }

        [JsonIgnore]
        public virtual ICollection<PURCHASE_ORDER> PURCHASE_ORDER { get; set; }
    }
}