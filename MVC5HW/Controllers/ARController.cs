using MVC5HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HW.Controllers
{
    public class ARController : BaseController
    {
        客戶資料Repository Repository = RepositoryHelper.Get客戶資料Repository();

        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View("index");
        }

        public ActionResult ContentTest()
        {
            return Content("內容測試");
        }

        public ActionResult FileTest()
        {
            return File(Server.MapPath("~/content/2583-5a03-o.png"), "image/png", "test.png");
        }

        public ActionResult JsonTest()
        {

            Repository.UnitOfWork.LazyLoadingEnabled = false;

            var data = Repository.All();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}