using System.Net;
using System.Web.Mvc;
using MVC5HW.Models;
using MVC5HW.Services;
using System.Collections.Generic;

namespace MVC5HW.Controllers
{
    public class 客戶資料Controller : BaseController
    {
        客戶資料Service 客戶資料Service;
        客戶資料Repository Repository = RepositoryHelper.Get客戶資料Repository();


        public 客戶資料Controller()
        {
            客戶資料Service = new 客戶資料Service();
        }

        // GET: 客戶資料
        public ActionResult Index(客戶資料ListVM model)
        {
            var data = 客戶資料Service.GetList(model);
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(List<客戶資料VM> 客戶資料)
        {
            foreach (var item in 客戶資料)
            {
                var query = Repository.Find(item.Id);
                if (query != null)
                {
                    query.地址 = item.地址;
                    query.傳真 = item.傳真;
                }
            }

            Repository.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult ViewIndex(客戶資料ViewListVM model)
        {
            var data = 客戶資料Service.GetViewList(model);
            return View(data);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View(new 客戶資料VM() { });
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(客戶資料VM 客戶資料)
        {
            if (ModelState.IsValid)
            {
                if (客戶資料Service.Create(客戶資料))
                {
                    return RedirectToAction("Index");
                }
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料VM 客戶資料 = 客戶資料Service.Get客戶資料ById(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料VM 客戶資料 = 客戶資料Service.Get客戶資料ById(id.Value);
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
        public ActionResult Edit(客戶資料VM 客戶資料)
        {
            if (ModelState.IsValid)
            {
                if (客戶資料Service.Edit(客戶資料))
                {
                    TempData["message"] = "修改成功";

                    return RedirectToAction("Index");
                }
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料VM 客戶資料 = 客戶資料Service.Get客戶資料ById(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (客戶資料Service.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete",new { id= id });
        }
    }
}
