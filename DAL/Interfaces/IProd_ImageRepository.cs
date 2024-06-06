using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IProd_ImageRepository
    {
        IEnumerable<ProdImageModel> GetImageById(int id);
    }
}
