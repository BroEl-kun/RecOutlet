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
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please provide a Last Name.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please provide a Position.")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Please provide a Username.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please provide a Password.")]
        public string Password { get; set; }
        public string PasswordSalt{ get; set; }
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
        public virtual ICollection<LOCATION> LOCATIONs { get; set; }
        public virtual ICollection<PURCHASE_ORDER> PURCHASE_ORDER { get; set; }
        public virtual ICollection<STORE_TRANSACTION> STORE_TRANSACTION { get; set; }
    }
}
