using BookApp.WebUI.Entitiy;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.CustomValidator 
{
    public class CustomPasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            List<IdentityError> identityErrors = new();

            if (password.ToLower().Contains("12345"))
            {
                identityErrors.Add(new IdentityError() { Code = "Contains12345", Description = "password field cannot be consecutive" });
            }

            if (password.ToLower().Contains(user.UserName))
            {
                identityErrors.Add(new IdentityError() { Code = "ContainsUserNmae", Description = "password field cannot be userName" });
            }


            if (identityErrors.Count()==0)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(identityErrors.ToArray()));
            }
        }
    }
}
