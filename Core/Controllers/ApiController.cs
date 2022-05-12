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
        public async Task DeleteContactAsync(Contact.Infrastructure.Contact contact)
        {
            await contactRepository.DeleteContactAsync(contact);
        }

        [HttpPost]
        public async Task DeleteContactAsync(int contactId)
        {
            await contactRepository.DeleteContactAsync(contactId);
        }

        [HttpPost]
        public async Task<Contact.Infrastructure.Contact> GetContactAsync(int contactId)
        {
            return await contactRepository.GetContactAsync(contactId);
        }

        [HttpGet]
        public async Task<IEnumerable<Contact.Infrastructure.Contact>> GetContactsAsync()
        {
            return await contactRepository.GetContactsAsync();
        }

        [HttpPost]
        public async Task<int> InsertContactDetailAsync(int contactId, ContactDetail contactDetail)
        {
            return await contactRepository.InsertContactDetailAsync(contactId, contactDetail);
        }

        [HttpPost]
        public async Task<int> RemoveAllContactDetailAsync(int contactId)
        {
            return await contactRepository.RemoveAllContactDetailAsync(contactId);
        }

        [HttpPost]
        public async Task<int> RemoveContactDetailAsync(int contactDetailId)
        {
            return await contactRepository.RemoveContactDetailAsync(contactDetailId);
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
        public async Task<Report.Infrastructure.Report> GetReportAsync(int reportId)
        {
            return await reportRepository.GetReportAsync(reportId);
        }

        [HttpGet]
        public async Task<IEnumerable<Report.Infrastructure.Report>> GetReportsAsync()
        {
            return await reportRepository.GetReportsAsync();
        }
    }
}
