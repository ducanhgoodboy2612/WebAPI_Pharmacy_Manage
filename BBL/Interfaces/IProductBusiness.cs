using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Interfaces
{
    public partial interface IProductBusiness
    {
        ProductModel GetDatabyID(string id);
        PromotionModel GetPromotion(string id);
        IEnumerable<ProductModel> GetDatabyCategory(string cate_name);
        IEnumerable<Product_ReportModel> GetProductSales(int pageIndex, int pageSize, out long total, DateTime? startDate, DateTime? endDate);
        IEnumerable<ProductModel> GetDatabyCateID(string id);
        IEnumerable<ProductModel> GetAllData();
        IEnumerable<ProductModel> GetNewProducts();
        IEnumerable<PromotionModel> GetProductInSale();
        IEnumerable<ProductModel> GetInventory(int pageIndex, int pageSize, out long total);
        IEnumerable<ProductModel_withRevenue> GetTop_bySales(int n);
        IEnumerable<ProductModel_withSoldNumber> GetTop_bySalesQuantity(int n);
        bool Create(ProductModel model);
        bool Update(ProductModel model);
        bool Delete(string id);
        public List<ProductModel> Search(int pageIndex, int pageSize, out long total, string product_name, int? fr_Price, int? to_Price);
        public List<ProductModel> Search2(int pageIndex, int pageSize, out long total, string product_name, int? fr_Price, int? to_Price);
        public List<ProductModel> Search_full(int pageIndex, int pageSize, out long total, string product_name, string cate_name, int? fr_Price, int? to_Price);
    }
}
