using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactApp.Repositories
{
    public interface IContactRepository
    {
        public Task<IEnumerable<Contact.Infrastructure.Contact>> GetContactsAsync();
        public Task<Contact.Infrastructure.Contact> GetContactAsync(int contactId);
        public Task<int> CreateContactAsync(Contact.Infrastructure.Contact contact);
        public Task DeleteContactAsync(Contact.Infrastructure.Contact contact);
        public Task DeleteContactAsync(int contactId);
        public Task<int> InsertContactDetailAsync(int contactId, Contact.Infrastructure.ContactDetail contactDetail);
        public Task<int> RemoveAllContactDetailAsync(int contactId);
        public Task<int> RemoveContactDetailAsync(int contactDetailId);
        public Task<int> RemoveContactDetailAsync(Contact.Infrastructure.ContactDetail contactDetail);
    }
}
