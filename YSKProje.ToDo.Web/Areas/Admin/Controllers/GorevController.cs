using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Areas.Admin.Models;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class GorevController : Controller
    {

        private readonly IGorevService _gorevService;
        private readonly IAciliyetService _aciliyetService;
        public GorevController(IGorevService gorevService, IAciliyetService aciliyetService)
        {
            _gorevService = gorevService;
            _aciliyetService = aciliyetService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "gorev";
            List<Gorev> gorevler = _gorevService.GetirAciliyetIleTamamlanmayan();
            List<GorevListViewModel> models = new List<GorevListViewModel>();
            foreach (var item in gorevler)
            {
                GorevListViewModel model = new GorevListViewModel
                {
                    Aciklama = item.Aciklama,
                    Aciliyet = item.Aciliyet,
                    AciliyetId = item.AciliyetId,
                    Ad = item.Ad,
                    Durum = item.Durum,
                    Id = item.Id,
                    OlusturulmaTarih = item.OlusturulmaTarih
                };
                models.Add(model);
            }
            return View(models);

        }

        public IActionResult EkleGorev()
        {

            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim");
            TempData["Active"] = "gorev";
            return View(new GorevAddViewModel());
        }
        [HttpPost]
        public IActionResult EkleGorev(GorevAddViewModel model)
        {
            TempData["Active"] = "gorev";
            if (ModelState.IsValid)
            {
                _gorevService.Kaydet(new Gorev()
                {
                    Aciklama = model.Aciklama,
                    Ad = model.Ad,
                    AciliyetId = model.AciliyetId,
                });
                return RedirectToAction("Index");
            }
            return View(model);

        }
        public IActionResult GuncelleGorev(int id)
        {
            TempData["Active"] = "gorev";
            var gorev = _gorevService.GetirIdile(id);
            GorevUpdateViewModel model = new GorevUpdateViewModel()
            {
                Id = gorev.Id,
                Ad = gorev.Ad,
                Aciklama = gorev.Aciklama,
                AciliyetId = gorev.AciliyetId,
            };
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim", gorev.AciliyetId);
            return View(model);
        }

        [HttpPost]
        public IActionResult GuncelleGorev(GorevUpdateViewModel model)
        {
            TempData["Active"] = "gorev";
            if (ModelState.IsValid)
            {
                _gorevService.Guncelle(new Gorev
                {
                    Id = model.Id,
                    Ad = model.Ad,
                    Aciklama = model.Aciklama,
                    AciliyetId = model.AciliyetId,
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult SilGorev(int id )
        {
            _gorevService.Sil(new Gorev { Id = id });
            return Json(null);
        }
    }

}