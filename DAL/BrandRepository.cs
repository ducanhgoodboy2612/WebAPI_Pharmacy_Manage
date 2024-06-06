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
    public class BrandRepository:IBrandRepository
    {
        private IDatabaseHelper _dbHelper;
        public BrandRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public IEnumerable<BrandModel> GetAllBrands()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Brand_getAll");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<BrandModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BrandModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Brand_GetById",
                     "@BrandID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<BrandModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public IEnumerable<ProductModel> GetTopNProductsByBrandId(int n, int brandId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetTopNProductsByBrandId",
                     "@n", n,
                     "@brandId", brandId);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProductModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
