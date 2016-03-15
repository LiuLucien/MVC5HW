using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5HW.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(s => !s.是否已刪除);
        }

        public IQueryable<客戶聯絡人> All(bool isAll)
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

        public 客戶聯絡人 Find(int id, bool isAll = false)
        {
            return this.All(isAll).FirstOrDefault(s => s.Id == id);
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}