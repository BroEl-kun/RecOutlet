using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models
{
    public partial class EMPLOYEE
    {
        public EMPLOYEE()
        {
            this.INVOICEs = new List<INVOICE>();
            this.LOCATIONs = new List<LOCATION>();
            this.PURCHASE_ORDER = new List<PURCHASE_ORDER>();
            this.STORE_TRANSACTION = new List<STORE_TRANSACTION>();
        }

        public short EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        [Required]
        [Display(Name = "Username: ")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(4, MinimumLength = 4)]
        [Display(Name = "PIN: ")]
        public string PIN { get; set; }
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
        public virtual ICollection<LOCATION> LOCATIONs { get; set; }
        public virtual ICollection<PURCHASE_ORDER> PURCHASE_ORDER { get; set; }
        public virtual ICollection<STORE_TRANSACTION> STORE_TRANSACTION { get; set; }
    }
}
