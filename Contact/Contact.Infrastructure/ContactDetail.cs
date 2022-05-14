using System.ComponentModel.DataAnnotations;

namespace Contact.Infrastructure
{
    public class ContactDetail
    {
        [Key]
        public int ContactDetailID { get; set; }
        public string InformationType { get; set; }
        public string InformationContent { get; set; }
        public int ContactID { get; set; }

    }
}
