using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalSanctuary.Controllers;
using AnimalSanctuary.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimalSanctuaryTests.ControllerTests
{
    [TestClass]
    public class AnimalControllerTest
    {

        [TestMethod]
        public void AnimalController_IndexModelContainsCorrectData_List()
        {
            //arrange
            AnimalController controller = new AnimalController();
            IActionResult actionResult = controller.Index();
            ViewResult indexView = controller.Index() as ViewResult;

            //act
            var result = indexView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(List<Animal>));
        }
    }
}
