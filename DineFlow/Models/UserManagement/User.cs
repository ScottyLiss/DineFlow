namespace DineFlow.Models.UserManagement
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; } = new() { Id = 0, Name = RoleName.Guest };
        public Location Location { get; set; } = new() { Id = 0 };
    }
}
