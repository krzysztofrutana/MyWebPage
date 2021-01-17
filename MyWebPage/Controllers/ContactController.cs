using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using MyWebPage.Models;

namespace MyWebPage.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailSender _emailSender;

        public ContactController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(ContactViewModel contactViewModel)
        {
            string msg = $"{contactViewModel.Name} {Environment.NewLine}  {contactViewModel.Message}";
            await _emailSender.SendEmailAsync(contactViewModel.Email, $"{contactViewModel.Email} - {contactViewModel.Subject}", msg);
            TempData["ConfirmMsg"] = "Dziękuję za wysłanie wiadomości";
            return RedirectToAction("Index", "Home");
        }
    }
}
