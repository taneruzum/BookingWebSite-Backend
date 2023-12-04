using AutoMapper;
using ReminderApp.Application.Dtos.Comment;
using ReminderApp.Application.Features.Commands.Comment.AddComment;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Application.Mappers
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<AddCommentCommand, AddCommentDto>().ReverseMap();
            CreateMap<Comment, AddCommentDto>().ReverseMap();
        }
    }
}
