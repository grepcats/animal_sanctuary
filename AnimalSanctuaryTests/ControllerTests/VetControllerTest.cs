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
    public class VetControllerTest
    {
        Mock<IVetRepository> mock = new Mock<IVetRepository>();
        private void DbSetup()
        {
            mock.Setup(m => m.Vets).Returns(new Vet[]
            {
                new Vet {VetId = 1, Name = "Jeremiah Fink", Specialty = "Horsebonologist"},
                new Vet {VetId = 1, Name = "Bilbo Baggins", Specialty = "Holder of Eldritch Frog Knowledge"}
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_VetIndexContainsModelData_List()
        {
            //Arrange
            DbSetup();
            ViewResult indexView = new VetController(mock.Object).Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Vet>));
        }

        [TestMethod]
        public void Mock_VetGetViewResultIndex_ActionResult()
        {
            //Arrange
            DbSetup();
            VetController controller = new VetController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_VetIndexModelContainsAnimals_Collection()
        {
            //arrange
            DbSetup();
            VetController controller = new VetController(mock.Object);
            Vet testVet = new Vet();
            testVet.Name = "Jeremiah Fink";
            testVet.Specialty = "Horsebonologist";
            testVet.VetId = 1;

            //act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Vet> collection = indexView.ViewData.Model as List<Vet>;

            //assert
            CollectionAssert.Contains(collection, testVet);
        }

        [TestMethod]
        public void Mock_VetPostViewResultCreate_ViewResult()
        {
            //Arrange
            Vet testVet = new Vet
            {
                VetId = 1,
                Name = "Jeremiah Fink",
                Specialty = "Horsebonologist"
            };
            DbSetup();
            VetController controller = new VetController(mock.Object);

            //Act
            var resultView = controller.Create(testVet);
            Console.WriteLine(resultView.GetType());
            var type = resultView.GetType();

            //Assert
            Assert.IsInstanceOfType(resultView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Mock_VetGetDetails_ReturnsView()
        {
            // Arrange
            Vet testVet = new Vet();
            testVet.VetId = 1;
            testVet.Name = "Jeremiah Fink";
            testVet.Specialty = "Horsebonologist";
            DbSetup();
            VetController controller = new VetController(mock.Object);

            //Act
            var resultView = controller.Details(testVet.VetId) as ViewResult;
            var model = resultView.ViewData.Model as Vet;

            //Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
        }
    }
}
