using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Faculty.Storages;
using System.Web.Mvc;
using ProjectDatabase.Models;
using Faculty.FileManage;
using ProjectDatabase.Repositories;
using ProjectDatabase.Entities;

namespace Faculty.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        EFUnitOfWork repository;

        public AdminController()
        {
            repository = new EFUnitOfWork("DefaultConnection");
        }

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
            ViewBag.Courses = repository.Courses.GetAll();
            ViewBag.Students = repository.Students.GetAll();
            ViewBag.Teachers = repository.TeacherLists.GetAll();
            ViewBag.Count = repository.TeacherLists.GetAll().ToList().Count;
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
            TeacherList teacherList = repository.TeacherLists.Get(Convert.ToInt32(Id));
            Teacher teacher = new Teacher { Name = teacherList.Name, Email = teacherList.Email, Surname = teacherList.Surname };
            repository.Teachers.Create(teacher);
            repository.TeacherLists.Delete(teacherList.Id);
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
            repository.TeacherLists.Delete(Convert.ToInt32(Id));
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
            ViewBag.Teachers = repository.Teachers.GetAll();
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
        public ActionResult ChangeCourse(int id)
        {
            Course course = repository.Courses.GetAll().Where(c => c.CourseId == id).FirstOrDefault();
            if(course != null)
            {
                ViewBag.Teachers = repository.Teachers.GetAll();
                ViewBag.Course = course;
                CreateCourse mycourse = new CreateCourse { id = id, Name = course.Name, FinishDate = course.FinishDate, StartDate = course.StartDate, Text = course.Text, TeacherEmail = course.Teacher.Email };
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
            if (ModelState.IsValid)
            {
                Teacher teacher = repository.Teachers.Find(t => t.Courses, t => t.Email == changeCourse.TeacherEmail).FirstOrDefault();
                Course course = repository.Courses.GetAll().Where(c => c.CourseId == changeCourse.id).FirstOrDefault();
                course.Name = changeCourse.Name;
                course.StartDate = changeCourse.StartDate;
                course.FinishDate = changeCourse.FinishDate;
                course.Text = changeCourse.Text;
                course.TeacherId = teacher.TeacherId;
                repository.Courses.Update(course);
                WriteToInfo("** admin: action ChangeCourseInList, AdminController");
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Teachers = repository.Teachers.GetAll();
                WriteToInfo("** admin: action ChangeCourseInList, AdminController");
                return View(changeCourse);
            }
            
        }

        /// <summary>
        /// This action blocks the student
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BlockStudent(int id)
        {
            Student student = repository.Students.Get(id);
            student.IsBlocked = true;
            repository.Students.Update(student);
            WriteToInfo("** admin: action BlockStudent, AdminController");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This action unblocks the student
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UnblockStudent(int id)
        {
            Student student = repository.Students.Get(id);
            student.IsBlocked = false;
            repository.Students.Update(student);
            WriteToInfo("** admin: action UnblockStudent, AdminController");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This action deletes course 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteCourse(int id)
        {
            Course course = repository.Courses.Get(id);
            course.IsRemoved = true;
            repository.Courses.Update(course);
            
            WriteToInfo("** admin: action DeleteCourse, AdminController");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This action restores course 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RestoreCourse(int id)
        {
            Course course = repository.Courses.Get(id);
            course.IsRemoved = false;
            repository.Courses.Update(course);
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
                Teacher teacher = repository.Teachers.Find(t => t.Courses, t => t.Email == createCourse.TeacherEmail).FirstOrDefault();
                Course course = new Course
                {
                    Name = createCourse.Name,
                    StartDate = createCourse.StartDate,
                    FinishDate = createCourse.FinishDate,
                    Text = createCourse.Text,
                    TeacherId = teacher.TeacherId
                };
                repository.Courses.Create(course);
            }
            WriteToInfo("** admin: action AddCourseToList, AdminController");
            return RedirectToAction("Index");
        }
    }
}