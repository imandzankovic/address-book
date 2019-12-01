

using AddressBook.Models.Request.Contact;
using AddressBook.Models.Response;
using AddressBook.Models.Response.Contact;
using AddressBook.Models.Search.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressBook.Core.Services
{
    public interface IContactService
    {
        Task<ContactResponseModel> AddContactAsync(ContactRequestModel model);
        Task<ContactResponseModel> UpdateContactAsync(int id, ContactRequestModel model);
        Task<ContactResponseModel> DeactivateContactAsync(int id);

        Task<ContactResponseModel> GetContactById(int id);
        Task<PagedResponseModel<ContactResponseModel>> SearchContactsAsync(ContactSearchModel model);
        Task<List<ContactResponseModel>> GetContactsAsync();
    }
}
