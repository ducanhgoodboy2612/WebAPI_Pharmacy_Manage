using BBL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierBusiness _bus;
        private string _path;
        private IWebHostEnvironment _env;
        public SupplierController(ISupplierBusiness bus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bus = bus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public SupplierModel GetDatabyID(string id)
        {
            return _bus.GetDatabyID(id);
        }
        [Route("create-supplier")]
        [HttpPost]
        public SupplierModel CreateItem([FromBody] SupplierModel model)
        {
            _bus.Create(model);
            return model;
        }

        [Route("update-supplier")]
        [HttpPost]
        public SupplierModel Update([FromBody] SupplierModel model)
        {
            _bus.Update(model);
            return model;
        }
        [Route("delete-supplier")]
        [HttpPost]
        public bool Delete(string id)
        {
            return _bus.Delete(id);
        }
    }
}
