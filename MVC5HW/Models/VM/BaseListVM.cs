using System.ComponentModel.DataAnnotations;

namespace MVC5HW.Models
{
    public class BaseListVM
    {
        [Display(Name = "查詢")]
        public string Search { get; set; }

        public int? EnumSearch { get; set; }

    }
}