﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YskProje.Todo.DTO.DTOs.AppUserDto;
using YSKProje.ToDo.Entities.Concrete;


namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class ProfilController : Controller
    {
      private readonly  UserManager<AppUser> _userManager;
      private readonly  IMapper _mapper;
        public ProfilController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task< IActionResult> Index()
        {
            TempData["Active"] = "profil";
            var appuser= await  _userManager.FindByNameAsync(User.Identity.Name);
           
            return View(_mapper.Map<AppUserListDto>(appuser));
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDto model)
        {
            if (ModelState.IsValid)
            {
                var guncelenecekKullanici = _userManager.Users.FirstOrDefault(x => x.Id == model.Id);
                guncelenecekKullanici.Name = model.Name;
                guncelenecekKullanici.Surname = model.SurName;
                guncelenecekKullanici.Email = model.Email;
                await _userManager.UpdateAsync(guncelenecekKullanici);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
