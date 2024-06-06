using DAL.Helper.Interfaces;
using Models;


using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Microsoft.Extensions.Configuration;
using DAL.Interfaces;
using Microsoft.Extensions.Options;

namespace DAL
{
    public class EmailRepository : IEmailRepository
    {

        private readonly SmtpSettings _smtpSettings;

        // Constructor để khởi tạo EmailService với cài đặt SMTP.
        public EmailRepository(IOptions<SmtpSettings> smtpSettings)
        {
            // Lấy cài đặt SMTP từ dependency injection sử dụng mẫu IOptions.
            _smtpSettings = smtpSettings.Value;
        }

        // Phương thức gửi email bất đồng bộ.
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            // Tạo một MimeMessage mới để biểu diễn email.
            var email = new MimeMessage();
            // Thiết lập địa chỉ và tên người gửi.
            email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            // Thiết lập địa chỉ người nhận.
            email.To.Add(new MailboxAddress(toEmail, toEmail));
            // Thiết lập chủ đề của email.
            email.Subject = subject;

            // Xây dựng nội dung email bằng HTML.
            var bodyBuilder = new BodyBuilder { HtmlBody = message };
            email.Body = bodyBuilder.ToMessageBody();

            // Tạo và khởi tạo một thể hiện của SmtpClient để kết nối với máy chủ SMTP.
            using var smtp = new SmtpClient();
            // Kết nối với máy chủ SMTP bất đồng bộ sử dụng máy chủ, cổng và tùy chọn SSL/TLS đã chỉ định.
            await smtp.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            // Xác thực với máy chủ SMTP sử dụng tên người dùng và mật khẩu đã chỉ định.
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            // Gửi email bất đồng bộ.
            await smtp.SendAsync(email);
            // Ngắt kết nối với máy chủ SMTP sau khi gửi email.
            await smtp.DisconnectAsync(true);
        }



        //private readonly IConfiguration _config;
        //private readonly IDatabaseHelper _dbHelper;

        //public EmailRepository(IConfiguration config, IDatabaseHelper dbHelper)
        //{
        //    _config = config;
        //    _dbHelper = dbHelper;
        //}

        //public void SendEmail(EmailModel request)
        //{
        //    var email = new MimeMessage();
        //    email.From.Add(MailboxAddress.Parse("emile70@ethereal.email"));
        //    email.To.Add(MailboxAddress.Parse("emile70@ethereal.email"));
        //    email.Subject = "Test Email";
        //    email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

        //    using var smtp = new MailKit.Net.Smtp.SmtpClient();
        //    smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
        //    smtp.Authenticate("emile70@ethereal.email", "ZzPGS3m1Z2qsHYXdkh");
        //    smtp.Send(email);
        //    smtp.Disconnect(true);
        //}
    }
}
