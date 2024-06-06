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
    public class CustomerBusiness:ICustomerBusiness
    {
        private ICustomerRepository _res;
        public CustomerBusiness(ICustomerRepository res)
        {
            _res = res;
        }

        public IEnumerable<CustomerModel> GetDatabyName(string name)
        {
            return _res.GetDatabyName(name);
        }
        public bool Create(CustomerModel model)
        {
            return _res.Create(model);
        }
        public bool Update(CustomerModel model)
        {
            return _res.Update(model);
        }
    }
}
