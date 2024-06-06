using BBL.Interfaces;
using BBL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IBrandBusiness _bus;
        private string _path;
        private IWebHostEnvironment _env;
        public BrandController(IBrandBusiness bus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bus = bus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
       

        [Route("get-all-brand")]
        [HttpGet]
        public IEnumerable<BrandModel> GetAllBrands()
        {
            return _bus.GetAllBrands();
        }

        [Route("get-by-id")]
        [HttpGet]
        public BrandModel GetDatabyID(string id)
        {
            return _bus.GetDatabyID(id);

        }
        [Route("get-product-by-brandId")]
        [HttpGet]
        public IEnumerable<ProductModel> GetTopNProductsByBrandId(int n, int brandId)
        {
            return _bus.GetTopNProductsByBrandId(n, brandId);
        }
    }
}
