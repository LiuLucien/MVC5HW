using AutoMapper;
using MVC5HW.Models;
using MVC5HW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5HW.Controllers
{
    [Authorize]
    public class MemberController : BaseController
    {
        MemberService Service;
        客戶資料Service 客戶資料Service;

        public MemberController()
        {
            Service = new MemberService();
            客戶資料Service = new 客戶資料Service();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public ActionResult Login(LoginViewModel login)
        {
            int UserId = 0;
            if (Service.CheckLogin(login.Account, login.Password, ref UserId))
            {
                var ticket = new FormsAuthenticationTicket(1, UserId.ToString(), DateTime.Now, DateTime.Now.AddHours(6), false, login.Account, FormsAuthentication.FormsCookiePath);
                var encTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

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

        // GET: 客戶資料/Edit/5
        public ActionResult Edit()
        {
            if (UserId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料VM 客戶資料 = 客戶資料Service.Get客戶資料ById(UserId);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(客戶帳號修改VM 客戶資料)
        {
            if (ModelState.IsValid)
            {
                客戶資料.Id = UserId;
                if (Service.Edit(客戶資料))
                {
                    TempData["message"] = "修改成功";

                    return RedirectToAction("Index", "Home");
                }
            }
            Mapper.CreateMap<客戶帳號修改VM, 客戶資料VM>();
            var data = Mapper.Map<客戶帳號修改VM, 客戶資料VM>(客戶資料);
            return View(data);
        }
    }
}