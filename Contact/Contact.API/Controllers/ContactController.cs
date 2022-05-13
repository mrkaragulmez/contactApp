using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contact.API.Models.Data;
using Contact.Infrastructure;

namespace Contact.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactDBContext _context;

        public ContactController(ContactDBContext context)
        {
            _context = context;
        }

        // GET: contact
        [HttpGet]
        public async Task<IEnumerable<Infrastructure.Contact>> GetContacts()
        {
            return await _context.Contacts.Include(x => x.ContactDetails).ToListAsync();
        }

        // GET: contact/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Infrastructure.Contact>> GetContact(int id)
        {
            Infrastructure.Contact contact = await _context.Contacts.Include(x => x.ContactDetails).FirstOrDefaultAsync(x => x.ContactID == id);
            
            if (contact == null)
                return NotFound();
            

            return contact;
        }


        // POST: contact
        [HttpPost]
        public async Task<int> PostContact(Infrastructure.Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return contact.ContactID;
        }

        // DELETE: api/Gateway/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [Route("insertcontactdetail")]
        public async Task<int> InsertContactDetail(ContactDetail contactDetail)
        {
            ContactDetail _contactDetail = new ContactDetail();
            _contactDetail.ContactID = contactDetail.ContactID;
            _contactDetail.InformationType = contactDetail.InformationType;
            _contactDetail.InformationContent = contactDetail.InformationContent;
            _context.ContactDetails.Add(_contactDetail);
            await _context.SaveChangesAsync();

            return _contactDetail.ContactID;
        }

        [HttpDelete]
        [Route("removecontactdetail/{id}")]
        public async Task<IActionResult> RemoveContactDetail(int id)
        {
            ContactDetail contactDetail = await _context.ContactDetails.FindAsync(id);
            if (contactDetail == null)
            {
                return NotFound();
            }
            _context.ContactDetails.Remove(contactDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.ContactID == id);
        }
    }
}
