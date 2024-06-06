using DAL.Helper.Interfaces;
using DAL.Helper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL
{
    public class ImpInvoiceRepository : I_ImpInvoiceRepository
    {
        private IDatabaseHelper _dbHelper;
        public ImpInvoiceRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public ImportInvoiceModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_ImportInvoice_details_GetById",
                     "@InvoiceID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ImportInvoiceModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(ImportInvoiceModel model)
        {

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Add_import_invoice",
                "@SupplierID", model.SupplierID,
                "@EmployeeID", model.EmployeeID,
                "@CarrierName ", model.CarrierName,
                "@Status", model.Status,
                "@list_json_invoice_details", model.list_json_invoice_detail != null ? MessageConvert.SerializeObject(model.list_json_invoice_detail) : null);
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
        public bool Update(ImportInvoiceModel model)
        {
            string msgError = "";
            try
            {
               
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Update_Import_invoice",
                "@InvoiceID", model.InvoiceID,
                "@SupplierID", model.SupplierID,
                "@EmployeeID", model.EmployeeID,
                "@CarrierName ", model.CarrierName,
                "@CreatedDate ", model.CreatedDate,
                "@Status", model.@Status,
                "@list_json_invoice_details", model.list_json_invoice_detail != null ? MessageConvert.SerializeObject(model.@list_json_invoice_detail) : null);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Delete_Import_Invoice_By_ID",
                "@InvoiceID", id
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
    }
}
