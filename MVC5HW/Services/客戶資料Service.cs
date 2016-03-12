using AutoMapper;
using MVC5HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HW.Services
{
    public class 客戶資料Service
    {
        客戶資料Repository Repository = RepositoryHelper.Get客戶資料Repository();

        public 客戶資料ListVM GetList(客戶資料ListVM model)
        {
            var data = Repository.All();

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
            var data = RepositoryHelper.Get客戶資料ViewRepository(Repository.UnitOfWork).All();

            if (!string.IsNullOrEmpty(model.Search))
            {
                data = data.Where(s => s.客戶名稱.Contains(model.Search));
            }
            Mapper.CreateMap<客戶資料View, 客戶資料ViewVM>();
            model.客戶資料View = Mapper.Map<List<客戶資料View>, List<客戶資料ViewVM>>(data.ToList());

            return model;
        }

        public 客戶資料VM Get客戶資料ById(int value)
        {
            客戶資料VM model = new 客戶資料VM();
            var query = Repository.Find(value);
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

            Repository.Add(data);
            Repository.UnitOfWork.Commit();
            return true;
        }

        public bool Edit(客戶資料VM model)
        {
            var query = Repository.Find(model.Id);

            if (query != null)
            {
                Mapper.CreateMap<客戶資料VM, 客戶資料>();
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

        internal List<SelectListItem> Get客戶IdList(int id)
        {
            List<SelectListItem> model = new List<SelectListItem>() { };

            foreach (var item in Repository.All())
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