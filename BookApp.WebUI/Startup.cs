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


            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 3;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;//0-9
            })
            .AddPasswordValidator<CustomPasswordValidator>()
            .AddEntityFrameworkStores<IdentityContext>();

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IBookRepository, EfBookRepository>();
            services.AddScoped<IGenreRepository, EfGenreRepository>();
            services.AddScoped<IWriterRepository, EfWriterRepository>();
            services.AddScoped<IContactRepository, EfContactRepository>();

            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<IGenreService, GenreManager>();
            services.AddScoped<IWriterService, WriterManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddControllersWithViews();


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePagesWithReExecute("/ErrorPage/ErrorNotFound", "?code={0}");
            app.UseRouting();
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
