using Microsoft.AspNetCore.Mvc;
using Msit14311Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Msit14311Site.Controllers
{
    public class AController : Controller
    {
        public IActionResult Index(string keyword)
        {
            if(String.IsNullOrEmpty(keyword))
            {
                keyword = "babacoco";
            }
            //return Content("Hello babacoco");
            return Content($"{keyword} ,Hello", "text/html",System.Text.Encoding.UTF8);
        }
   
        public IActionResult First()
        {
            return View();

        }
        public IActionResult Second()
        {
            return View();

        }
        public IActionResult GetDemo()
        {
            return View();

        }
        public IActionResult AjaxEvent()
        {
            return View();

        }
        public IActionResult sleep()
        {
            System.Threading.Thread.Sleep(5000);
            return Content("Hello Ajax Event","text/plain");

        }
        public IActionResult Register(Member member)
        {
            //todo 將收到會員資料寫進資料庫中

            return Content(member.Name, "text/plain");
        }
    }
}
