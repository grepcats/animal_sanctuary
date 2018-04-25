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
        public void Mock_IndexContainsModelData_List()
        {
            //arrange
            DbSetup();
            ViewResult indexView = new AnimalController(mock.Object).Index() as ViewResult;

            //act
            var result = indexView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(List<Animal>));
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult()
        {
            //arrange
            DbSetup();
            AnimalController controller = new AnimalController(mock.Object);

            //act
            var result = controller.Index();

            //assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexModelContainsAnimals_Collection()
        {
            //arrange
            DbSetup();
            AnimalController controller = new AnimalController(mock.Object);
            Animal testAnimal = new Animal();
            testAnimal.Species = "Feline";
            testAnimal.AnimalId = 1;

            //act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Animal> collection = indexView.ViewData.Model as List<Animal>;

            //assert
            CollectionAssert.Contains(collection, testAnimal);
        }
    }
}
