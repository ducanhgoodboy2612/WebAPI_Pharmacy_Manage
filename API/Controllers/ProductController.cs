using BBL;
using BBL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductBusiness _bus;
        private string _path;
        private IWebHostEnvironment _env;
        public ProductController(IProductBusiness bus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bus = bus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public ProductModel GetDatabyID(string id)
        {
            return _bus.GetDatabyID(id);
        }
        [Route("get-promotion/{id}")]
        [HttpGet]
        public PromotionModel GetPromotion(string id)
        {
            return _bus.GetPromotion(id);
        }
        [Route("get-by-category/{cate_name}")]
        [HttpGet]
        public IEnumerable<ProductModel> GetDatabyCategory(string cate_name)
        {
            return _bus.GetDatabyCategory(cate_name);
        }
        [Route("get-by-cateID/{id}")]
        [HttpGet]
        public IEnumerable<ProductModel> GetDatabyCateID(string id)
        {
            return _bus.GetDatabyCateID(id);
        }
        [Route("get-top-by-sales/{n}")]
        [HttpGet]
        public IEnumerable<ProductModel_withRevenue> GetTop_bySales(int n)
        {
            return _bus.GetTop_bySales(n);
        }

        [Route("get-top-by-salesQuantity/{n}")]
        [HttpGet]
        public IEnumerable<ProductModel_withSoldNumber> GetTop_bySalesQuantity(int n)
        {
            return _bus.GetTop_bySalesQuantity(n);
        }
        [Route("get-all-data")]
        [HttpGet]
        public IEnumerable<ProductModel> GetAllData()
        {
            return _bus.GetAllData();
        }
        [Route("get-new-prod")]
        [HttpGet]
        public IEnumerable<ProductModel> GetNewProducts()
        {
            return _bus.GetNewProducts();
        }
        [AllowAnonymous]
        [Route("create-product")]
        [HttpPost]
        public ProductModel CreateItem([FromBody] ProductModel model)
        {
            _bus.Create(model);
            return model;
        }
        [AllowAnonymous]
        [Route("update-product")]
        [HttpPost]
        public ProductModel Update([FromBody] ProductModel model)
        {
            _bus.Update(model);
            return model;
        }
        [Route("delete-product")]
        [HttpDelete]
        public bool Delete(string id)
        {
            return _bus.Delete(id);


        }

        public class ProductSalesRequest
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        [Route("get-top-sales")]
        [HttpPost]
        public IActionResult GetProductSales([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                DateTime? startDate = null;
                if (formData.Keys.Contains("startDate") && formData["startDate"] != null && formData["startDate"].ToString() != "")
                {
                    startDate = Convert.ToDateTime(formData["startDate"].ToString());

                }
                DateTime? endDate = null;
                if (formData.Keys.Contains("endDate") && formData["endDate"] != null && formData["endDate"].ToString() != "")
                {
                    endDate = Convert.ToDateTime(formData["endDate"].ToString());
                }
                // Assuming you have a service or business logic layer called _bus
                long total = 0;
                var data = _bus.GetProductSales(page, pageSize,  out total, startDate, endDate);

                return Ok(new
                {
                    TotalItems = total,
                    Data = data,
                    Page = page,
                    PageSize = pageSize
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Route("get-inventory")]
        [HttpPost]
        public IActionResult GetInventory([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                
                long total = 0;
                var data = _bus.GetInventory(page, pageSize, out total);

                return Ok(new
                {
                    TotalItems = total,
                    Data = data,
                    Page = page,
                    PageSize = pageSize
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        //[AllowAnonymous]
        [Route("search")]
        [HttpPost]
        //public IActionResult Search([FromBody] Dictionary<string, object> formData)
        //{
        //    try
        //    {
        //        var page = int.Parse(formData["page"].ToString());
        //        var pageSize = int.Parse(formData["pageSize"].ToString());
        //        string product_name = "";
        //        if (formData.Keys.Contains("product_name") && !string.IsNullOrEmpty(Convert.ToString(formData["product_name"]))) { product_name = Convert.ToString(formData["product_name"]); }
        //        int fr_Price = 0;
        //        if (formData.Keys.Contains("fr_Price") && formData["fr_Price"] != null && formData["fr_Price"].ToString() != "")
        //        {
        //            fr_Price = Convert.ToInt32(formData["fr_Price"].ToString());

        //        }
        //        int to_Price = 0;
        //        if (formData.Keys.Contains("to_Price") && formData["to_Price"] != null && formData["to_Price"].ToString() != "")
        //        {
        //            to_Price = Convert.ToInt32(formData["to_Price"].ToString());
        //        }
        //        long total = 0;
        //        var data = _bus.Search(page, pageSize, out total, product_name, fr_Price, to_Price);
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
        //[Route("search2")]
        //[HttpPost]
        public IActionResult Search2([FromBody] Dictionary<string, object> formData)
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
                var data = _bus.Search2(page, pageSize, out total, product_name, fr_Price, to_Price);
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
        [Route("search_full_prod")]
        [HttpPost]
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
        //[Route("search_full")]
        //[HttpPost]
        //public IActionResult Search_Full([FromBody] Dictionary<string, object> formData)
        //{
        //    try
        //    {
        //        var page = int.Parse(formData["page"].ToString());
        //        var pageSize = int.Parse(formData["pageSize"].ToString());
        //        string product_name = "";
        //        if (formData.Keys.Contains("product_name") && !string.IsNullOrEmpty(Convert.ToString(formData["product_name"]))) { product_name = Convert.ToString(formData["product_name"]); }
        //        string cate_name = "";
        //        if (formData.Keys.Contains("cate_name") && !string.IsNullOrEmpty(Convert.ToString(formData["cate_name"]))) { product_name = Convert.ToString(formData["cate_name"]); }
        //        int? fr_Price = null;
        //        if (formData.Keys.Contains("fr_Price") && formData["fr_Price"] != null && formData["fr_Price"].ToString() != "")
        //        {
        //            fr_Price = Convert.ToInt32(formData["fr_Price"].ToString());

        //        }
        //        int? to_Price = null;
        //        if (formData.Keys.Contains("to_Price") && formData["to_Price"] != null && formData["to_Price"].ToString() != "")
        //        {
        //            fr_Price = Convert.ToInt32(formData["to_Price"].ToString());
        //        }
        //        long total = 0;
        //        var data = _bus.Search2(page, pageSize, out total, product_name, fr_Price, to_Price);
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
    }
}
