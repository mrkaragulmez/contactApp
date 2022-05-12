﻿using Report.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactApp.Repositories
{
    public interface IReportRepository
    {
        public Task<int> CreateReportAsync(Report.Infrastructure.Report report);
        public Task<IEnumerable<Report.Infrastructure.Report>> GetReportsAsync();
        public Task<Report.Infrastructure.Report> GetReportAsync(int reportId);
    }
}
