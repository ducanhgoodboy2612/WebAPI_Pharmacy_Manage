using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IUserRepository
    {
        UserModel Login(string username, string password);
        User_with_AccountModel GetDatabyID(string id);
        bool Create(User_with_AccountModel model);
        bool Update(User_with_AccountModel model);

        List<UsersModel> SearchUser(int pageIndex, int pageSize, out long total, int? userId, string phoneNumber);

         bool Create(User_AccountModel model);
        List<User_AccountModel> Search_UserAcc(int pageIndex, int pageSize, out long total, int? userId, string email);
    }
}
