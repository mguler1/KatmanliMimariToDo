﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YskProje.Todo.DTO.DTOs.AciliyetDto;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Areas.Admin.Models;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AciliyetController : Controller
    {
       private readonly IAciliyetService _aciliyetService;
        private readonly IMapper _mapper;
        public AciliyetController(IAciliyetService aciliyetService, IMapper mapper)
        {
         _aciliyetService = aciliyetService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "aciliyet";  
            return View(_mapper.Map<List<AciliyetListDto>>(_aciliyetService.GetirHepsi()));
        }
        public IActionResult EkleAciliyet()
        {
            TempData["Active"] = "aciliyet";
            return View(new AciliyetAddDto());
        }
        [HttpPost]
        public IActionResult EkleAciliyet(AciliyetAddDto model)
        {
            TempData["Active"] = "aciliyet";
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
            TempData["Active"] = "aciliyet";
            return View(_mapper.Map<AciliyetUpdateDto>(_aciliyetService.GetirIdile(id)));
        }
        [HttpPost]
        public IActionResult GuncelleAciliyet(AciliyetUpdateDto model)
        {
            TempData["Active"] = "aciliyet";
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

