﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleLoginSystem.Models
{
    public class UserModel
    {
        [Required]
        [StringLength(150)]
        [Display(Name="Username: ")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength=6)]
        [Display(Name="Password: ")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        public string PasswordSalt { get; set; }
    }
}