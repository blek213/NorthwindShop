using NorthwindShop.Models;
using NorthwindShop.Models.ShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindShop.Controllers
{
    public class UserController : Controller
    {
        ShopContext DbShop = new ShopContext();

        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult Register()
        {
            Clients client = new Clients
            {
                Name = "Andrew",
                Email = "klarsom@gmail.com",
                Password = "1111",
                DatimeRegister = System.DateTime.Now.Date


            };

            DbShop.Clients.Add(client);
            DbShop.SaveChanges();

            return View();
        }

    }
}