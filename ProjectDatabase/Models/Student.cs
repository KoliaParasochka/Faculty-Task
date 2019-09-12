using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public bool IsBlocked { get; set; }

        public Student()
        {
            Courses = new List<Course>();
            Marks = new List<Mark>();
        }
    }
}
