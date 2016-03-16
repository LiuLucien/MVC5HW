using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC5HW.Models
{
    /// <summary>
    /// 客戶資料VM類別。
    /// </summary>
    public class 客戶帳號修改VM
    {
        public int Id { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string 密碼 { get; set; }

        [Display(Name = "電話"), Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(50, ErrorMessage = "{0}長度不可超過50。")]
        public string 電話 { get; set; }

        [Display(Name = "傳真"), StringLength(50, ErrorMessage = "{0}長度不可超過50。")]
        public string 傳真 { get; set; }

        [Display(Name = "地址"), StringLength(100, ErrorMessage = "{0}長度不可超過100。")]
        public string 地址 { get; set; }

        [EmailAddress]
        [Display(Name = "Email"), StringLength(250, ErrorMessage = "{0}長度不可超過250。")]
        public string Email { get; set; }
    }
   
}