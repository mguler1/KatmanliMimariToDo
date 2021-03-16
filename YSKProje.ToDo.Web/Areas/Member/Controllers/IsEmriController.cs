﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Web.Areas.Admin.Models;

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class IsEmriController : Controller
    {
        private readonly IGorevService _gorevService;
        public IsEmriController(IGorevService gorevService)
        {
            _gorevService = gorevService;
        }
        public IActionResult Index(int id)
        {
          var  gorevler=  _gorevService.GetirTumTablolar(x => x.AppUserId == id &&! x.Durum);
            List< GorevListAllViewModel> models = new List< GorevListAllViewModel>();
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
    }
}
