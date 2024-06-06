using DAL.Helper;
using DAL.Helper.Interfaces;
using DAL.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InvoiceRepository : I_InvoiceRepository
    {
        private IDatabaseHelper _dbHelper;
        public InvoiceRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public SalesInvoiceModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_invoice_details_GetById",
                     "@InvoiceID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SalesInvoiceModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(SalesInvoiceModel model)
        {

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "[sp_Add_sales_invoice_V3]",
                "@CustomerName", model.CustomerName,
                "@Phone", model.Phone,
                "@Address ", model.Address,
                "@Email ", model.Email,
                "@Status", model.Status,
                "@list_json_invoice_details", model.list_json_invoice_detail != null ? MessageConvert.SerializeObject(model.list_json_invoice_detail) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }


                //send email

                //using (var client = new HttpClient())
                //{
                //    var emailModel = new
                //    {
                //        To = model.Email,
                //        Subject = "Xác nhận thanh toán",
                //        Body = $"Xin chào {model.CustomerName},<br><br>Cảm ơn bạn đã mua hàng. Đơn hàng của bạn đã được thanh toán thành công.<br><br>Trân trọng,<br>Cửa hàng của chúng tôi"
                //    };

                //    var json = JsonConvert.SerializeObject(emailModel);
                //    var content = new StringContent(json, Encoding.UTF8, "application/json");

                //    var response = client.PostAsync("https://localhost:44315/api/send-email", content).Result;
                //    if (!response.IsSuccessStatusCode)
                //    {
                //        var errorContent =  response.Content.ReadAsStringAsync();
                //        throw new Exception($"Email sending failed: {errorContent}");
                //    }
                //}

                //SendEmailNotification(model.Email, model);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void SendEmailNotification(string email, SalesInvoiceModel invoice)
        {
            // Create a new MailMessage object
            MailMessage message = new MailMessage();
            message.From = new MailAddress("ducanhhahaha73@gmail.com");
            message.To.Add(email);
            message.Subject = "Order Confirmation";
            message.Body = $"Thank you for your order! Your invoice details are as follows:\n\n" +
                          $"Invoice Number: {invoice.InvoiceID}\n" +
                          $"Customer Name: {invoice.CustomerName}\n" +
                          $"Address: {invoice.Address}\n" +
                          $"Phone: {invoice.Phone}\n" +
                          $"Email: {invoice.Email}\n" +
                          $"Status: {invoice.Status}\n\n" +
                          $"Invoice Details:\n{string.Join("\n", invoice.list_json_invoice_detail.Select(d => $"{d.Product_Id} - {d.Quantity} - {d.Total_Price}"))}"
                          ;

            // Create a new SmtpClient object
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.example.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("ducanhhahaha73@gmail.com", "chocopyke2003");

            // Send the email
            client.Send(message);
        }



        public async Task<bool> CreateAsync(SalesInvoiceModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "[sp_Add_sales_invoice_V3]",
                "@CustomerName", model.CustomerName,
                "@Phone", model.Phone,
                "@Address ", model.Address,
                "@Email ", model.Email,
                "@Status", model.Status,
                "@list_json_invoice_details", model.list_json_invoice_detail != null ? MessageConvert.SerializeObject(model.list_json_invoice_detail) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }

                // send email
                using (var client = new HttpClient())
                {
                    var emailModel = new
                    {
                        To = model.Email,
                        Subject = "Xác nhận thanh toán",
                        Body = $"Xin chào {model.CustomerName},<br><br>Cảm ơn bạn đã mua hàng. Đơn hàng của bạn đã được thanh toán thành công.<br><br>Trân trọng,<br>Cửa hàng của chúng tôi"
                    };

                    var json = JsonConvert.SerializeObject(emailModel);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("https://localhost:44315/api/send-email", content);
                    if (!response.IsSuccessStatusCode)
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Email sending failed: {errorContent}");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CreateAsync: " + ex.Message, ex);
            }
        }

        public bool Update(SalesInvoiceModel model)
        {
            string msgError = "";
            try
            {
                //date lay ngay he thong
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Update_Sales_invoice",
                "@InvoiceID", model.InvoiceID,
                "@CustomerName", model.CustomerName,
                "@Phone", model.Phone,
                "@Address ", model.Address,
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


        public bool UpdateSalesInvoiceInfo(SalesInvoiceModel2 model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_UpdateSalesInvoice_Info",
                "@InvoiceID", model.InvoiceID,
                "@Status", model.Status,
                "@CustomerName", model.CustomerName,
                "@Phone", model.Phone,
                "@Address", model.Address);
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

        public bool UpdateInvoiceDetail_Prod(InvoiceDetail_U model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_UpdateInvoiceDetail_Prod",
                "@InvoiceID", model.InvoiceID,
                "@Product_Id", model.Product_Id,
                "@Quantity", model.Quantity);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "[sp_DeleteInvoice]",
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
        //public List<EmployeeModel> Search(int pageIndex, int pageSize, out long total, string emp_name, int? fr_Salary, int? to_Salary)
        //{
        //    string msgError = "";
        //    total = 0;
        //    try
        //    {
        //        var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_search_emp",
        //            "@page_index", pageIndex,
        //            "@page_size", pageSize,
        //            "@emp_name", emp_name,
        //            "@fr_Salary", fr_Salary,
        //            "@to_Salary", to_Salary
        //             );
        //        if (!string.IsNullOrEmpty(msgError))
        //            throw new Exception(msgError);
        //        if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
        //        return dt.ConvertTo<EmployeeModel>().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<SalesInvoiceModel> SearchSalesInvoices(int pageIndex, int pageSize, out long total, string phone, DateTime? fr_Date, DateTime? to_Date)
        {
            string errorMsg = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out errorMsg, "sp_sales_invoice_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@phone", phone,
                    "@fr_Date", fr_Date,
                    "@to_Date", to_Date
                );

                if (!string.IsNullOrEmpty(errorMsg))
                    throw new Exception(errorMsg);

                if (dt.Rows.Count > 0)
                    total = (long)dt.Rows[0]["RecordCount"];

                return dt.ConvertTo<SalesInvoiceModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SalesInvoiceModel> Search_full(int pageIndex, int pageSize, out long total)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "[sp_sales_invoice_search_all]",
                    "@page_index", pageIndex,
                    "@page_size", pageSize
                   
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SalesInvoiceModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
