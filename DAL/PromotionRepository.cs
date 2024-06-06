using DAL.Helper;
using DAL.Helper.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PromotionRepository : IPromotionRepository
    {
        private IDatabaseHelper _dbHelper;
        public PromotionRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public PromotionModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Promotion_getbyId",
                     "@Sale_Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<PromotionModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public bool Create(PromotionModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_AddPromotion",
                    "@Product_Id", model.Product_Id,
                    "@Discount", model.Discount,
                    "@Start_Date", model.Start_Date,
                    "@End_Date", model.End_Date);

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
