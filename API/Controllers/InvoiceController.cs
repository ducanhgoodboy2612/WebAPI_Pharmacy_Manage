using BBL;
using BBL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Net;
using System.Net.Mail;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private I_InvoiceBusiness _bus;
        private string _path;
        private IWebHostEnvironment _env;
        public InvoiceController(I_InvoiceBusiness bus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bus = bus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public SalesInvoiceModel GetDatabyID(int id)
        {
            return _bus.GetDatabyID(id);
        }
        [Route("create-invoice")]
        [HttpPost]
        public SalesInvoiceModel CreateItem([FromBody] SalesInvoiceModel model)
        {
            _bus.Create(model);
            return model;
        }

        [Route("update-invoice")]
        [HttpPost]
        public SalesInvoiceModel Update([FromBody] SalesInvoiceModel model)
        {
            _bus.Update(model);
            return model;
        }

        [Route("update-invoice-info")]
        [HttpPost]
        public SalesInvoiceModel2 UpdateSalesInvoiceInfo([FromBody] SalesInvoiceModel2 model)
        {
            _bus.UpdateSalesInvoiceInfo(model);
            return model;
        }

        [Route("update-invoice-detail-prod")]
        [HttpPost]
        public InvoiceDetail_U UpdateSalesInvoiceInfo([FromBody] InvoiceDetail_U model)
        {
            _bus.UpdateInvoiceDetail_Prod(model);
            return model;
        }
        [Route("delete-invoice")]
        [HttpDelete]
        public bool Delete(string id)
        {
            return _bus.Delete(id);


        }
        [Route("search-invoice")]
        [HttpPost]
        public IActionResult SearchSalesInvoices([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var pageIndex = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());

                string phone = "";
                if (formData.Keys.Contains("phone") && !string.IsNullOrEmpty(Convert.ToString(formData["phone"])))
                {
                    phone = Convert.ToString(formData["phone"]);
                }

                DateTime? fr_Date = null;
                if (formData.Keys.Contains("fr_Date") && formData["fr_Date"] != null && formData["fr_Date"].ToString() != "")
                {
                    fr_Date = DateTime.Parse(formData["fr_Date"].ToString());
                }

                DateTime? to_Date = null;
                if (formData.Keys.Contains("to_Date") && formData["to_Date"] != null && formData["to_Date"].ToString() != "")
                {
                    to_Date = DateTime.Parse(formData["to_Date"].ToString());
                }

                long total = 0;
                var data = _bus.SearchSalesInvoices(pageIndex, pageSize, out total, phone, fr_Date, to_Date);

                return Ok(new
                {
                    TotalItems = total,
                    Data = data,
                    Page = pageIndex,
                    PageSize = pageSize
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("search-invoice-nmbt")]
        [HttpPost]
        public IActionResult SearchSalesInvoices2([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var pageIndex = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());

                string phone = "";
                if (formData.Keys.Contains("phone") && !string.IsNullOrEmpty(Convert.ToString(formData["phone"])))
                {
                    phone = Convert.ToString(formData["phone"]);
                }

                DateTime? fr_Date = null;
                if (formData.Keys.Contains("fr_Date") && formData["fr_Date"] != null && formData["fr_Date"].ToString() != "")
                {
                    fr_Date = DateTime.Parse(formData["fr_Date"].ToString());
                }

                DateTime? to_Date = null;
                if (formData.Keys.Contains("to_Date") && formData["to_Date"] != null && formData["to_Date"].ToString() != "")
                {
                    to_Date = DateTime.Parse(formData["to_Date"].ToString());
                }

                long total = 0;
                var data = _bus.SearchSalesInvoices(pageIndex, pageSize, out total, phone, fr_Date, to_Date);

                return Ok(new
                {
                    TotalItems = total,
                    Data = data,
                    Page = pageIndex,
                    PageSize = pageSize
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("search-full")]
        [HttpPost]
        public IActionResult Search_full([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                
                long total = 0;
                var data = _bus.Search_full(page, pageSize, out total);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
