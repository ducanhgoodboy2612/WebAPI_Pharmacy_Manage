using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IEmployeeRepository
    {
        EmployeeModel GetDatabyID(string id);
        bool Create(EmployeeModel model);
        bool Update(EmployeeModel model);
        bool Delete(string id);
        public List<EmployeeModel> Search(int pageIndex, int pageSize, out long total, string emp_name, int? fr_Salary, int? to_Salary);
        public List<EmployeeModel> SearchEmp(int pageIndex, int pageSize, out long total, string ten, string dia_chi);
        public List<EmployeeModel> Search2(int pageIndex, int pageSize, out long total, string emp_name, int? fr_Salary, int? to_Salary);
    }
}
