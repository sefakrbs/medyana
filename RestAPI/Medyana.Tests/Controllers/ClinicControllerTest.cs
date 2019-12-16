using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Medyana;
using Medyana.Controllers;
using Medyana.Models;

namespace Medyana.Tests.Controllers
{
    [TestClass]
    public class ClinicControllerTest
    {
        [TestMethod]
        public void ClinicList()
        {
            // Arrange
            ClinicController controller = new ClinicController();

            // Act
            List<ClinicViewModel> result = controller.ClinicList() as List<ClinicViewModel>;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ClinicCreate()
        {
            // Arrange
            ClinicController controller = new ClinicController();

            // Act
            int result = controller.Create(new ClinicViewModel() { Name = "ClinicControllerTest" });

            // Assert
            Assert.AreNotEqual(-1, result);
        }

        [TestMethod]
        public void ClinicUpdate()
        {
            // Arrange
            ClinicController controller = new ClinicController();

            // Act
            int result = controller.Update(new ClinicViewModel() { Id = 88, Name = "ClinicControllerTest" });

            // Assert
            Assert.AreNotEqual(-1, result);
        }

        [TestMethod]
        public void ClinicDelete()
        {
            // Arrange
            ClinicController controller = new ClinicController();

            // Act
            bool result = controller.Delete(88);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
