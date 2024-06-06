using BBL;
using BBL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private IPromotionBusiness _bus;
        private string _path;
        private IWebHostEnvironment _env;
        public PromotionController(IPromotionBusiness bus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bus = bus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public PromotionModel GetDatabyID(string id)
        {
            return _bus.GetDatabyID(id);
        }

        [Route("create-promotion")]
        [HttpPost]
        public PromotionModel CreateItem([FromBody] PromotionModel model)
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
    }
}
