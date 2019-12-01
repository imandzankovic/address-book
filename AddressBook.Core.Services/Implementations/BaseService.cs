using Autofac;
using AddressBook.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AddressBook.Core.Services.Implementations
{
    public class BaseService : IBaseService
    {
        public ILifetimeScope Scope { get; set; }
        public BaseService(ILifetimeScope scope)
        {
            Scope = scope;

        }


    }
}
