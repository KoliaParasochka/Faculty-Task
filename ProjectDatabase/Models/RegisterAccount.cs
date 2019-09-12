using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase.Models
{
    public class RegisterAccount
    {
        [Required]
        [RegularExpression(@"[A-Za-zА-Яа-я]+", ErrorMessage = "Имя не может содержать цыфры")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-zА-Яа-я]+", ErrorMessage = "Фамилия не может содержать цыфры")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 2)]
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Я преподаватель")]
        public string IsTeacher { get; set; }
    }
}
