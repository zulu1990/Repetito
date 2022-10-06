using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repetito.Application.Organizationing.Commands;
using Repetito.Application.Organizationing.Query;
using Repetito.Common;
using Repetito.Contracts.CalendarContracts;

namespace Repetito.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalendarController : ControllerBase
{
    private readonly ISender _mediator;
    public CalendarController(ISender mediator)
    {
        _mediator = mediator;
    }



    [Authorize]
    [HttpGet("my-calendar")]
    public async Task<IActionResult> GetMyCalendar()
    {
        var teacherId = HttpContext.GetUserId();

        var query = new GetMyCalendarQuery(teacherId);

        var result = await _mediator.Send(query);

        return result.Success? (ActionResult) Ok(result.Data) : BadRequest(result.ErrorMessage);
    }


    [Authorize]
    [HttpPost("add-calendar-entry")]
    public async Task<IActionResult> AddCalendarEntry(AddCalendarEntry addCalendarEntry)
    {
        var teacherId = HttpContext.GetUserId();

        var command = new AddCalendarEntryCommand
        {
            PupilId = addCalendarEntry.PupilId,
            StartTime = addCalendarEntry.StartTime,
            EndTime = addCalendarEntry.EndTime,
            DayOfWeek = addCalendarEntry.DayOfWeek,
            TeacherId = teacherId
        };

        var result = await _mediator.Send(command);

        return Ok();
    }
}
