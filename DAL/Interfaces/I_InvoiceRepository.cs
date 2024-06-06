using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface I_InvoiceRepository
    {
        SalesInvoiceModel GetDatabyID(int id);
        bool Create(SalesInvoiceModel model);
        bool Update(SalesInvoiceModel model);

        bool UpdateSalesInvoiceInfo(SalesInvoiceModel2 model);
        bool UpdateInvoiceDetail_Prod(InvoiceDetail_U model);
        bool Delete(string id);
        public List<SalesInvoiceModel> SearchSalesInvoices(int pageIndex, int pageSize, out long total, string phone, DateTime? fr_Date, DateTime? to_Date);
        public List<SalesInvoiceModel> Search_full(int pageIndex, int pageSize, out long total);
    }
}
