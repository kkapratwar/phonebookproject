using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Phonebook.TestUI.Controllers;
using Phonebook.TestUI.Services;

namespace Phonebook.TestUI.Tests.Controllers
{
    [TestClass]
    public class PhonebookControllerTests
    {
        private Mock<HttpSessionStateBase> session;

        private Mock<HttpContextBase> httpContext;

        private ControllerContext controllerContext;

        private PhonebookController phonebookController;

        private Mock<IPhonebookService> phonebookService;

        [TestInitialize]
        public void Init()
        {
            this.session = new Mock<HttpSessionStateBase>();
            this.session.SetupGet(s => s["token"]).Returns(Guid.NewGuid());

            this.httpContext = new Mock<HttpContextBase>();
            this.httpContext.SetupGet(c => c.Session).Returns(session.Object);

            this.controllerContext = new ControllerContext();
            this.controllerContext.HttpContext = httpContext.Object;

            this.phonebookService = new Mock<IPhonebookService>();
            this.phonebookService.Setup(x => x.ValidateAndGet(It.IsAny<string>())).Returns(Guid.NewGuid().ToString());

            this.phonebookController = new PhonebookController(phonebookService.Object);
            this.phonebookController.ControllerContext = this.controllerContext;
        }
        [TestMethod]
        public void IndexViewWithSuccess()
        {
            this.phonebookService.Setup(x => x.GetAllPhonebookRecords(It.IsAny<string>())).Returns(new List<Common.Phonebook>());

            var view = this.phonebookController.Index();

            var viewResult = view as ViewResult;
            var model = viewResult.Model as List<Common.Phonebook>;

            model.Should().NotBeNull("List<Phonebook> should be returned.");
            viewResult.ViewName.Should().Be("Index", "Index view should be returned.");
        }

        [TestMethod]
        public void AddPhonebookRecordWithSuccess()
        {
            this.phonebookService.Setup(x => x.GetPhonebookRecord(It.IsAny<string>(), It.IsAny<int>())).Returns(new Common.Phonebook());

            var viewResult = this.phonebookController.AddEditPhonebookRecord(0) as ViewResult;

            var model = viewResult.Model as Phonebook.Common.Phonebook;
            model.Should().NotBeNull("Phonebook model should be returned.");
        }

        [TestMethod]
        public void PostAddPhonebookRecordWithSuccess()
        {
            this.phonebookService.Setup(x => x.GetPhonebookRecord(It.IsAny<string>(), It.IsAny<int>())).Returns(new Common.Phonebook());
            this.phonebookService.Setup(x => x.AddPhonebookRecord(It.IsAny<string>(), It.IsAny<Phonebook.Common.Phonebook>())).Returns(1);

            var viewResult = this.phonebookController.AddEditPhonebookRecord(new Common.Phonebook()) as ViewResult;

            var model = viewResult.Model as List<Common.Phonebook>;
            model.Should().NotBeNull("List<Phonebook> should be returned.");
            viewResult.ViewName.Should().Be("Index", "Index view should be returned.");
        }

        [TestMethod]
        public void UpdatePhonebookRecordWithSuccess()
        {
            this.phonebookService.Setup(x => x.GetPhonebookRecord(It.IsAny<string>(), It.IsAny<int>())).Returns(new Common.Phonebook());

            var viewResult = this.phonebookController.AddEditPhonebookRecord(1) as ViewResult;

            var model = viewResult.Model as Phonebook.Common.Phonebook;
            model.Should().NotBeNull("Phonebook model should be returned.");
        }

        [TestMethod]
        public void PostUpdatePhonebookRecordWithSuccess()
        {
            this.phonebookService.Setup(x => x.GetPhonebookRecord(It.IsAny<string>(), It.IsAny<int>())).Returns(new Common.Phonebook());
            this.phonebookService.Setup(x => x.UpdatePhonebookRecord(It.IsAny<string>(), It.IsAny<Phonebook.Common.Phonebook>())).Returns(true);

            var viewResult = this.phonebookController.AddEditPhonebookRecord(new Common.Phonebook { Id = 1 }) as ViewResult;

            var model = viewResult.Model as List<Common.Phonebook>;
            model.Should().NotBeNull("List<Phonebook> should be returned.");
            viewResult.ViewName.Should().Be("Index", "Index view should be returned.");
        }

        [TestMethod]
        public void DeletePhonebookRecordWithSuccess()
        {
            this.phonebookService.Setup(x => x.DeletePhonebookRecord(It.IsAny<string>(), It.IsAny<int>())).Returns(true);

            var viewResult = this.phonebookController.Delete(1) as ViewResult;

            var model = viewResult.Model as List<Common.Phonebook>;
            model.Should().NotBeNull("List<Phonebook> should be returned.");
            viewResult.ViewName.Should().Be("Index", "Index view should be returned.");
        }
    }
}
