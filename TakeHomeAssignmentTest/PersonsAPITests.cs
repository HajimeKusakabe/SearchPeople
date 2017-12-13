using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeHomeAssignment.Models;
using Moq;
using TakeHomeAssignment.Controllers;

namespace TakeHomeAssignmentTest
{
    [TestClass]
    public class PersonsAPITests
    {
        [TestMethod]
        public void GetPersons_ShouldReturnAllPersons()
        {
            // Arrange
            var mockPersons = new Mock<IPersonApp>();
            mockPersons.Setup(x => x.GetAllPersons());
            var controller = new PersonsAPIController(mockPersons.Object);
            // Act
            controller.GetAllPersons();
            // Assert
            mockPersons.VerifyAll();
        }

        [TestMethod]
        public void GetPersons_ShouldReturnMatchedPersons()
        {
            // Arrange
            var mockPersons = new Mock<IPersonApp>();
            string input = "Steve";
            mockPersons.Setup(x => x.FindPersons(input));
            var controller = new PersonsAPIController(mockPersons.Object);
            // Act
            controller.FindPersons(input);
            // Assert
            mockPersons.VerifyAll();
        }
    }
}
