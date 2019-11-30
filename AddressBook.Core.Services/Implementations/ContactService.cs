using Autofac;
using AddressBook.Core.Common.Extensions.Generic;
using AddressBook.Models.Request.Contact;
using AddressBook.Models.Response;
using AddressBook.Models.Response.Contact;
using AddressBook.Models.Search.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Core.Services.Implementations
{
    public class ContactService : BaseService, IContactService
    {
        private List<ContactResponseModel> contacts;

        public ContactService(ILifetimeScope scope) : base(scope)
        {
            contacts = GetDummyContacts();
        }

        public async Task<ContactResponseModel> AddContactAsync(ContactRequestModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ContactResponseModel> UpdateContactAsync(int id, ContactRequestModel model)
        {
            throw new NotImplementedException();
        }

        public async Task DeactivateContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ContactResponseModel> GetContactById(int id)
        {
            var samplesList = contacts.Where(q => q.Id == id).AsQueryable();
             
            return samplesList.FirstOrDefault();
        }

        public async Task<PagedResponseModel<ContactResponseModel>> GetContactsAsync(ContactSearchModel model)
        {
            var samplesList = contacts.Where(q =>
                (string.IsNullOrEmpty(model.FirstName) || q.FirstName.Contains(model.FirstName))
                && (string.IsNullOrEmpty(model.LastName) || q.LastName.Contains(model.LastName))
                && (string.IsNullOrEmpty(model.Email) || q.Email.Contains(model.Email))
                && (model.ModifiedFrom == null || q.ModifiedDate >= model.ModifiedFrom)
                && (model.ModifiedTo == null || q.ModifiedDate <= model.ModifiedTo))
                .AsQueryable();

            var page = samplesList.ToPagedResponseModel(model.PageNumber, model.PageSize);

            return page;
        }

        private List<ContactResponseModel> GetDummyContacts()
        {
            var list = new List<ContactResponseModel>
            {
                new ContactResponseModel()
                {
                    Id = 1001,
                    Phone = 257897654,
                    FirstName = "Nera",
                    LastName = "Zjakic",
                    Email = "nera@mail.com",
                    ModifiedDate = new DateTime(2018, 10, 25)
                },
                new ContactResponseModel()
                {
                    Id = 1002,
                    Phone = 284321543,
                    FirstName = "Zlatan",
                    LastName = "Cilic",
                    Email = "zlatan@mail.com",
                    ModifiedDate = new DateTime(2018, 10, 29)
                },
                new ContactResponseModel()
                {
                    Id = 1003,
                    Phone = 312345678,
                    FirstName = "Amra",
                    LastName = "Mesic",
                    Email = "amra@mail.com",
                    ModifiedDate = new DateTime(2018, 11, 2)
                },
                new ContactResponseModel()
                {
                    Id = 1004,
                    Phone = 22345677,
                    FirstName = "Mirza",
                    LastName = "Dalic",
                    Email = "mirza@mail.com",
                    ModifiedDate = new DateTime(2018, 11, 3)
                },
                new ContactResponseModel()
                {
                    Id = 1005,
                    Phone = 341234567,
                    FirstName = "Ivana",
                    LastName = "Granzov",
                    Email = "ivana@mail.com",
                    ModifiedDate = new DateTime(2018, 11, 4)
                }
            };

            return list;
        }
    }
}
