using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC5HW.Models
{
    /// <summary>
    /// 客戶資料ApiVM。
    /// </summary>
    public class 客戶資料ApiVM
    {
        public string 電話 { get; set; }
        public string 傳真 { get; set; }
        public string 地址 { get; set; }

        [JsonIgnore]
        public string Email { get; set; }
    }
}