using AutoMapper;
using MVC5HW.Helpers;
using MVC5HW.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HW.Services
{
    public class 客戶銀行資訊Service
    {
        客戶銀行資訊Repository Repository = RepositoryHelper.Get客戶銀行資訊Repository();
        客戶資料Repository 客戶資料Repository = RepositoryHelper.Get客戶資料Repository();


        public 客戶銀行資訊ListVM GetList(客戶銀行資訊ListVM model)
        {
            var data = Repository.All();

            if (!string.IsNullOrEmpty(model.Search))
            {
                data = data.Where(s => s.帳戶名稱.Contains(model.Search));
            }
            data = data.OrderBy(s => s.Id);

            //Mapper.CreateMap<客戶銀行資訊, 客戶銀行資訊VM>();
            //model.客戶銀行資訊 = Mapper.Map<List<客戶銀行資訊>, List<客戶銀行資訊VM>>(data.ToList());
            model.客戶銀行資訊 = data.Select(s => new 客戶銀行資訊VM()
            {
                Id = s.Id,
                分行代碼 = s.分行代碼,
                客戶Id = s.客戶Id,
                帳戶名稱 = s.帳戶名稱,
                帳戶號碼 = s.帳戶號碼,
                銀行代碼 = s.銀行代碼,
                銀行名稱 = s.銀行名稱,
            }).ToPagedList(model.Page, model.PageSize);

            foreach (var item in model.客戶銀行資訊)
            {
                item.客戶名稱 = 客戶資料Repository.Where(s => s.Id == item.客戶Id).Select(s => s.客戶名稱).FirstOrDefault();
            }

            return model;
        }

        public 客戶銀行資訊VM Get客戶銀行資訊ById(int value)
        {
            客戶銀行資訊VM model = new 客戶銀行資訊VM();
            var query = Repository.Find(value);
            if (query != null)
            {
                Mapper.CreateMap<客戶銀行資訊, 客戶銀行資訊VM>();
                model = Mapper.Map<客戶銀行資訊, 客戶銀行資訊VM>(query);
                model.客戶名稱 = 客戶資料Repository.Where(s => s.Id == query.客戶Id).Select(s => s.客戶名稱).FirstOrDefault();
            }
            return model;
        }

        public bool Create(客戶銀行資訊VM model)
        {
            客戶銀行資訊 data = new 客戶銀行資訊();

            Mapper.CreateMap<客戶銀行資訊VM, 客戶銀行資訊>();
            data = Mapper.Map<客戶銀行資訊VM, 客戶銀行資訊>(model);

            Repository.Add(data);
            Repository.UnitOfWork.Commit();
            return true;
        }

        public bool Edit(客戶銀行資訊VM model)
        {
            var query = Repository.Find(model.Id);

            if (query != null)
            {
                Mapper.CreateMap<客戶銀行資訊VM, 客戶銀行資訊>();
                Mapper.Map(model, query);
                Repository.UnitOfWork.Commit();
                return true;
            }
            return false;
        }

        public bool Delete(int value)
        {
            var query = Repository.Find(value);

            if (query != null)
            {
                query.是否已刪除 = true;
                Repository.UnitOfWork.Commit();
                return true;
            }
            return false;
        }
    }
}