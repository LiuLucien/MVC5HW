using System.Net;
using System.Web.Mvc;
using MVC5HW.Models;
using MVC5HW.Services;
using System.Collections.Generic;
using System;
using System.IO;
using NPOI.HSSF.UserModel;

namespace MVC5HW.Controllers
{
    public class 客戶資料Controller : BaseController
    {
        客戶資料Service 客戶資料Service;
        客戶聯絡人Service 客戶聯絡人Service;
        客戶資料Repository Repository = RepositoryHelper.Get客戶資料Repository();
        客戶聯絡人Repository 客戶聯絡人Repository = RepositoryHelper.Get客戶聯絡人Repository();

        public 客戶資料Controller()
        {
            客戶資料Service = new 客戶資料Service();
            客戶聯絡人Service = new 客戶聯絡人Service();
        }

        // GET: 客戶資料
        [計算時間]
        public ActionResult Index(客戶資料ListVM model, int? 客戶Id, string type)
        {
            var data = 客戶資料Service.GetList(model);
            if (客戶Id.HasValue)
            {
                TempData["客戶Id"] = 客戶Id.Value;
                TempData["type"] = type;
            }
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(IList<客戶資料批次更新VM> 客戶資料)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in 客戶資料)
                {
                    var query = Repository.Find(item.Id);
                    if (query != null)
                    {
                        query.地址 = item.地址;
                        query.電話 = item.電話;
                    }
                }
                Repository.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            return View(客戶資料Service.GetList(new 客戶資料ListVM()));
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
        [HandleError(ExceptionType = typeof(Exception))]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception();
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
        public ActionResult Edit(客戶修改資料VM 客戶資料)
        {
            客戶資料 data = Repository.Find(客戶資料.Id);

            if (TryUpdateModel<客戶資料>(data, new string[] {
                "客戶名稱","統一編號","電話","傳真","地址","Email" ,"客戶分類"}))
            {
                Repository.UnitOfWork.Commit();

                TempData["message"] = "修改成功";

                return RedirectToAction("Index");
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
            return RedirectToAction("Delete", new { id = id });
        }

        // GET: 客戶聯絡人
        [ChildActionOnly]
        public ActionResult Contect(客戶聯絡人ListVM model)
        {
            var data = 客戶聯絡人Service.GetList(model);
            return PartialView(data);
        }

        [HttpPost]
        public ActionResult Contect(IList<客戶聯絡人批次修改VM> 客戶聯絡人, int 客戶Id)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in 客戶聯絡人)
                {
                    var query = 客戶聯絡人Repository.Find(item.Id);
                    if (query != null)
                    {
                        query.職稱 = item.職稱;
                        query.電話 = item.電話;
                        query.手機 = item.手機;
                    }
                }
                客戶聯絡人Repository.UnitOfWork.Commit();
            }
            return RedirectToAction("Details", new { Id = 客戶Id });
        }

        public FileResult 匯出Excel()
        {
            HSSFWorkbook book = new HSSFWorkbook();

            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            var data = 客戶資料Service.GetList(new 客戶資料ListVM());

            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("客戶名稱");
            row1.CreateCell(1).SetCellValue("統一編號");
            row1.CreateCell(1).SetCellValue("傳真	");
            row1.CreateCell(1).SetCellValue("地址");
            row1.CreateCell(1).SetCellValue("Email");

            for (int i = 0; i < data.客戶資料.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(data.客戶資料[i].客戶名稱.ToString());
                rowtemp.CreateCell(0).SetCellValue(data.客戶資料[i].統一編號.ToString());
                rowtemp.CreateCell(0).SetCellValue(data.客戶資料[i].傳真.ToString());
                rowtemp.CreateCell(0).SetCellValue(data.客戶資料[i].地址.ToString());
                rowtemp.CreateCell(1).SetCellValue(data.客戶資料[i].Email.ToString());
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);

            return File(ms, "application/vnd.ms-excel", "報表.xls");

            //MemoryStream ms = ExcelHelper.匯出Excel<客戶資料VM>(data.客戶資料, new 客戶資料VM());
            //return File(ms.ToArray(), "application/vnd.ms-excel", "report.xls");
        }
    }
}
