using System.Collections.Generic;

namespace BackgroundService
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public virtual List<ContactDetail> ContactDetails { get; set; }
    }
}
