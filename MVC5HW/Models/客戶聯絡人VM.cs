using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVC5HW.Models
{

    public class 客戶聯絡人ListVM : BaseListVM
    {
        public List<客戶聯絡人VM> 客戶聯絡人 { get; set; }

        public 客戶聯絡人ListVM()
        {
            客戶聯絡人 = new List<客戶聯絡人VM>();
        }
    }

    /// <summary>
    /// 客戶聯絡人VM類別。
    /// </summary>
    public class 客戶聯絡人VM
    {
        public int Id { get; set; }

        [Display(Name = "客戶"), Required(ErrorMessage = "{0}欄位必填")]
        public int 客戶Id { get; set; }

        public List<SelectListItem> 客戶IdList { get; set; }


        [Display(Name = "職稱"), Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(50, ErrorMessage = "{0}長度不可超過50。")]
        public string 職稱 { get; set; }

        [Display(Name = "姓名"), Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(50, ErrorMessage = "{0}長度不可超過50。")]
        public string 姓名 { get; set; }

        [EmailAddress]
        [Display(Name = "Email"), Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(250, ErrorMessage = "{0}長度不可超過250。")]
        public string Email { get; set; }

        [Display(Name = "手機"), StringLength(50, ErrorMessage = "{0}長度不可超過50。")]
        public string 手機 { get; set; }

        [驗證電話(ErrorMessage = "電話格式錯誤(xxxx-xxxxxx)")]
        [Display(Name = "電話"), StringLength(50, ErrorMessage = "{0}長度不可超過50。")]
        public string 電話 { get; set; }

        [Display(Name = "客戶名稱")]
        public string 客戶名稱 { get; set; }
    }
}