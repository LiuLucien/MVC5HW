using MVC5HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5HW.Areas.Web.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost,AllowAnonymous]
        public ActionResult Login(LoginViewModel login)
        {
            if (CheckLogin(login.Email, login.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(login.Email, login.RememberMe);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Password", "您輸入的帳號或密碼錯誤");
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [HandleError]
        public ActionResult ErrorType(string a)
        {
            if (a == "1")
            {
                throw new Exception("error 1");
            }
            if (a == "b")
            {
                throw new ArgumentException("error 2");
            }
            return View();
        }

        private bool CheckLogin(string username, string password)
        {
            return (
                username == "abc@gmail.com" &&
                password == "123"
                );
        }
    }
}