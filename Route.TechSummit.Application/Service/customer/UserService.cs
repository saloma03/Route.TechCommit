using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.TechSummit.Abstraction.Services;
using Route.TechSummit.DTOs.UserDTOs;

namespace Route.TechSummit.Application.Service.customer
{
    internal class UserService : IUserService
    {
        public Task<UserDto> AuthenticateAsync(UserLoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> CreateUserAsync(UserCreateDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(int id, UserCreateDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
