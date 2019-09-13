using ProjectDatabase;
using ProjectDatabase.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Faculty.FileManage;
using ProjectDatabase.EF;

namespace Faculty.Storages
{
    /// <summary>
    /// This class created to works
    /// with database context
    /// </summary>
    public class Storage : IStorage
    {
        FileManager fileManager = new FileManager();
        

        /// <summary>
        /// This method gets a count of students
        /// who studies on one course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public int GetCountOfStudentsOnCourse(Course course)
        {
            int count = 0;
            count = course.Students.Count;
            return count;
        }
       
        /// <summary>
        /// This method gets an email with 
        /// helping a given id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetEmail(string userId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                
                return user.Email;
            }
            

        }

        /// <summary>
        /// This method takes student with 
        /// a given email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Student GetStudent(string email)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Student> students = db.Students.Include(s => s.Courses).ToList();
                var student = from stud in students
                              where email == stud.Email
                              select stud;
                if (student.Count() >= 1)
                {
                    return student.First();
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// This method takes a teacher with
        /// a given email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Teacher GetTeacher(string email)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Teacher> teachers = db.Teachers.Include(s => s.Courses).ToList();
                var teacher = from t in teachers
                              where email == t.Email
                              select t;
                if (teacher.Count() >= 1)
                {
                    return teacher.First();
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// This method adds course to student into
        /// our database
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="userId"></param>
        public void AddCourseToStudent(string Name, dynamic userId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Course> courses = db.Courses.Include(s => s.Students).ToList();
                var takeCourse = from el in courses
                                 where el.Name == Name
                                 select el;
                Course course = takeCourse.FirstOrDefault();
                string email = GetEmail(userId);
                List<Student> students = db.Students.Include(s => s.Courses).ToList();
                var takeStudent = from stud in students
                                  where email == stud.Email
                                  select stud;
                Student student = takeStudent.FirstOrDefault();
                var oldStud = db.Students.Find(student.Id);
                var oldCourse = db.Courses.Find(course.CourseId);
                oldStud.Courses.Add(course);
                db.Entry(oldStud).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// This method adds new student into 
        /// a database
        /// </summary>
        /// <param name="student"></param>
        public void AddStudent(Student student)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// This method blocks student when the 
        /// second parameter is true and unblock
        /// whei it is false
        /// </summary>
        /// <param name="name"></param>
        /// <param name="act"></param>
        public void BlockUnblockStudent(string name, bool act)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Student> students = db.Students.ToList();
                var takeStudent = from el in students
                                  where el.Name == name
                                  select el;
                Student person = takeStudent.FirstOrDefault();
                var blockStud = db.Students.Find(person.Id);
                blockStud.IsBlocked = act;
                db.Entry(blockStud).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// This method takest students from database
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudents()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Students.ToList();
            }
        }

        /// <summary>
        /// This method removes course when the second parameter 
        /// if true and restores it when the parament is false
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="act"></param>
        public void RemoveRestoreCourse(string Name, bool act)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Course> courses = db.Courses.ToList();
                var takeCourse = from el in courses
                                 where el.Name == Name
                                 select el;
                Course course = takeCourse.FirstOrDefault();
                var delCourse = db.Courses.Find(course.CourseId);
                delCourse.IsRemoved = act;
                db.Entry(delCourse).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        

        /// <summary>
        /// This method adds teacher into a database
        /// </summary>
        /// <param name="id"></param>
        public void AddTeacher(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var teacher = db.TeacherLists.Find(id);
                db.Teachers.Add(new Teacher { Name = teacher.Name, Email = teacher.Email, Surname = teacher.Surname });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// This method removes teacher into a database
        /// </summary>
        /// <param name="id"></param>
        public void DelTeacher(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var teacher = db.TeacherLists.Find(id);
                db.TeacherLists.Remove(teacher);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// This method takes the teachersLists it is not
        /// a teachers
        /// </summary>
        /// <returns></returns>
        public List<TeacherList> GetTeacherList()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.TeacherLists.ToList();
            }
        }

        /// <summary>
        /// This method takes the list of teachers 
        /// </summary>
        /// <returns></returns>
        public List<Teacher> GetTeachers()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Teachers.ToList();
            }
        }

        /// <summary>
        /// This method takes courses with 
        /// students from our database
        /// </summary>
        /// <returns></returns>
        public List<Course> GetCoursesAndStudents()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Courses.Include(s => s.Students).ToList();
            }
        }

        /// <summary>
        /// This method takes courses with 
        /// teachers from our database
        /// </summary>
        /// <returns></returns>
        public List<Course> GetCoursesAndTeachers()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Courses.Include(t => t.Teacher).ToList();
            }
        }

        /// <summary>
        /// This method adds the teache to teacherlists
        /// </summary>
        /// <param name="model"></param>
        public void AddTeacherToList(RegisterAccount model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.TeacherLists.Add(new TeacherList { Name = model.Name, Email = model.Email, Surname = model.SurName });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// This method adds course into database
        /// </summary>
        /// <param name="course"></param>

        public void AddCourse(Course course)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// This method changes course into a database
        /// </summary>
        /// <param name="course"></param>
        public void ChangeCourse(CreateCourse course)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Course> courses = db.Courses.ToList();
                var takeCourses = from el in courses
                                  where el.Name == course.Name
                                  select el;

                Course newCourse = takeCourses.FirstOrDefault();
                List<Teacher> teachers = db.Teachers.Include(s => s.Courses).ToList();
                var teacher = from t in teachers
                              where course.TeacherEmail == t.Email
                              select t;

                Teacher newTeacher = teacher.FirstOrDefault();

                var take = db.Courses.Find(newCourse.CourseId);
                take.Name = course.Name;
                take.Text = course.Text;
                take.StartDate = course.StartDate;
                take.FinishDate = course.FinishDate;
                take.TeacherId = newTeacher.TeacherId;

                db.Entry(take).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// This method adds mark into a database
        /// </summary>
        /// <param name="mark"></param>
        public void AddMark(Mark mark)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Marks.Add(mark);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// This method deletes a mark from data base
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="studentId"></param>
        public void DelMark(int courseId, int studentId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var marks = db.Marks.ToList();
                var getIdMark = from el in marks
                                where el.StudentId == studentId
                                select el;
                if (getIdMark.Count() > 0)
                {
                    var getCourseIdMark = from el in getIdMark
                                          where el.CourseId == courseId
                                          select el;
                    if (getCourseIdMark.Count() > 0)
                    {
                        var takeMark = db.Marks.Find(getCourseIdMark.FirstOrDefault().Id);
                        db.Marks.Remove(takeMark);
                        db.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// This method gets Mark from our database
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public Mark GetMark(int courseId, int studentId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var marks = db.Marks.ToList();
                var getMark = from el in marks
                                where el.CourseId == courseId && el.StudentId == studentId
                                select el;
                if (getMark.Count() > 0)
                {
                    return getMark.FirstOrDefault();
                }
                else
                {
                    return null;
                }

            }
        }
    }
}