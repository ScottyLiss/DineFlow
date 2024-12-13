using DineFlow.Data;
using DineFlow.Interfaces;
using DineFlow.Models.UserManagement;
using System.Security.Cryptography;
using System.Text;

namespace DineFlow.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly AppDbContext _dbContext;

        public UserManagementService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<User> CreateUserAsync(string email, string password, int roleId, int locationId)
        {
            var user = new User
            {
                Email = email,
                PasswordHash = HashPassword(password),
                RoleId = roleId,
                Location = new Location() { Id = locationId }
            };

            await _dbContext.SaveChangesAsync();
            return user;
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
        }
    }
}
