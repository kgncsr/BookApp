using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Models
{
    public class UserViewModel
    {
        [Display(Name = "Kullanıcı Adınız")]
        [Required(ErrorMessage = "UserName zorunludur.")]
        public string UserName { get; set; }
        [Display(Name = "Telefon No")]
        public string Phone { get; set; }
        [Display(Name = "Email Adresiniz")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Doğru format giriniz")]
        [Required(ErrorMessage = "Email zorunludur.")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="Şifreniz")]
        [Required(ErrorMessage = "Şifre zorunludur.")]
        public string Password { get; set; }
    }
}
