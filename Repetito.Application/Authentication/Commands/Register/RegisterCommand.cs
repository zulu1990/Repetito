using MediatR;
using Repetito.Application.Authentication.Common;
using Repetito.Application.Common.Authentication;
using Repetito.Application.Common.Persistance;
using Repetito.Domain;
using Repetito.Domain.Entities;
using Repetito.Domain.Enums;

namespace Repetito.Application.Authentication.Commands.Register
{
    public record RegisterCommand
    (
       string FirstName,
       string LastName,
       string Email,
       string Password,
       string Subject,
       Sex Sex,
       City City
    ) : IRequest<Result<AuthenticationResult>>;
   

    
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHandler _passwordHandler;
        private readonly IGenericRepository<Teacher> _teachersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IPasswordHandler passwordHandler,
            IGenericRepository<Teacher> teachersRepository, IUnitOfWork unitOfWork)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHandler = passwordHandler;
            _teachersRepository = teachersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _teachersRepository.GetByExpression(x => x.Email == request.Email);

            if (existingUser is not null)
            {
                return Result<AuthenticationResult>.Fail("User Exists");
            }
            _passwordHandler.CreateSaltAndHash(request.Password, out var passwordHash, out var passwordSalt);

            var teacher = new Teacher
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Subject = request.Subject,
                Sex = request.Sex,
                City = request.City,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _teachersRepository.Add(teacher);

            await _unitOfWork.CommitAsync();

            var token = _jwtTokenGenerator.GenerateToken(teacher);

            return Result<AuthenticationResult>.Succeed(new AuthenticationResult(token));
        }
    }

}
