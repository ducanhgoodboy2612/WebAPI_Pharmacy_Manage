using DAL.Interfaces;
using Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBL.Interfaces;

namespace BBL
{
    public class BrandBusiness:IBrandBusiness
    {
        private IBrandRepository _res;
        public BrandBusiness(IBrandRepository res)
        {
            _res = res;
        }

       
        public IEnumerable<BrandModel> GetAllBrands()
        {
            return _res.GetAllBrands();
        }

        public BrandModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);

        }
        public IEnumerable<ProductModel> GetTopNProductsByBrandId(int n, int brandId)
        {
            return _res.GetTopNProductsByBrandId(n, brandId);
        }
    }
}
