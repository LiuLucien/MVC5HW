using AutoMapper;
using MVC5HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HW.Services
{
    public class 客戶銀行資訊Service : BaseService
    {
        public 客戶銀行資訊ListVM GetList(客戶銀行資訊ListVM model)
        {
            var data = db.客戶銀行資訊.Where(s => !s.是否已刪除);

            if (!string.IsNullOrEmpty(model.Search))
            {
                data = data.Where(s => s.帳戶名稱.Contains(model.Search));
            }
            Mapper.CreateMap<客戶銀行資訊, 客戶銀行資訊VM>();
            model.客戶銀行資訊 = Mapper.Map<List<客戶銀行資訊>, List<客戶銀行資訊VM>>(data.ToList());

            foreach (var item in model.客戶銀行資訊)
            {
                item.客戶名稱 = db.客戶資料.Where(s => s.Id == item.客戶Id).Select(s => s.客戶名稱).FirstOrDefault();
            }

            return model;
        }

        public 客戶銀行資訊VM Get客戶銀行資訊ById(int value)
        {
            客戶銀行資訊VM model = new 客戶銀行資訊VM();
            var query = db.客戶銀行資訊.FirstOrDefault(s => s.Id == value && !s.是否已刪除);
            if (query != null)
            {
                Mapper.CreateMap<客戶銀行資訊, 客戶銀行資訊VM>();
                model = Mapper.Map<客戶銀行資訊, 客戶銀行資訊VM>(query);
                model.客戶名稱= db.客戶資料.Where(s => s.Id == query.客戶Id).Select(s => s.客戶名稱).FirstOrDefault();
            }
            return model;
        }

        public bool Create(客戶銀行資訊VM model)
        {
            客戶銀行資訊 data = new 客戶銀行資訊();

            Mapper.CreateMap<客戶銀行資訊VM, 客戶銀行資訊>();
            data = Mapper.Map<客戶銀行資訊VM, 客戶銀行資訊>(model);

            db.客戶銀行資訊.Add(data);
            db.SaveChanges();
            return true;
        }

        public bool Edit(客戶銀行資訊VM model)
        {
            var query = db.客戶銀行資訊.FirstOrDefault(s => s.Id == model.Id && !s.是否已刪除);

            if (query != null)
            {
                Mapper.CreateMap<客戶銀行資訊VM, 客戶銀行資訊>();
                Mapper.Map(model, query);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int value)
        {
            var query = db.客戶銀行資訊.FirstOrDefault(s => s.Id == value && !s.是否已刪除);

            if (query != null)
            {
                query.是否已刪除 = true;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}