using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Interfaces
{
    public partial interface IPromotionBusiness
    {
        PromotionModel GetDatabyID(string id);
        bool Create(PromotionModel model);
    }
}
