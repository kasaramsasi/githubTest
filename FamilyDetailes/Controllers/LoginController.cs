using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyDetailes.Models;
using BusinessLayer;

namespace FamilyDetailes.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorise(UserLogin user)
        {
            using(LoginDBEntities loginDBEntities = new LoginDBEntities())
            {
                var UserDetailes = loginDBEntities.UserLogins.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
                if(UserDetailes == null)
                {
                    user.LoginErrorMessage = "Invalid Attempt";
                    return View("Login", user);
                }
                else
                {
                    Session["UserName"] = user.Username;
                    return RedirectToAction("Index", "Family");
                }
                
            }

            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();


            return RedirectToAction("Login", "Login");

        }


        [HttpGet]
        [ActionName("Register")]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Register")]
        public ActionResult Register_Post()
        {
               if (ModelState.IsValid)
                {
                    Register register = new Register();
                    UpdateModel(register);
                RegisterBusinessLayer registerBusinessLayer = new RegisterBusinessLayer();
                registerBusinessLayer.AddRegistredUser(register);

                    return RedirectToAction("Login","Login");
                }
            return View();

        }

        }
}