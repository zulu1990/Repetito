using MediatR;
using Repetito.Application.Authentication.Common;
using Repetito.Application.Common.Authentication;
using Repetito.Application.Common.Persistance;
using Repetito.Domain;
using Repetito.Domain.Entities;

namespace Repetito.Application.Authentication.Queries.Login
{
    public record LoginQuery
    (
        string Email,
        string Password
    ) : IRequest<Result<AuthenticationResult>>;


    internal class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IPasswordHandler _passwordHandler;
        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IGenericRepository<Teacher> teacherRepository, IPasswordHandler passwordHandler)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _teacherRepository = teacherRepository;
            _passwordHandler = passwordHandler;
        }

        public async Task<Result<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var existingTeacher = await _teacherRepository.GetByExpression(x => x.Email == request.Email);

            if (existingTeacher is null)
                return Result<AuthenticationResult>.Fail("Incorrect Credentials");
            

            if (_passwordHandler.VerifyPasswordHash(request.Password, existingTeacher.PasswordHash, existingTeacher.PasswordSalt) == false)
                return Result<AuthenticationResult>.Fail("Incorrect Credentials");


            var token = _jwtTokenGenerator.GenerateToken(existingTeacher);
            return Result<AuthenticationResult>.Succeed(new AuthenticationResult(token));
        }
    }
}
