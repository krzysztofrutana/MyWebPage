using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebPage.Models;
using MyWebPage.Services;

namespace MyWebPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FileService _fileService;


        public HomeController(ILogger<HomeController> logger, FileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetCV(String language)
        {
            String filePath;
            if (language.Equals("PL"))
            {
                filePath = "Content/About/CVs/CV_PL.pdf";
            }
            else
            {
                filePath = "Content/About/CVs/CV_EN.pdf";
            }
            if(filePath == null)
            {
                return NotFound();
            }
            return _fileService.GetFileAsStream(filePath) ?? (IActionResult)NotFound();
        }

        public IActionResult ChangeCulture(string language)
        {
            HttpContext.Response.Cookies.Append(
                            CookieRequestCultureProvider.DefaultCookieName,
                            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(language)));

            return RedirectToAction("Index", new { culture = language }) ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
