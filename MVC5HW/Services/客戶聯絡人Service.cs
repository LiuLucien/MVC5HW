using AutoMapper;
using MVC5HW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC5HW.Services
{
    public class 客戶聯絡人Service
    {
        客戶聯絡人Repository Repository = RepositoryHelper.Get客戶聯絡人Repository();
        客戶資料Repository 客戶資料Repository = RepositoryHelper.Get客戶資料Repository();

        public 客戶聯絡人ListVM GetList(客戶聯絡人ListVM model)
        {
            var data = Repository.All();

            if (model.客戶Id != 0)
            {
                data = data.Where(s => s.客戶Id == model.客戶Id);
            }
            if (!string.IsNullOrEmpty(model.Search))
            {
                data = data.Where(s => s.職稱.Contains(model.Search));
            }
            Mapper.CreateMap<客戶聯絡人, 客戶聯絡人VM>();
            model.客戶聯絡人 = Mapper.Map<List<客戶聯絡人>, List<客戶聯絡人VM>>(data.ToList());

            foreach (var item in model.客戶聯絡人)
            {
                item.客戶名稱 = 客戶資料Repository.Where(s => s.Id == item.客戶Id).Select(s => s.客戶名稱).FirstOrDefault();
            }

            return model;
        }

        public 客戶聯絡人VM Get客戶聯絡人ById(int value)
        {
            客戶聯絡人VM model = new 客戶聯絡人VM();
            var query = Repository.Find(value);
            if (query != null)
            {
                Mapper.CreateMap<客戶聯絡人, 客戶聯絡人VM>();
                model = Mapper.Map<客戶聯絡人, 客戶聯絡人VM>(query);
                model.客戶名稱 = 客戶資料Repository.Where(s => s.Id == value).Select(s => s.客戶名稱).FirstOrDefault();
            }
            return model;
        }

        public bool Create(客戶聯絡人VM model, ref string errorMsg)
        {
            客戶聯絡人 data = new 客戶聯絡人();

            Mapper.CreateMap<客戶聯絡人VM, 客戶聯絡人>();
            data = Mapper.Map<客戶聯絡人VM, 客戶聯絡人>(model);

            Repository.Add(data);
            Repository.UnitOfWork.Commit();
            return true;
        }

        public bool Edit(客戶聯絡人VM model, ref string errorMsg)
        {
            var query = Repository.Find(model.Id);

            if (query != null)
            {
                Mapper.CreateMap<客戶聯絡人VM, 客戶聯絡人>();
                Mapper.Map(model, query);
                Repository.UnitOfWork.Commit();
                return true;
            }
            errorMsg = "找不到資料!!";
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