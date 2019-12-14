using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Models;
using eCommerce.BLL.Interfaces;
using eCommerce.BLL.DTO;
using AutoMapper;
using eCommerce.BLL.Infrastructure;

namespace eCommerce.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService serv)
        {
            this.userService = serv;
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            UserViewModel userModel = new UserViewModel();
            return this.View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(UserViewModel userModel)
        {
            try
            {
                userModel.userId = this.userService.FindMaxId() + 1;
                var userDto = new UserDTO(userModel.userId, userModel.username, userModel.password, userModel.isAdmin);
                this.userService.CreateUser(userDto);
                return this.RedirectToAction("Login", "User");

            }
            catch (ArgumentNullException)
            {
                this.ViewBag.DuplicateMessage = "Таке і'мя користувача вже існує.";
                return this.View("AddOrEdit");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel userModel)
        {
            var obj = this.userService.GetByUsernamePassword(userModel.username, userModel.password);
            if (obj != null && obj.isAdmin==true)
            {
                this.Session["isAdmin"] = "true";
                this.Session["User_ID"] = obj.userId.ToString();
                this.Session["Username"] = obj.username.ToString();
                this.Session["Password"] = obj.password.ToString();
                return this.RedirectToAction("MainPageAdmin", "MainPage");
            }
            else if (obj != null)
            {
                this.Session["User_ID"] = obj.userId.ToString();
                this.Session["Username"] = obj.username.ToString();
                this.Session["Password"] = obj.password.ToString();
                return this.RedirectToAction("MainPage", "MainPage");
            }
            else
            {
                this.ViewBag.DuplicateMessage = "Неправильне і'мя користувача або пароль.";
                return this.View("Login");
            }
        }
    }
}