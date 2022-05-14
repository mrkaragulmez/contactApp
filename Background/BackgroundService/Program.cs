using IronXL;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConnection connection = GetConnection();
            using IModel channel = connection.CreateModel();
            channel.QueueDeclare("reports", exclusive: false);
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                byte[] body = eventArgs.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);
                ProducerRequestModel data = JsonConvert.DeserializeObject<ProducerRequestModel>(message);
                SaveReportDocument(data);
            };
            channel.BasicConsume(queue: "reports", autoAck: true, consumer: consumer);
            Console.ReadLine();
        }

        private static async Task SaveReportDocument(ProducerRequestModel model)
        {
            CreateExcel(model.FilePath, GetReports());
            RestClient restClient = new RestClient("http://localhost:5629");
            RestRequest restRequest = new RestRequest($"/report/updatereportstatus/{model.ID}/COMPLETED", Method.Post);
            await restClient.ExecuteAsync(restRequest);
        }
        private static void CreateExcel(string FilePath, List<ReportModel> model)
        {
            WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
            var sheet = workbook.CreateWorkSheet("ReportSheet");
            sheet["A1"].Value = "Location";
            sheet["B1"].Value = "Contact Count";
            sheet["C1"].Value = "Gsm Count";

            for (int i = 0; i < model.Count; i++)
            {
                sheet[$"A{i+2}"].Value = model.ElementAt(i).Location;
                sheet[$"B{i+2}"].Value = model.ElementAt(i).ContactCount;
                sheet[$"C{i+2}"].Value = model.ElementAt(i).GsmCount;
            }
            workbook.SaveAs(FilePath);
        }

        private static List<ReportModel> GetReports()
        {
            RestClient restClient = new RestClient("http://localhost:6561");
            RestRequest restRequest = new RestRequest("/contact", Method.Get);
            RestResponse restResponse = restClient.ExecuteAsync(restRequest).Result;
            List<Contact> contacts = JsonConvert.DeserializeObject<IEnumerable<Contact>>(restResponse.Content).ToList();

            List<string> locationList = GetLocationList(contacts);

            List<ReportModel> reportModels = new List<ReportModel>();
            foreach (string item in locationList)
            {
                ReportModel reportModel = new ReportModel();
                reportModel.Location = item;
                foreach (Contact _item in contacts.Where(x => x.ContactDetails.Any(x => x.InformationContent == item)))
                {
                    reportModel.ContactCount++;
                    reportModel.GsmCount += _item.ContactDetails.Where(x => x.InformationType.Equals("gsm")).Count();
                }
                reportModels.Add(reportModel);
            }

            return reportModels;
        }

        private static List<string> GetLocationList(List<Contact> contacts)
        {
            List<string> locationList = new List<string>();
            foreach (var item in contacts)
            {
                List<string> currentLocationList = item.ContactDetails?.Where(x => x.InformationType.Equals("location"))?.Select(x => x.InformationContent).Distinct().ToList();
                locationList.AddRange(currentLocationList);
            }
            return locationList.Distinct().ToList();
        }

        private static IConnection GetConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@rabbitmq:5672")
            };
            return connectionFactory.CreateConnection();
        }
    }
}
