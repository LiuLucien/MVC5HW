using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HW.Controllers
{
    public abstract class BaseController : Controller
    {
        public int UserId => string.IsNullOrEmpty(User.Identity.Name) ? 0 : Convert.ToInt32((User.Identity.Name));

        protected override void HandleUnknownAction(string actionName)
        {
            if (this.ControllerContext.HttpContext.Request.HttpMethod.ToUpper() == "GET")
            {
                this.View(actionName).ExecuteResult(this.ControllerContext);
            }
            else
            {
                base.HandleUnknownAction(actionName);
            }
        }
    }
}