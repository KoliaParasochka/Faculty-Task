using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public Teacher()
        {
            
            Courses = new List<Course>();
        }
    }
}
