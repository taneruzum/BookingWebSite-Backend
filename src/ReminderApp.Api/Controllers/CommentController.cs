using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReminderApp.Application.Dtos.Comment;
using ReminderApp.Application.Features.Commands.Comment.AddComment;
using ReminderApp.Application.Features.Commands.Comment.CreateComment;
using ReminderApp.Application.Features.Commands.Comment.UpdateComment;
using ReminderApp.Application.Features.Queries.Comment.GetAllComment;
using ReminderApp.Application.Features.Queries.Comment.GetAllCommentForUser;
using ReminderApp.Infrastructure.Attributes;

namespace ReminderApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UserRequestAttributeFilter]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CommentController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        [Route("Create-Comment")]
        [Authorize]
        public async Task<IActionResult> CreateComment([FromBody] AddCommentDto addCommentDto)
        {
            CreateCommentCommand createComment = new(addCommentDto.Email, addCommentDto.Comment, addCommentDto.Star);
            bool result = await _mediatr.Send(createComment);
            return result is true ? Ok(result) : BadRequest(false);
        }

        [HttpPost]
        [Route("Update-Comment")]
        [Authorize]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDto updateCommentDto)
        {
            UpdateCommentCommand updateComment = new(updateCommentDto.Email, updateCommentDto.Comment, updateCommentDto.Star);
            bool result = await _mediatr.Send(updateComment);
            return result is true ? Ok(result) : BadRequest(false);
        }

        [HttpGet]
        [Route("Get-All-Comment-For-User")]
        public async Task<IActionResult> GetAllCommentForUser()
        {
            GetAllCommentForUserQuery getAllComment = new();
            List<AllCommentDto>? allCommentDto = await _mediatr.Send(getAllComment);
            return allCommentDto is not null && allCommentDto.Count() > 0 ? Ok(allCommentDto) : NotFound(null);
        }

        [HttpGet]
        [Route("Get-All-Comment")]
        public async Task<IActionResult> GetAllComment()
        {
            GetAllCommentQuery getAllComment = new();
            List<AllCommentDto>? comments = await _mediatr.Send(getAllComment);
            return comments is not null ? Ok(comments) : NotFound(null);
        }
    }
}
