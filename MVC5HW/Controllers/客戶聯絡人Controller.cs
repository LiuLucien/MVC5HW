using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5HW.Models;
using MVC5HW.Services;

namespace MVC5HW.Controllers
{
    public class 客戶聯絡人Controller : BaseController
    {
        客戶聯絡人Service 客戶聯絡人Service;
        客戶資料Service 客戶資料Service;

        public 客戶聯絡人Controller()
        {
            客戶聯絡人Service = new 客戶聯絡人Service();
            客戶資料Service = new 客戶資料Service();
        }

        // GET: 客戶聯絡人
        public ActionResult Index(客戶聯絡人ListVM model)
        {
            var data = 客戶聯絡人Service.GetList(model);
            return View(data);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            var model = new 客戶聯絡人VM();

            model.客戶IdList = 客戶資料Service.Get客戶IdList(0);

            return View(model);
        }

        // POST: 客戶聯絡人/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(客戶聯絡人VM 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                string errorMsg = string.Empty;
                if (客戶聯絡人Service.Create(客戶聯絡人,ref errorMsg))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", errorMsg);
            }
            客戶聯絡人.客戶IdList = 客戶資料Service.Get客戶IdList(客戶聯絡人.客戶Id);

            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人VM 客戶聯絡人 = 客戶聯絡人Service.Get客戶聯絡人ById(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            客戶聯絡人.客戶IdList = 客戶資料Service.Get客戶IdList(客戶聯絡人.客戶Id);

            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人VM 客戶聯絡人 = 客戶聯絡人Service.Get客戶聯絡人ById(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            客戶聯絡人.客戶IdList = 客戶資料Service.Get客戶IdList(客戶聯絡人.客戶Id);

            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(客戶聯絡人VM 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                string errorMsg = string.Empty;

                if (客戶聯絡人Service.Edit(客戶聯絡人,ref errorMsg))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", errorMsg);
            }
            客戶聯絡人.客戶IdList = 客戶資料Service.Get客戶IdList(客戶聯絡人.客戶Id);

            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人VM 客戶聯絡人 = 客戶聯絡人Service.Get客戶聯絡人ById(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            客戶聯絡人.客戶IdList = 客戶資料Service.Get客戶IdList(客戶聯絡人.客戶Id);

            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (客戶聯絡人Service.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete", new { id = id });
        }

        public JsonResult TestAjax()
        {
            return Json(new
            {
                Message = "TEST"
            },JsonRequestBehavior.AllowGet);
        }
    }
}
