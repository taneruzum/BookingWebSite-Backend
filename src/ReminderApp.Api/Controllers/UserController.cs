using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Application.Dtos.User;
using ReminderApp.Application.Features.Commands.User.CreateUser;
using ReminderApp.Application.Features.Commands.User.DeleteUser;
using ReminderApp.Application.Features.Commands.User.LoginUser;
using ReminderApp.Application.Features.Commands.User.RefreshToken;
using ReminderApp.Application.Features.Commands.User.UserImageAdd;
using ReminderApp.Application.Features.Queries.User.GetAllUser;
using ReminderApp.Application.Features.Queries.User.GetUserWithToken;
using ReminderApp.Application.Features.Queries.User.UserImageGet;
using ReminderApp.Application.Validations.Validate;
using ReminderApp.Domain.Models;
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
        private IJwtTokenService _jwtTokenService;
        private readonly IImageService _imageService;
        public UserController(IMediator mediatr, IJwtTokenService jwtTokenService, IImageService imageService)
        {
            _mediatr = mediatr;
            _jwtTokenService = jwtTokenService;
            _imageService = imageService;
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
            LoginResponse loginResponse = new() { IsSuccess = response.isSuccess, Token = response.token, UserId = response.userId };
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
        [Route("Get-All-User")]
        public async Task<IActionResult> GetAllUser()
        {
            GetAllUserQuery getAllUserQuery = new();
            List<AllUserDto> allUserDtos = await _mediatr.Send(getAllUserQuery);
            return allUserDtos is not null ? Ok(allUserDtos) : NotFound(null);
        }

        [HttpGet]
        [Route("Get-User-With-Token")]
        public async Task<IActionResult> GetUserWithToken([FromHeader] string token)
        {
            GetUserWithTokenQuery getUserWithTokenCommand = new(token);
            var response = await _mediatr.Send(getUserWithTokenCommand);
            return response is not null ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        [Route("Refresh-Token")]
        public async Task<IActionResult> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand refreshTokenCommand = new(token);
            var response = await _mediatr.Send(refreshTokenCommand);
            if (response is null)
                return BadRequest(default);
            LoginResponse loginResponse = new() { IsSuccess = response.AccessToken is null ? false : true, Token = response.AccessToken ?? null };
            return response is not null ? Ok(loginResponse) : BadRequest(loginResponse);
        }

        [HttpPost]
        [Authorize]
        [Route("User-Image-Add")]
        public async Task<IActionResult> UserImageAdd([FromForm] FileUpload fileUpload)
        {
            UserImageAddCommand imageAddCommand = new(fileUpload, _jwtTokenService.GetTokenInHeader());
            bool dbResponse = await _mediatr.Send(imageAddCommand);
            return dbResponse is true ? Ok(dbResponse) : BadRequest(dbResponse);
        }

        [HttpGet]
        [Authorize]
        [Route("User-Image-Get")]
        public async Task<IActionResult> UserImageGet()
        {
            UserImageGetQuery imageGetQuery = new(_jwtTokenService.GetTokenInHeader());
            var response = await _mediatr.Send(imageGetQuery);
            return File(response.Photo, $"{response.FileType}/{response.ContentType}");
        }

        [HttpPost]
        [Route("Image-Add")]
        public async Task<IActionResult> ImageAdd([FromForm] FileUpload fileUpload)
        {
            return Ok(await _imageService.AddImageAsync(fileUpload));
        }
    }
}
