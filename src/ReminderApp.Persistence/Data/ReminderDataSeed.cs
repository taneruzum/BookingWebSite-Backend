using MediatR;
using Microsoft.EntityFrameworkCore;
using ReminderApp.Application.Dtos.User;
using ReminderApp.Application.Features.Commands.User.CreateUser;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Persistence.Data
{
    public class ReminderDataSeed
    {
        private readonly IMediator _mediator;
        private readonly DbContext _dbContext;

        public ReminderDataSeed(IMediator mediator, DbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (!_dbContext.Set<User>().Any())
            {
                CreateUserDto createUserDtoTaner = new() { Email = "taner@gmail.com",Password = "taner123"};
                CreateUserDto createUserDtoUgur = new() { Email = "ugur@gmail.com",Password = "ugur123"};

                CreateUserCommand createUserCommandTaner = new(createUserDtoTaner);
                CreateUserCommand createUserCommandUgur = new(createUserDtoUgur);

                List<CreateUserCommand> createUserCommands = new();
                
                createUserCommands.Add(createUserCommandTaner);
                createUserCommands.Add(createUserCommandUgur);

                foreach (var createUserCommand in createUserCommands)
                {
                    await _mediator.Send(createUserCommand);
                }
            }
        }
    }
}
