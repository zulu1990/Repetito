using Repetito.Domain.Entities;

namespace Repetito.Application.Common.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Teacher teacher);
    }
}
