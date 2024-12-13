using DineFlow.Models.UserManagement;

namespace DineFlow.Tests.Models.UserManagement
{
    public class PermissionTests
    {
        [Fact]
        public void Permissions_Should_InitializeCorrectly()
        {
            // Arrange
            var permission = new Permission() { Id = 0, Name = "TestPermission" };

            // Assert
            Assert.Equal(0, permission.Id);
            Assert.Equal("TestPermission", permission.Name);
        }
    }
}
