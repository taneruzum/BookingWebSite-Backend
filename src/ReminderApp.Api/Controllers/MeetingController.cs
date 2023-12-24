using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Application.Dtos.Meeting;
using ReminderApp.Application.Features.Commands.Meeting.CreateMeeting;
using ReminderApp.Application.Features.Commands.Meeting.DisactiveMeeting;
using ReminderApp.Application.Features.Queries.Meeting.GetAllMeetings;
using ReminderApp.Application.Features.Queries.Meeting.GetMeeting;

namespace ReminderApp.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IJwtTokenService _jwtTokenService;
        public MeetingController(IMediator mediatr, IJwtTokenService jwtTokenService)
        {
            _mediatr = mediatr;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        [Route("Create-Meeting")]
        public async Task<IActionResult> CreateMeeting([FromBody] CreateMeetingDto createMeetingDto)
        {
            CreateMeetingCommand createMeetingCommand = new(createMeetingDto, _jwtTokenService.GetTokenInHeader());
            bool result = await _mediatr.Send(createMeetingCommand);
            return result is true ? Ok(true) : BadRequest(false);
        }

        [HttpGet]
        [Route("Get-Active-Meeting")]
        public async Task<IActionResult> GetMeeting()
        {
            GetMeetingQuery getMeetingQuery = new(_jwtTokenService.GetTokenInHeader());
            var response = await _mediatr.Send(getMeetingQuery);
            return response is not null ? Ok(response) : NotFound();
        }

        [HttpPut]
        [Route("Disactive-Meeting-Update")]
        public async Task<IActionResult> DisactiveMeeting([FromHeader]Guid meetingId)
        {
            DisactiveMeetingCommand disactiveMeetingCommand = new(meetingId);
            bool result = await _mediatr.Send(disactiveMeetingCommand);
            return result is true ? Ok(true) : BadRequest(false);
        }

        [HttpGet]
        [Route("Get-All-Meetings")]
        public async Task<IActionResult> GetAllMeetings()
        {
            GetAllMeetingsQuery getAllMeetingsQuery = new();
            List<GetAllMeetingDto> meetings = await _mediatr.Send(getAllMeetingsQuery);
            return meetings is not null && meetings.Count() > 0 ? Ok(meetings) : NotFound();
        }
    }
}
