using BBL;
using BBL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DAL.Interfaces;
using Models;
using System.Net.Mail;
using System.Net;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository _emailService;

        // Constructor để inject IEmailService vào controller.
        public EmailController(IEmailRepository emailService)
        {
            _emailService = emailService;
        }

        // Endpoint xử lý yêu cầu gửi email.
        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            try
            {
                // Gọi phương thức SendEmailAsync từ IEmailService để gửi email.
                await _emailService.SendEmailAsync(request.ToEmail, request.Subject, request.Message);
                // Trả về kết quả thành công nếu email được gửi thành công.
                return Ok(new { message = "Email sent successfully." });
            }
            catch (System.Exception ex)
            {
                // Trả về mã lỗi 500 và thông báo lỗi nếu gửi email thất bại.
                return StatusCode(500, new { message = "Email sending failed.", error = ex.Message });
            }
        }
    }

    // Model chứa thông tin của yêu cầu gửi email.
    public class EmailRequest
    {
        public string ToEmail { get; set; } // Địa chỉ email người nhận.
        public string Subject { get; set; } // Chủ đề của email.
        public string Message { get; set; } // Nội dung của email.
    }
}

