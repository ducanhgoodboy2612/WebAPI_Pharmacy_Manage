using BBL;
using BBL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccController : ControllerBase
    {
        private IUserAcc_Business _bus;
        private string _path;
        private IWebHostEnvironment _env;
        public UserAccController(IUserAcc_Business bus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bus = bus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        //[Route("get-by-id/{id}")]
        //[HttpGet]
        //public EmployeeModel GetDatabyID(string id)
        //{
        //    return _empBusiness.GetDatabyID(id);
        //}

        [Route("create-user-acc")]
        [HttpPost]
        public User_AccountModel CreateItem([FromBody] User_AccountModel model)
        {
            _bus.Create(model);
            return model;
        }

        //[Route("update-emp")]
        //[HttpPost]
        //public EmployeeModel Update([FromBody] EmployeeModel model)
        //{
        //    _empBusiness.Update(model);
        //    return model;
        //}
        //[Route("delete-emp")]
        //[HttpDelete]
        //public bool Delete(string id)
        //{
        //    return _empBusiness.Delete(id);


        //}
        //[Route("search")]
        //[HttpPost]
        //public IActionResult Search2([FromBody] Dictionary<string, object> formData)
        //{
        //    try
        //    {
        //        var page = int.Parse(formData["page"].ToString());
        //        var pageSize = int.Parse(formData["pageSize"].ToString());
        //        string emp_name = "";
        //        if (formData.Keys.Contains("emp_name") && !string.IsNullOrEmpty(Convert.ToString(formData["emp_name"]))) { emp_name = Convert.ToString(formData["emp_name"]); }
        //        int? fr_Salary = null;
        //        if (formData.Keys.Contains("fr_Salary") && formData["fr_Salary"] != null && formData["fr_Salary"].ToString() != "")
        //        {
        //            fr_Salary = Convert.ToInt32(formData["fr_Salary"].ToString());

        //        }
        //        int? to_Salary = null;
        //        if (formData.Keys.Contains("to_Salary") && formData["to_Salary"] != null && formData["to_Salary"].ToString() != "")
        //        {
        //            to_Salary = Convert.ToInt32(formData["to_Salary"].ToString());
        //        }
        //        long total = 0;
        //        var data = _empBusiness.Search2(page, pageSize, out total, emp_name, fr_Salary, to_Salary);
        //        return Ok(
        //            new
        //            {
        //                TotalItems = total,
        //                Data = data,
        //                Page = page,
        //                PageSize = pageSize
        //            }
        //            );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}


        //[Route("search2")]
        //[HttpPost]
        //public IActionResult SearchEmp([FromBody] Dictionary<string, object> formData)
        //{
        //    try
        //    {
        //        var page = int.Parse(formData["page"].ToString());
        //        var pageSize = int.Parse(formData["pageSize"].ToString());
        //        string ten = "";
        //        if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"]))) { ten = Convert.ToString(formData["ten"]); }
        //        string dia_chi = "";
        //        if (formData.Keys.Contains("dia_chi") && !string.IsNullOrEmpty(Convert.ToString(formData["dia_chi"]))) { dia_chi = Convert.ToString(formData["dia_chi"]); }
        //        long total = 0;
        //        var data = _empBusiness.SearchEmp(page, pageSize, out total, ten, dia_chi);
        //        return Ok(
        //            new
        //            {
        //                TotalItems = total,
        //                Data = data,
        //                Page = page,
        //                PageSize = pageSize
        //            }
        //            );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}

