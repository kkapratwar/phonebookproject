namespace PhoneBook.Service.Filters
{
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using Phonebook.Database;
    using PhoneBook.Service.Helper;
    using Unity.Attributes;

    public class APIAuthentication : AuthorizationFilterAttribute
    {
        [Dependency]
        public IConfiguration Configuration { get; set; }


        public override void OnAuthorization(HttpActionContext actionContext)
        {
            const string APIKEY = "ApiKey";

            var query = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query);

            if (!string.IsNullOrWhiteSpace(query[APIKEY]))
            {
                if (Configuration.ApiKey == query[APIKEY])
                {
                    return;
                }
            }
            HandleUnauthorized(actionContext);
        }

        private void HandleUnauthorized(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
    }
}