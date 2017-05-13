using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestEntity.Models;

namespace TestEntity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            NorthwindEntities NorthwindDB = new NorthwindEntities();

            int amountOfCustomers = NorthwindDB.Customers.Count();

            ViewBag.Message = $"We have {amountOfCustomers} Customers";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}