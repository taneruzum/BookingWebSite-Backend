using MediatR;
using ReminderApp.Domain.Models;

namespace ReminderApp.Application.Features.Commands.User.UserImageAdd
{
    public record UserImageAddCommand(
         FileUpload FileUpload,
         string token
    ) : IRequest<bool>;
}
