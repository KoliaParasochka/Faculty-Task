using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Faculty.Storages;
using System.Web.Mvc;
using ProjectDatabase.Models;
using Faculty.FileManage;

namespace Faculty.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        Storage storage = new Storage();
        FileManager fileManager = new FileManager();

        private void WriteToInfo(string message)
        {
            string result = DateTime.Now.ToString();
            result += "\n " + message + "\n";
            string fullPath = Server.MapPath("~/Content/Events/info.txt");
            fileManager.SaveContent(result, fullPath);
        }

        // GET: Admin
        /// <summary>
        /// This action show us a personal area
        /// of administrator
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Courses = storage.GetCoursesAndTeachers();
            ViewBag.Students = storage.GetStudents();
            ViewBag.Teachers = storage.GetTeacherList();
            ViewBag.Count = storage.GetTeacherList().Count;
            WriteToInfo("** admin: gets courses and teachers (starts method storage.GetCoursesAndTeachers())\n" +
                "gets students (starts method storage.GetStudents())\n" + "gets the list of new teachers (storage.GetTeacherList())\n" 
                + "gets a size of teacher list (starts method storage.GetTeacherList().Count) - action Index,  AdminController");
            return View();
        }

        /// <summary>
        /// This action adds new teacher into database
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddTeacher(string Id)
        {
            storage.AddTeacher(Convert.ToInt32(Id));
            storage.DelTeacher(Convert.ToInt32(Id));
            WriteToInfo("** admin: adds teacher to teachers in database (starts method storage.AddTeacher(Convert.ToInt32(Id)))\n" +
                "deletes an teacher from teacher list in database (starts method storage.DelTeacher(Convert.ToInt32(Id)))\n - action AddTeacher, AdminController");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This action removes the teacher
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelTeacher(string Id)
        {
            storage.DelTeacher(Convert.ToInt32(Id));
            WriteToInfo("** admin: deletes an teacher from teacher list in database (starts method storage.DelTeacher(Convert.ToInt32(Id)))\n - action DelTeacher,  AdminController");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This action adds new course into database
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult AddCourse()
        {
            ViewBag.Teachers = storage.GetTeachers();
            WriteToInfo("** admin: gets teachers to show it on view (starts method storage.GetTeachers()) - action AddCourse,  AdminController");
            return View();
        }

        /// <summary>
        /// This action takes our course
        /// from database and show it on the 
        /// view to change it
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        //[HttpPost]
        public ActionResult ChangeCourse(int? id)
        {
            List<Course> courses = storage.GetCoursesAndTeachers();
            var courseList = from el in courses
                             where el.CourseId == id
                             select el;
            Course course = courseList.FirstOrDefault();
            if(course != null)
            {
                ViewBag.Teachers = storage.GetTeachers();
                ViewBag.Course = course;
                CreateCourse mycourse = new CreateCourse { Name = course.Name, FinishDate = course.FinishDate, StartDate = course.StartDate, Text = course.Text, TeacherEmail = course.Teacher.Email };
                WriteToInfo("** admin: action ChangeCourse, AdminController");
                return View(mycourse);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// This action changes courses
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangeCourse(CreateCourse changeCourse)
        {
            ViewBag.IsValid = true;
            if (ModelState.IsValid && changeCourse.FinishDate > changeCourse.StartDate && changeCourse.StartDate > DateTime.Now && changeCourse.FinishDate > DateTime.Now)
            {
                storage.ChangeCourse(changeCourse);
                WriteToInfo("** admin: action ChangeCourseInList, AdminController");
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Teachers = storage.GetTeachers();
                WriteToInfo("** admin: action ChangeCourseInList, AdminController");
                ViewBag.Message = "Дата начала обучения должна быть строго больше даты завершения";
                ViewBag.IsValid = false;
                return View(changeCourse);
            }
            
        }

        /// <summary>
        /// This action blocks the student
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BlockStudent(string Name)
        {
            storage.BlockUnblockStudent(Name, true);
            WriteToInfo("** admin: action BlockStudent, AdminController");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This action unblocks the student
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UnblockStudent(string Name)
        {
            storage.BlockUnblockStudent(Name, false);
            WriteToInfo("** admin: action UnblockStudent, AdminController");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This action deletes course 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteCourse(string Name)
        {
            storage.RemoveRestoreCourse(Name, true);
            WriteToInfo("** admin: action DeleteCourse, AdminController");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This action restores course 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RestoreCourse(string Name)
        {
            storage.RemoveRestoreCourse(Name, false);
            WriteToInfo("** admin: action RestoreCourse, AdminController");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This is a second method of changing 
        /// the course it gets the result of
        /// changing and put it into ou database.
        /// </summary>
        /// <param name="createCourse"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCourseToList(CreateCourse createCourse)
        {
            if (ModelState.IsValid)
            {
                Teacher teacher = storage.GetTeacher(createCourse.TeacherEmail);
                Course course = new Course
                {
                    Name = createCourse.Name,
                    StartDate = createCourse.StartDate,
                    FinishDate = createCourse.FinishDate,
                    Text = createCourse.Text,
                    TeacherId = teacher.TeacherId
                };
                storage.AddCourse(course);
            }
            WriteToInfo("** admin: action AddCourseToList, AdminController");
            return RedirectToAction("Index");
        }
    }
}