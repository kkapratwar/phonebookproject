using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Phonebook.Database;
using PhoneBook.Service.Contracts;
using PhoneBook.Service.Controllers;
using PhoneBook.Service.Filters;
using Unity;
using Unity.Injection;

namespace PhoneBook.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}