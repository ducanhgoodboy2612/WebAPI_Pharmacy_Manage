using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
//using System.Web.Http;

public class FunctionController : ControllerBase
{
    [HttpPost]
    [Route("api/send-email")]
    public IActionResult SendEmail([FromBody] EmailModel model)
    {
        try
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ducanhhahaha73@gmail.com", "chocopyke2003"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("your-email@gmail.com"),
                Subject = model.Subject,
                Body = model.Body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(model.To);

            smtpClient.Send(mailMessage);
            return Ok("Email sent successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error sending email: " + ex.Message);
        }
    }
}

public class EmailModel
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}

