using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Core.Services.Exceptions
{
    public abstract class ServiceException : Exception
    {
        public abstract int StatusCode { get; }  
        public abstract object Value { get; }
    }
}
