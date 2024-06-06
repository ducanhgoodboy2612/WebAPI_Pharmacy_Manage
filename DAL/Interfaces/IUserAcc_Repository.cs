using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IUserAcc_Repository
    {
        bool Create(User_AccountModel model);
    }
}
