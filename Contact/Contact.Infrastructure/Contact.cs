using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contact.Infrastructure
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public virtual List<ContactDetail> ContactDetails { get; set; }
    }
}
