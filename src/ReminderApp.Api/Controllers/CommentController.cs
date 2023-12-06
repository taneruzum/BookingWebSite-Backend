using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReminderApp.Application.Dtos.Comment;
using ReminderApp.Application.Features.Commands.Comment.AddComment;
using ReminderApp.Application.Features.Queries.Comment.GetAllComment;
using ReminderApp.Application.Features.Queries.Comment.GetAllCommentForUser;
using ReminderApp.Domain.Entities;
using ReminderApp.Infrastructure.Attributes;
using System.Collections.Generic;

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
        [Route("Add-Comment")]
        [Authorize]
        public async Task<IActionResult> AddComment([FromBody] AddCommentDto addCommentDto)
        {
            AddCommentCommand addCommentCommand = new(addCommentDto);
            bool response = await _mediatr.Send(addCommentCommand);
            return response is true ? Ok(response) : BadRequest(response);
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
