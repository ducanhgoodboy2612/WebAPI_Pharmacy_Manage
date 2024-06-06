using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface ISupplierRepository
    {
        SupplierModel GetDatabyID(string id);
        bool Create(SupplierModel model);
        bool Update(SupplierModel model);
        bool Delete(string id);
    }
}
