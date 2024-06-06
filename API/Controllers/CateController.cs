using BBL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CateController : ControllerBase
    {
        private ICateBusiness _bus;
        private string _path;
        private IWebHostEnvironment _env;
        public CateController(ICateBusiness bus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bus = bus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("getCate-by-id/{id}")]
        [HttpGet]
        public CategoryModel GetDatabyID(string id)
        {
            return _bus.GetDatabyID(id);
        }

        [Route("get-all-cate")]
        [HttpGet]
        public IEnumerable<CategoryModel> GetAllCates()
        {
            return _bus.GetAllCates();
        }
        [Route("create-cate")]
        [HttpPost]
        public CategoryModel CreateItem([FromBody] CategoryModel model)
        {
            _bus.Create(model);
            return model;
        }
        //[Route("update-supplier")]
        //[HttpPost]
        //public SupplierModel Update([FromBody] SupplierModel model)
        //{
        //    _bus.Update(model);
        //    return model;
        //}
        [Route("delete-cate")]
        [HttpPost]
        public bool Delete(string id)
        {
            return _bus.Delete(id);
        }
    }
}
