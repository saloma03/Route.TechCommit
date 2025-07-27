using Route.TechSummit.DTOs.UserDTOs;

namespace Route.TechSummit.Abstraction.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserCreateDto userDto);
        Task<UserDto> AuthenticateAsync(UserLoginDto loginDto);
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task UpdateUserAsync(int id, UserCreateDto userDto);
        Task DeleteUserAsync(int id);

    }
}
