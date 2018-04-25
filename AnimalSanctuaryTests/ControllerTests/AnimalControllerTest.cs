using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalSanctuary.Controllers;
using AnimalSanctuary.Models.Repositories;
using AnimalSanctuary.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;

namespace AnimalSanctuaryTests.ControllerTests
{
    [TestClass]
    public class AnimalControllerTest
    {
        Mock<IAnimalRepository> mock = new Mock<IAnimalRepository>();
        private void DbSetup()
        {
            mock.Setup(m => m.Animals).Returns(new Animal[]
            {
                new Animal {AnimalId = 1, Species = "Feline", Sex = "Male", HabitatType = "desert", MedicalEmergency = false },
                new Animal {AnimalId = 2, Species = "Canine", Sex = "Female", HabitatType = "living room", MedicalEmergency = true }
            }.AsQueryable());
        }

        [TestMethod]
        public void AnimalController_IndexModelContainsCorrectData_List()
        {
            //arrange
            DbSetup();
            ViewResult indexView = new AnimalController(mock.Object).Index() as ViewResult;

            //act
            var result = indexView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(List<Animal>));
        }
    }
}
