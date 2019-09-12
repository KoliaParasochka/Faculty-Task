using Faculty.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Faculty.Controllers
{
    public class TestController : Controller
    {
        IStorage storage;

        public TestController()
        {
            storage = new Storage();
        }

        public TestController(IStorage stor)
        {
            storage = stor;
        }

        // GET: Test
        public ActionResult Index()
        {
            var model = storage.GetStudents();
            return View(model);
        }

        public ActionResult Teachers()
        {
            var model = storage.GetTeachers();
            return View(model);
        }

        public ActionResult CoursesAndStudents()
        {
            var model = storage.GetCoursesAndStudents();
            return View(model);
        }

        public ActionResult CoursesAndTeachers()
        {
            var model = storage.GetCoursesAndTeachers();
            return View(model);
        }

        public ActionResult TeacherList()
        {
            var model = storage.GetTeacherList();
            return View(model);
        }

        public ActionResult GetTeacher(string teststr)
        {
            var model = storage.GetTeacher(teststr);
            
            return View(model);
        }

        public ActionResult GetStudent(string teststr)
        {
            var model = storage.GetStudent(teststr);
            return View(model);
        }
    }
}