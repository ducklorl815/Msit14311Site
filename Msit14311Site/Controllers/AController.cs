using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Msit14311Site.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Msit14311Site.Controllers
{
    public class AController : Controller
    {
        private readonly IWebHostEnvironment _host;
        private readonly DemoContext _context;
        public AController(IWebHostEnvironment host, DemoContext context)
        {
            _host = host;
            _context = context;
        }
        public IActionResult Index(string keyword)
        {
            if(String.IsNullOrEmpty(keyword))
            {
                keyword = "babacoco";
            }
            //return Content("Hello babacoco");
            return Content($"{keyword} ,Hello", "text/html",System.Text.Encoding.UTF8);
        }
        public IActionResult promise()
        {
            return View();
        }

        public IActionResult First()
        {
            return View();

        }
        public IActionResult Fetch()
        {
            return View();

        }
        public IActionResult sync()
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
        public IActionResult Register(Member member, IFormFile File1)
        //
        {
            //todo 將收到會員資料寫進資料庫中
            string filepath = Path.Combine(_host.WebRootPath, "uploads", File1.FileName);
            //檔案存到filepath中
            using (var filestream = new FileStream(filepath, FileMode.Create))
            {
                File1.CopyTo(filestream);
            }

            //檔案轉成二進位
            byte[] imByte = null;
            using (var memoryStream = new MemoryStream())
            {
                File1.CopyTo(memoryStream);
                imByte = memoryStream.ToArray();
            }

            member.FileName = File1.FileName;
            member.FileData = imByte;

            //將收到會員資料寫進資料庫中
            _context.Members.Add(member);
            _context.SaveChanges();

            //string info = $"{File1.FileName} - {File1.ContentType} - {File1.Length}";
            string info = _host.WebRootPath;
            //return Content(info, "text/plain");
            return Content(member.Name, "text/plain");
        }
        public IActionResult City()
        {
            var cities = _context.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }
        public IActionResult Site(string city)
        {
            var Sites = _context.Addresses.Where(a => a.City== city).Select(a=>a.SiteId).Distinct();
            return Json(Sites);
        }
        public IActionResult Road(string Sites)
        {
            var Road = _context.Addresses.Where(a => a.SiteId == Sites).Select(a => a.Road).Distinct();
            return Json(Road);
        }
    }
}
