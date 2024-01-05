using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Application.Dtos.Meeting;
using ReminderApp.Application.Features.Commands.Meeting.AddVoteForMeeting;
using ReminderApp.Application.Features.Commands.Meeting.CreateMeeting;
using ReminderApp.Application.Features.Commands.Meeting.DisactiveMeeting;
using ReminderApp.Application.Features.Queries.Meeting.GetAllMeetings;
using ReminderApp.Application.Features.Queries.Meeting.GetMeeting;
using ReminderApp.Application.Features.Queries.Meeting.GetMeetingNotification;
using ReminderApp.Application.Features.Queries.Meeting.GetSingleMeetingForUser;

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

        [HttpGet]
        [Route("Get-Personality-Meeting-Notification")]
        public async Task<IActionResult> GetPersonalityMeetingNotification()
        {
            GetPersonalityMeetingNotificationQuery getPersonalityMeetingNotification = new();
            List<AllPersonalNotificationDto> allPersonalNotifications = await _mediatr.Send(getPersonalityMeetingNotification);
            return allPersonalNotifications is not null && allPersonalNotifications.Count() > 0 ? Ok(allPersonalNotifications) : NotFound();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Add-Vote-For-Meeting")]
        public async Task<IActionResult> AddVoteForMeeting([FromBody] VoteForMeetingDto voteForMeetingDto)
        {
            AddVoteForMeetingCommand addVoteForMeetingCommand = new(voteForMeetingDto);
            bool response = await _mediatr.Send(addVoteForMeetingCommand);
            return response is true ? Ok(true) : BadRequest(false);
        }

        [HttpGet]
        [Route("Get-Single-Meeting-For-User")]
        public async Task<IActionResult> GetSingleMeetingForUser([FromHeader]Guid meetingId)
        {
            GetSingleMeetingForUserQuery getSingleMeetingForUser = new(meetingId);
            var response = await _mediatr.Send(getSingleMeetingForUser);
            return response is not null ? Ok(response) : NotFound();
        }
    }
}
