using AutoMapper;
using MVC5HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HW.Services
{
    public class MemberService
    {
        客戶資料Repository Repository = RepositoryHelper.Get客戶資料Repository();

        public bool CheckLogin(string username, string password, ref int UserId)
        {
            password = password.GetHashCode().ToString();
            return Repository.CheckLogin(username, password, ref UserId, false);
        }

        public bool Edit(客戶帳號修改VM model)
        {
            var query = Repository.Find(model.Id);

            if (query != null)
            {
                if (query.密碼 != model.密碼)
                {
                    model.密碼 = model.密碼.GetHashCode().ToString();
                }
                Mapper.CreateMap<客戶帳號修改VM, 客戶資料>();
                Mapper.Map(model, query);
                Repository.UnitOfWork.Commit();
                return true;
            }
            return false;
        }
    }
}