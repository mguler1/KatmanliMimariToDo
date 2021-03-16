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

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class IsEmriController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IGorevService _gorevService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDosyaService _dosyaService;
        public IsEmriController(IAppUserService appUserService, IGorevService gorevService, UserManager<AppUser> userManager, IDosyaService dosyaService)
        {
            _appUserService = appUserService;
            _gorevService = gorevService;
            _userManager = userManager;
            _dosyaService = dosyaService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "isemri";
            //var model= _appUserService.GetirAdminOlmayanlar();
            List<Gorev> gorevler = _gorevService.GetirTumTablolar();
            List<GorevListAllViewModel> models = new List<GorevListAllViewModel>();
            foreach (var item in gorevler)
            {
                GorevListAllViewModel model = new GorevListAllViewModel();
                model.Id = item.Id;
                model.Aciklama = item.Aciklama;
                model.Aciliyet = item.Aciliyet;
                model.Ad = item.Ad;
                model.AppUser = item.AppUser;
                model.OlusturulmaTarih = item.OlusturulmaTarih;
                model.Raporlar = item.Raporlar;
                models.Add(model);
            }
            return View(models);
        }
        public IActionResult AtaPersonel(int id, string s, int sayfa = 1)
        {
            TempData["Active"] = "isemri";
            ViewBag.AktifSayfa = sayfa;

            ViewBag.Aranan = s;
            int toplamSayfa;
            var gorev = _gorevService.GetirAciliyetId(id);
            var personeller = _appUserService.GetirAdminOlmayanlar(out toplamSayfa, s, sayfa);
            ViewBag.ToplamSayfa = toplamSayfa;
            List<AppUserListViewModel> appUserListModel = new List<AppUserListViewModel>();
            foreach (var item in personeller)
            {
                AppUserListViewModel model = new AppUserListViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.SurName = item.Surname;
                model.Email = item.Email;
                appUserListModel.Add(model);
            }
            ViewBag.Personeller = appUserListModel;
            GorevListViewModel gorevmodel = new GorevListViewModel();
            gorevmodel.Id = gorev.Id;
            gorevmodel.Ad = gorev.Ad;
            gorevmodel.Aciklama = gorev.Aciklama;
            gorevmodel.Aciliyet = gorev.Aciliyet;
            gorevmodel.OlusturulmaTarih = gorev.OlusturulmaTarih;
            return View(gorevmodel);
        }
        [HttpPost]
        public IActionResult AtaPersonel(PersonelGorevlendirViewModel model)
        {
            var guncellenecekgorev = _gorevService.GetirIdile(model.GorevId);
            guncellenecekgorev.AppUserId = model.PersonelId;
            _gorevService.Guncelle(guncellenecekgorev);
            return RedirectToAction("Index");
        }
        public IActionResult GorevlendirPersonel(PersonelGorevlendirViewModel model)
        {
            TempData["Active"] = "isemri";
            var user = _userManager.Users.FirstOrDefault(x => x.Id == model.PersonelId);
            var gorev = _gorevService.GetirAciliyetId(model.GorevId);
            AppUserListViewModel userModel = new AppUserListViewModel();
            userModel.Id = user.Id;
            userModel.Name = user.Name;
            userModel.SurName = user.Surname;
            userModel.Email = user.Email;

            GorevListViewModel gorevModel = new GorevListViewModel();
            gorevModel.Id = gorev.Id;
            gorevModel.Aciklama = gorev.Aciklama;
            gorevModel.Aciliyet = gorev.Aciliyet;
            gorevModel.Ad = gorev.Ad;

            PersonelGorevlendirListViewModel personelGorevlendirModel = new PersonelGorevlendirListViewModel();
            personelGorevlendirModel.AppUser = userModel;
            personelGorevlendirModel.Gorev = gorevModel;
            return View(personelGorevlendirModel);
        }
        public IActionResult Detaylandir(int id)
        {
            TempData["Active"] = "isemri";
            var gorev = _gorevService.GetirRaporlarIdIle(id);
            GorevListAllViewModel model = new GorevListAllViewModel();
            model.Id = gorev.Id;
            model.Raporlar = gorev.Raporlar;
            model.Ad = gorev.Ad;
            model.Aciklama = gorev.Aciklama;
            model.AppUser = gorev.AppUser;
            return View(model);
        }
           public IActionResult GetirExcel(int id)
        {
            return File(_dosyaService.AktarExcel(_gorevService.GetirRaporlarIdIle(id).Raporlar), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }

        public IActionResult GetirPdf(int id)
        {
            var path = _dosyaService.AktarPdf(_gorevService.GetirRaporlarIdIle(id).Raporlar);
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}