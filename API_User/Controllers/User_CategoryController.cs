using BBL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_CategoryController : ControllerBase
    {
        private ICateBusiness _bus;
        private string _path;
        private IWebHostEnvironment _env;
        public User_CategoryController(ICateBusiness bus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bus = bus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-all-cate")]
        [HttpGet]
        public IEnumerable<CategoryModel> GetAllCates()
        {
            return _bus.GetAllCates();
        }
        [Route("getCate-by-id/{id}")]
        [HttpGet]
        public CategoryModel GetDatabyID(string id)
        {
            return _bus.GetDatabyID(id);
        }
    }
}
