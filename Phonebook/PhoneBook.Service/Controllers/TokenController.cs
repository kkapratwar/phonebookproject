using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using Phonebook.Common;
using Phonebook.Database;
using PhoneBook.Common;
using PhoneBook.Service.Contracts;
using PhoneBook.Service.Helper;

namespace PhoneBook.Service.Controllers
{
    /// <summary>
    /// The TokenController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("api/token")]
    public class TokenController : ApiController, ITokenController
    {
        /// <summary>
        /// The phonebook repository
        /// </summary>
        private IPhonebookRepository phonebookRepository;

        /// <summary>
        /// The configuration
        /// </summary>
        private IConfiguration configuration;


        /// <summary>
        /// Initializes a new instance of the <see cref="TokenController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public TokenController(IPhonebookRepository repository, IConfiguration configuration)
        {
            this.phonebookRepository = repository;
            this.configuration = configuration;
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [Route("getToken")]
        public string Get()
        {
            try
            {
                var newToken = Guid.NewGuid();
                phonebookRepository.AddToken(new TokenRequestModel { Token = newToken.ToString(), ExpirationTime = DateTime.Now.AddMinutes(this.configuration.ExpirationTime) });
                return newToken.ToString();
            }
            catch (Exception ex)
            {
                //Log message using log4net.
                return null;
            }
        }
    }
}
