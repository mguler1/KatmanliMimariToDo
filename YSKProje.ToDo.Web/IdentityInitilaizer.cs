using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web
{
    public static class IdentityInitilaizer
    {
        public static async Task SeedData (UserManager<AppUser> 
            userManger ,RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole==null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }
            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }
            var adminUser = await userManger.FindByNameAsync("Güler");
            if (adminUser ==null)
            {
                AppUser user = new AppUser
                {
                    Name="Mehti",
                    Surname="GÜLER",
                    Email="deneme@gmail.com",
                    UserName="Güler"
                };
                await userManger.CreateAsync(user," Deneme1.");
            }
        }
    }
}
