using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models
{
    public partial class EMPLOYEE
    {
        //TODO: add new field in database --> PINSalt

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
        [Display(Name = "PIN: ")]
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
        public virtual ICollection<LOCATION> LOCATIONs { get; set; }
        public virtual ICollection<PURCHASE_ORDER> PURCHASE_ORDER { get; set; }
        public virtual ICollection<STORE_TRANSACTION> STORE_TRANSACTION { get; set; }
    }
}
