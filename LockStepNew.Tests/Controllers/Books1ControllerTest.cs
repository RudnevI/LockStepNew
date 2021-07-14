using LockStep.Library.Domain;
using LockStepNew.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LockStepNew.Tests.Controllers
{
    [TestClass]
    public class Books1ControllerTest
    {


        [TestMethod]
        public void Index()
        {
            var controller = new Books1Controller();

            var result = controller.Index() as ViewResult;
            if (result is null)
                Assert.Fail("Empty result");
            var model = (List<Book>)result.ViewData.Model;
            if (model is null)
                Assert.Fail("Empty model");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {
            var controller = new Books1Controller();

            var result = controller.Details(1) as ViewResult;



            if (result is null) Assert.Fail("Empty result");

            var book = (Book)result.ViewData.Model;
            if (book is null) Assert.Fail("Empty model");

            

            Assert.IsNotNull(result);
        }
    }
}
