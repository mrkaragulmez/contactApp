using Microsoft.EntityFrameworkCore;
using Contact.Infrastructure;

namespace Contact.API.Models.Data
{
    public class ContactDBContext : DbContext
    {
        public ContactDBContext(DbContextOptions<ContactDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Infrastructure.Contact>()
                .HasMany(c => c.ContactDetails)
                .WithOne(e => e.Contact)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Infrastructure.Contact> Contacts { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
    }
}
