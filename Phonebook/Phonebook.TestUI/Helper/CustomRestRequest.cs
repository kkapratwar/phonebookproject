using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace Phonebook.TestUI.Helper
{
    public class CustomRestRequest : RestRequest
    {
        public CustomRestRequest()
        {
        }

        public CustomRestRequest(string baseUri, Method method)
        {
        }
    }
}