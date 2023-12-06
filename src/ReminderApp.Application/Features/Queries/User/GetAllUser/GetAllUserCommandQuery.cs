using AutoMapper;
using MediatR;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Dtos.User;

namespace ReminderApp.Application.Features.Queries.User.GetAllUser
{
    public class GetAllUserCommandQuery : IRequestHandler<GetAllUserQuery, List<AllUserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUserCommandQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AllUserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            => _mapper.Map<List<AllUserDto>>(await _unitOfWork.GetReadRepository<Domain.Entities.User>().GetAllAsync());
    }
}
