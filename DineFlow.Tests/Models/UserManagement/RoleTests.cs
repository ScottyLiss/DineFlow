using DineFlow.Models.UserManagement;

namespace DineFlow.Tests.Models.UserManagement
{
    public class RoleTests
    {
        [Fact]
        public void RoleName_Should_InitializeCorrectly()
        {
            // Arrange
            var role = new Role() { Id = 0, Name = RoleName.Guest };

            // Assert 
            Assert.Equal(0, role.Id);
            Assert.Equal(RoleName.Guest, role.Name);
        }

        [Fact]
        public void RoleName_Should_HaveAdminIfAdminAssigned()
        {
            // Arrange
            var role = new Role() { Id = 1, Name = RoleName.Admin };

            // Act & Assert 
            Assert.Equal(RoleName.Admin, role.Name);
        }

        [Fact]
        public void RoleName_Should_DefaultToGuestIfNoRoleNameProvided()
        {
            // Arrange
            var role = new Role() { Id = 1 };

            // Assert 
            Assert.Equal(RoleName.Guest, role.Name);
        }
    }
}
