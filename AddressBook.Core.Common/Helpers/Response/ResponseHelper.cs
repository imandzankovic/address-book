using AddressBook.Entities;
using AddressBook.Models.Response.Contact;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Core.Common.Helpers
{
    public class ResponseHelper
    {
        public static Contact responseToEntity(Contact contactResponseModel)
        {
            Contact contact = new Contact();

            contactResponseModel.Id = contact.Id;
            contactResponseModel.FirstName = contact.FirstName;
            contactResponseModel.LastName = contact.LastName;
            contactResponseModel.Phone = contact.Phone;
            contactResponseModel.Email = contact.Email;

            return contact;

        }

        public static ContactResponseModel entityToResponse(Contact contact)
        {
            ContactResponseModel contactResponseModel = new ContactResponseModel();

            contactResponseModel.Id = contact.Id;
            contactResponseModel.FirstName = contact.FirstName;
            contactResponseModel.LastName = contact.LastName;
            contactResponseModel.Phone = contact.Phone;
            contactResponseModel.Email = contact.Email;

            return contactResponseModel;

        }

    }

}
