using Azure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReminderApp.Application.Dtos.Comment;
using ReminderApp.Application.Features.Commands.Comment.AddComment;
using ReminderApp.Application.Features.Queries.Comment.GetAllComment;
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

        [HttpGet]
        [Route("Add-Comment")]
        [Authorize]
        public async Task<IActionResult> AddComment([FromBody] AddCommentDto addCommentDto)
        {
            //AddCommentCommand addCommentCommand = new(addCommentDto);
            //bool response = await _mediatr.Send(addCommentCommand);
            //return response is true ? Ok(response) : BadRequest(response);
            return Ok();
        }

        [HttpGet]
        [Route("Get-All-Comment")]
        public async Task<IActionResult> GetAllComment()
        {
            //GetAllCommentQuery getAllComment = new();
            //List<AllCommentDto>? allCommentDto = await _mediatr.Send(getAllComment);
            //if (allCommentDto is not null && allCommentDto.Count > 0)
            //{
            //    List<byte[]> imageBytesList = allCommentDto.Select(dto => dto.Image).ToList();
            //    var imageFiles = new List<FileContentResult>();
            //}
            //return NotFound();
            return Ok();
        }
    }
}
