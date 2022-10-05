using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Msit14311Site.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Msit14311Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Address()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult action(string txtbox)
        {
            DemoContext db = new();
            var q = from p in db.Members
                    where p.Name == txtbox
                    select p;
            if(q.Any())
            {
                return Content("已經有這個帳號", "text/plain",System.Text.Encoding.UTF8);
            }
            return Content("可以使用", "text/plain", System.Text.Encoding.UTF8);
        }
    }
}
