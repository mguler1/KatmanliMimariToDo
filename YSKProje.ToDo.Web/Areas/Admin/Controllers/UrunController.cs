using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YskProje.Todo.DTO.DTOs.UrunDto;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UrunController : Controller
    {
        private readonly IUrunService _urunService;
        private readonly IMapper _mapper;
        public UrunController(IUrunService urunService, IMapper mapper)
        {
            _urunService = urunService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "urunler";
            return View(_mapper.Map<List<UrunListDto>>(_urunService.GetirHepsi()));
        }
        public IActionResult EkleUrun()
        {
            TempData["Active"] = "urunler";
            return View(new UrunAddDto());
        }
        [HttpPost]
        public IActionResult EkleUrun(UrunAddDto model)
        {
            TempData["Active"] = "urunler";
            if (ModelState.IsValid)
            {
                _urunService.Kaydet(new Urun()
                {
                    UrunAdi = model.UrunAdi,
                    UrunAciklama = model.UrunAciklama,
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult GuncelleUrun(int id)
        {
            TempData["Active"] = "urunler";
            return View(_mapper.Map<UrunUpdateDto>(_urunService.GetirIdile(id)));
        }
        [HttpPost]
        public IActionResult GuncelleUrun(UrunUpdateDto model)
        {
            TempData["Active"] = "urunler";
            if (ModelState.IsValid)
            {
                _urunService.Guncelle(new Urun
                {
                    Id = model.Id,
                    UrunAdi = model.UrunAdi,
                    UrunAciklama = model.UrunAciklama
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
