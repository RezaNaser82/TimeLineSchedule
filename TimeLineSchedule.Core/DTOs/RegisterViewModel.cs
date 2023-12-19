using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLineSchedule.Core.DTOs.User
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [MinLength(3, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(24, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [Display(Name = "کلمه عبور")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,20}$", ErrorMessage = "کلمه عبور باید حداقل 8 کاراکتر و شامل حرف و عدد باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
