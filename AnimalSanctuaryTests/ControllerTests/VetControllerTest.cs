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
    class VetControllerTest
    {
        Mock<IVetRepository> mock = new Mock<IVetRepository>();
        private void DbSetup()
        {
            mock.Setup(m => m.Vets).Returns(new Vet[]
            {
                new Vet {VetId = 1, Name = "Jeremiah Fink", Specialty = "Horsebonologist"},
                new Vet {VetId = 1, Name = "Jeremiah Fink", Specialty = "Holder of Eldritch Frog Knowledge"}
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
    }
}
