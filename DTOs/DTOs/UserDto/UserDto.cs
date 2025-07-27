
using Route.TechSummit.Domain.Enum;

namespace Route.TechSummit.DTOs.UserDTOs

{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
    }

    public class UserUpdateDto
    {
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public string Password { get; set; } // Optional, depending on your update logic
    }

    public class UserCreateDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }

    public class UserLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
