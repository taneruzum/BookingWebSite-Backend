using MediatR;
using ReminderApp.Application.Abstractions.Services;

namespace ReminderApp.Application.Features.Queries.User.GetUserWithToken
{
    public class GetUserWithTokenCommandHandler : IRequestHandler<GetUserWithTokenCommand, Domain.Entities.User>
    {
        private readonly IJwtTokenService _jwtTokenService;

        public GetUserWithTokenCommandHandler(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        public async Task<Domain.Entities.User> Handle(GetUserWithTokenCommand request, CancellationToken cancellationToken)
        {
            return await _jwtTokenService.GetUserWithTokenAsync(request.token);

        }
    }
}
