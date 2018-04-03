using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthwindShop.Models;
using PagedList.Mvc;
using PagedList;
namespace NorthwindShop.Controllers
{
    public class HomeController : Controller
    {
        ShopContext DbShop = new ShopContext();
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Confections(int? page)
        {         
            IEnumerable<Products> confections = DbShop.Database.SqlQuery<Products>("SELECT * FROM Products WHERE CategoryID = 3");

            int confectionsCount = 0;

            foreach(var b in confections)
            {
                confectionsCount++;
            }

            int pageSize = 15;
            int pageCount = (confectionsCount) / (pageSize);
            int pageNumber = (page ?? 1);

            return View(confections.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Beverages(int? page)
        {
            IEnumerable<Products> beverages = DbShop.Database.SqlQuery<Products>("SELECT * FROM Products WHERE CategoryID = 1");

            int confectionsCount = 0;

            foreach (var b in beverages)
            {
                confectionsCount++;
            }

            int pageSize = 15;
            int pageCount = (confectionsCount) / (pageSize);
            int pageNumber = (page ?? 1);

            return View(beverages.ToPagedList(pageNumber,pageSize));
        }

    }
}