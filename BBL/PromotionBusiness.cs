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
    public class PromotionBusiness:IPromotionBusiness
    {
        private IPromotionRepository _res;
        public PromotionBusiness(IPromotionRepository res)
        {
            _res = res;
        }

        public PromotionModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public bool Create(PromotionModel model)
        {
            return _res.Create(model);
        }
    }
}
