using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IReportRepository
    {
        decimal GetTotalRevenue();
        decimal GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate);
        decimal GetTotalImportByDateRange(DateTime startDate, DateTime endDate);
    }
}
