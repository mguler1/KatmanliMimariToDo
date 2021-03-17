using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YSKProje.ToDo.Business.Concrete;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class HomeController : Controller
    {
     private readonly   IRaporService _raporService;
     private readonly   IGorevService _gorevService;
     private readonly   UserManager<AppUser> _userManager;
        public HomeController(IRaporService raporService, UserManager<AppUser> userManager,IGorevService gorevService)
        {
            _raporService = raporService;
            _userManager = userManager;
            _gorevService = gorevService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.RaporSayisi = _raporService.RaporSayisiAppUserId(user.Id);
            ViewBag.TamamlananGorevSayisi = _gorevService.GorevSayisiTamamlananAppUserId(user.Id);
            return View();
        }
    }
}