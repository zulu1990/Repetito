using MediatR;
using Repetito.Application.Authentication.Common;
using Repetito.Application.Common.Authentication;
using Repetito.Application.Common.Persistance;
using Repetito.Domain;
using Repetito.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repetito.Application.Authentication.Queries.Login
{
    public class LoginQuery : IRequest<Result<AuthenticationResult>>
    {
        public string Token { get; set; }
    }


    public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IGenericRepository<Teacher> _teacherRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IGenericRepository<Teacher> teacherRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _teacherRepository = teacherRepository;
        }

        public async Task<Result<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //var token = _jwtTokenGenerator.GenerateToken(Guid.Empty, "", "");
            return Result<AuthenticationResult>.Succeed(new AuthenticationResult(""));

        }
    }
}
