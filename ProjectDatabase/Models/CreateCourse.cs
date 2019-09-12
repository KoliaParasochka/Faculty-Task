using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase.Models
{
    public class CreateCourse
    {
        public int CourseId { get; set; }

        [Required]
        [Display(Name = "Почта преподавателя")]
        public string TeacherEmail { get; set; }

        [Required]
        [Display(Name = "Название курса")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Описание курса")]
        [StringLength(1000, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.")]  
        public string Text { get; set; }

        [Required]
        [Display(Name = "Начало обучения")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Завершение обучения")]
        public DateTime FinishDate { get; set; }


    }
}
