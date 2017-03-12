using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class LoginModel:IValidatableObject
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public bool LoginCheck()
        {
            if (this.UserName.Equals("123") && this.Password.Equals("123456"))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(this.LoginCheck())
            {
                yield return ValidationResult.Success;
                yield break;
            }
            yield return new ValidationResult("登入失敗", new string[] { "Username"   });
            yield break;
        }
    }
}