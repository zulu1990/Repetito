using MediatR;
using Repetito.Application.Common.Persistance;
using Repetito.Domain;
using Repetito.Domain.Entities;

namespace Repetito.Application.Organizationing.Query;

public record GetMyCalendarQuery(Guid TeacherId) : IRequest<Result<Calendar>>;



internal class GetMyCalendarQueryHandler : IRequestHandler<GetMyCalendarQuery, Result<Calendar>>
{
    private readonly IGenericRepository<Teacher> _teacherRepository;
    private readonly IGenericRepository<Calendar> _calendarRepository;

    public GetMyCalendarQueryHandler(IGenericRepository<Teacher> teacherRepository, IGenericRepository<Calendar> calendarRepository)
    {
        _teacherRepository = teacherRepository;
        _calendarRepository = calendarRepository;
    }


    public async Task<Result<Calendar>> Handle(GetMyCalendarQuery request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetByExpression(x=> x.Id == request.TeacherId);
        var calendar = await _calendarRepository.GetByExpression(x => x.TeacherId == request.TeacherId, includes: "CalendarEntries");

        throw new NotImplementedException();
    }
}

