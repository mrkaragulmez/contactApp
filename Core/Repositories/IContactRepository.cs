using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactApp.Repositories
{
    public interface IContactRepository
    {
        public Task<IEnumerable<Contact.Infrastructure.Contact>> GetContactsAsync();
        public Task<Contact.Infrastructure.Contact> GetContactAsync(int contactId);
        public Task<int> CreateContactAsync(Contact.Infrastructure.Contact contact);
        public Task DeleteContactAsync(int contactId);
        public Task<int> InsertContactDetailAsync(Contact.Infrastructure.ContactDetail contactDetail);
        public Task RemoveContactDetailAsync(int contactDetailId);
    }
}
