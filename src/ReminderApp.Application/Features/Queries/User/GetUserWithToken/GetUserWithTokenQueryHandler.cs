using MediatR;
using ReminderApp.Application.Abstractions.Services;

namespace ReminderApp.Application.Features.Queries.User.GetUserWithToken
{
    public class GetUserWithTokenQueryHandler : IRequestHandler<GetUserWithTokenQuery, Domain.Entities.User>
    {
        private readonly IJwtTokenService _jwtTokenService;

        public GetUserWithTokenQueryHandler(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        public async Task<Domain.Entities.User> Handle(GetUserWithTokenQuery request, CancellationToken cancellationToken)
        {
            return await _jwtTokenService.GetUserWithTokenAsync(request.token);

        }
    }
}
