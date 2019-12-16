﻿using System;
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
        public ActionResult Register(int id = 0)
        {
            UserViewModel userModel = new UserViewModel();
            return this.View(userModel);
        }
        [HttpPost]
        public ActionResult Register(UserViewModel userModel)
        {
            try
            {
                userModel.userId = this.userService.FindMaxId() + 1;
                userModel.isAdmin = false;
                userModel.password = Helper.Encrypt(userModel.password);
                var userDto = new UserDTO(userModel.userId, userModel.username, userModel.password, userModel.isAdmin);
                this.userService.CreateUser(userDto);
                return this.RedirectToAction("Login", "User");

            }
            catch (ArgumentNullException)
            {
                this.ViewBag.DuplicateMessage = "Choose different username.";
                return this.View("Register");
            }
        }

        public ActionResult Account(int id)
        {
            var userAccount = this.userService.GetById(id);
            var viewModel = new UserViewModel
            {
                userId = userAccount.userId,
                username = userAccount.username,
                password = userAccount.password,
                isAdmin = userAccount.isAdmin,
            };

            return this.View(viewModel);
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
                this.ViewBag.DuplicateMessage = "Incorrect username or password.";
                return this.View("Login");
            }
        }
        public ActionResult LogOut()
        {
            this.Session["User_ID"] = null;
            this.Session["Username"] = null;
            this.Session["Password"] = null;
            this.Session["isAdmin"] = null;
            return this.View("Login");
        }
        [HttpGet]
        public ActionResult AllUsers()
        {
            IEnumerable<UserDTO> users = this.userService.GetAll();
            return this.View(users);
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var user = this.userService.GetById(id);
            return this.View(user);
        }

        [HttpPost]
        public ActionResult EditUser(UserDTO user)
        {
            this.userService.Update(user);
            return RedirectToAction("AllUsers", "User");
        }

        public ActionResult DeleteUser(int id)
        {
            var allComentsToThisUser = this.userService.GetAllComments().Where(e => e.userId == id);
            foreach (var item in allComentsToThisUser)
            {
                this.userService.DisposeComment(item.commentId);
            }
            var allOrdersToThisUser = this.userService.GetAllOrders().Where(e => e.userId == id);
            foreach (var item in allOrdersToThisUser)
            {
                this.userService.DisposeOrder(item.orderId);
            }
            this.userService.Dispose(id);

            return RedirectToAction("AllUsers", "User");
        }
    }
}