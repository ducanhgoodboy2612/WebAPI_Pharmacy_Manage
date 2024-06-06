using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    public class UsersModel
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }
    }

    public class UserModel
    {
        public int Id { get; set; }
        public int UserType { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }

    public class User_AccountModel
    {
        public int UserID { get; set; }
        public int UserType { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        //public string Token { get; set; }
    }

    public class User_with_AccountModel
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }

        public int UserType { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
    }
}
