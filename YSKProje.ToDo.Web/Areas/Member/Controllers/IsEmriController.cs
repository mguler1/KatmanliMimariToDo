using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YskProje.Todo.DTO.DTOs.GorevDto;
using YskProje.Todo.DTO.DTOs.RaporDto;
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
        private readonly IMapper _mapper;
        public IsEmriController(IGorevService gorevService, UserManager<AppUser> userManager,IRaporService raporService, IMapper mapper)
        {
            _gorevService = gorevService;
            _userManager = userManager;
            _raporService = raporService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "isemri";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
             
            return View(_mapper.Map<List<GorevAllListDto>>(_gorevService.GetirTumTablolar(x => x.AppUserId == user.Id && !x.Durum)));
        }
        public IActionResult EkleRapor(int id)
        {
            TempData["Active"] = "isemri";
           var gorev= _gorevService.GetirAciliyetId(id);
            RaporAddDto model = new RaporAddDto();
            model.GorevId = id;
            model.Gorev = gorev;
            return View(model);
        }
        [HttpPost]
        public IActionResult EkleRapor(RaporAddDto model)
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
        public IActionResult GuncelleRapor(int id)
        {
            TempData["Active"] = "isemri";
            var rapor= _raporService.GetirGorevileId(id);
            RaporUpdateDto model = new RaporUpdateDto();
            model.Id = rapor.Id;
            model.Tanim = rapor.Tanim;
            model.Detay = rapor.Detay;
            model.Gorev = rapor.Gorev;
            model.GorevId = rapor.GorevId;
            return View(model);
        }
        [HttpPost]
        public IActionResult GuncelleRapor(RaporUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var guncellenecekrapor = _raporService.GetirIdile(model.Id);
                guncellenecekrapor.Tanim = model.Tanim;
                guncellenecekrapor.Detay = model.Detay;
                _raporService.Guncelle(guncellenecekrapor);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult TamamlananGorev(int gorevId)
        {
          var guncellenecekGorev =_gorevService.GetirIdile(gorevId);
            guncellenecekGorev.Durum = true;
            _gorevService.Guncelle(guncellenecekGorev);
            return Json(null);
        }
    }
}
