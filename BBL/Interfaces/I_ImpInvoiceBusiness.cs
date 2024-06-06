using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Interfaces
{
    public partial interface I_ImpInvoiceBusiness
    {
        ImportInvoiceModel GetDatabyID(int id);
        bool Create(ImportInvoiceModel model);

        bool Update(ImportInvoiceModel model);
        bool Delete(string id);
    }
}
