using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Medyana;
using Medyana.Models;
using Medyana.Controllers;

namespace Medyana.Tests.Controllers
{
    [TestClass]
    public class EquipmentControllerTest
    {
        [TestMethod]
        public void EquipmentList()
        {
            // Arrange
            EquipmentController controller = new EquipmentController();

            // Act
            List<EquipmentViewModel> result = controller.EquipmentList() as List<EquipmentViewModel>;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EquipmentCreate()
        {
            // Arrange
            EquipmentController controller = new EquipmentController();

            // Act
            int result = controller.Create(new EquipmentViewModel() { Name = "EquipmentControllerTest" });

            // Assert
            Assert.AreNotEqual(-1, result);
        }

        [TestMethod]
        public void EquipmentUpdate()
        {
            // Arrange
            EquipmentController controller = new EquipmentController();

            // Act
            int result = controller.Update(new EquipmentViewModel() { Id = 88, Name = "EquipmentControllerTest" });

            // Assert
            Assert.AreNotEqual(-1, result);
        }

        [TestMethod]
        public void EquipmentDelete()
        {
            // Arrange
            EquipmentController controller = new EquipmentController();

            // Act
            bool result = controller.Delete(88);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
