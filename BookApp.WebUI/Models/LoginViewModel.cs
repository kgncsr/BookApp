﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email zorunlu")]
        [Display(Name = "Email Adresiniz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Şifreniz")]
        [Required(ErrorMessage ="Şifre zorunlu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
