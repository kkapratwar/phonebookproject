using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phonebook.Database;
using Moq;
using PhoneBook.Service.Helper;
using PhoneBook.Common;
using PhoneBook.Service.Controllers;
using FluentAssertions;

namespace Phonebook.Service.Tests.Controller
{
    /// <summary>
    /// Summary description for TokenControllerTests
    /// </summary>
    [TestClass]
    public class TokenControllerTests
    {
        /// <summary>
        /// The phonebook repository
        /// </summary>
        private Mock<IPhonebookRepository> phonebookRepository;

        /// <summary>
        /// The configuration
        /// </summary>
        private Mock<IConfiguration> configuration;

        /// <summary>
        /// The token controller
        /// </summary>
        private TokenController tokenController;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            this.phonebookRepository = new Mock<IPhonebookRepository>();
            this.configuration = new Mock<IConfiguration>();
            this.tokenController = new TokenController(phonebookRepository.Object, configuration.Object);

            configuration.SetupGet(x => x.ApiKey).Returns("Test");
            configuration.SetupGet(x => x.ExpirationTime).Returns(5);
        }

        /// <summary>
        /// Verify if the Get method returns the token or not.
        /// </summary>
        [TestMethod]
        public void GetTokenWithSuccess()
        {
            this.phonebookRepository.Setup(x => x.AddToken(It.IsAny<TokenRequestModel>()));
            var token = tokenController.Get();

            token.Should().NotBeNull("the token should be created.");
            phonebookRepository.VerifyAll();
        }

        /// <summary>
        /// Verify Get method on exception.
        /// </summary>
        [TestMethod]
        public void GetTokenWithException()
        {
            this.phonebookRepository.Setup(x => x.AddToken(It.IsAny<TokenRequestModel>())).Throws(new Exception());
            var token = tokenController.Get();

            token.Should().BeNull("exception occured while adding token.");
            phonebookRepository.VerifyAll();
        }
    }
}
