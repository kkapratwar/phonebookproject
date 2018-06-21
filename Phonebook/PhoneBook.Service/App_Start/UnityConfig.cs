using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;
using Phonebook.Database;
using PhoneBook.Service.Filters;
using PhoneBook.Service.Helper;
using Unity;
using Unity.WebApi;

namespace PhoneBook.Service
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IPhonebookRepository, PhonebookRepository>();
            container.RegisterType<IConfiguration, Configuration>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            //Register the filter injector
            var providers = config.Services.GetFilterProviders().ToList();

            var defaultprovider = providers.Single(i => i is ActionDescriptorFilterProvider);
            config.Services.Remove(typeof(IFilterProvider), defaultprovider);

            config.Services.Add(typeof(IFilterProvider), new UnityFilterProvider(container));
        }
    }
}