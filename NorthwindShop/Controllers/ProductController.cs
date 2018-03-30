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
            HttpCookie cookieProduct= Request.Cookies["Product"];

            int cookieValue = Int32.Parse(cookieProduct.Value);

            var FoundModel = DbShop.Products.First(p => p.ProductID == cookieValue);
            ViewBag.ourProduct = FoundModel;

            return View();
        }

        [HttpPost]
        public ActionResult Cart(int? Id)
        {
            var Product = DbShop.Products.First(p => p.ProductID == Id);

            HttpCookie cookieProduct = new HttpCookie("Product",Id.ToString());

            Response.Cookies.Add(cookieProduct);

            return RedirectToAction("Confection", "Product", new { Id = Id });
        }
    
    }
}