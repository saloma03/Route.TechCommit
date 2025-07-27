using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.TechSummit.Abstraction.DTOs.UserDTOs;

namespace Route.TechSummit.Abstraction.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserCreateDto userDto);
        Task<UserDto> AuthenticateAsync(UserLoginDto loginDto);
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task UpdateUserAsync(int id, UserCreateDto userDto);
        Task DeleteUserAsync(int id);a
    }
}
