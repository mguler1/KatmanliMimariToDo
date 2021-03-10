using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Models;

namespace YSKProje.ToDo.Web.Controllers
{
    public class HomeController : Controller
    {
       private readonly IGorevService _gorevService;
       private readonly UserManager<AppUser> _userManager;
        public HomeController(IGorevService gorevService, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _gorevService = gorevService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> KayitOl(AppUserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname
                };
                
             var result= await  _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                 var addroleResult= await _userManager.AddToRoleAsync(user, "Member");
                    if (addroleResult.Succeeded)
                    {
                        return RedirectToAction("GirisYap");
                    }
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}