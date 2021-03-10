using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Business.Interfaces;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    public class IsEmriController : Controller
    {
        IAppUserService _appUserService;
        public IsEmriController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            TempData["Active"]="isemri";
            return View(_appUserService.GetirAdminOlmayanlar());
        }
    }
}
