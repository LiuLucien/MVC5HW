using MVC5HW.Models;
using MVC5HW.Services;
using System.Net;
using System.Web.Mvc;

namespace MVC5HW.Controllers
{
    public class 客戶銀行資訊Controller : BaseController
    {
        客戶銀行資訊Service 客戶銀行資訊Service;
        客戶資料Service 客戶資料Service;

        public 客戶銀行資訊Controller()
        {
            客戶銀行資訊Service = new 客戶銀行資訊Service();
            客戶資料Service = new 客戶資料Service();
        }

        // GET: 客戶銀行資訊
        public ActionResult Index(客戶銀行資訊ListVM model)
        {
            var aa = UserId;
            return View(客戶銀行資訊Service.GetList(model));
        }

        // GET: 客戶銀行資訊/Create
        public ActionResult Create()
        {
            var model = new 客戶銀行資訊VM();
            model.客戶IdList = 客戶資料Service.Get客戶IdList(0);
            return View(model);
        }

        // POST: 客戶銀行資訊/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(客戶銀行資訊VM 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                if (客戶銀行資訊Service.Create(客戶銀行資訊))
                {
                    return RedirectToAction("Index");
                }
            }
            客戶銀行資訊.客戶IdList = 客戶資料Service.Get客戶IdList(客戶銀行資訊.客戶Id);

            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊VM 客戶銀行資訊 = 客戶銀行資訊Service.Get客戶銀行資訊ById(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊VM 客戶銀行資訊 = 客戶銀行資訊Service.Get客戶銀行資訊ById(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            客戶銀行資訊.客戶IdList = 客戶資料Service.Get客戶IdList(客戶銀行資訊.客戶Id);

            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(客戶銀行資訊VM 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                if (客戶銀行資訊Service.Edit(客戶銀行資訊))
                {
                    return View("index", 客戶銀行資訊Service.GetList(new 客戶銀行資訊ListVM()));
                    //return RedirectToAction("Index");
                }
            }
            客戶銀行資訊.客戶IdList = 客戶資料Service.Get客戶IdList(客戶銀行資訊.客戶Id);

            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊VM 客戶銀行資訊 = 客戶銀行資訊Service.Get客戶銀行資訊ById(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            客戶銀行資訊.客戶IdList = 客戶資料Service.Get客戶IdList(客戶銀行資訊.客戶Id);

            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (客戶銀行資訊Service.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete", new { id = id });
        }
    }
}
