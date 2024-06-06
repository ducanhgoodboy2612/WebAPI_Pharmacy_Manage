using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{

    public interface IEmailRepository
    {
        Task SendEmailAsync(string toEmail, string subject, string message);
    }

    //public partial interface IEmailRepository
    //{
    //    void SendEmail(EmailModel request);

    //}
}
