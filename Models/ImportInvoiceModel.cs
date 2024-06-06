using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ImportInvoiceModel
    {
        public int InvoiceID { get; set; }
        public int SupplierID { get; set; }
        public int EmployeeID { get; set; }
        public string CarrierName { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public List<ImportInvoiceDetailModel> list_json_invoice_detail { get; set; }
    }

    public class ImportInvoiceDetailModel
    {
        public int InvoiceID { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
    }

}
