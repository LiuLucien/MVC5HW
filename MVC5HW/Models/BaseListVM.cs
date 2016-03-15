using System.ComponentModel.DataAnnotations;

namespace MVC5HW.Models
{
    public class BaseListVM
    {
        [Display(Name = "地址")]
        public string Search { get; set; }
    }
}