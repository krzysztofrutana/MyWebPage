using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MyWebPage.Models
{
    public class SendMail : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using(MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("test@testkrutanapersonal.cba.pl");
                mailMessage.Subject = subject;
                mailMessage.Body = htmlMessage;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress("krzysztofrutana@wp.pl"));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.cba.pl";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential();
                networkCredential.UserName = "test@testkrutanapersonal.cba.pl";
                networkCredential.Password = "Unreal123";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                await smtp.SendMailAsync(mailMessage);
            }
        }
    }
}
