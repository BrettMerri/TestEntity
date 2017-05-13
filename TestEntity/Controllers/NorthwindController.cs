using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestEntity.Models;

namespace TestEntity.Controllers
{
    public class NorthwindController : Controller
    {
        // GET: Northwind
        public ActionResult ListAllCustomers()
        {
            List<Customer> CustomerList = GetCustomerList();
            List<string> CityList = GetCityList();

            ViewBag.SearchResultsList = CustomerList;
            ViewBag.CityList = CityList;

            return View();
        }

        public ActionResult SearchCustomersByCustomerID(string CustomerID)
        {
            if (CustomerID == null || CustomerID == "")
            {
                return RedirectToAction("ListAllCustomers");
            }

            List<Customer> CustomerList = GetCustomerList();
            List<string> CityList = GetCityList();

            List<Customer> SearchResultsList = CustomerList
                .Where(x => x.CustomerID.ToUpper()
                .Contains(CustomerID.ToUpper()))
                .ToList();

            ViewBag.SearchResultsList = SearchResultsList;
            ViewBag.CityList = CityList;
            ViewBag.CustomerIDSelection = CustomerID;

            return View("ListAllCustomers");
        }

        public ActionResult SearchCustomersByCity(string City)
        {
            List<Customer> CustomerList = GetCustomerList();
            List<string> CityList = GetCityList();

            if (City == "Show all")
            {
                return RedirectToAction("ListAllCustomers");
            }

            List<Customer> SearchResultsList = CustomerList
                .Where(x => x.City !=null && x.City
                .Equals(City))
                .ToList();

            ViewBag.SearchResultsList = SearchResultsList;
            ViewBag.CityList = CityList;
            ViewBag.CitySelection = City;

            return View("ListAllCustomers");
        }

        public List<Customer> GetCustomerList()
        {
            NorthwindEntities NE = new NorthwindEntities();
            return NE.Customers.ToList();
        }

        public List<string> GetCityList()
        {
            NorthwindEntities NE = new NorthwindEntities();
            return NE.Customers.Where(x => x.City != null)
                .Select(x => x.City)
                .Distinct()
                .ToList();
        }
    }
}