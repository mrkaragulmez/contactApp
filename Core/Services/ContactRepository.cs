using Contact.Infrastructure;
using ContactApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactApp.Services
{
    public class ContactRepository : IContactRepository
    {
        public async Task<int> CreateContactAsync(Contact.Infrastructure.Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteContactAsync(Contact.Infrastructure.Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteContactAsync(int contactId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contact.Infrastructure.Contact> GetContactAsync(int contactId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Contact.Infrastructure.Contact>> GetContactsAsync()
        {
            throw new System.NotImplementedException();
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
    }
}
