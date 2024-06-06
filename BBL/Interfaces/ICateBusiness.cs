using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Interfaces
{
    public partial interface ICateBusiness
    {
        CategoryModel GetDatabyID(string id);
        IEnumerable<CategoryModel> GetAllCates();
        bool Create(CategoryModel model);
        //bool Update(CategoryModel model);
        bool Delete(string id);
    }
}
