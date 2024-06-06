using BBL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_ProductController : ControllerBase
    {
        private IProductBusiness _bus;
        private string _path;
        private IWebHostEnvironment _env;
        public User_ProductController(IProductBusiness bus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bus = bus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id")]
        [HttpGet]
        public ProductModel GetDatabyID(string id)
        {
            return _bus.GetDatabyID(id);
        }
        [Route("get-by-category/{cate_name}")]
        [HttpGet]
        public IEnumerable<ProductModel> GetDatabyCategory(string cate_name)
        {
            return _bus.GetDatabyCategory(cate_name);
        }
        [Route("get-all-data")]
        [HttpGet]
        public IEnumerable<ProductModel> GetAllData()
        {
            return _bus.GetAllData();
        }
        [Route("get-new-products")]
        [HttpGet]
        public IEnumerable<ProductModel> GetNewPros()
        {
            return _bus.GetNewProducts();
        }
        [Route("get-product-in-sales")]
        [HttpGet]
        public IEnumerable<PromotionModel> GetProductInSale()
        {
            return _bus.GetProductInSale();
        }
        [Route("get-top-by-sales-quantity/{n}")]
        [HttpGet]
        public IEnumerable<ProductModel_withSoldNumber> GetTop_bySalesQuantity(int n)
        {
            return _bus.GetTop_bySalesQuantity(n);
        }
        [Route("search_full_prod")]
        [HttpPost]
        //public IActionResult Search_Full([FromBody] Dictionary<string, object> formData)
        //{
        //    try
        //    {
        //        var page = int.Parse(formData["page"].ToString());
        //        var pageSize = int.Parse(formData["pageSize"].ToString());
        //        string product_name = "";
        //        if (formData.Keys.Contains("product_name") && !string.IsNullOrEmpty(Convert.ToString(formData["product_name"]))) { product_name = Convert.ToString(formData["product_name"]); }
        //        string cate_name = "";
        //        if (formData.Keys.Contains("cate_name") && !string.IsNullOrEmpty(Convert.ToString(formData["cate_name"]))) { cate_name = Convert.ToString(formData["cate_name"]); }
        //        int? fr_Price = null;
        //        if (formData.Keys.Contains("fr_Price") && formData["fr_Price"] != null && formData["fr_Price"].ToString() != "")
        //        {
        //            fr_Price = Convert.ToInt32(formData["fr_Price"].ToString());

        //        }
        //        int? to_Price = null;
        //        if (formData.Keys.Contains("to_Price") && formData["to_Price"] != null && formData["to_Price"].ToString() != "")
        //        {
        //            to_Price = Convert.ToInt32(formData["to_Price"].ToString());
        //        }
        //        long total = 0;
        //        var data = _bus.Search_full(page, pageSize, out total, product_name, cate_name, fr_Price, to_Price);
        //        return Ok(
        //            new
        //            {
        //                TotalItems = total,
        //                Data = data,
        //                Page = page,
        //                PageSize = pageSize
        //            }
        //            );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public IActionResult Search_Product_withCate([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string product_name = "";
                if (formData.Keys.Contains("product_name") && !string.IsNullOrEmpty(Convert.ToString(formData["product_name"]))) { product_name = Convert.ToString(formData["product_name"]); }
                string cate_id = "";
                if (formData.Keys.Contains("cate_id") && !string.IsNullOrEmpty(Convert.ToString(formData["cate_id"]))) { cate_id = Convert.ToString(formData["cate_id"]); }
                int? fr_Price = null;
                if (formData.Keys.Contains("fr_Price") && formData["fr_Price"] != null && formData["fr_Price"].ToString() != "")
                {
                    fr_Price = Convert.ToInt32(formData["fr_Price"].ToString());

                }
                int? to_Price = null;
                if (formData.Keys.Contains("to_Price") && formData["to_Price"] != null && formData["to_Price"].ToString() != "")
                {
                    to_Price = Convert.ToInt32(formData["to_Price"].ToString());
                }
                long total = 0;
                var data = _bus.Search_full(page, pageSize, out total, product_name, cate_id, fr_Price, to_Price);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
