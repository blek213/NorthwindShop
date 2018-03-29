using NorthwindShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindShop.Controllers
{
    public class ProductController : Controller
    {
        ShopContext DbShop = new ShopContext();

        public ActionResult Confection(int? Id)
        {
            if(Id != null)
            {
                var modelConfection = DbShop.Products.First(p=>p.ProductID == Id);

                var modelCategories = DbShop.Categories.First(p => p.CategoryID == modelConfection.CategoryID);

                ViewBag.ImageCategory = modelCategories.Picture;

                return View(modelConfection);
            }

            return RedirectToAction("Confections", "Home");
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