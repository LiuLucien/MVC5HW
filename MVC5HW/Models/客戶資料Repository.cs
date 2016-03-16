using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5HW.Models
{
    public class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
    {
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(s => !s.是否已刪除);
        }

        public IQueryable<客戶資料> All(bool isAll)
        {
            if (isAll)
            {
                return base.All();
            }
            else
            {
                return this.All();
            }
        }

        public 客戶資料 Find(int id, bool isAll = false)
        {
            return this.All(isAll).FirstOrDefault(s => s.Id == id);
        }

        public bool CheckLogin(string username, string password,ref int UserId, bool isAll = false)
        {
            UserId = this.All(isAll).Where(s => s.帳號 == username && s.密碼 == password).Select(s => s.Id).FirstOrDefault();

            return UserId != 0;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{
        
	}
}