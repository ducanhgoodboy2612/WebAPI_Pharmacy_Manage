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
    public class ProductRepository : IProductRepository
    {
        private IDatabaseHelper _dbHelper;
        public ProductRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public ProductModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Product_GetById",
                     "@ProductId", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProductModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public PromotionModel GetPromotion(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetPromotionByProductId",
                     "@Product_Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<PromotionModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public IEnumerable<ProductModel> GetDatabyCategory(string cate_name)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Product_GetAllByCate",
                     "@CategoryName", cate_name);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProductModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public IEnumerable<ProductModel> GetDatabyCateID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Product_GetAllByCateid",
                     "@CategoryID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProductModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public IEnumerable<ProductModel> GetAllData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Product_GetAll");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProductModel>(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ProductModel> GetNewProd()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "[sp_GetNewProducts]");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProductModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<ProductModel> GetNewProducts()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Product_GetNewP");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProductModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(ProductModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Product_Create",
                "@Cate_Id", model.Cate_Id,
                "@Product_Name", model.Product_Name,
                "@Unit", model.Unit,
                "@Unit_Price", model.Unit_Price,
                "@Quantity_In_Stock", model.Quantity_In_Stock,
                "@Picture", model.Picture,
                "@Status", model.Status,
                "@Description", model.Description,
                "@BrandID", model.BrandID
                );
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
        public bool Update(ProductModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_UpdateProduct",
                "@Product_Id", model.Product_Id,
                "@Cate_Id", model.Cate_Id,
                "@Product_Name", model.Product_Name,
                "@Unit", model.Unit,
                "@Unit_Price", model.Unit_Price,
                "@Quantity_In_Stock", model.Quantity_In_Stock,
                "@Picture", model.Picture,
                "@Status", model.Status,
                "@Description", model.Description,
                "@BrandID", model.BrandID);
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

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "[sp_DeleteProduct]",
                "@Product_Id", id
                );
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

        public IEnumerable<PromotionModel> GetProductInSale()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_GetProductsInPromotion");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<PromotionModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ProductModel_withRevenue> GetTop_bySales(int n)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Product_GetTop_BySales",
                     "@N", n);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProductModel_withRevenue>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ProductModel_withSoldNumber> GetTop_bySalesQuantity(int n)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Product_GetTop_ByQuantity",
                     "@N", n);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ProductModel_withSoldNumber>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product_ReportModel> GetProductSales(int pageIndex, int pageSize, out long total, DateTime? startDate, DateTime? endDate)
        {
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out string msgError, "[sp_GetProductSalesQuantity]",
                    "@pageIndex", pageIndex,
                    "@pageSize", pageSize,
                    "@startDate", startDate,
                    "@endDate", endDate
                );

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                if (dt.Rows.Count > 0)
                    total = Convert.ToInt64(dt.Rows[0]["RecordCount"]);

                return dt.ConvertTo<Product_ReportModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<ProductModel> GetInventory(int pageIndex, int pageSize, out long total)
        {
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out string msgError, "[sp_Get_Inventory]",
                    "@page_index", pageIndex,
                    "@page_size", pageSize
                );

                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);

                if (dt.Rows.Count > 0)
                    total = Convert.ToInt64(dt.Rows[0]["RecordCount"]);

                return dt.ConvertTo<ProductModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<ProductModel> Search(int pageIndex, int pageSize, out long total, string product_name, int? fr_Price, int? to_Price)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "[sp_search_product]",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@product_name", product_name,
                    "@fr_Price", fr_Price,
                    "@to_Price", to_Price
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ProductModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ProductModel> Search2(int pageIndex, int pageSize, out long total, string product_name, int? fr_Price, int? to_Price)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_search_product",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@product_name", product_name,
                    "@fr_Price", fr_Price,
                    "@to_Price", to_Price
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ProductModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<ProductModel> Search_full(int pageIndex, int pageSize, out long total, string product_name, string cate_name, int? fr_Price, int? to_Price)
        //{
        //    string msgError = "";
        //    total = 0;
        //    try
        //    {
        //        var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_search_full",
        //            "@page_index", pageIndex,
        //            "@page_size", pageSize,
        //            "@product_name", product_name,
        //            "@cate_name", cate_name,
        //            "@fr_Price", fr_Price,
        //            "@to_Price", to_Price
        //             );
        //        if (!string.IsNullOrEmpty(msgError))
        //            throw new Exception(msgError);
        //        if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
        //        return dt.ConvertTo<ProductModel>().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<ProductModel> Search_full(int pageIndex, int pageSize, out long total, string product_name, string cate_id, int? fr_Price, int? to_Price)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_product_search_full_v2",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@product_name", product_name,
                    "@cate_id", cate_id,
                    "@fr_Price", fr_Price,
                    "@to_Price", to_Price
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ProductModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
