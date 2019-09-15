using Faculty.FileManage;
using Faculty.Storages;
using Microsoft.AspNet.Identity;
using ProjectDatabase.Entities;
using ProjectDatabase.Interfaces;
using ProjectDatabase.Models;
using ProjectDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Faculty.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork database;
        FileManager fileManager = new FileManager();

        public HomeController()
        {
            database = new EFUnitOfWork("DefaultConnection");
        }

        private void WriteToInfo(string message)
        {
            string result = DateTime.Now.ToString();
            result += "\n " + message + "\n";
            string fullPath = Server.MapPath("~/Content/Events/info.txt");
            fileManager.SaveContent(result, fullPath);
        }

        /// <summary>
        /// This method changes spaces 
        /// into another symbol ('|')
        /// </summary>
        /// <returns></returns>
        private List<Course> DelSpases()
        {
            List<Course> courses = (List<Course>)database.Courses.GetAll();
            foreach (var el in courses)
            {
                el.Name = el.Name.Replace(' ', '|');
                el.Teacher.Name = el.Teacher.Name.Replace(' ', '|');
            }
            WriteToInfo("user: " + User.Identity.Name + " get courses with teachers (start th method GetCoursesAndTeachers())\n - method DelSpases, HomeController");
            return courses;
        }

        /// <summary>
        /// This action finds the count of students
        /// in course ant set it in a value CountStudents
        /// </summary>
        /// <param name="courses"></param>
        /// <returns></returns>
        private List<Course> FindCountStudents(List<Course> courses)
        {
            Storage storage = new Storage();
            List<Course> c = (List<Course>) database.Courses.GetAll(s => s.Students); /*storage.GetCoursesAndStudents();*/
            for(int i = 0;i < courses.Count; i++)
            {
                courses[i].CountStudents = storage.GetCountOfStudentsOnCourse(c[i]);
            }
            WriteToInfo("user: " + User.Identity.Name + " found the count of students on one course and save it - action Index, HomeController ");
            return courses;
        }


        /// <summary>
        /// This action show us a main page
        /// of our site
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Courses = database.Courses.GetAll();
            WriteToInfo("user: " + User.Identity.Name + " taken courses and printed it - action Index, HomeController");
            return View("Index");
        }

        /// <summary>
        /// This action sorts ascending
        /// </summary>
        /// <param name="How"></param>
        /// <returns></returns>
        private IOrderedEnumerable<Course> SortEsc(string How)
        {
            if (How == "По количеству студентов")
            {
                var courses = DelSpases();
                courses = FindCountStudents(courses);
                var sort = from t in courses
                           orderby t.CountStudents
                           select t;

                return sort;
            }
            if (How == "По имени")
            {
                var courses = DelSpases();
                courses = FindCountStudents(courses);
                var sort = from t in courses
                           orderby t.Name
                           select t;
                return sort;
            }
            if (How == "По продолжительности")
            {
                var courses = DelSpases();
                courses = FindCountStudents(courses);
                var sort = from t in courses
                           orderby t.FinishDate - t.StartDate
                           select t;
                return sort;
            }
            return null;
        }

        /// <summary>
        /// This action sorts descending
        /// </summary>
        /// <param name="How"></param>
        /// <returns></returns>
        private IOrderedEnumerable<Course> SortDesc(string How)
        {
            if (How == "По количеству студентов")
            {
                var courses = DelSpases();
                courses = FindCountStudents(courses);
                var sort = from t in courses
                           orderby t.CountStudents descending
                           select t;

                return sort;
            }
            if (How == "По имени")
            {
                var courses = DelSpases();
                courses = FindCountStudents(courses);
                var sort = from t in courses
                           orderby t.Name descending
                           select t;
                return sort;
            }
            if (How == "По продолжительности")
            {
                var courses = DelSpases();
                courses = FindCountStudents(courses);
                var sort = from t in courses
                           orderby t.FinishDate - t.StartDate descending
                           select t;
                return sort;
            }
            return null;
        }

        /// <summary>
        /// This action finds elements with
        /// given names or teacher names
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string[] How, string[] IncrOrDecr)
        {
            if (IncrOrDecr[0] == "По убыванию")
            {
                WriteToInfo("user: " + User.Identity.Name + "descenting sorting, action Index, HomeController");
                ViewBag.Courses = SortDesc(How[0]);
                return View();
            }
            else if (IncrOrDecr[0] == "По возростанию")
            {
                WriteToInfo("user: " + User.Identity.Name + " ascenting sorting - action Index, HomeController");
                ViewBag.Courses = SortEsc(How[0]);
                return View();
            }
            else
            {
                WriteToInfo("user: " + User.Identity.Name + " sorting is failed - action Index, HomeController");
                ViewBag.Courses = DelSpases();
                return View();
            }
        }


        /// <summary>
        /// This method takes courses with a given name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private Course GetCoursesWithName(string Name)
        {
            List<Course> courses = (List<Course>)database.Courses.GetAll(m => m.Students); /*storage.GetCoursesAndStudents();*/
            var course = from el in courses
                         where el.Name == Name
                         select el;
            WriteToInfo("user: " + User.Identity.Name + " get courses with name " + Name + " - method GetCoursesWithName, HomeController");
            return course.FirstOrDefault();
        }

        /// <summary>
        /// This action show us the result of our searching
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowCourses()
        {
            ViewBag.Message = "Some message";
            WriteToInfo("user: " + User.Identity.Name + " get courses - action ShowCourses, HomeController");
            return View("ShowCourses", DelSpases());
        }

        /// <summary>
        /// This action show us the result of our searching
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ShowCourses(string Name)
        {
            WriteToInfo("user: " + User.Identity.Name + " get courses with name:" + Name + " - action ShowCourses, HomeController");
            List<Course> courses = DelSpases();

            if (string.IsNullOrEmpty(Name))
            {
                return View(courses);
            }
            else
            {
                Name = Name.Replace(' ', '|');
                var names = courses.Where(a => a.Name.Contains(Name)).ToList();
                if (names.Count <= 0)
                {
                    var teachers = courses.Where(a => a.Teacher.Surname.Contains(Name)).ToList();
                    if (teachers.Count <= 0)
                    {
                        return new HttpNotFoundResult();
                    }
                    teachers = FindCountStudents(teachers);
                    return View(teachers);
                }
                names = FindCountStudents(names);
                return View(names);
            }
        }

        /// <summary>
        /// This method show us a full information 
        /// arcoding to course which we opend
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Text"></param>
        /// <param name="StartDate"></param>
        /// <param name="FinishDate"></param>
        /// <returns></returns>
        //[HttpPost]
        //public ActionResult Read(string Name, string Text, string StartDate, string FinishDate, 
        //    string TeacherSurname, string TeacherName, string countStud)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var userId = User.Identity.GetUserId();
        //        var person = storage.GetStudent(storage.GetEmail(userId));
        //        if (person != null)
        //        {
        //            ViewBag.CanRegister = true;
        //        }
        //        else
        //        {
        //            ViewBag.CanRegister = false;
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.CanRegister = true;
        //    }

        //    ViewBag.Name = Name.Replace('|', ' ');
        //    ViewBag.Content = Text;
        //    ViewBag.Teacher = TeacherName + " " + TeacherSurname;
        //    ViewBag.StartDate = StartDate;
        //    ViewBag.FinishDate = FinishDate;
        //    ViewBag.CountStud = countStud;
        //    WriteToInfo("user: " + User.Identity.Name + " opened course to be aquqinted with it - action Read, HomeController");
        //    return View();
        //}

        [HttpPost]
        public ActionResult Read(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var person = database.Students.Find(s => s.Courses, s => s.Email == User.Identity.Name);
                if (person != null)
                {
                    ViewBag.CanRegister = true;
                }
                else
                {
                    ViewBag.CanRegister = false;
                }
            }
            else
            {
                ViewBag.CanRegister = true;
            }
            Course course = database.Courses.Find(p => p.Students, p => p.CourseId == id).First();
            ViewBag.CountStud = course.Students.Count;
            ViewBag.Course = database.Courses.Get(id);
            WriteToInfo("user: " + User.Identity.Name + " opened course to be aquqinted with it - action Read, HomeController");
            return View();
        }

        /// <summary>
        /// This action help ou to register on the courses
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult Registration(int id)
        {
            Course course = database.Courses.Get(id);
            Student student = database.Students.Find(s => s.Courses, s => s.Email == User.Identity.Name).First();
            student.Courses.Add(course);
            database.Students.Update(student);
            //WriteToInfo("user: " + User.Identity.Name + " was regirstrated on course '" + Name + "' - action Registration, HomeController");
            return Redirect("Index");
        }


        /// <summary>
        /// This action show us the information about our faculty
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ////WriteToInfo("user: " + User.Identity.Name + " opened the view About - action About, HomeController ");
            return View("About");
        }
    }
}