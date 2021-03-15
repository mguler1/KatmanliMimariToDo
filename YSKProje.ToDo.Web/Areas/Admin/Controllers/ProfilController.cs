using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Areas.Admin.Models;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProfilController : Controller
    {
      private readonly  UserManager<AppUser> _userManager;
        public ProfilController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task< IActionResult> Index()
        {
            TempData["Active"] = "profil";
            var appuser= await  _userManager.FindByNameAsync(User.Identity.Name);
            AppUserListViewModel model = new AppUserListViewModel();
            model.Id = appuser.Id;
            model.Name = appuser.Name;
            model.SurName = appuser.Surname;
            model.Email = appuser.Email;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserListViewModel model)
        {
            if (ModelState.IsValid)
            {
                var guncelenecekKullanici = _userManager.Users.FirstOrDefault(x => x.Id == model.Id);
                guncelenecekKullanici.Name = model.Name;
                guncelenecekKullanici.Surname = model.SurName;
                guncelenecekKullanici.Email = model.Email;
                await _userManager.UpdateAsync(guncelenecekKullanici);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
