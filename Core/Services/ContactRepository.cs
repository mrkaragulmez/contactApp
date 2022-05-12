using Contact.Infrastructure;
using ContactApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ContactApp.Services
{
    public class ContactRepository : IContactRepository
    {
        IConnection connection;
        public async Task<int> CreateContactAsync(Contact.Infrastructure.Contact contact)
        {
            RestClient restClient = new RestClient("http://localhost:6561");
            RestRequest restRequest = new RestRequest("/contact", Method.Post);
            restRequest.AddJsonBody(contact);
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            return JsonConvert.DeserializeObject<int>(restResponse.Content);
        }

        public async Task DeleteContactAsync(int contactId)
        {
            RestClient restClient = new RestClient("http://localhost:6561");
            RestRequest restRequest = new RestRequest("/contact", Method.Delete);
            restRequest.AddParameter("id", contactId);
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            JsonConvert.DeserializeObject<int>(restResponse.Content);
        }

        public async Task<Contact.Infrastructure.Contact> GetContactAsync(int contactId)
        {
            RestClient restClient = new RestClient("http://localhost:6561");
            RestRequest restRequest = new RestRequest($"/contact/{contactId}", Method.Get);
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            return JsonConvert.DeserializeObject<Contact.Infrastructure.Contact>(restResponse.Content);
        }

        public async Task<IEnumerable<Contact.Infrastructure.Contact>> GetContactsAsync()
        {
            RestClient restClient = new RestClient("http://localhost:6561");
            RestRequest restRequest = new RestRequest("/contact", Method.Get);
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            return JsonConvert.DeserializeObject<IEnumerable<Contact.Infrastructure.Contact>>(restResponse.Content);

            //if (connection == null || !connection.IsOpen)
            //    connection = GetConnection();
            //AddLog("Connection is open now");
        }

        public async Task<int> InsertContactDetailAsync(int contactId, ContactDetail contactDetail)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> RemoveAllContactDetailAsync(int contactId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> RemoveContactDetailAsync(int contactDetailId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> RemoveContactDetailAsync(ContactDetail contactDetail)
        {
            throw new System.NotImplementedException();
        }

        private IConnection GetConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@rabbitmq:5672")
            };
            return connectionFactory.CreateConnection();
        }

        private void AddLog(string logMessage)
        {
            Debug.WriteLine(logMessage);
        }
    }
}
