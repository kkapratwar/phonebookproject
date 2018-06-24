using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phonebook.Database;
using Moq;
using PhoneBook.Service.Helper;
using PhoneBook.Service.Controllers;
using FluentAssertions;
using System.Net.Http;
using System.Web.Http;
using System.Net;

namespace Phonebook.Service.Tests.Controller
{
    /// <summary>
    /// Summary description for PhonebookControllerTests
    /// </summary>
    [TestClass]
    public class PhonebookControllerTests
    {
        /// <summary>
        /// The phonebook repository
        /// </summary>
        private Mock<IPhonebookRepository> phonebookRepository;

        private PhonebookController phonebookController;

        /// <summary>
        /// Initializes lcoal instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            this.phonebookRepository = new Mock<IPhonebookRepository>();
            this.phonebookController = new PhonebookController(this.phonebookRepository.Object);

            var configuration = new HttpConfiguration();
            var request = new System.Net.Http.HttpRequestMessage();
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;
            this.phonebookController.Request = request;
        }

        /// <summary>
        /// Test to get all phonebook records with success.
        /// </summary>
        [TestMethod]
        public void GetAllPhonebookRecordsSuccess()
        {
            this.phonebookRepository.Setup(x => x.GetPhonebookRecords()).Returns(new List<Common.Phonebook>());

            var httpResponse = this.phonebookController.Get();
            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK, "get request processed successfully.");
            httpResponse.Content.Should().NotBeNull("should return list of phonebook records.");

            this.phonebookRepository.VerifyAll();
        }

        /// <summary>
        /// Test to get all phonebook records with exception.
        /// </summary>
        [TestMethod]
        public void GetAllPhonebookRecordsWithException()
        {
            this.phonebookRepository.Setup(x => x.GetPhonebookRecords()).Throws(new Exception());

            var httpResponse = this.phonebookController.Get();
            httpResponse.StatusCode.Should().Be(HttpStatusCode.InternalServerError, "exception occurred while processing the get request.");

            this.phonebookRepository.VerifyAll();
        }

        /// <summary>
        /// Test to get phonebook record by Id with success.
        /// </summary>
        [TestMethod]
        public void GetPhonebookRecordByIdWithSuccess()
        {
            this.phonebookRepository.Setup(x => x.GetPhonebookRecord(It.IsAny<int>())).Returns(new Common.Phonebook());

            var httpResponse = this.phonebookController.Get(It.IsAny<int>());
            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK, "get request processed successfully.");
            httpResponse.Content.Should().NotBeNull("should return phonebook record.");

            this.phonebookRepository.VerifyAll();
        }

        /// <summary>
        /// Test to get phonebook record by invalid Id.
        /// </summary>
        [TestMethod]
        public void GetPhonebookRecordByIdWithInvlaidId()
        {
            this.phonebookRepository.Setup(x => x.GetPhonebookRecord(It.IsAny<int>()));

            var httpResponse = this.phonebookController.Get(It.IsAny<int>());
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound, "not found code should be returned.");

            this.phonebookRepository.VerifyAll();
        }

        /// <summary>
        /// Test to get phonebook record by id with exception.
        /// </summary>
        [TestMethod]
        public void GetPhonebookRecordByIdWithException()
        {
            this.phonebookRepository.Setup(x => x.GetPhonebookRecord(It.IsAny<int>())).Throws(new Exception());

            var httpResponse = this.phonebookController.Get(It.IsAny<int>());
            httpResponse.StatusCode.Should().Be(HttpStatusCode.InternalServerError, "exception occurred while processing the get request.");

            this.phonebookRepository.VerifyAll();
        }

        /// <summary>
        /// Adds phonebook record with success.
        /// </summary>
        [TestMethod]
        public void AddPhonebookRecordWithSuccess()
        {
            this.phonebookRepository.Setup(x => x.AddNewPhonebookRecord(It.IsAny<Common.Phonebook>())).Returns(1);

            var modelState = this.phonebookController.ModelState;
            var httpResponse = this.phonebookController.Post(It.IsAny<Common.Phonebook>());
            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK, "add request processed successfully.");
            httpResponse.Content.Should().NotBe("0", "should return id of the newly added phonebook records.");

            this.phonebookRepository.VerifyAll();
        }

        /// <summary>
        /// Adds phonebook record with invalid model state.
        /// </summary>
        [TestMethod]
        public void AddPhonebookRecordWithInvalidModelState()
        {
            this.phonebookRepository.Setup(x => x.AddNewPhonebookRecord(It.IsAny<Common.Phonebook>())).Returns(1);

            var modelState = this.phonebookController.ModelState;
            modelState.AddModelError("FirstName", "First name field is required.");
            var httpResponse = this.phonebookController.Post(It.IsAny<Common.Phonebook>());
            httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest, "bad request error should be returned on model state error.");
            modelState["FirstName"].Errors[0].ErrorMessage.Should().Be("First name field is required.", "model state error should be returned.");
        }

        /// <summary>
        /// Adds phonebook records with exception.
        /// </summary>
        [TestMethod]
        public void AddPhonebookRecordsWithException()
        {
            this.phonebookRepository.Setup(x => x.AddNewPhonebookRecord(It.IsAny<Common.Phonebook>())).Throws(new Exception());

            var httpResponse = this.phonebookController.Post(It.IsAny<Common.Phonebook>());
            httpResponse.StatusCode.Should().Be(HttpStatusCode.InternalServerError, "exception occurred while processing the add request.");

            this.phonebookRepository.VerifyAll();
        }

        /// <summary>
        /// Updates the phonebook record with success.
        /// </summary>
        [TestMethod]
        public void UpdatePhonebookRecordWithSuccess()
        {
            this.phonebookRepository.Setup(x => x.UpdatePhonebookRecord(It.IsAny<Common.Phonebook>()));

            var httpResponse = this.phonebookController.Put(It.IsAny<Common.Phonebook>());
            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK, "update request processed successfully.");
            ((ObjectContent)httpResponse.Content).Value.Should().Be(true, "phone record should be updated successfully.");

            this.phonebookRepository.VerifyAll();
        }

        /// <summary>
        /// Updates the phonebook record with invalid model state.
        /// </summary>
        [TestMethod]
        public void UpdatePhonebookRecordWithInvalidModelState()
        {
            this.phonebookRepository.Setup(x => x.UpdatePhonebookRecord(It.IsAny<Common.Phonebook>()));

            var modelState = this.phonebookController.ModelState;
            modelState.AddModelError("FirstName", "First name field is required.");
            var httpResponse = this.phonebookController.Put(It.IsAny<Common.Phonebook>());
            httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest, "bad request error should be returned on model state error.");
            modelState["FirstName"].Errors[0].ErrorMessage.Should().Be("First name field is required.", "model state error should be returned.");
        }

        /// <summary>
        /// Updates the phonebook records with exception.
        /// </summary>
        [TestMethod]
        public void UpdatePhonebookRecordsWithException()
        {
            this.phonebookRepository.Setup(x => x.UpdatePhonebookRecord(It.IsAny<Common.Phonebook>())).Throws(new Exception());

            var httpResponse = this.phonebookController.Put(new Common.Phonebook());
            httpResponse.StatusCode.Should().Be(HttpStatusCode.InternalServerError, "exception occurred while processing the udpate request.");

            this.phonebookRepository.VerifyAll();
        }

        /// <summary>
        /// Deletes the phonebook record with success.
        /// </summary>
        [TestMethod]
        public void DeletePhonebookRecordWithSuccess()
        {
            this.phonebookRepository.Setup(x => x.DeletePhonebookRecord(It.IsAny<int>()));

            var httpResponse = this.phonebookController.Delete(1);
            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK, "delete request processed successfully.");
            ((ObjectContent)httpResponse.Content).Value.Should().Be(true, "phone record should be deleted successfully.");

            this.phonebookRepository.VerifyAll();
        }

        /// <summary>
        /// Deletes the phonebook records with exception.
        /// </summary>
        [TestMethod]
        public void DeletePhonebookRecordsWithException()
        {
            this.phonebookRepository.Setup(x => x.DeletePhonebookRecord(It.IsAny<int>())).Throws(new Exception());

            var httpResponse = this.phonebookController.Delete(1);
            httpResponse.StatusCode.Should().Be(HttpStatusCode.InternalServerError, "exception occurred while processing the delete request.");

            this.phonebookRepository.VerifyAll();
        }
    }
}
