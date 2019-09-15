using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Faculty.Controllers;
using Faculty.Storages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectDatabase.Models;

namespace FacultyTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethodAbout()
        {
            HomeController homeController = new HomeController();
            ViewResult result = homeController.About() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AboutViewEqualAboutCshtml()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.About() as ViewResult;

            Assert.AreEqual("About", result.ViewName);
        }   
    }
}
