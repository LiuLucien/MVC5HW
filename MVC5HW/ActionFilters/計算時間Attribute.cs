using System;
using System.Web.Mvc;

namespace MVC5HW.Controllers
{
    internal class 計算時間Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            System.Diagnostics.Debug.WriteLine("Action前" + DateTime.Now);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            System.Diagnostics.Debug.WriteLine("Action後" + DateTime.Now);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            System.Diagnostics.Debug.WriteLine("Action Result前" + DateTime.Now);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            System.Diagnostics.Debug.WriteLine("Action Result後" + DateTime.Now);
        }
    }
}