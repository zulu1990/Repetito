using MediatR;
using Repetito.Application.Common.Persistance;
using Repetito.Application.Teachers.Models;
using Repetito.Domain;
using Repetito.Domain.Entities;
using Repetito.Domain.Enums;


namespace Repetito.Application.Teachers.Queries;

public record TeacherSearchQuery : IRequest<Result<IEnumerable<Teacher>>>
{
    public IEnumerable<City> Citis { get; init; }
    public Sex Sex { get; init; }
    public int Experience { get; init; }
    public string Subject { get; init; }
    public int MaxAge { get; init; }
    public int MinAge { get; init; }
}



internal class TeacherSearchQueryHandler : IRequestHandler<TeacherSearchQuery, Result<IEnumerable<Teacher>>>
{
    private readonly IGenericRepository<Teacher> _teacherRepository;

    public TeacherSearchQueryHandler(IGenericRepository<Teacher> teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<Result<IEnumerable<Teacher>>> Handle(TeacherSearchQuery request, CancellationToken cancellationToken)
    {
        var teachers =  await  _teacherRepository.ListAsync(x => request.Citis.Contains(x.City) && request.Sex == x.Sex && request.Experience > x.Experience && request.MaxAge >= x.Age && request.MinAge <= x.Age,
            includes: "Rating");

        return teachers.Any() ? Result<IEnumerable<Teacher>>.Succeed(teachers) : Result<IEnumerable<Teacher>>.Fail("Not Found");
    }
}
