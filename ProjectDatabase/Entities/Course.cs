using System;
using System.Collections.Generic;

namespace ProjectDatabase.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public int CountStudents { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public int? TeacherId { get; set; }
        public Course()
        {
            Students = new List<Student>();
        }
    }
}
