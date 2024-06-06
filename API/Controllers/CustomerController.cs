using BBL;
using BBL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerBusiness _bus;
        private string _path;
        private IWebHostEnvironment _env;
        public CustomerController(ICustomerBusiness khachBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bus = khachBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;     
        }
        [Route("get-by-name/{name}")]
        [HttpGet]
        public IEnumerable<CustomerModel> GetDatabyName(string name)
        {
            return _bus.GetDatabyName(name);
        }

        [Route("create-customer")]
        [HttpPost]
        public CustomerModel CreateItem([FromBody] CustomerModel model)
        {
            _bus.Create(model);
            return model;
        }

        [Route("update-customer")]
        [HttpPost]
        public CustomerModel Update([FromBody] CustomerModel model)
        {
            _bus.Update(model);
            return model;
        }
    }
}
