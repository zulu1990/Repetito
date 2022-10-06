using MediatR;
using Repetito.Application.Common.Persistance;
using Repetito.Domain;
using Repetito.Domain.Entities;

namespace Repetito.Application.Teachers.Queries;

public record GetProfileQuery(Guid TeacherId) : IRequest<Result<Teacher>>;


internal class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, Result<Teacher>>
{
    private readonly IGenericRepository<Teacher> _teacherRepository;

    public GetProfileQueryHandler(IGenericRepository<Teacher> teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<Result<Teacher>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetByExpression(x=> x.Id == request.TeacherId, includes: "Pupils, Feedbacks");

        return teacher is null ? Result<Teacher>.Fail("Not Found") : Result<Teacher>.Succeed(teacher);
    }
}
