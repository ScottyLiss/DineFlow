namespace DineFlow.DTOs
{
    public class CreateUserDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public int RoleId { get; set; }
        public int LocationId;
    }
}
