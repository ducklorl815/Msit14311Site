using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Msit14311Site.Controllers
{
    public class AController : Controller
    {
        public IActionResult Index()
        {
            //return Content("Hello babacoco");
            return Content("babacoco ,Hello","text/html",System.Text.Encoding.UTF8);
        }
   
        public IActionResult First()
        {
            return View();

        }
        public IActionResult Second()
        {
            return View();

        }
    }
}
