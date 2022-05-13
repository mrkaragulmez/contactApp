using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using Report.API.Models.Data;
using Report.API.Repositories;
using Report.Infrastructure;

namespace Report.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMessageProducer _messageProducer;
        private readonly ReportDBContext _context;

        public ReportController(ReportDBContext context, IHostingEnvironment hostingEnvironment, IMessageProducer messageProducer)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public async Task<ActionResult<Infrastructure.Report>> PostReport()
        {
            Infrastructure.Report report = new Infrastructure.Report();
            report.RequestDate = DateTime.Now;
            report.FilePath = $"{_hostingEnvironment.ContentRootPath}\\GeneratedReports\\ContactReport_{report.RequestDate.ToString("dd/MM/yyyy")}";
            _context.Reports.Add(report);
            int saved = await _context.SaveChangesAsync();
            if (saved > 0)
            {
                CreateDocument(report);
                return CreatedAtAction("GetReport", new { id = report.ID }, report);
            }
            else
            {
                return CreatedAtAction("GetReport", null);
            }
        }

        // GET: Report
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Infrastructure.Report>>> GetReports()
        {
            return await _context.Reports.ToListAsync();
        }

        // GET: Report/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Infrastructure.Report>> GetReport(int id)
        {
            var report = await _context.Reports.FindAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            return report;
        }

        private void CreateDocument<T>(T document)
        {
            IConnection connection = GetConnection();
            _messageProducer.SendMessage(document, connection);
        }

        private IConnection GetConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@rabbitmq:5672")
            };
            AddLog("Connection is open now");
            return connectionFactory.CreateConnection();
        }

        private void AddLog(string logMessage)
        {
            Debug.WriteLine(logMessage);
        }
    }
}
