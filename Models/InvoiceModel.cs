using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SalesInvoiceModel
    {
        public int InvoiceID { get; set; }
        //public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<InvoiceDetailModel> list_json_invoice_detail { get; set; }
    }

    public class InvoiceDetailModel
    {
        public int InvoiceID { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public int Total_Price { get; set; }
        public int Status { get; set; }
    }



    public class SalesInvoiceModel2
    {
        public int InvoiceID { get; set; }
        //public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        
    }

    public class InvoiceDetail_U
    {
        public int InvoiceID { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }

    }
}
