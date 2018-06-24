namespace Phonebook.TestUI.Services
{
    using System.Collections.Generic;

    using Phonebook.Common;
    using Phonebook.TestUI.Constants;
    using Phonebook.TestUI.Helper;

    using RestSharp;

    /// <summary>
    /// The phonebookservice class.
    /// </summary>
    /// <seealso cref="Phonebook.TestUI.Services.IPhonebookService" />
    public class PhonebookService : IPhonebookService
    {
        /// <summary>
        /// The rest client.
        /// </summary>
        private IRestClient restClient;

        /// <summary>
        /// The rest request.
        /// </summary>
        private IRestRequest restRequest;

        /// <summary>
        /// The configuration.
        /// </summary>
        private IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhonebookService"/> class.
        /// </summary>
        /// <param name="restClient">The rest client.</param>
        /// <param name="configuration">The configuration.</param>
        public PhonebookService(IRestClient restClient, IConfiguration configuration)
        {
            this.restClient = restClient;
            this.configuration = configuration;
        }

        /// <summary>
        /// Adds the phonebook record.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="phonebook">The phonebook.</param>
        /// <returns></returns>
        int IPhonebookService.AddPhonebookRecord(string token, Phonebook phonebook)
        {
            this.CreateAPIUrl(APIActions.Add, token);
            this.restRequest.AddObject(phonebook);
            this.restRequest.Method = Method.POST;
            var result = restClient.Execute<int>(restRequest);
            return result.Data;
        }

        /// <summary>
        /// Deletes the phonebook record.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        bool IPhonebookService.DeletePhonebookRecord(string token, int id)
        {
            this.restRequest.Resource = $"phonebook/{APIActions.Delete}/{id}?ApiKey={this.configuration.ApiKey}&token={token}";
            this.restRequest.Method = Method.DELETE;
            var result = restClient.Execute<bool>(restRequest);
            return result.Data;
        }

        /// <summary>
        /// Gets all phonebook records.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>The List<see cref="Phonebook"/>/></returns>
        List<Phonebook> IPhonebookService.GetAllPhonebookRecords(string token)
        {
            this.CreateAPIUrl(APIActions.GetAll, token);
            var response = restClient.Execute<List<Phonebook>>(restRequest);

            return response.Data;
        }

        /// <summary>
        /// Gets the phonebook record.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        Phonebook IPhonebookService.GetPhonebookRecord(string token, int id)
        {
            this.restRequest.Resource = $"phonebook/{APIActions.GetById}/{id}?ApiKey={this.configuration.ApiKey}&token={token}";
            this.restRequest.Method = Method.GET;
            var result = restClient.Execute<Phonebook>(restRequest);
            return result.Data;
        }

        /// <summary>
        /// Updates the phonebook record.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="phonebook">The phonebook.</param>
        /// <returns></returns>
        bool IPhonebookService.UpdatePhonebookRecord(string token, Phonebook phonebook)
        {
            this.CreateAPIUrl(APIActions.Update, token);
            this.restRequest.AddObject(phonebook);
            this.restRequest.Method = Method.PUT;
            var result = restClient.Execute<bool>(restRequest);
            return result.Data;
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <returns>The token.</returns>
        string IPhonebookService.ValidateAndGet(string token = null)
        {
            this.restRequest = new RestRequest();
            this.restRequest.Resource = $"token?ApiKey={this.configuration.ApiKey}";
            this.restRequest.RequestFormat = DataFormat.Json;
            this.restRequest.AddParameter("Application/Json", new { token = token }, ParameterType.RequestBody);
            this.restRequest.Method = Method.GET;
            return this.restClient.Execute(restRequest).Content.Replace("\"", "");
        }

        /// <summary>
        /// Creates the API URL.
        /// </summary>
        /// <param name="action">The action.</param>
        private void CreateAPIUrl(string action, string token)
        {
            this.restRequest = new RestRequest();
            this.restRequest.Resource = $"phonebook/{action}?ApiKey={this.configuration.ApiKey}&token={token}";
        }


    }
}