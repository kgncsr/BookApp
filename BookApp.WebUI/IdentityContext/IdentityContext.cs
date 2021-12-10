using BookApp.WebUI.Entitiy;
using BookApp.WebUI.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookApp.WebUI.Context
{
    public class IdentityContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }
    }
}
