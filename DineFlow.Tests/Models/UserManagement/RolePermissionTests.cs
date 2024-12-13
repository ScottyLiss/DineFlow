using DineFlow.Models.UserManagement;

namespace DineFlow.Tests.Models.UserManagement
{
    public class RolePermissionTests
    {
        [Fact]
        public void RolePermission_Should_InitializeCorrectly()
        {
            // Arrange
            var rolePermission = new RolePermission()
            {
                RoleId = 1,
                Role = new()
                {
                    Id = 1,
                    Name = RoleName.Admin
                },
                PermissionId = 2,
                Permission = new()
                {
                    Id = 2,
                    Name = "TestPermission"
                }
            };

            // Assert
            Assert.Equal(1, rolePermission.RoleId);
            Assert.Equal(1, rolePermission.Role.Id);
            Assert.Equal(RoleName.Admin, rolePermission.Role.Name);
            Assert.Equal(2, rolePermission.PermissionId);
            Assert.Equal(2, rolePermission.Permission.Id);
            Assert.Equal("TestPermission", rolePermission.Permission.Name);
        }
    }
}
