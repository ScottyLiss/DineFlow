using DineFlow.Data;
using DineFlow.Models.UserManagement;
using DineFlow.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DineFlow.Tests.Services
{
    public class UserManagementServiceTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task UserManagementService_Should_CreateAUserCorrectly()
        {
            // Arrange
            using var dbContext = GetInMemoryDbContext();
            var service = new UserManagementService(dbContext);
            var email = "TestEmail@email.com";
            var password = "SuperSecretPassword";
            var roleId = 1;
            var locationId = 2;
            var expectedHash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password)));

            // Act
            var user = await service.CreateUserAsync(email, password, roleId, locationId);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(email, user.Email);
            Assert.NotNull(user.PasswordHash);
            Assert.Equal(roleId,user.RoleId);
            Assert.NotNull(user.Location);
            Assert.Equal(locationId, user.Location.Id);
            Assert.Equal(expectedHash, user.PasswordHash);
        }
    }
}
