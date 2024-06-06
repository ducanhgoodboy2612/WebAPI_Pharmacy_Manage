using BBL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL
{
    public class Prod_ImageBusiness : IProd_ImageBusiness
    {
        private IProd_ImageRepository _res;
        public Prod_ImageBusiness(IProd_ImageRepository res)
        {
            _res = res;
        }

        
        public IEnumerable<ProdImageModel> GetImageById(int id)
        {
            return _res.GetImageById(id);
        }
    }
}
