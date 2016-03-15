using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MVC5HW.Models
{
    public sealed class 驗證電話Attribute : ValidationAttribute
    {
        public const string RegExString = @"\d{4}-\d{6}";

        public 驗證電話Attribute()
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            if (value is string)
            {
                Regex regEx = new Regex(RegExString);
                return regEx.IsMatch(value.ToString());
            }
            return false;
        }
    }
}