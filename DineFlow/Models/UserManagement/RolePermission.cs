namespace DineFlow.Models.UserManagement
{
    public class RolePermission
    {
        public int RoleId { get; set; }
        public required Role Role { get; set; }
        public int PermissionId { get; set; }
        public required Permission Permission { get; set; }
    }
}
