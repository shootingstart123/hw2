using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Park.Controllers
{
    public class HomeController : Controller
    {
        /*
        public class ParkWithCount
        {
            public Models.Park Data { get; set; }
            public int ReadCount { get; set; }
        }*/
        // GET: Home
        public ActionResult Index()
        {
            Service.DatabaseService db = new Service.DatabaseService();
            var list = db.LoadAllPark();
            return View(list);

            //return Content("<h1>hello world</h1>" + id);
        }
        public ActionResult MAP1()
        {
            return View();
        }
        public ActionResult MAP2()
        {
            return View();
        }

    }
}