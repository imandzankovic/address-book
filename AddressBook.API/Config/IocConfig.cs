using AddressBook.Core.Services.Registration;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.API.Config
{
    public class IocConfig
    {
        public static IServiceProvider ConfigureServices(
            IServiceCollection services,
            IConfigurationRoot configuration)
        {
            var builder = new ContainerBuilder();


            builder.RegisterModule<ServiceModule>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Populate(services);

            var container = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
        }
    }
}
