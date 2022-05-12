using Contact.Infrastructure;
using ContactApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly IContactRepository contactRepository;
        private readonly IReportRepository reportRepository;
        public ApiController(IContactRepository _contactRepository, IReportRepository _reportRepository)
        {
            contactRepository = _contactRepository;
            reportRepository = _reportRepository;
        }

        [HttpPost]
        public async Task<int> CreateContact(Contact.Infrastructure.Contact contact)
        {
            return await contactRepository.CreateContactAsync(contact);
        }

        [HttpPost]
        [Route("deletecontact/{id}")]
        public async Task DeleteContactAsync(int id)
        {
            await contactRepository.DeleteContactAsync(id);
        }

        [HttpGet]
        [Route("getcontact/{id}")]
        public async Task<Contact.Infrastructure.Contact> GetContactAsync(int id)
        {
            return await contactRepository.GetContactAsync(id);
        }

        [HttpGet]
        [Route("getcontacts")]
        public async Task<IEnumerable<Contact.Infrastructure.Contact>> GetContactsAsync()
        {
            return await contactRepository.GetContactsAsync();
        }

        [HttpPost]
        [Route("insertcontactdetail/{id}")]
        public async Task<int> InsertContactDetailAsync(int id, ContactDetail contactDetail)
        {
            return await contactRepository.InsertContactDetailAsync(id, contactDetail);
        }

        [HttpPost]
        public async Task<int> RemoveAllContactDetailAsync(int id)
        {
            return await contactRepository.RemoveAllContactDetailAsync(id);
        }

        [HttpPost]
        public async Task<int> RemoveContactDetailAsync(int id)
        {
            return await contactRepository.RemoveContactDetailAsync(id);
        }

        [HttpPost]
        public async Task<int> RemoveContactDetailAsync(ContactDetail contactDetail)
        {
            return await contactRepository.RemoveContactDetailAsync(contactDetail);
        }

        [HttpPost]
        public async Task<int> CreateReportAsync(Report.Infrastructure.Report report)
        {
            return await reportRepository.CreateReportAsync(report);
        }

        [HttpPost]
        public async Task<Report.Infrastructure.Report> GetReportAsync(int id)
        {
            return await reportRepository.GetReportAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Report.Infrastructure.Report>> GetReportsAsync()
        {
            return await reportRepository.GetReportsAsync();
        }
    }
}
