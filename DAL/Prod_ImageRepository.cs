using DAL.Helper;
using DAL.Helper.Interfaces;
using Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Prod_ImageRepository : IProd_ImageRepository
    {
        private IDatabaseHelper _dbHelper;
        public Prod_ImageRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public IEnumerable<ProdImageModel> GetImageById(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetProductImages",
                     "@ProductId", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProdImageModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
