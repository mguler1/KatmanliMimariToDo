using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Areas.Admin.Models;

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class IsEmriController : Controller
    {
        private readonly IGorevService _gorevService;
        private readonly IRaporService _raporService;
        private readonly UserManager<AppUser> _userManager;
        public IsEmriController(IGorevService gorevService, UserManager<AppUser> userManager,IRaporService raporService)
        {
            _gorevService = gorevService;
            _userManager = userManager;
            _raporService = raporService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "isemri";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var gorevler = _gorevService.GetirTumTablolar(x => x.AppUserId == user.Id && !x.Durum);
            List<GorevListAllViewModel> models = new List<GorevListAllViewModel>();
            foreach (var item in gorevler)
            {
                GorevListAllViewModel model = new GorevListAllViewModel();
                model.Id = item.Id;
                model.Aciklama = item.Aciklama;
                model.Aciliyet = item.Aciliyet;
                model.Ad = item.Ad;
                model.AppUser = item.AppUser;
                model.Raporlar = item.Raporlar;
                model.OlusturulmaTarih = item.OlusturulmaTarih;
                models.Add(model);
            }
            return View(models);
        }
        public IActionResult EkleRapor(int id)
        {
            TempData["Active"] = "isemri";
           var gorev= _gorevService.GetirAciliyetId(id);
            RaporAddViewModel model = new RaporAddViewModel();
            model.GorevId = id;
            model.Gorev = gorev;
            return View(model);
        }
        [HttpPost]
        public IActionResult EkleRapor(RaporAddViewModel model)
        {
            TempData["Active"] = "isemri";
            if (ModelState.IsValid)
            {
                _raporService.Kaydet(new Rapor()
                {

                    GorevId = model.GorevId,
                    Detay = model.Detay,
                    Tanim=model.Tanim
                });
                return RedirectToAction("Index");
            }
          
            return View(model);
        }
    }
}
