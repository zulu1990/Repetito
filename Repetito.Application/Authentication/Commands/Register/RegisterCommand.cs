using MediatR;
using Repetito.Application.Authentication.Common;
using Repetito.Application.Common.Authentication;
using Repetito.Domain;

namespace Repetito.Application.Authentication.Commands.Register
{
    public record RegisterCommand
    (
       string FirstName,
       string LastName,
       string Email,
       string Password
    ) : IRequest<Result<AuthenticationResult>>;
   

    
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<Result<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
