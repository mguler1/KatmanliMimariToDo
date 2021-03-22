using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using YskProje.Todo.DTO.DTOs.AciliyetDto;
using YskProje.Todo.DTO.DTOs.AppUserDto;
using YskProje.Todo.DTO.DTOs.GorevDto;
using YskProje.Todo.DTO.DTOs.RaporDto;
using YSKProje.ToDo.Business.Concrete;
using YSKProje.ToDo.Business.DiContainer;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Business.ValidationRules.FluentValidation;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.CustomCollectionExtansions;

namespace YSKProje.ToDo.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContainer();//business katmanýnda oluþturduðum yapý
            services.AddDbContext<TodoContext>();
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<TodoContext>();

            //cookie config
            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "IsTakipCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays( 20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddValidator();//oluþturduðum class
            services.AddControllersWithViews().AddFluentValidation();
        }

    
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole>roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IdentityInitilaizer.SeedData(userManager,roleManager).Wait();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                    );
               
            });
        }
    }
}
