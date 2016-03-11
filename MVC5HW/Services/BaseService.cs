using MVC5HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5HW.Services
{
    public class BaseService
    {
        public 客戶資料Entities db;

        public BaseService()
        {
            db = new 客戶資料Entities();
        }
    }
}