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
    public class UserAcc_Business : IUserAcc_Business
    {
        private IUserAcc_Repository _res;
        public UserAcc_Business(IUserAcc_Repository res)
        {
            _res = res;
        }
        //public EmployeeModel GetDatabyID(string id)
        //{
        //    return _res.GetDatabyID(id);
        //}
        public bool Create(User_AccountModel model)
        {
            return _res.Create(model);
        }
        //public bool Update(EmployeeModel model)
        //{
        //    return _res.Update(model);
        //}
        //public bool Delete(string id)
        //{
        //    return _res.Delete(id);
        //}
        //public List<EmployeeModel> Search(int pageIndex, int pageSize, out long total, string emp_name, int? fr_Salary, int? to_Salary)
        //{
        //    //total = 0;
        //    return _res.Search(pageIndex, pageSize, out total, emp_name, fr_Salary, to_Salary);
        //}
        //public List<EmployeeModel> SearchEmp(int pageIndex, int pageSize, out long total, string ten_khach, string dia_chi)
        //{
        //    return _res.SearchEmp(pageIndex, pageSize, out total, ten_khach, dia_chi);
        //}
        //public List<EmployeeModel> Search2(int pageIndex, int pageSize, out long total, string emp_name, int? fr_Salary, int? to_Salary)
        //{
        //    return _res.Search2(pageIndex, pageSize, out total, emp_name, fr_Salary, to_Salary);
        //}
    }


}

