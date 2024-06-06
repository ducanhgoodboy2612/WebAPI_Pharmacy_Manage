using BBL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Prod_ImageController : ControllerBase
    {
        private IProd_ImageBusiness _bus;
        private string _path;
        private IWebHostEnvironment _env;
        public Prod_ImageController(IProd_ImageBusiness bus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bus = bus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
      
        [Route("get-by-proid/{id}")]
        [HttpGet]
        public IEnumerable<ProdImageModel> GetImageById(int id)
        {
            return _bus.GetImageById(id);
        }
    }
}
