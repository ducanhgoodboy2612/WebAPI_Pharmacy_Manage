using BBL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Report_StatisticController : ControllerBase
    {
        private IReportBusiness _bus;
        private string _path;
        private IWebHostEnvironment _env;
        public Report_StatisticController(IReportBusiness bus, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bus = bus;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        [Route("get-total-revenue")]
        [HttpGet]
        public IActionResult GetTotalRevenue()
        {
            try
            {
                var totalRevenue = _bus.GetTotalRevenue();
                return Ok(new { totalRevenue });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Lỗi: {ex.Message}" });
            }
        }
        [Route("get-total-revenue-by-date")]
        [HttpGet]
        public IActionResult GetTotalRevenueByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                var totalRevenue = _bus.GetTotalRevenueByDateRange(startDate, endDate);
                return Ok(new { startDate, endDate, totalRevenue });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"There is no sale invoice in this time." });
            }
        }

        [Route("get-total-import-by-date")]
        [HttpGet]
        public IActionResult GetTotalImportByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                var totalRevenue = _bus.GetTotalImportByDateRange(startDate, endDate);
                return Ok(new { startDate, endDate, totalRevenue });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"There is no import invoice in this time." });
            }
        }
    }
}
