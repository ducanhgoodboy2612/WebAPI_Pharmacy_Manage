using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Interfaces
{
    public partial interface IReportBusiness
    {
        decimal GetTotalRevenue();
        decimal GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate);
        decimal GetTotalImportByDateRange(DateTime startDate, DateTime endDate);
        
    }
}
