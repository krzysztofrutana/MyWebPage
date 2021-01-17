using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MyWebPage.Models
{
    public class SendMail : IEmailSender
    {
        private readonly IConfiguration _config;
        public SendMail(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using(MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(_config.GetValue<string>("Email:EmailAdress"));
                mailMessage.Subject = subject;
                mailMessage.Body = htmlMessage;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(_config.GetValue<string>("Email:OnAdress")));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = _config.GetValue<string>("Email:Host");
                smtp.EnableSsl = true;
                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential();
                networkCredential.UserName = _config.GetValue<string>("Email:EmailAdress");
                networkCredential.Password = _config.GetValue<string>("Email:AgentPassword");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = int.Parse(_config.GetValue<string>("Email:Port"));
                await smtp.SendMailAsync(mailMessage);
            }
        }
    }
}
