using Microsoft.AspNetCore.Mvc;
using DAL;
using BBL.Interfaces;
using DAL.Interfaces;
using Models;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        [HttpPost]

        public void SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("emile70@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("ducanh3935@gmail.com"));
            email.Subject = "Test Email";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("emile70@ethereal.email", "ZzPGS3m1Z2qsHYXdkh");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
        //private readonly IEmailRepository _emailService;


        //public MailController(IEmailRepository emailService)
        //{
        //    _emailService = emailService;
        //}

        //[HttpPost]
        //public IActionResult SendEmail(Models.EmailModel request)
        //{
        //    _emailService.SendEmail(request);
        //    return Ok();
        //}



        //private IEmailBusiness _bus;
        //private string _path;
        //private IWebHostEnvironment _env;
        //public MailController(IEmailBusiness bus, IConfiguration configuration, IWebHostEnvironment env)
        //{
        //    _bus = bus;
        //    _path = configuration["AppSettings:PATH"];
        //    _env = env;
        //}
        //[Route("send-email")]
        //[HttpPost]
        //public void SendEmail(Models.EmailModel request)
        //{
        //    _bus.SendEmail(request);
        //}
    }
}
