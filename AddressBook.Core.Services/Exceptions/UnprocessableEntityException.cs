using AddressBook.Models.Response.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Core.Services.Exceptions
{
    public class UnprocessableEntityException : ServiceException
    {
        private readonly IEnumerable<ValidationMessageResponseModel> validations;

        public override int StatusCode => 422;

        public override object Value => validations;

        public UnprocessableEntityException(IEnumerable<ValidationMessageResponseModel> validations)
        {
            this.validations = validations;
        }
    }
}
