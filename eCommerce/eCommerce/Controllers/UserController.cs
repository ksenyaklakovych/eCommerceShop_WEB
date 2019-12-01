using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Models;

namespace eCommerce.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(User userModel)
        {
            //User name = new User();
            using (commerceShopDB dbModel = new commerceShopDB())
            {
                userModel.userId = 1;
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.Successmessage = "Registration Succesful.";
            return View("AddOrEdit", new User());
        }
    }
}