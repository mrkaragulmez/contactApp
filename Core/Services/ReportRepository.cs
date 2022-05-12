using ContactApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactApp.Services
{
    public class ReportRepository : IReportRepository
    {
        public async Task<int> CreateReportAsync(Report.Infrastructure.Report report)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Report.Infrastructure.Report> GetReportAsync(int reportId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Report.Infrastructure.Report>> GetReportsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
