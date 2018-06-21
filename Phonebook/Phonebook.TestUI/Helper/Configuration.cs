using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Phonebook.TestUI.Helper
{
    public class Configuration : IConfiguration
    {
        public string ApiKey => ConfigurationManager.AppSettings["APIKey"].ToString();
    }
}