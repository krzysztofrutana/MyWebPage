using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebPage.Models;

namespace MyWebPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SendMail(ContactViewModel contactViewModel)
        {
            string msg = $"{contactViewModel.Name} {Environment.NewLine}  {contactViewModel.Message}";
            await _emailSender.SendEmailAsync(contactViewModel.Email, $"{contactViewModel.Email} - {contactViewModel.Subject}", msg);
            TempData["ConfirmMsg"] = "Dziękuję za wysłanie wiadomości";
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
