using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Entitiy
{
    public class AppUser : IdentityUser
    {
        public string Genre { get; set; }
    }
}
