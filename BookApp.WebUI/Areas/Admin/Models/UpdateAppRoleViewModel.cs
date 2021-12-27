using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Areas.Admin.Models
{
    public class UpdateAppRoleViewModel
    {
        public UpdateAppRoleViewModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        [Required(ErrorMessage ="İsim Alanı bos gecilemez.")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }

    }
}
