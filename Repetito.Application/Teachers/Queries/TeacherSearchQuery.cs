using MediatR;
using Repetito.Application.Common.Persistance;
using Repetito.Application.Teachers.Models;
using Repetito.Domain;
using Repetito.Domain.Entities;
using Repetito.Domain.Enums;


namespace Repetito.Application.Teachers.Queries;

public record TeacherSearchQuery : IRequest<Result<IEnumerable<TeacherProfile>>>
{
    public IEnumerable<City> Citis { get; init; }
    public Sex Sex { get; init; }
    public int Experience { get; init; }
    public string Subject { get; init; }
    public int MaxAge { get; init; }
    public int MinAge { get; init; }
}



internal class TeacherSearchQueryHandler : IRequestHandler<TeacherSearchQuery, Result<IEnumerable<TeacherProfile>>>
{
    private readonly IGenericRepository<Teacher> _teacherRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TeacherSearchQueryHandler(IUnitOfWork unitOfWork, IGenericRepository<Teacher> teacherRepository)
    {
        _unitOfWork = unitOfWork;
        _teacherRepository = teacherRepository;
    }

    public async Task<Result<IEnumerable<TeacherProfile>>> Handle(TeacherSearchQuery request, CancellationToken cancellationToken)
    {
        var teachers =  await  _teacherRepository.ListAsync(x => request.Citis.Contains(x.City) && request.Sex == x.Sex && request.Experience > x.Experience && request.MaxAge >= x.Age && request.MinAge <= x.Age,
            includes: "Rating");


        throw new NotImplementedException();
    }
}
