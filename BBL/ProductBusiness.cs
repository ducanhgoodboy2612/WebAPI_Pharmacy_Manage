using BBL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BBL
{
    public class ProductBusiness: IProductBusiness
    {
        private IProductRepository _res;
        public ProductBusiness(IProductRepository res)
        {
            _res = res;
        }

        public ProductModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public PromotionModel GetPromotion(string id) { return _res.GetPromotion(id);}
        public IEnumerable<ProductModel> GetDatabyCategory(string cate_name)
        {
            return _res.GetDatabyCategory(cate_name);
        }
        public IEnumerable<ProductModel> GetDatabyCateID(string id)
        {
            return _res.GetDatabyCateID(id);
        }
        public IEnumerable<ProductModel_withRevenue> GetTop_bySales(int n)
        {
            return _res.GetTop_bySales(n);
        }
        public IEnumerable<ProductModel_withSoldNumber> GetTop_bySalesQuantity(int n)
        {
            return _res.GetTop_bySalesQuantity(n);
        }
        public IEnumerable<Product_ReportModel> GetProductSales(int pageIndex, int pageSize, out long total, DateTime? startDate, DateTime? endDate)
        {
            return _res.GetProductSales(pageIndex, pageSize, out total, startDate, endDate);
        }

        public IEnumerable<ProductModel> GetInventory(int pageIndex, int pageSize, out long total)
        {
            return _res.GetInventory(pageIndex, pageSize, out total);
        }

        public IEnumerable<ProductModel> GetAllData()
        {
            return _res.GetAllData();
        }
        public IEnumerable<ProductModel> GetNewProducts()
        {
            return _res.GetNewProducts();
        }
        public IEnumerable<PromotionModel> GetProductInSale()
        {
            return _res.GetProductInSale();
        }
        public bool Create(ProductModel model)
        {
            return _res.Create(model);
        }
        public bool Update(ProductModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<ProductModel> Search(int pageIndex, int pageSize, out long total, string product_name, int? fr_Price, int? to_Price)
        {
            return _res.Search(pageIndex, pageSize, out total, product_name, fr_Price, to_Price);
        }
        public List<ProductModel> Search2(int pageIndex, int pageSize, out long total, string product_name, int? fr_Price, int? to_Price)
        {
            return _res.Search2(pageIndex, pageSize, out total, product_name, fr_Price, to_Price);
        }
        public List<ProductModel> Search_full(int pageIndex, int pageSize, out long total, string product_name, string cate_name, int? fr_Price, int? to_Price)
        {
            return _res.Search_full(pageIndex, pageSize, out total, product_name, cate_name, fr_Price, to_Price);
        }
    }
}
