using Contact.Infrastructure;
using ContactApp.Repositories;
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
        public async Task<IEnumerable<Contact.Infrastructure.Contact>> GetContactsAsync()
        {
            RestClient restClient = new RestClient("http://localhost:6561");
            RestRequest restRequest = new RestRequest("/contact", Method.Get);
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            return JsonConvert.DeserializeObject<IEnumerable<Contact.Infrastructure.Contact>>(restResponse.Content);

        }
        public async Task<Contact.Infrastructure.Contact> GetContactAsync(int contactId)
        {
            RestClient restClient = new RestClient("http://localhost:6561");
            RestRequest restRequest = new RestRequest($"/contact/{contactId}", Method.Get);
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            return JsonConvert.DeserializeObject<Contact.Infrastructure.Contact>(restResponse.Content);
        }

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
            RestRequest restRequest = new RestRequest($"/contact/{contactId}", Method.Delete);
            await restClient.ExecuteAsync(restRequest);
        }

        public async Task<int> InsertContactDetailAsync(ContactDetail contactDetail)
        {
            RestClient restClient = new RestClient("http://localhost:6561");
            RestRequest restRequest = new RestRequest("/contact/insertcontactdetail", Method.Post);
            restRequest.AddJsonBody(contactDetail);
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            return JsonConvert.DeserializeObject<int>(restResponse.Content);
        }


        public async Task RemoveContactDetailAsync(int contactDetailId)
        {
            RestClient restClient = new RestClient("http://localhost:6561");
            RestRequest restRequest = new RestRequest($"/contact/removecontactdetail/{contactDetailId}", Method.Delete);
            await restClient.ExecuteAsync(restRequest);
        }
    }
}
