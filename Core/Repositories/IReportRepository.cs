using Report.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactApp.Repositories
{
    public interface IReportRepository
    {
        public Task<Report.Infrastructure.Report> CreateReportAsync();
        public Task<IEnumerable<Report.Infrastructure.Report>> GetReportsAsync();
        public Task<Report.Infrastructure.Report> GetReportAsync(int reportId);
    }
}
