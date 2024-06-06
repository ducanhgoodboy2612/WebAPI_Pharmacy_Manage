using API.Code;
using BBL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBusiness _userBusiness;
        private readonly AppSettings _appSettings;
        private ITools _tools;
        public UserController(IUserBusiness userBusiness, IOptions<AppSettings> appSettings, ITools tools)
        {
            _userBusiness = userBusiness;
            _appSettings = appSettings.Value;
            _tools = tools;
        }
        //Login
        
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _userBusiness.Login(model.Username, model.Password);
            if (user == null)
                return BadRequest(new { message = "Incorrect username or password!" });
            //return Ok(new { username = user.Username, email = user.Email, token = user.Token });
            return Ok(user);
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public User_with_AccountModel GetDatabyID(string id)
        {
            return _userBusiness.GetDatabyID(id);
        }

        [Route("create-user")]
        [HttpPost]
        public User_with_AccountModel CreateUser([FromBody] User_with_AccountModel model)
        {
            _userBusiness.Create(model);
            return model;
        }

        [Route("update-user")]
        [HttpPost]
        public User_with_AccountModel Update([FromBody] User_with_AccountModel model)
        {
            _userBusiness.Update(model);
            return model;
        }

        [Route("create-userAcc")]
        [HttpPost]
        public User_AccountModel CreateItem([FromBody] User_AccountModel model)
        {
            _userBusiness.Create(model);
            return model;
        }

        [Route("search-user-acc")]
        [HttpPost]
        public IActionResult Search_UserAcc([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var pageIndex = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                int? userId = null;
                string email = null;

                // Kiểm tra và lấy giá trị của UserID nếu có
                if (formData.ContainsKey("user_id") && formData["user_id"] != null && formData["user_id"].ToString() != "")
                {
                    userId = int.Parse(formData["user_id"].ToString());
                }

                // Kiểm tra và lấy giá trị của Email nếu có
                if (formData.ContainsKey("email") && !string.IsNullOrEmpty(Convert.ToString(formData["email"])))
                {
                    email = Convert.ToString(formData["email"]);
                }

                long total = 0;
                var data = _userBusiness.Search_UserAcc(pageIndex, pageSize, out total, userId, email);

                return Ok(new
                {
                    TotalItems = total,
                    Data = data,
                    Page = pageIndex,
                    PageSize = pageSize
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("search-users")]
        [HttpPost]
        public IActionResult SearchUsers([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var pageIndex = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                int? userId = null;
                string phoneNumber = null;

                // Kiểm tra và lấy giá trị của UserID nếu có
                if (formData.ContainsKey("userId") && formData["userId"] != null && formData["userId"].ToString() != "")
                {
                    userId = int.Parse(formData["userId"].ToString());
                }

                // Kiểm tra và lấy giá trị của PhoneNumber nếu có
                if (formData.ContainsKey("phoneNumber") && !string.IsNullOrEmpty(Convert.ToString(formData["phoneNumber"])))
                {
                    phoneNumber = Convert.ToString(formData["phoneNumber"]);
                }

                long total = 0;
                var data = _userBusiness.SearchUser(pageIndex, pageSize, out total, userId, phoneNumber);

                return Ok(new
                {
                    TotalItems = total,
                    Data = data,
                    Page = pageIndex,
                    PageSize = pageSize
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string filePath = $"/img/medicine/{file.FileName.Replace("-", "_").Replace("%", "")}";
                    var fullPath = _tools.CreatePathFile(filePath);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return Ok(new { filePath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Không thể upload tệp");
            }
        }
    }
}
