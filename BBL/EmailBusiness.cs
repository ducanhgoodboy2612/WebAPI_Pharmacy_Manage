using BBL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL
{
    public class EmailBusiness : IEmailBusiness
    {
        private IEmailRepository _res;
        public EmailBusiness(IEmailRepository res)
        {
            _res = res;
        }

        //public void SendEmail(EmailModel request)
        //{
        //     _res.SendEmail(request);
        //}
    }
}
