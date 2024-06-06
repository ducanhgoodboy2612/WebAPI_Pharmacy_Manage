using BBL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_InvoiceController : ControllerBase
    {
        private I_InvoiceBusiness _bus;
        private string _path;
        private IWebHostEnvironment _env;
        public User_InvoiceController(I_InvoiceBusiness bus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bus = bus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("create-invoice")]
        [HttpPost]
        public SalesInvoiceModel CreateItem([FromBody] SalesInvoiceModel model)
        {
            _bus.Create(model);
            return model;
        }
    }
}
