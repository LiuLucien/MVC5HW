using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5HW.Models
{   
	public  class 客戶資料ViewRepository : EFRepository<客戶資料View>, I客戶資料ViewRepository
	{

	}

	public  interface I客戶資料ViewRepository : IRepository<客戶資料View>
	{

	}
}