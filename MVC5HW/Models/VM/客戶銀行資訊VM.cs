using PagedList;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC5HW.Models
{
    public class 客戶銀行資訊ListVM : BaseListVM
    {
        public IPagedList<客戶銀行資訊VM> 客戶銀行資訊 { get; set; }

        public 客戶銀行資訊ListVM()
        {
            
        }
    }

    /// <summary>
    /// 客戶銀行資訊VM類別。
    /// </summary>
    public class 客戶銀行資訊VM
    {
        public int Id { get; set; }

        [Display(Name = "客戶"), Required(ErrorMessage = "{0}欄位必填")]
        public int 客戶Id { get; set; }

        public List<SelectListItem> 客戶IdList { get; set; }

        [Display(Name = "銀行名稱"), Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(50, ErrorMessage = "{0}長度不可超過50。")]
        public string 銀行名稱 { get; set; }

        [Display(Name = "銀行代碼"), Required(ErrorMessage = "{0}欄位必填")]
        public int 銀行代碼 { get; set; }

        [Display(Name = "分行代碼")]
        public int? 分行代碼 { get; set; }

        [Display(Name = "帳戶名稱"), Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(50, ErrorMessage = "{0}長度不可超過50。")]
        public string 帳戶名稱 { get; set; }

        [Display(Name = "帳戶號碼"), StringLength(20, ErrorMessage = "{0}長度不可超過20。")]
        public string 帳戶號碼 { get; set; }

        [Display(Name = "客戶名稱")]
        public string 客戶名稱 { get; set; }
    }
}