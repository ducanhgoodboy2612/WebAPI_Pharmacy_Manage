using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface ICustomerRepository
    {
        IEnumerable<CustomerModel> GetDatabyName(string name);
        bool Create(CustomerModel model);
        bool Update(CustomerModel model);
    }
}
