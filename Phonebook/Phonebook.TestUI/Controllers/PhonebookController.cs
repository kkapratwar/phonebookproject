namespace Phonebook.TestUI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Phonebook.Common;
    using Phonebook.TestUI.Services;

    /// <summary>
    /// The phonebook controller.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class PhonebookController : Controller
    {
        /// <summary>
        /// The phonebook service.
        /// </summary>
        private IPhonebookService phonebookService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhonebookController"/> class.
        /// </summary>
        /// <param name="phonebookService">The phonebook service.</param>
        public PhonebookController(IPhonebookService phonebookService)
        {
            this.phonebookService = phonebookService;
        }

        /// <summary>
        /// Index action to display all the phoebook records.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Index()
        {
            var token = this.ValidateAndGetToken();

            return IndexView(token);
        }

        public ActionResult AddEditPhonebookRecord(int id = 0)
        {
            var phonebook = new Phonebook();
            if (id > 0)
            {
                var token = this.ValidateAndGetToken();

                phonebook = this.phonebookService.GetPhonebookRecord(token, id);
            }
            return View(phonebook);
        }

        [HttpPost]
        public ActionResult AddEditPhonebookRecord(Phonebook phonebook)
        {
            if (ModelState.IsValid)
            {
                var token = this.ValidateAndGetToken();
                var result = false;
                if (phonebook.Id > 0)
                {
                    result = this.phonebookService.UpdatePhonebookRecord(token, phonebook);
                }
                else
                {
                    result = this.phonebookService.AddPhonebookRecord(token, phonebook) > 0;
                }

                if (result)
                {
                    return IndexView(token);
                }
            }
            return View(phonebook);
        }

        public ActionResult Delete(int id)
        {
            var token = this.ValidateAndGetToken();

            this.phonebookService.DeletePhonebookRecord(token, id);

            return IndexView(token);
        }

        private ActionResult IndexView(string token)
        {
            var phonebookRecords = this.phonebookService.GetAllPhonebookRecords(token);
            if (phonebookRecords == null)
            {
                phonebookRecords = new List<Phonebook>();
            }
            return View("Index", phonebookRecords);

        }
        private string ValidateAndGetToken()
        {
            if (Session["token"] == null)
            {
                Session["token"] = this.phonebookService.ValidateAndGet();
            }
            else
            {
                Session["token"] = this.phonebookService.ValidateAndGet(Session["token"].ToString());
            }

            return Session["token"].ToString();
        }

    }
}