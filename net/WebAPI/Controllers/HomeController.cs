using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebAPI.Controllers
{
    // https://localhost:44362/Home/Index
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult GetCountryInfo()
        {
            return View();
        }

    }
}



