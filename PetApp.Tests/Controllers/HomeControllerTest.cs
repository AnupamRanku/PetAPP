using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetApp;
using PetApp.Controllers;
using PetApp.Model;
using PetApp.Common;

namespace PetApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexRetursaView()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void IndexWithNoError()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("", result.ViewBag.Error);
        }


        [TestMethod]
        public void PeopleIsNotEmpty()
        {
            PetInfo pmodel = new PetInfo();
            Assert.IsNotNull(pmodel.GetPeople());            
        }


        [TestMethod]
        public void AtleastOneCatUnderOwner()
        {
            PetInfo pmodel = new PetInfo();           
            Assert.AreNotEqual(pmodel.GetCatByGender().Count, 0);
        }


        [TestMethod]
        public void ConfirmCatNamesSorting()
        {
            PetInfo pmodel = new PetInfo();
            Dictionary<String, CatStat> catDB = pmodel.GetCatByGender();

            foreach (var catS in catDB.Values)
            {
                String allCatNames = String.Join(",", catS.CatNames);
                catS.CatNames.Sort();
                if (String.Join(",", catS.CatNames) != allCatNames){
                    Assert.Fail("Cat Name is not sorted: " + allCatNames);

                }
            }
        }
    }



}
