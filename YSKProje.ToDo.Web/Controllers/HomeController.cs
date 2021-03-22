using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YskProje.Todo.DTO.DTOs.AppUserDto;
using YSKProje.ToDo.Business.Interfaces;
using YSKProje.ToDo.Entities.Concrete;
using YSKProje.ToDo.Web.Models;

namespace YSKProje.ToDo.Web.Controllers
{
    public class HomeController : Controller
    {
       private readonly IGorevService _gorevService;
       private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController(IGorevService gorevService, UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _gorevService = gorevService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GirisYap(AppUserSigInDto model)
        {
            if (ModelState.IsValid)
            {
             var user=  await _userManager.FindByNameAsync(model.UserName);
                if (user!=null)
                {
                var identityResult=  await  _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                    if (identityResult.Succeeded)
                    {
                      var roller= await _userManager.GetRolesAsync(user);
                      
                        if (roller.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                    }
                }
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
            }
            return View("Index",model);
        }
        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> KayitOl(AppUserAddDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname
                };
                
             var result= await  _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                 var addroleResult= await _userManager.AddToRoleAsync(user, "Member");
                    if (addroleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> CikisYap()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        public IActionResult StatusCode(int? code)
        {
            if (code==404)
            {
                ViewBag.Code = code;
                ViewBag.Message = "Sayfa Bulunamadı";
            }
           
            return View();
        }
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
          ViewBag.path=exceptionHandlerPathFeature.Path;
          ViewBag.message=exceptionHandlerPathFeature.Error.Message;
           
            return View();
        }
    }
}