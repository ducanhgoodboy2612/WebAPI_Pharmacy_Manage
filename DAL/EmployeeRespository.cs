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
    public class EmployeeRespository:IEmployeeRepository
    {
        private IDatabaseHelper _dbHelper;
        public EmployeeRespository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public EmployeeModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_GetEmployeeById",
                     "@EmployeeId", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<EmployeeModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public bool Create(EmployeeModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_AddEmployee",
                "@Name", model.Name,
                "@Gender", model.Gender,
                "@YoB", model.YoB,
                "@Address", model.Address,
                "@Phone", model.Phone,
                "@Salary", model.Salary);
               
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
        public bool Update(EmployeeModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_UpdateEmployee",
                "@EmployeeId", model.ID,
                "@Name", model.Name,
                "@Gender", model.Gender,
                "@YoB", model.YoB,
                "@Address", model.Address,
                "@Phone", model.Phone,
                "@Salary", model.Salary);
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
        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "[sp_DeleteEmployee]",
                "@EmployeeId", id
                );
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
        public List<EmployeeModel> Search(int pageIndex, int pageSize, out long total, string emp_name, int? fr_Salary, int? to_Salary)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_search_emp",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@emp_name", emp_name,
                    "@fr_Salary", fr_Salary,
                    "@to_Salary", to_Salary
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<EmployeeModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeModel> Search2(int pageIndex, int pageSize, out long total, string emp_name, int? fr_Salary, int? to_Salary)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "[sp_search_emp]",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@emp_name", emp_name,
                    "@fr_Salary", fr_Salary,
                    "@to_Salary",   to_Salary
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<EmployeeModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeModel> SearchEmp(int pageIndex, int pageSize, out long total, string ten, string dia_chi)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_employee_search2",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@name", ten,
                    "@address", dia_chi);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<EmployeeModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
