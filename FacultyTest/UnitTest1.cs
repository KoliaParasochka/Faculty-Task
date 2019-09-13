//using System;
//using System.Collections.Generic;
//using System.Web.Mvc;
//using Faculty.Controllers;
//using Faculty.Storages;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using ProjectDatabase.Models;

//namespace FacultyTest
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        Storage storage = new Storage();

//        [TestMethod]
//        public void TestMethodAbout()
//        {
//            HomeController homeController = new HomeController();
//            ViewResult result = homeController.About() as ViewResult;

//            Assert.IsNotNull(result);
//        }

//        [TestMethod]
//        public void AboutViewEqualAboutCshtml()
//        {
//            HomeController controller = new HomeController();

//            ViewResult result = controller.About() as ViewResult;

//            Assert.AreEqual("About", result.ViewName);
//        }

//        [TestMethod]
//        public void TestGetStudents()
//        {
//            var mock = new Mock<IStorage>();
//            mock.Setup(a => a.GetStudents()).Returns(new List<Student>());
//            TestController controller = new TestController(mock.Object);

//            // Act
//            ViewResult result = controller.Index() as ViewResult;

//            // Assert
//            Assert.IsNotNull(result.Model);
//        }

//        [TestMethod]
//        public void TestGetTeachers()
//        {
//            var mock = new Mock<IStorage>();
//            mock.Setup(a => a.GetTeachers()).Returns(new List<Teacher>());
//            TestController controller = new TestController(mock.Object);

//            // Act
//            ViewResult result = controller.Teachers() as ViewResult;

//            // Assert
//            Assert.IsNotNull(result.Model);
//        }

//        [TestMethod]
//        public void TestGetCoursesAndStudents()
//        {
//            var mock = new Mock<IStorage>();
//            mock.Setup(a => a.GetCoursesAndStudents()).Returns(new List<Course>());
//            TestController controller = new TestController(mock.Object);

//            // Act
//            ViewResult result = controller.CoursesAndStudents() as ViewResult;

//            // Assert
//            Assert.IsNotNull(result.Model);
//        }

//        [TestMethod]
//        public void TestGetCoursesAndTeachers()
//        {
//            var mock = new Mock<IStorage>();
//            mock.Setup(a => a.GetCoursesAndTeachers()).Returns(new List<Course>());
//            TestController controller = new TestController(mock.Object);

//            // Act
//            ViewResult result = controller.CoursesAndTeachers() as ViewResult;

//            // Assert
//            Assert.IsNotNull(result.Model);
//        }

//        [TestMethod]
//        public void TestGetTeacherList()
//        {
//            var mock = new Mock<IStorage>();
//            mock.Setup(a => a.GetTeacherList()).Returns(new List<TeacherList>());
//            TestController controller = new TestController(mock.Object);

//            // Act
//            ViewResult result = controller.TeacherList() as ViewResult;

//            // Assert
//            Assert.IsNotNull(result.Model);
//        }

//        [TestMethod]
//        public void TestGetTeacher()
//        {
//            var mock = new Mock<IStorage>();
//            mock.Setup(a => a.GetTeacher("gena2@gmail.com")).Returns(new Teacher());
//            TestController controller = new TestController(mock.Object);

//            // Act
//            ViewResult result = controller.GetTeacher("gena2@gmail.com") as ViewResult;

//            // Assert
//            Assert.IsNotNull(result.Model);
//        }

//        [TestMethod]
//        public void TestGetStudent()
//        {
            
//            var mock = new Mock<IStorage>();
//            mock.Setup(a => a.GetTeacher("myemail1@mail.ru")).Returns(new Teacher());
//            TestController controller = new TestController(mock.Object);

//            // Act
//            ViewResult result = controller.GetTeacher("myemail1@mail.ru") as ViewResult;

//            // Assert
//            Assert.IsNotNull(result.Model);
//        }
//    }
//}
