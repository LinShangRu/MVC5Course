using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.Valids
{
    public class 商品名稱不能出現123關鍵字Attribute : DataTypeAttribute
    {

        public 商品名稱不能出現123關鍵字Attribute() : base(DataType.Text)
        {
            this.ErrorMessage = this.GetType().Name;
        }
        public override bool IsValid(object value)
        {
            string str = Convert.ToString(value);

            if (str.Contains("Will"))
            {
                return false;
            }

            return true;
        }
    }
}