namespace DineFlow.Models.UserManagement
{
    public class Role
    {
        public required int Id { get; set; }
        public RoleName Name { get; set; } = RoleName.Guest;
    }
}
