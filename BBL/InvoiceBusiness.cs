using BBL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BBL
{
    public class InvoiceBusiness : I_InvoiceBusiness
    {
        private I_InvoiceRepository _res;
        public InvoiceBusiness(I_InvoiceRepository res)
        {
            _res = res;
        }

        public SalesInvoiceModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(SalesInvoiceModel model)
        {
            return _res.Create(model);
        }
        public bool Update(SalesInvoiceModel model)
        {
            return _res.Update(model);
        }

        public bool UpdateSalesInvoiceInfo(SalesInvoiceModel2 model)
        {
            return _res.UpdateSalesInvoiceInfo(model);
        }

        public bool UpdateInvoiceDetail_Prod(InvoiceDetail_U model)
        {
            return _res.UpdateInvoiceDetail_Prod(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<SalesInvoiceModel> SearchSalesInvoices(int pageIndex, int pageSize, out long total, string phone, DateTime? fr_Date, DateTime? to_Date)
        {
            return _res.SearchSalesInvoices(pageIndex, pageSize, out total, phone, fr_Date, to_Date);
        }
        public List<SalesInvoiceModel> Search_full(int pageIndex, int pageSize, out long total)
        {
            return _res.Search_full(pageIndex, pageSize, out total);
        }
    }
}
