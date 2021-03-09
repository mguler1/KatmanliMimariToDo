using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YSKProje.ToDo.Web.Areas.Admin.Controllers
{
    public class GorevController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            TempData["Active"] = "gorev";
            return View();
        }
    }
}
