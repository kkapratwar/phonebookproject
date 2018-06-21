using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phonebook.TestUI.Services;
using RestSharp;

namespace Phonebook.TestUI.Controllers
{
    public class PhonebookController : Controller
    {
        private IPhonebookService phonebookService;

        public PhonebookController(IPhonebookService phonebookService)
        {
            this.phonebookService = phonebookService;
        }
        // GET: Phonebook
        public ActionResult Index()
        {
            var phonebookRecords = this.phonebookService.GetAllPhonebookRecords();

            return View();
        }
    }
}