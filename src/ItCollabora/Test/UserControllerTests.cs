using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ItCollabora.Controllers;
using ItCollabora.Models;
using ItCollabora.Repository.Interfaces;

namespace ItCollabora.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly UserController _userController;

        public UserControllerTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userController = new UserController(_mockUserRepository.Object);
        }

        [TestMethod]
        public async Task GetOne_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new UserModel { UserId = userId, Name = "John Doe", Email = "john@example.com", EncryptedPassword = "hashedpassword" };
            _mockUserRepository.Setup(repo => repo.GetOne(userId)).ReturnsAsync(user);

            // Act
            var result = await _userController.GetOne(userId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateUser_ReturnsOkResult()
        {
            // Arrange
            var userToCreate = new UserModel { Name = "Jane Doe", Email = "jane@example.com", EncryptedPassword = "hashedpassword" };
            _mockUserRepository.Setup(repo => repo.CreateOne(It.IsAny<UserModel>())).ReturnsAsync(userToCreate);

            // Act
            var result = await _userController.CreateUser(userToCreate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        // Similar tests for UpdateUser and DeleteUser can be added.
    }
}
