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
    public class SupplierBusiness : ISupplierBusiness
    {
        private ISupplierRepository _res;
        public SupplierBusiness(ISupplierRepository res)
        {
            _res = res;
        }

        public SupplierModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(SupplierModel model)
        {
            return _res.Create(model);
        }
        public bool Update(SupplierModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
    }
}
