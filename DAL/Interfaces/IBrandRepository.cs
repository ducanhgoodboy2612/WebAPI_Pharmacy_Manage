using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IBrandRepository
    {
        IEnumerable<BrandModel> GetAllBrands();

         BrandModel GetDatabyID(string id);
        IEnumerable<ProductModel> GetTopNProductsByBrandId(int n, int brandId);
    }
}
