using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindShop.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Confection()
        {
            return View();
        }
        public ActionResult Beverage()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
    }
}