using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Route.TechSummit.Abstraction.DTOs.UserDTOs;
using Route.TechSummit.Abstraction.Services;
using Route.TechSummit.Controllers.Controllers.Base;

namespace Route.TechSummit.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userDto)
        {
            var user = await _userService.CreateUserAsync(userDto);
            return HandleResult(user, System.Net.HttpStatusCode.Created);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var user = await _userService.AuthenticateAsync(loginDto);
            return HandleResult(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return HandleResult(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return HandleResult(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserCreateDto userDto)
        {
            await _userService.UpdateUserAsync(id, userDto);
            return HandleResult(null, System.Net.HttpStatusCode.NoContent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(    int id)
        {
            await _userService.DeleteUserAsync(id);
            return HandleResult(null, System.Net.HttpStatusCode.NoContent);
        }
    }
}
