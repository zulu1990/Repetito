using MediatR;
using Repetito.Application.Common.Persistance;
using Repetito.Domain;
using Repetito.Domain.Entities;

namespace Repetito.Application.Organizationing.Query;

public record GetMyCalendarQuery(Guid TeacherId) : IRequest<Result<Calendar>>;



internal class GetMyCalendarQueryHandler : IRequestHandler<GetMyCalendarQuery, Result<Calendar>>
{
    private readonly IGenericRepository<Teacher> _teacherRepository;

    public GetMyCalendarQueryHandler(IGenericRepository<Teacher> teacherRepository)
    {
        _teacherRepository = teacherRepository;
        
    }


    public async Task<Result<Calendar>> Handle(GetMyCalendarQuery request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetByExpression(x=> x.Id == request.TeacherId, includes: "CalendarEntries");

        throw new NotImplementedException();
    }
}

