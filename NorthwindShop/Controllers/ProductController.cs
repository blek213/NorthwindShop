using NorthwindShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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

        public ActionResult Beverage(int? Id)
        {
            if (Id != null)
            {
                var modelConfection = DbShop.Products.First(p => p.ProductID == Id);

                var modelCategories = DbShop.Categories.First(p => p.CategoryID == modelConfection.CategoryID);

                ViewBag.ImageCategory = modelCategories.Picture;

                return View(modelConfection);
            }

            return RedirectToAction("Beverages", "Home");
        }

        public ActionResult Cart()
        {
            HttpCookie cookieNickName = Request.Cookies["Product"];

            ViewBag.ourProduct = cookieNickName.Value;

            return View();
        }

        [HttpPost]
        public ActionResult Cart(int? Id)
        {
            var Product = DbShop.Products.First(p => p.ProductID == Id);

            CookieContainer cookieContainer = new CookieContainer();

            return RedirectToAction("Confection", "Product", new { Id = Id });
        }
    
    }
}