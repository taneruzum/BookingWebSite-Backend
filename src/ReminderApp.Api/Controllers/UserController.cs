using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Application.Dtos.User;
using ReminderApp.Application.Features.Commands.User.CreateUser;
using ReminderApp.Application.Features.Commands.User.DeleteUser;
using ReminderApp.Application.Features.Commands.User.LoginUser;
using ReminderApp.Application.Features.Queries.User.GetUserWithToken;
using ReminderApp.Application.Validations.Validate;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Models.Login;
using ReminderApp.Infrastructure.Attributes;

namespace ReminderApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ModelValidationFilter]
    [UserRequestAttributeFilter]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IJwtTokenService _jwtTokenService;
        public UserController(IMediator mediatr, IJwtTokenService jwtTokenService)
        {
            _mediatr = mediatr;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        [Route("Register-User")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            CreateUserCommand createUserCommand = new(createUserDto = createUserDto);
            bool response = await _mediatr.Send(createUserCommand);
            return response is true ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        [Route("Login-User")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDto loginUserDto)
        {
            LoginUserCommand loginUserCommand = new(loginUserDto = loginUserDto);
            var response = await _mediatr.Send(loginUserCommand);
            LoginResponse loginResponse = new() { IsSuccess = response.isSuccess, Token = response.token };
            return response.isSuccess is true ? Ok(loginResponse) : BadRequest(loginResponse);
        }

        [HttpDelete]
        [Route("Delete-User")]
        public async Task<IActionResult> DeleteUser([FromHeader] Guid id)
        {
            DeleteUserCommand deleteUserCommand = new(id);
            var response = await _mediatr.Send(deleteUserCommand);
            return response is true ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        [Route("Get-User-With-Token")]
        public async Task<IActionResult> GetUserWithToken([FromHeader] string token)
        {
            GetUserWithTokenCommand getUserWithTokenCommand = new(token);
            var response = await _mediatr.Send(getUserWithTokenCommand);
            return response is not null ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        [Route("Token-Expire-Test")]
        public async Task<IActionResult> TokenExpireTest()
        {
            return Ok("NOT SKT");
        }
    }
}
