using NorthwindShop.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NorthwindShop.Controllers
{
    public class ProductController : Controller
    {
        ShopContext DbShop = new ShopContext();

        CookieContainer cookieContainer = new CookieContainer();

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
            
            if(Request.Cookies["Product"] != null)
            {
                HttpCookie cookieProduct = Request.Cookies["Product"];

                //Distribution our cookie value in two values: 1) ProductId 2) Count

                string str = cookieProduct.Value;

                int positionStr = str.IndexOf("/");

                string IdValue = "";

                for (int i = 0; i < positionStr; i++)
                {
                    IdValue += str[i];
                }

                positionStr++;

                string CountValue = "";

                for (int i = positionStr; i < str.Length; i++)
                {
                    CountValue += str[i];
                }

                int ProductId = Int32.Parse(IdValue);

                int Count = Int32.Parse(CountValue);

                //Found our model by ProductId

                var FoundModel = DbShop.Products.First(p => p.ProductID == ProductId);

                //Representing our values for client

                ViewBag.ourProduct = FoundModel;

                ViewBag.Count = Count;
            }
               
            return View();
        }
       

        [HttpPost]
        public ActionResult Cart(int? IdProductSet,int? InputText)
        {
            var Product = DbShop.Products.First(p => p.ProductID == IdProductSet);
            
            HttpCookie cookieProduct = new HttpCookie("Product", IdProductSet.ToString() + "/" + InputText.ToString());

            Response.Cookies.Add(cookieProduct);

            return RedirectToAction("Confection", "Product", new { Id = IdProductSet });
        }

        public ActionResult AddToCart(int? IdProductFromView)
        {
            var Product = DbShop.Products.First(p => p.ProductID == IdProductFromView);

            return PartialView(Product);
        }


    }
}