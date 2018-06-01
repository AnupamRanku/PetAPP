using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetApp;
using PetApp.Controllers;
using PetApp.Model;

namespace PetApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void AboutError()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("", result.ViewBag.Error);
        }


        [TestMethod]
        public void People()
        {
            PetInfo pmodel = new PetInfo();
            Assert.IsNotNull(pmodel.GetPeople());            
        }


        [TestMethod]
        public void CatDBModel()
        {
            PetInfo pmodel = new PetInfo();           
            Assert.AreNotEqual(pmodel.GetCatByGender().Count, 0);
        }


        
    }
}
