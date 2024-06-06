using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Interfaces
{
    public partial interface IBrandBusiness
    {
        IEnumerable<BrandModel> GetAllBrands();
        BrandModel GetDatabyID(string id);
        IEnumerable<ProductModel> GetTopNProductsByBrandId(int n, int brandId);
    }
}
