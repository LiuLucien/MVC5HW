using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HW.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HomeController共用ViewBag]
        public ActionResult About()
        {
            return View();
        }

        [HomeController共用ViewBag]
        public ActionResult Contact()
        {
            return View();
        }
    }
}