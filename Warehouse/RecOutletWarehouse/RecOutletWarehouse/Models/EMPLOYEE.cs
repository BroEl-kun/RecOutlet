using System;
using System.Collections.Generic;
using Newtonsoft.Json;
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

        [Required(ErrorMessage = "Please provide a First Name.")]
        [MaxLength(50, ErrorMessage = "Max Legth of 50 Characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please provide a Last Name.")]
        [MaxLength(50, ErrorMessage = "Max Legth of 50 Characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please provide a Position.")]
        [MaxLength(50, ErrorMessage = "Max Legth of 50 Characters")]
        public string Position { get; set; }
        [Display(Name = "Username: ")]
        [Required]
        [MaxLength(50, ErrorMessage = "Max Legth of 50 Characters")]
        public string Username { get; set; }
        [Required(ErrorMessage="Please provide a password.")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string PasswordSalt{ get; set; }
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
        public virtual ICollection<LOCATION> LOCATIONs { get; set; }
        public virtual ICollection<PURCHASE_ORDER> PURCHASE_ORDER { get; set; }
        public virtual ICollection<STORE_TRANSACTION> STORE_TRANSACTION { get; set; }
    }
}
