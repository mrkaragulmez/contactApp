using Contact.Infrastructure;
using ContactApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
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
        #region Contact

        [HttpGet]
        [Route("getcontacts")]
        public async Task<IEnumerable<Contact.Infrastructure.Contact>> GetContactsAsync()
        {
            return await contactRepository.GetContactsAsync();
        }

        [HttpGet]
        [Route("getcontact/{id}")]
        public async Task<Contact.Infrastructure.Contact> GetContactAsync(int id)
        {
            return await contactRepository.GetContactAsync(id);
        }

        [HttpPost]
        [Route("createcontact")]
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


        #endregion
        
        #region ContactDetail
        [HttpPost]
        [Route("insertcontactdetail")]
        public async Task<Contact.Infrastructure.Contact> InsertContactDetailAsync(ContactDetail contactDetail)
        {
            return await contactRepository.InsertContactDetailAsync(contactDetail);
        }

        [HttpPost]
        [Route("removecontactdetail/{id}")]
        public async Task RemoveContactDetailAsync(int id)
        {
            await contactRepository.RemoveContactDetailAsync(id);
        }
        #endregion

        #region Report
        [HttpPost]
        [Route("createreport")]
        public async Task<Report.Infrastructure.Report> CreateReportAsync()
        {
            if (false)
            {
                throw new Exception();
            }
            return await reportRepository.CreateReportAsync();
        }

        [HttpGet]
        [Route("getreport/{id}")]
        public async Task<Report.Infrastructure.Report> GetReportAsync(int id)
        {
            return await reportRepository.GetReportAsync(id);
        }

        [HttpGet]
        [Route("getreports")]
        public async Task<IEnumerable<Report.Infrastructure.Report>> GetReportsAsync()
        {
            return await reportRepository.GetReportsAsync();
        }
        #endregion


    }
}
