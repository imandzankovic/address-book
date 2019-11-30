using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Models.Response.Contact
{
    public class ContactResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
