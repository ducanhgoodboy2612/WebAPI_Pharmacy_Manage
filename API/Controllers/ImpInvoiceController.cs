using BBL;
using BBL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpInvoiceController : ControllerBase
    {
        private I_ImpInvoiceBusiness _bus;
        private string _path;
        private IWebHostEnvironment _env;
        public ImpInvoiceController(I_ImpInvoiceBusiness bus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bus = bus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public ImportInvoiceModel GetDatabyID(int id)
        {
            return _bus.GetDatabyID(id);
        }
        [Route("create-invoice")]
        [HttpPost]
        public ImportInvoiceModel CreateItem([FromBody] ImportInvoiceModel model)
        {
            _bus.Create(model);
            return model;
        }
        [Route("update-invoice")]
        [HttpPost]
        public ImportInvoiceModel Update([FromBody] ImportInvoiceModel model)
        {
            _bus.Update(model);
            return model;
        }
        [Route("delete")]
        [HttpPost]
        public bool Delete(string id)
        {
            return _bus.Delete(id);

        }
    }
}
