using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Core.Services.Exceptions
{
    public class NotFoundException : ServiceException
    {
        public override int StatusCode => 404;

        public override object Value => new ErrorMessage("notFound");

        public NotFoundException()
        {

        }
    }
}
