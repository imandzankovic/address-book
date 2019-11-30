

using Autofac;

namespace AddressBook.Core.Services.Registration
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register any type wich name ending with "Service"
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
