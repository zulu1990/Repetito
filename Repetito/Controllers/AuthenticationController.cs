using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repetito.Application.Authentication.Commands.Register;
using Repetito.Application.Authentication.Queries.Login;
using Repetito.Contracts.Authentication;

namespace Repetito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(
                request.FirstName, request.LastName, 
                request.Email, request.Password,
                request.Subject, request.Sex, request.City);
            var authenticationResult = await _mediator.Send(command);

            return authenticationResult.Success ? (ActionResult)Ok(authenticationResult.Data) : Problem(authenticationResult.ErrorMessage);
        }


        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {

            var query = new LoginQuery(request.Email, request.Password);

            var authenticationResult = await _mediator.Send(query);

            return authenticationResult.Success ? (ActionResult)Ok(authenticationResult.Data) : Problem(authenticationResult.ErrorMessage);
        }
    }
}
