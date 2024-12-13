using DineFlow.Models.UserManagement;

namespace DineFlow.Interfaces
{
    public interface IUserManagementService
    {
        Task<User> CreateUserAsync(string email, string password, int roleId, int locationId);
    }
}