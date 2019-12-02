using AddressBook.Entities;
using AddressBook.Models.Request.Contact;


namespace AddressBook.Core.Common.Helpers
{
    public class RequestHelper
    {
        public static Contact requestToEntity(ContactRequestModel contactRequestModel, int? id = null)
        {

            Contact contact = new Contact();

            contact.Id = id.HasValue ? contact.Id : 0;
            contact.FirstName = contactRequestModel.FirstName;
            contact.LastName = contactRequestModel.LastName;
            contact.Phone = contactRequestModel.Phone;
            contact.Email = contactRequestModel.Email;

            return contact;


        }

        public static ContactRequestModel entityToRequest(Contact contact)
        {
            ContactRequestModel contactRequest = new ContactRequestModel();

            contactRequest.FirstName = contact.FirstName;
            contactRequest.LastName = contact.LastName;
            contactRequest.Phone = contact.Phone;
            contactRequest.Email = contact.Email;

            return contactRequest;


        }
    }
}
