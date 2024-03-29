﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YskProje.Todo.DTO.DTOs.GorevDto;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Controllers;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class GorevController : Controller
    {

        private readonly IGorevService _gorevService;
        private readonly IAciliyetService _aciliyetService;
        private readonly IUrunService _urunService;
        private readonly IMapper _mapper;
        public GorevController(IGorevService gorevService, IAciliyetService aciliyetService, IUrunService urunService, IMapper mapper)
        {
            _mapper = mapper;
            _gorevService = gorevService;
            _aciliyetService = aciliyetService;
            _urunService = urunService;
        }
        public IActionResult Index()
        {
            
            return View(_mapper.Map<List<GorevListDto>>(_gorevService.GetirAciliyetIleTamamlanmayan()));

        }

        public IActionResult EkleGorev()
        {

            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim");
            ViewBag.Urun = new SelectList(_urunService.GetirHepsi(), "Id", "UrunAdi");
            TempData["Active"] = "gorev";
            return View(new GorevAddDto());
        }
        [HttpPost]
        public IActionResult EkleGorev(GorevAddDto model)
        {
            TempData["Active"] = "gorev";
            if (ModelState.IsValid)
            {
                _gorevService.Kaydet(new Gorev()
                {
                    Aciklama = model.Aciklama,
                    Ad = model.Ad,
                    AciliyetId = model.AciliyetId,
                    UrunId=model.UrunId
                });
                return RedirectToAction("Index");
            }
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim");
            ViewBag.Urun = new SelectList(_urunService.GetirHepsi(), "Id", "UrunAdi");
            return View(model);

        }
        public IActionResult GuncelleGorev(int id)
        {
            TempData["Active"] = "gorev";
            var gorev = _gorevService.GetirIdile(id);
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim", gorev.AciliyetId);
            ViewBag.Urun = new SelectList(_urunService.GetirHepsi(), "Id", "UrunAdi");
            return View(_mapper.Map<GorevUpdateDto>(_gorevService.GetirIdile(id)));
        }

        [HttpPost]
        public IActionResult GuncelleGorev(GorevUpdateDto model)
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
            ViewBag.Aciliyetler = new SelectList(_aciliyetService.GetirHepsi(), "Id", "Tanim", model.AciliyetId);
            ViewBag.Urun = new SelectList(_urunService.GetirHepsi(), "Id", "UrunAdi");
            return View(model);
        }
        public IActionResult SilGorev(int id )
        {
            _gorevService.Sil(new Gorev { Id = id });
            return Json(null);
        }
    }

}