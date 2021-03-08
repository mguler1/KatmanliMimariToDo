﻿using Microsoft.AspNetCore.Mvc;
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
    public class AciliyetController : Controller
    {
       private readonly IAciliyetService _aciliyetService;
        public AciliyetController(IAciliyetService aciliyetService)
        {
         _aciliyetService = aciliyetService;
        }
        public IActionResult Index()
        {
            List<Aciliyet> aciliyetler = _aciliyetService.GetirHepsi();

            List<AciliyetListViewModel> model = new List<AciliyetListViewModel>();
            foreach (var item in aciliyetler)
            {
                AciliyetListViewModel aciliyetmodel = new AciliyetListViewModel();
                aciliyetmodel.Id = item.Id;
                aciliyetmodel.Tanim = item.Tanim;
                model.Add(aciliyetmodel);
            }
            return View(model);
        }
        public IActionResult EkleAciliyet()
        {
            
            return View(new AciliyetAddViewModel());
        }
        [HttpPost]
        public IActionResult EkleAciliyet(AciliyetAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _aciliyetService.Kaydet(new Aciliyet()
                {
                    Tanim = model.Tanim
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult GuncelleAciliyet(int id)
        {
           var aciliyet= _aciliyetService.GetirIdile(id);
            AciliyetUpdateViewModel model = new AciliyetUpdateViewModel
            {
                Id = aciliyet.Id,
                Tanim = aciliyet.Tanim
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult GuncelleAciliyet(AciliyetUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {

          
            _aciliyetService.Guncelle(new Aciliyet
            {
                Id = model.Id,
                Tanim = model.Tanim
            });
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}

