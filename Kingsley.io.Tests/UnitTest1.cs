using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kingsley.io.Controllers;
using System.Web.Mvc;

namespace Kingsley.io.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FooActionReturnsAboutView()
        {
            var homeController = new HomeController();
            var result = homeController.Foo() as ViewResult;
            Assert.AreEqual("About", result.ViewName);
        }

        [TestMethod]
        public void ContactFormReturnsResult()
        {
            var homeController = new HomeController();
            var result = homeController._Contact() as ViewResult;
            //Assert.IsNotNull(result.ViewBag.TheMessage);
        }
    }
}
