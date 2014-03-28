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
        [MaxLength(100, ErrorMessage = "The name you entered is too long.")]
        public string VendorName { get; set; }

        [MaxLength(100, ErrorMessage = "The name you entered is too long.")]
        public string ContactName { get; set; }

        [Required(ErrorMessage="Please provide the phone number of the vendor or contact person.")]
        [MaxLength(15, ErrorMessage = "The phone number you entered is too long.")]
        public string ContactPhone { get; set; }

        [MaxLength(15, ErrorMessage = "The fax number you entered is too long.")]
        public string ContactFax { get; set; }

        [MaxLength(15, ErrorMessage = "The phone number you entered is too long.")]
        public string AltPhone { get; set; }

        [MaxLength(50, ErrorMessage = "The address you entered is too long.")]
        public string VendorAddress { get; set; }

        [MaxLength(50, ErrorMessage = "The address you entered is too long.")]
        public string VendorAddress2 { get; set; }

        [MaxLength(50, ErrorMessage = "The city you entered is too long.")]
        public string VendorCity { get; set; }
        
        [MaxLength(2,ErrorMessage="Enter the two-letter state code.")]
        public string VendorState { get; set; }

        [MaxLength(10, ErrorMessage = "The zip you entered is too long.")]
        public string VendorZip { get; set; }

        [MaxLength(50, ErrorMessage = "The country you entered is too long.")]
        public string VendorCountry { get; set; }

        [MaxLength(100, ErrorMessage = "The website you entered is too long.")]
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