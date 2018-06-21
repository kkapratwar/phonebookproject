

namespace Phonebook.TestUI.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Phonebook.Common;
    using Phonebook.TestUI.Helper;
    using RestSharp;

    /// <summary>
    /// The phonebookservice class.
    /// </summary>
    /// <seealso cref="Phonebook.TestUI.Services.IPhonebookService" />
    public class PhonebookService : IPhonebookService
    {
        private IRestClient restClient;

        private IRestRequest restRequest;

        private IConfiguration configuration;

        public PhonebookService(IRestClient restClient, IConfiguration configuration)
        {
            this.restClient = restClient;
            this.restRequest = new RestRequest();
            this.configuration = configuration;
        }

        /// <summary>
        /// Adds the phonebook record.
        /// </summary>
        /// <param name="phonebook">The phonebook.</param>
        /// <returns></returns>
        int IPhonebookService.AddPhonebookRecord(Phonebook phonebook)
        {
            var result = restClient.Execute<int>(restRequest);
            var data = result.Data;
            return data;
        }

        /// <summary>
        /// Deletes the phonebook record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        bool IPhonebookService.DeletePhonebookRecord(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all phonebook records.
        /// </summary>
        /// <returns></returns>
        List<Phonebook> IPhonebookService.GetAllPhonebookRecords()
        {
            var token = GetToken();
            this.restRequest.Resource = "phonebook/getall?ApiKey={api_key}&token={token}";
            this.restRequest.AddUrlSegment("api_key", this.configuration.ApiKey);
            this.restRequest.AddUrlSegment("token", token);
            var response = restClient.Execute<List<Phonebook>>(restRequest);

            return response.Data;
        }

        /// <summary>
        /// Gets the phonebook record.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        Phonebook IPhonebookService.GetPhonebookRecord(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the phonebook record.
        /// </summary>
        /// <param name="phonebook">The phonebook.</param>
        /// <returns></returns>
        bool IPhonebookService.UpdatePhonebookRecord(Phonebook phonebook)
        {
            throw new NotImplementedException();
        }

        private string GetToken()
        {
            this.restRequest.Resource = "token";
            this.restRequest.Method = Method.GET;
            return this.restClient.Execute(restRequest).Content.Replace("\"","");
        }
    }
}