using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repetito.Application.Teachers.Commands.GeneratePupil;
using Repetito.Application.Teachers.Models;
using Repetito.Application.Teachers.Queries;
using Repetito.Common;
using Repetito.Contracts.Teacher;



//TO-DO CHECK ON SUCCESS FALSE 

namespace Repetito.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly ISender _mediator;

    public TeacherController(ISender mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpPost("edit-info")]
    public async Task<IActionResult> Edit()
    {
        var teacherId = HttpContext.GetUserId();

        return Ok();
    }

    [Authorize]
    [HttpPost("add-pupil")]
    public async Task<IActionResult> AddPupil(AddPupilModel addPupilModel)
    {
        var teacherId = HttpContext.GetUserId();
        var addPupilCommand = new AddPupilCommand(teacherId, new AddNewPupil(addPupilModel.FirstName, addPupilModel.LastName, addPupilModel.Age));

        var result = await _mediator.Send(addPupilCommand);

        return Ok();
    }

    [Authorize]
    [HttpPost("generate-pupils")]
    public async Task<IActionResult> TempPupilCreation()
    {
        var teacherId = HttpContext.GetUserId();
        var command = new GeneratePupilForTeacherCommand(teacherId);

        await _mediator.Send(command);


        return Ok();
    }

    [Authorize]
    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var teacherId = HttpContext.GetUserId();

        var query = new GetProfileQuery(teacherId);

        var response = await _mediator.Send(query);

        return Ok(response);

    }



    [HttpGet("get-teachers")]
    public async Task<IActionResult> GetTeachers(TeacherSearchParams teacherSearchParams)
    {
        var teacherSeachQuery = new TeacherSearchQuery()
        {
            Citis = teacherSearchParams.Citis, 
            Sex = teacherSearchParams.Sex, 
            Experience =teacherSearchParams.Experience, 
            Subject = teacherSearchParams.Subject, 
            MaxAge = teacherSearchParams.MaxAge,
            MinAge = teacherSearchParams.MinAge
        };



        var response = await _mediator.Send(teacherSeachQuery);
        return Ok(response.Data);
    }
}
