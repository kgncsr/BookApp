using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Business.Abstract;
using BookApp.Business.Concrete;
using BookApp.DataAccess.Abstract;
using BookApp.DataAccess.Concrete.EntityFramework;
using BookApp.WebUI.Context;
using Microsoft.EntityFrameworkCore;
using BookApp.WebUI.Entitiy;
using BookApp.WebUI.Entity;
using BookApp.WebUI.CustomValidator;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace BookApp.WebUI
{
    public class Startup
    {


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>(opt =>
            {
                opt.UseSqlServer("server = DESKTOP-R8THRJK;database = Bookdb; integrated security = true;");
            });



            //dependency 
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IBookRepository, EfBookRepository>();
            services.AddScoped<IGenreRepository, EfGenreRepository>();
            services.AddScoped<IWriterRepository, EfWriterRepository>();
            services.AddScoped<IContactRepository, EfContactRepository>();

            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<IGenreService, GenreManager>();
            services.AddScoped<IWriterService, WriterManager>();
            services.AddScoped<IContactService, ContactManager>();

            //Identity
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;//0-9
                opt.Lockout.MaxFailedAccessAttempts = 3;
            })
            .AddPasswordValidator<CustomPasswordValidator>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddErrorDescriber<MyIdentityErrorDescriber>();
            services.AddControllersWithViews();

            CookieBuilder cookieBuilder = new CookieBuilder();
            cookieBuilder.Name = "BookApp";
            cookieBuilder.HttpOnly = false;
            cookieBuilder.SameSite = SameSiteMode.Lax;
            cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest;


            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/Account/login";
                opt.LogoutPath = "/Home/Index";
                opt.Cookie = cookieBuilder;
                opt.SlidingExpiration = true;
                opt.ExpireTimeSpan = System.TimeSpan.FromDays(30);

            });

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePagesWithReExecute("/ErrorPage/ErrorNotFound", "?code={0}");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
