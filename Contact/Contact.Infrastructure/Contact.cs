﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contact.Infrastructure
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public ICollection<ContactDetail> ContactDetails { get; set; }
    }
}
