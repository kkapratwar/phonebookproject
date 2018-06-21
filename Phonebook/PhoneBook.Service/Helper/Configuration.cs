using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PhoneBook.Service.Helper
{
    public class Configuration : IConfiguration
    {
        public string ApiKey => ConfigurationManager.AppSettings["APIKey"].ToString();

        public int ExpirationTime => Convert.ToInt32(ConfigurationManager.AppSettings["KeyExpirationTime"]);
    }
}