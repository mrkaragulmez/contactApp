using System.ComponentModel.DataAnnotations;

namespace Contact.Infrastructure
{
    public class ContactDetail
    {
        [Key]
        public int ID { get; set; }
        public Information InformationType { get; set; }
        public string InformationContent { get; set; }
        public Contact Contact { get; set; }

    }
    public enum Information
    {
        Gsm,
        Email,
        Location
    }
}
