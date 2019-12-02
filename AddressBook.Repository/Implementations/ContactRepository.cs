using AddressBook.Core.Common.Extensions.Generic;
using AddressBook.Entities;
using AddressBook.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace AddressBook.Repository
{
    public class ContactRepository
    {
        private readonly ContactContext _dbContext;

        public ContactRepository(ContactContext _contactContext)
        {
            _dbContext = _contactContext;
        }

        public async Task<Contact> Add(Contact contact)
        {
            _dbContext.Set<Contact>().Add(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> Delete(int id)
        {
            var contact = await _dbContext.Set<Contact>().FindAsync(id);
            if (contact == null)
            {
                return contact;
            }

            _dbContext.Set<Contact>().Remove(contact);
            await _dbContext.SaveChangesAsync();

            return contact;
        }

        public async Task<Contact> Get(int id)
        {
            return await _dbContext.Set<Contact>().FindAsync(id);
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _dbContext.Set<Contact>().ToListAsync();
        }


        public async Task<Contact> Update(int id, Contact contact)
        {

            var savedContact = await _dbContext.Set<Contact>().FindAsync(id);
            contact.Id = (contact.Id == 0) ? savedContact.Id : contact.Id;

            var UpdatedContact = CheckObjectProperties.CheckUpdateObject(savedContact, contact);

            _dbContext.Entry(savedContact).CurrentValues.SetValues(UpdatedContact);

            //_dbContext.Set<Contact>().Update(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }


    }
}
