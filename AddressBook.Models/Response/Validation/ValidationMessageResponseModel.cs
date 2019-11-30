using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Models.Response.Validation
{
    public class ValidationMessageResponseModel
    {
        public string PropertyName { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
