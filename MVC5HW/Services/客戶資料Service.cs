using AutoMapper;
using MVC5HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HW.Services
{
    public class 客戶資料Service : BaseService
    {

        public 客戶資料ListVM GetList(客戶資料ListVM model)
        {
            var data = db.客戶資料.Where(s => !s.是否已刪除);

            if (!string.IsNullOrEmpty(model.Search))
            {
                data = data.Where(s => s.客戶名稱.Contains(model.Search));
            }
            Mapper.CreateMap<客戶資料, 客戶資料VM>();
            model.客戶資料 = Mapper.Map<List<客戶資料>, List<客戶資料VM>>(data.ToList());

            return model;
        }

        public 客戶資料ViewListVM GetViewList(客戶資料ViewListVM model)
        {
            var data = db.客戶資料View.ToList();

            if (!string.IsNullOrEmpty(model.Search))
            {
                data = data.Where(s => s.客戶名稱.Contains(model.Search)).ToList();
            }
            Mapper.CreateMap<客戶資料View, 客戶資料ViewVM>();
            model.客戶資料View = Mapper.Map<List<客戶資料View>, List<客戶資料ViewVM>>(data.ToList());

            return model;
        }

        public 客戶資料VM Get客戶資料ById(int value)
        {
            客戶資料VM model = new 客戶資料VM();
            var query = db.客戶資料.FirstOrDefault(s => s.Id == value && !s.是否已刪除);
            if (query != null)
            {
                Mapper.CreateMap<客戶資料, 客戶資料VM>();
                model = Mapper.Map<客戶資料, 客戶資料VM>(query);
            }
            return model;
        }

        public bool Create(客戶資料VM model)
        {
            客戶資料 data = new 客戶資料();

            Mapper.CreateMap<客戶資料VM, 客戶資料>();
            data = Mapper.Map<客戶資料VM, 客戶資料>(model);

            db.客戶資料.Add(data);
            db.SaveChanges();
            return true;
        }

        public bool Edit(客戶資料VM model)
        {
            var query = db.客戶資料.FirstOrDefault(s => s.Id == model.Id && !s.是否已刪除);

            if (query != null)
            {
                Mapper.CreateMap<客戶資料VM, 客戶資料>();
                Mapper.Map(model, query);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int value)
        {
            var query = db.客戶資料.FirstOrDefault(s => s.Id == value && !s.是否已刪除);

            if (query != null)
            {
                query.是否已刪除 = true;

                var bank = db.客戶銀行資訊.Where(s => s.客戶Id == value && !s.是否已刪除);
                foreach (var item in bank)
                {
                    item.是否已刪除 = true;
                }

                var contact = db.客戶聯絡人.Where(s => s.客戶Id == value && !s.是否已刪除);
                foreach (var item in contact)
                {
                    item.是否已刪除 = true;
                }
                db.SaveChanges();
                return true;
            }
            return false;
        }

        internal List<SelectListItem> Get客戶IdList(int id)
        {
            List<SelectListItem> model = new List<SelectListItem>() { };

            foreach (var item in db.客戶資料.Where(s => !s.是否已刪除))
            {
                model.Add(new SelectListItem()
                {
                    Text = item.客戶名稱,
                    Value = item.Id.ToString(),
                    Selected = item.Id == id
                });
            }
            return model;
        }
    }
}