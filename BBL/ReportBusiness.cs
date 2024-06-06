using BBL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL
{
    public class ReportBusiness : IReportBusiness
    {
        private IReportRepository _res;
        public ReportBusiness(IReportRepository res)
        {
            _res = res;
        }

        public decimal GetTotalRevenue()
        {
            return _res.GetTotalRevenue();
        }

        public decimal GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate)
        {
            return _res.GetTotalRevenueByDateRange(startDate, endDate);
        }

        public decimal GetTotalImportByDateRange(DateTime startDate, DateTime endDate)
        {
            return _res.GetTotalImportByDateRange(startDate, endDate);
        }
    }
}
