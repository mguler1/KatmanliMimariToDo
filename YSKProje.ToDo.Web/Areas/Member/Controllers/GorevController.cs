using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YskProje.Todo.DTO.DTOs.GorevDto;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Areas.Admin.Models;

namespace YSKProje.ToDo.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class GorevController : Controller
    {
        private readonly IGorevService _gorevService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public GorevController(IGorevService gorevService, UserManager<AppUser> userManager,IMapper mapper)
        {
            _gorevService = gorevService;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task< IActionResult> Index(int aktifSatfa=1)
        {
            TempData["Active"] = "gorev";
            var user=  await _userManager.FindByNameAsync(User.Identity.Name);
            int toplamsayfa;
         
           
           var gorevler= _mapper.Map<List<GorevAllListDto>>(_gorevService.GetirTumTablolarlaTamamlanmayan(out toplamsayfa, user.Id, aktifSatfa));
            ViewBag.ToplamSayfa = toplamsayfa;
            ViewBag.AktifSayfa = aktifSatfa;
            return View(gorevler);
        }
    }
}
