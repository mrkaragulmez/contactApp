using Microsoft.EntityFrameworkCore;

namespace Report.API.Models.Data
{
    public class ReportDBContext : DbContext
    {
        public ReportDBContext(DbContextOptions<ReportDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Infrastructure.Report> Reports { get; set; }
    }
}
