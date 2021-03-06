﻿using System.ComponentModel.DataAnnotations;

namespace MVC5HW.Models
{
    public class BaseListVM
    {
        [Display(Name = "查詢")]
        public string Search { get; set; }

        public int? EnumSearch { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public BaseListVM()
        {
            Page = 1;
            PageSize = 2;
        }
    }
}