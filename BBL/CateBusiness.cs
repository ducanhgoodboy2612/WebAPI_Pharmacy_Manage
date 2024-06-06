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
    public class CateBusiness:ICateBusiness
    {
        private ICateRepository _res;
        public CateBusiness(ICateRepository res)
        {
            _res = res;
        }

        public CategoryModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public IEnumerable<CategoryModel> GetAllCates()
        {
            return _res.GetAllCates();
        }
        public bool Create(CategoryModel model)
        {
            return _res.Create(model);
        }
        //public bool Update(SupplierModel model)
        //{
        //    return _res.Update(model);
        //}
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
    }
}
