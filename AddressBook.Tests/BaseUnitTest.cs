using AddressBook.API;
using AddressBook.Repository;
using AddressBook.Repository.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Tests
{
    public abstract class BaseUnitTest
    {
        protected TestServer GetTestServer()
        {
            var builder = new WebHostBuilder()
                .UseStartup<TestStartup>();
                


            return new TestServer(builder);
        }

        protected ContactRepository GetInMemoryPersonRepository()
        {

            var options = new DbContextOptionsBuilder<ContactContext>().UseInMemoryDatabase(databaseName: "AddressBook").Options;
            ContactContext contactContext = new ContactContext(options);
            contactContext.Database.EnsureDeleted();
            contactContext.Database.EnsureCreated();
            return new ContactRepository(contactContext);
        }
    }


}
