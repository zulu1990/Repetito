using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Repetito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ISender _mediator;


        [Authorize]
        [HttpPost("edit-info")]
        public async Task<IActionResult> Edit()
        {
            return Ok();
        }
    }
}
