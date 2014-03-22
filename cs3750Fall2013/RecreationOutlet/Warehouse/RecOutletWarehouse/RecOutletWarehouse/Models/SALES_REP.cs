using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models
{
    public partial class SALES_REP
    {
        public SALES_REP() {
            this.PRODUCT_LINE = new List<PRODUCT_LINE>();
        }

        public short RepID { get; set; }

        [Required(ErrorMessage="Please provide the rep's first name.")]
        public string SalesRepFirstName { get; set; }

        [Required(ErrorMessage = "Please provide the rep's last name.")]
        public string SalesRepLastName { get; set; }

        [Required(ErrorMessage = "Please provide the rep's phone number.")]
        [MaxLength(15,ErrorMessage= "The phone number you entered is too long.")]
        public string SalesRepPhone { get; set; }
        
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid e-mail address")]
        public string SalesRepEmail { get; set; }

        [JsonIgnore]
        public virtual ICollection<PRODUCT_LINE> PRODUCT_LINE { get; set; }
    }
}
