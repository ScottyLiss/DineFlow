using DineFlow.Models.UserManagement;

namespace DineFlow.Tests.Models.UserManagement
{
    public class UserTests
    {
        [Fact]
        public void User_Should_InitializeCorrectly()
        {
            // Arrange 
            Guid userGuid = Guid.NewGuid();
            var user = new User() { Email = "testEmail@email.com", Id = userGuid, PasswordHash = "hashPassWord", RoleId = 1, Role = new Role() { Id = 1, Name = RoleName.User } };

            // Assert
            Assert.Equal("testEmail@email.com", user.Email);
            Assert.Equal(userGuid, user.Id);
            Assert.Equal("hashPassWord", user.PasswordHash);
            Assert.Equal(1, user.RoleId);
            Assert.NotNull(user.Role);
            Assert.Equal(0, user.Location.Id);
        }

        [Fact]
        public void User_Should_HaveDefaultRoleIfNoRoleDefined()
        {
            // Arrange 
            Guid userGuid = Guid.NewGuid();
            var user = new User() { Email = "testEmail@email.com", Id = userGuid, PasswordHash = "hashPassWord", RoleId = 1 };

            // Assert
            Assert.Equal("testEmail@email.com", user.Email);
            Assert.Equal(userGuid, user.Id);
            Assert.Equal("hashPassWord", user.PasswordHash);
            Assert.Equal(1, user.RoleId);
            Assert.Equal(0, user.Role.Id);
            Assert.Equal(RoleName.Guest, user.Role.Name);
        }

        [Fact]
        public void User_Should_HaveLocationIdSetIfProvided()
        {
            // Arrange
            Guid userGuid = Guid.NewGuid();
            var user = new User() { Email = "testEmail@email.com", Id = userGuid, PasswordHash = "hashPassWord", RoleId = 1, Location = new() { Id = 12 } };

            // Assert
            Assert.Equal("testEmail@email.com", user.Email);
            Assert.Equal(userGuid, user.Id);
            Assert.Equal("hashPassWord", user.PasswordHash);
            Assert.Equal(1, user.RoleId);
            Assert.Equal(0, user.Role.Id);
            Assert.Equal(RoleName.Guest, user.Role.Name);
            Assert.Equal(12, user.Location.Id);
        }
    }
}
