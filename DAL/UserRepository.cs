using DAL.Helper;
using DAL.Helper.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private IDatabaseHelper _dbHelper;
        public UserRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public UserModel Login(string username, string password)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_login",
                     "@username", username,
                     "@pass", password
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User_with_AccountModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "[sp_get_user_by_id_v2]",
                     "@UserID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<User_with_AccountModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public bool Create(User_with_AccountModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "[sp_user_create]",
                    
                    "@FullName", model.FullName,
                    "@DateOfBirth", model.DateOfBirth,
                    "@Gender", model.Gender,
                    "@Address", model.Address,
                    "@Email", model.Email,
                    "@PhoneNumber", model.PhoneNumber,
                    "@Status", model.Status,
                    "@UserType", model.UserType,
                    "@Username", model.Username,
                    "@Pass", model.Pass
                );
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(User_with_AccountModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "[sp_update_user]",
                    "@UserID", model.UserID,
                    "@FullName", model.FullName,
                    "@DateOfBirth", model.DateOfBirth,
                    "@Gender", model.Gender,
                    "@Address", model.Address,
                    "@Email", model.Email,
                    "@PhoneNumber", model.PhoneNumber,
                    "@Status", model.Status,
                    "@UserType", model.UserType,
                    "@Username", model.Username,
                    "@Pass", model.Pass
                );
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<UsersModel> SearchUser(int pageIndex, int pageSize, out long total, int? userId, string phoneNumber)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "[sp_users_search]",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@userID", userId,
                    "@phoneNumber", phoneNumber
                );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<UsersModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //create v1

        public bool Create(User_AccountModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "[sp_Add_UserAccount]",
                "@UserType", model.UserType,
                "@Username", model.Username,
                "@Pass", model.Pass,
                "@Email", model.Email);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<User_AccountModel> Search_UserAcc(int pageIndex, int pageSize, out long total, int? userId, string email)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "[sp_user_search_paged]",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@user_id", userId,
                    "@username", email
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<User_AccountModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
