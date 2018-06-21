using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Phonebook.Database;
using PhoneBook.Service.Helper;
using Unity.Attributes;

namespace PhoneBook.Service.Filters
{
    public class CustomAuthentication : AuthorizationFilterAttribute
    {
        [Dependency]
        public IPhonebookRepository PhonebookRepository { get; set; }

        [Dependency]
        public IConfiguration Configuration { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            const string APIKEY = "ApiKey";
            const string TOKENKEY = "token";

            var query = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query);

            if (!string.IsNullOrWhiteSpace(query[APIKEY]) && !string.IsNullOrWhiteSpace(query[TOKENKEY]))
            {
                if (Configuration.ApiKey == query[APIKEY] && this.PhonebookRepository.GetTokenId(query[TOKENKEY]) > 0)
                {
                    return;
                }
            }
            HandleUnauthorized(actionContext);
            // Basic authentication.
            //var authHeader = actionContext.Request.Headers.Authorization;

            //if (authHeader != null)
            //{
            //    if (authHeader.Scheme.Equals("basic", StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrWhiteSpace(authHeader.Parameter))
            //    {
            //        var rawCredentials = authHeader.Parameter;
            //        var encoding = Encoding.GetEncoding("iso-8859-1");
            //        var credentials = encoding.GetString(Convert.FromBase64String(rawCredentials));
            //        var split = credentials.Split(':');

            //        var userName = split[0];
            //        var password = split[1];

            //        if (userName != null && password != null)
            //        {
            //            var principal = new GenericPrincipal(new GenericIdentity(userName), null);
            //            Thread.CurrentPrincipal = principal;
            //            return;
            //        }
            //    }
            //}
            //HandleUnauthorized(actionContext);
        }

        private void HandleUnauthorized(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
    }
}