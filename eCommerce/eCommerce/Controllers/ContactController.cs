using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.BLL.DTO;
using eCommerce.BLL.Interfaces;
using eCommerce.Models;

namespace eCommerce.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public IContactService ContactService;

        public ContactController(IContactService ic)
        {
            this.ContactService = ic;
        }
        [HttpGet]

        public ActionResult ContactForm()
        {
            return View();
        }
        [HttpPost]

        public ActionResult ContactForm(ContactViewModel contact)
        {
            contact.contactId = ContactService.FindMaxId()+1;
            ContactService.CreateContact(new ContactDTO(contact.contactId,contact.fullName,contact.email,contact.message));
            return RedirectToAction("MainPage","MainPage");
        }   

    }
}