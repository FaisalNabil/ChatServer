using Chat.Entity;
using Chat.Service.Interfaces;
using Chat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chat.Models;

namespace Chat.Controllers
{
    public class HomeController : Controller
    {
        IUserService userService = ServiceFactory.GetUserService();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(ModelUserRegistration modelUserRegistration)
        {
            User newUser = new User();

            if (doesExistInDatabase(modelUserRegistration.UserName))
            {
                modelUserRegistration.UserExistMessage = "User Name Taken, Try another one";
                return View(modelUserRegistration);
            }

            newUser.UserName = modelUserRegistration.UserName;
            newUser.UserEmail = modelUserRegistration.UserEmail;
            newUser.UserPassword = modelUserRegistration.UserPassword;
            newUser.isActive = true;
            newUser.dateCreated = DateTime.Now.ToString();

            ModelState.Clear();
            ModelUserRegistration newUserModel = new ModelUserRegistration();
            if (userService.Insert(newUser) == 1)
            {
                newUserModel.NotifyAccountCreatedStatus = "Account Created Successfully";
            }
            else
            {
                newUserModel.NotifyAccountCreatedStatus = "Oops!! Error occured, Account Was Not Created";
            }
            return View(newUserModel);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ModelLogin modelLogin)
        {
            User user = userService.GetByName(modelLogin.UserName);

            if (modelLogin.UserPassword == user.UserPassword)
            {
                Session["LoggedInUser"] = user.UserId;
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.Clear();
                ModelLogin newModelLogin = new ModelLogin();
                newModelLogin.ErrorMessage = "User Name and Password Did not match";
                return View(newModelLogin);
            }
        }

        //Auxiliary Methods
        private bool doesExistInDatabase(string userName)
        {
            if (userService.GetByName(userName) != null) return true;
            else return false;
        }
    }
}