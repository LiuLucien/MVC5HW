﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC5HW.Models
{
    public class 客戶資料ListVM : BaseListVM
    {
        public List<客戶資料VM> 客戶資料 { get; set; }

        public 客戶分類Enum 客戶資料Enums { get; set; }

        public 客戶資料ListVM()
        {
            客戶資料 = new List<客戶資料VM>();
        }
    }


    /// <summary>
    /// 客戶資料VM類別。
    /// </summary>
    public class 客戶資料VM
    {
        public int Id { get; set; }

        [Display(Name = "客戶名稱"), Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(50, ErrorMessage = "{0}長度不可超過50。")]
        public string 客戶名稱 { get; set; }

        [Display(Name = "統一編號"), Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(8, ErrorMessage = "{0}長度不可超過8。")]
        public string 統一編號 { get; set; }

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

        [Required]
        [Display(Name = "帳號")]
        public string 帳號 { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string 密碼 { get; set; }

        [Display(Name = "客戶分類")]
        public byte 客戶分類 { get; set; }

        public string 客戶分類str { get; set; }
    }

    public class 客戶修改資料VM
    {
        public int Id { get; set; }

        [Display(Name = "客戶名稱"), Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(50, ErrorMessage = "{0}長度不可超過50。")]
        public string 客戶名稱 { get; set; }

        [Display(Name = "統一編號"), Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(8, ErrorMessage = "{0}長度不可超過8。")]
        public string 統一編號 { get; set; }

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

        [Display(Name = "客戶分類")]
        public byte 客戶分類 { get; set; }
    }

    public class 客戶資料批次更新VM
    {
        [Required(ErrorMessage = "{0}欄位必填")]
        public int Id { get; set; }

        [Display(Name = "電話"), Required(ErrorMessage = "{0}欄位必填")]
        [StringLength(50, ErrorMessage = "{0}長度不可超過50。")]
        public string 電話 { get; set; }

        [Display(Name = "地址"), StringLength(100, ErrorMessage = "{0}長度不可超過100。")]
        public string 地址 { get; set; }
    }
}