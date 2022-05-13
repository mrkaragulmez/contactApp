using ContactApp.Repositories;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactApp.Services
{
    public class ReportRepository : IReportRepository
    {
        public async Task<int> CreateReportAsync()
        {
            RestClient restClient = new RestClient("http://localhost:5629");
            RestRequest restRequest = new RestRequest("/report", Method.Post);
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            return JsonConvert.DeserializeObject<int>(restResponse.Content);
        }

        public async Task<Report.Infrastructure.Report> GetReportAsync(int reportId)
        {
            RestClient restClient = new RestClient("http://localhost:5629");
            RestRequest restRequest = new RestRequest($"/report/{reportId}", Method.Get);
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            return JsonConvert.DeserializeObject<Report.Infrastructure.Report>(restResponse.Content);
        }

        public async Task<IEnumerable<Report.Infrastructure.Report>> GetReportsAsync()
        {
            RestClient restClient = new RestClient("http://localhost:5629");
            RestRequest restRequest = new RestRequest("/report", Method.Get);
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            return JsonConvert.DeserializeObject<IEnumerable<Report.Infrastructure.Report>>(restResponse.Content);
        }
    }
}
