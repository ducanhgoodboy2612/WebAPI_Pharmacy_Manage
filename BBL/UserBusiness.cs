using BBL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BBL
{
    public class UserBusiness:IUserBusiness
    {
        private IUserRepository _res;
        private string secret;
        public UserBusiness(IUserRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }
        public UserModel Login(string username, string password)
        {
            var user = _res.Login(username, password);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }

        public User_with_AccountModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(User_with_AccountModel model)
        {
            return _res.Create(model);
        }

        public bool Update(User_with_AccountModel model) { return _res.Update(model); }
        public bool Create(User_AccountModel model)
        {
            return _res.Create(model);
        }
        public List<UsersModel> SearchUser(int pageIndex, int pageSize, out long total, int? userId, string phoneNumber)
        {
            return _res.SearchUser(pageIndex, pageSize, out total, userId, phoneNumber);
        }

        public List<User_AccountModel> Search_UserAcc(int pageIndex, int pageSize, out long total, int? userId, string email)
        {
            return _res.Search_UserAcc(pageIndex, pageSize, out total, userId, email);
        }
    }
}
