using DineFlow.Controllers;
using DineFlow.DTOs;
using DineFlow.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DineFlow.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserManagementService> _mockService;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _mockService = new Mock<IUserManagementService>();
            _controller = new UserController(_mockService.Object);
        }

        [Fact]
        public async Task UserController_Create_WithValidModelState_Should_CallServiceAndRedirect()
        {
            // arrange
            var userDto = new CreateUserDto
            {
                Email = "TestEmail@email.com",
                Password = "SuperSecretPassword",
                RoleId = 1,
                LocationId = 2
            };

            // Act
            var result = await _controller.Create(userDto);

            // Assert
            _mockService.Verify(s => s.CreateUserAsync(userDto.Email, userDto.Password, userDto.RoleId, userDto.LocationId), Times.Once());
            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("Index", redirectResult.Url);
        }

        [Fact]
        public async Task UserController_Create_WithInvalidModelState_Should_ReturnViewWithDto()
        {
            // Arrange
            var userDto = new CreateUserDto
            {
                Email = "invalid-email",
                Password = "short-pass",
                RoleId = 0,
                LocationId = 0
            };

            _controller.ModelState.AddModelError("Email", "Invalid Email");

            // Act
            var result = await _controller.Create(userDto);

            // Assert
            _mockService.Verify(s => s.CreateUserAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never());

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(userDto, viewResult.Model);
        }
    }
}
