using AddressBook.Entities;
using Microsoft.EntityFrameworkCore;


namespace AddressBook.Repository.Context
{
    public class ContactContext : DbContext
    {
        public virtual DbSet<Contact> Contacts { get; set; }

        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }


    }
}
