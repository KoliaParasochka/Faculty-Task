using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectDatabase.Entities
{
    public class CreateCourse : IValidatableObject
    {
        public int CourseId { get; set; }

        public int id { get; set; }

        [Required]
        [Display(Name = "Почта преподавателя")]
        public string TeacherEmail { get; set; }

        [Required]
        [Display(Name = "Название курса")]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Описание курса")]
        [StringLength(10000, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.")]
        public string Text { get; set; }

        [Required]
        [Display(Name = "Начало обучения")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Завершение обучения")]
        public DateTime FinishDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (StartDate < DateTime.Now)
            {
                errors.Add(new ValidationResult("Дата начала курса должна быть больше текущей даты!"));
            }
            if (StartDate > FinishDate)
            {
                errors.Add(new ValidationResult("Дата завершения курса не может быть раньше даты начала!"));
            }
            if (FinishDate < DateTime.Now)
            {
                errors.Add(new ValidationResult("Дата завершения курса не может быть меньше текущей даты!"));
            }
            return errors;
        }
    }
}
