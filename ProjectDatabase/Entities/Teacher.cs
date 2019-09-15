using System.Collections.Generic;


namespace ProjectDatabase.Entities
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
