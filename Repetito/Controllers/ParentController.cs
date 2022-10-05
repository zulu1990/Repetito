using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repetito.Application.Parents.Commands.Rating;
using Repetito.Contracts.General;

namespace Repetito.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParentController : ControllerBase
{
    private readonly ISender _mediator;

    public ParentController(ISender mediator)
    {
        _mediator = mediator;
    }


    [HttpPost("rate-teacher")]
    public async Task<IActionResult> RateTeacher(TeacherFeedback model)
    {
        var feedbackCommand = new FeedbackCommand(Guid.Parse("4097b74f-bc08-49f9-b888-c13eb78b0a70"), model.Comment, model.Rating);

        var result = await _mediator.Send(feedbackCommand);

        return Ok();
    }
}
