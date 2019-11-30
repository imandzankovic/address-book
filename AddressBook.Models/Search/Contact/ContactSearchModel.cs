using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Models.Search.Contact
{
    public class ContactSearchModel : PagedSearchModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int Phone { get; set; }
        public DateTime? ModifiedFrom { get; set; }
        public DateTime? ModifiedTo { get; set; }
    }
}
