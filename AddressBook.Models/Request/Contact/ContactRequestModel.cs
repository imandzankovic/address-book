using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Models.Request.Contact
{
    public class ContactRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}
