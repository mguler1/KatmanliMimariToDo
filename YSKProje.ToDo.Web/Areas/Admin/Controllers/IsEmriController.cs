using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YskProje.Todo.DTO.DTOs.AppUserDto;
using YskProje.Todo.DTO.DTOs.GorevDto;
using YskProje.Todo.DTO.DTOs.PersonelDto;
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
        private readonly IMapper _mapper;
        public IsEmriController(IAppUserService appUserService, IGorevService gorevService, UserManager<AppUser> userManager, IDosyaService dosyaService, IMapper mapper)
        {
            _appUserService = appUserService;
            _gorevService = gorevService;
            _userManager = userManager;
            _dosyaService = dosyaService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "isemri";
      
            return View(_mapper.Map<List<GorevAllListDto>>(_gorevService.GetirTumTablolar()));
        }
        public IActionResult AtaPersonel(int id, string s, int sayfa = 1)
        {
            TempData["Active"] = "isemri";

            ViewBag.AktifSayfa = sayfa;

            ViewBag.Aranan = s;

            var personeller = _mapper.Map<List<AppUserListDto>>(_appUserService.GetirAdminOlmayanlar(out int toplamSayfa, s, sayfa));
            ViewBag.ToplamSayfa = toplamSayfa;

            ViewBag.Personeller = personeller;

            return View(_mapper.Map<GorevListDto>(_gorevService.GetirAciliyetId(id)));
        }
        [HttpPost]
        public IActionResult AtaPersonel(PersonelGorevlendirDto model)
        {
            var guncellenecekgorev = _gorevService.GetirIdile(model.GorevId);
            guncellenecekgorev.AppUserId = model.PersonelId;
            _gorevService.Guncelle(guncellenecekgorev);
            return RedirectToAction("Index");
        }
        public IActionResult GorevlendirPersonel(PersonelGorevlendirDto model)
        {

            TempData["Active"] = "isemri";

            PersonelGorevlendirListDto personelGorevlendirModel = new PersonelGorevlendirListDto
            {
                AppUser = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(I => I.Id == model.PersonelId)),
                Gorev = _mapper.Map<GorevListDto>(_gorevService.GetirAciliyetId(model.GorevId))
            };
            return View(personelGorevlendirModel);
        }
        public IActionResult Detaylandir(int id)
        {
            TempData["Active"] = "isemri";
            return View(_mapper.Map<GorevAllListDto>(_gorevService.GetirRaporlarIdIle(id)));
          
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