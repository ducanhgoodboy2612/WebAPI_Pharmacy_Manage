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
    public class ImpInvoiceBusiness : I_ImpInvoiceBusiness
    {
        private I_ImpInvoiceRepository _res;
        public ImpInvoiceBusiness(I_ImpInvoiceRepository res)
        {
            _res = res;
        }

        public ImportInvoiceModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(ImportInvoiceModel model)
        {
            return _res.Create(model);
        }
        public bool Update(ImportInvoiceModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
    }
}
