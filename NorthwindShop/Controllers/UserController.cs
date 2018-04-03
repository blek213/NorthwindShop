using NorthwindShop.Models;
using NorthwindShop.Models.ShopModels;
using NorthwindShop.Models.TemporaryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NorthwindShop.Controllers
{
    public class UserController : Controller
    {
        ShopContext DbShop = new ShopContext();

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Login login)
        {
            IEnumerable<Clients> clients = DbShop.Clients;

            // Email Validation

            if (string.IsNullOrEmpty(login.Email))
            {
                ModelState.AddModelError("Email", "The field is required");
            }

            else if (Regex.IsMatch(login.Email, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}") == false)
            {
                ModelState.AddModelError("Email", "Not correct email");
            }

            // Password Validation

            if (string.IsNullOrEmpty(login.Password))
            {
                ModelState.AddModelError("Password", "The field is required");
            }

            else if (login.Password.Length < 4 == true)
            {
                ModelState.AddModelError("Password", "Min value is 4");
            }

            else if (login.Password.Length > 50 == true)
            {
                ModelState.AddModelError("Password", "Max value is 50");
            }

            // Check if user exist 

            int checkVal = 0;

            foreach (var b in clients)
            {
                if (b.Email == login.Email)
                {
                    checkVal++;
                }

                if(checkVal != 0)
                {
                    break;
                }

            }

            if(checkVal == 0)
            {
                ModelState.AddModelError("Email", "The client with this email doesn't exist");
            }

            if (ModelState.IsValid)
            {
               foreach(var b in clients)
                {
                    if(b.Email == login.Email && b.Password == login.Password)
                    {
                        FormsAuthentication.SetAuthCookie(b.Name, true);

                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("Email", "The login or password is incorrect ");

            }

            return View(login);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            IEnumerable<Clients> clients = DbShop.Clients;

            // Name Validation

            if (string.IsNullOrEmpty(register.Name))
            {
                ModelState.AddModelError("Name", "The field is required");
            }

            else if (register.Name.Length < 3 || register.Name.Length > 50)
            {
                ModelState.AddModelError("Name", "The Name must be between 50 and 3 symbols");
            }

            // Email Validation

            if (string.IsNullOrEmpty(register.Email))
            {
                ModelState.AddModelError("Email", "The field is required");
            }

            else if (Regex.IsMatch(register.Email, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}") == false)
            {
                ModelState.AddModelError("Email", "Not correct email");
            }

            // Password Validation

            if (string.IsNullOrEmpty(register.Password))
            {
                ModelState.AddModelError("Password", "The field is required");
            }

            else if (register.Password.Length < 4 == true)
            {
                ModelState.AddModelError("Password", "Min value is 4");
            }

            else if (register.Password.Length > 50 == true)
            {
                ModelState.AddModelError("Password", "Max value is 50");
            }

            // RepeatPassword Validation

            if (string.IsNullOrEmpty(register.RepeatPassword))
            {
                ModelState.AddModelError("RepeatPassword", "The field is required");
            }

            else if (register.RepeatPassword.Length < 4)
            {
                ModelState.AddModelError("RepeatPassword", "Min value is 4");
            }

            else if (register.RepeatPassword.Length > 50)
            {
                ModelState.AddModelError("RepeatPassword", "Max value is 50");
            }

            else if (register.Password != register.RepeatPassword)
            {
                ModelState.AddModelError("Password", "Passwords are not equal");
                ModelState.AddModelError("RepeatPassword", "Passwords are not equal");
            }

            // Check if user exist 

            foreach(var b in clients)
            {
                if(b.Email == register.Email)
                {
                    ModelState.AddModelError("Email", "The client with the same email exist");
                }
            }
           
            if (ModelState.IsValid)
            {
                Clients client = new Clients
                {
                    Name = register.Name,
                    Email = register.Email,
                    Password = register.Password,
                    DatimeRegister = System.DateTime.Now.Date
                };

                DbShop.Clients.Add(client);
                DbShop.SaveChanges();

                FormsAuthentication.SetAuthCookie(register.Name, true);
            }

            return View(register);
        }

        [HttpPost]
        public ActionResult SignOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

    }
}