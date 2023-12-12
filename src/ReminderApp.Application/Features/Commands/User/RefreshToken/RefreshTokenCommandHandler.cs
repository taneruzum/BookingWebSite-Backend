using MediatR;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Models;

namespace ReminderApp.Application.Features.Commands.User.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Token>
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenService _jwtTokenService;

        public RefreshTokenCommandHandler(IUserService userService, IJwtTokenService jwtTokenService)
        {
            _userService = userService;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<Token> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var dbResponse = await _jwtTokenService.GetUserWithTokenAsync(request.token);
            return await _userService.RefreshTokenLoginAsync(dbResponse.RefreshToken);
        }
    }
}
