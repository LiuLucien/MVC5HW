using System;
using System.Web.Mvc;

namespace MVC5HW.Controllers
{
    internal class HomeController共用ViewBagAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = "Your application description page.";
            base.OnActionExecuting(filterContext);
        }
    }
}