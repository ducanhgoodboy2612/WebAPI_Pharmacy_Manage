using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Interfaces
{
    public partial interface ICustomerBusiness
    {
        IEnumerable<CustomerModel> GetDatabyName(string name);
        bool Create(CustomerModel model);
        bool Update(CustomerModel model);
    }
}
