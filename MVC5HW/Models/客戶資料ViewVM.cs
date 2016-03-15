using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC5HW.Models
{

    public class 客戶資料ViewListVM : BaseListVM
    {
        public List<客戶資料ViewVM> 客戶資料View { get; set; }

        public 客戶資料ViewListVM()
        {
            客戶資料View = new List<客戶資料ViewVM>();
        }
    }

    /// <summary>
    /// 客戶聯絡人VM類別。
    /// </summary>
    public class 客戶資料ViewVM
    {
        [Display(Name = "客戶名稱")]
        public string 客戶名稱 { get; set; }

        [Display(Name = "聯絡人數量")]
        public int? 聯絡人數量 { get; set; }

        [Display(Name = "銀行帳戶數量")]
        public int? 銀行帳戶數量 { get; set; }
    }
}