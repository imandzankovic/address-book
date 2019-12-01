using AddressBook.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AddressBook.Repository.Context
{
    public class ContactContext : DbContext
    {
        public virtual DbSet<Contact> Contacts { get; set; }

        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

       
    }
}
