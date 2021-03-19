using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YskProje.Todo.DTO.DTOs.AppUserDto;
using YSKProje.ToDo.Entities.Concrete;


namespace YSKProje.ToDo.Web.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public Wrapper(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {

            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            AppUserListDto model = new AppUserListDto();
            model.Id = user.Id;
            model.Name = user.Name;
            model.SurName = user.Surname;
            model.Email = user.Email;
            var roles = _userManager.GetRolesAsync(user).Result;
            if (roles.Contains("Admin"))
            {
                return View(model);
            }
            return View("Member", model);
        }
    }
}