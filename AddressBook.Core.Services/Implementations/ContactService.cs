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
using AddressBook.Entities;
using AddressBook.Repository;
using AddressBook.Repository.Context;
using AddressBook.Core.Common.Helpers;

namespace AddressBook.Core.Services.Implementations
{
    public class ContactService : AddressBook.Core.Services.IContactService
    {
   
        private List<ContactResponseModel> _contacts;
        private readonly ContactRepository _contactRepository;
        public ContactService(ContactRepository contactRepository) 
        {
            _contactRepository = contactRepository;
           
        }

        public async Task<ContactResponseModel> AddContactAsync(Models.Request.Contact.ContactRequestModel model)
        {
            var newContact = RequestHelper.requestToEntity(model);
            var createdContact=await _contactRepository.Add(newContact);
            return ResponseHelper.entityToResponse(createdContact);
        }

        public async Task<ContactResponseModel> UpdateContactAsync(int id, Models.Request.Contact.ContactRequestModel model)
        {
            var contactToUpdate = RequestHelper.requestToEntity(model,id);
            var updatedContact = await _contactRepository.Update(id,contactToUpdate);
            return ResponseHelper.entityToResponse(updatedContact);
        }

        public async Task<ContactResponseModel> DeactivateContactAsync(int id)
        {
            
            var contactToDelete = await _contactRepository.Delete(id);
            return ResponseHelper.entityToResponse(contactToDelete);
        }

        public async Task<ContactResponseModel> GetContactById(int id)
        {
            var contact = await _contactRepository.Get(id);
            var responseContact = ResponseHelper.entityToResponse(contact);
            return responseContact;
        }

        public async Task<PagedResponseModel<ContactResponseModel>> SearchContactsAsync(ContactSearchModel model)
        {
            var samplesList = _contacts.Where(q =>
                (string.IsNullOrEmpty(model.FirstName) || q.FirstName.Contains(model.FirstName))
                && (string.IsNullOrEmpty(model.LastName) || q.LastName.Contains(model.LastName))
                && (string.IsNullOrEmpty(model.Email) || q.Email.Contains(model.Email))
                && (model.ModifiedFrom == null || q.ModifiedDate >= model.ModifiedFrom)
                && (model.ModifiedTo == null || q.ModifiedDate <= model.ModifiedTo))
                .AsQueryable();

            var page =  samplesList.ToPagedResponseModel(model.PageNumber, model.PageSize);

            return page;
        }

        public async Task<List<ContactResponseModel>> GetContactsAsync()
        {
            var contacts = await _contactRepository.GetAll();
            var responseContactList = new List<ContactResponseModel>();
            foreach (var contact in contacts)
            {
                responseContactList.Add(ResponseHelper.entityToResponse(contact));
            }
            return responseContactList;
        }
    }
}
