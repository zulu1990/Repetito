using MediatR;
using Repetito.Application.Common.Persistance;
using Repetito.Domain;
using Repetito.Domain.Entities;

namespace Repetito.Application.Organizationing.Commands;

public record AddCalendarEntryCommand : IRequest<Result>
{
    public Guid TeacherId { get; set; }
    public Guid PupilId { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
}


internal class AddCalendarEntryCommandHandler : IRequestHandler<AddCalendarEntryCommand, Result>
{
    private readonly IGenericRepository<CalendarEntry> _calendarEntryRepository;
    private readonly IGenericRepository<Teacher> _teacherRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddCalendarEntryCommandHandler(IUnitOfWork unitOfWork, IGenericRepository<Teacher> teacherRepository, IGenericRepository<CalendarEntry> calendarEntryRepository)
    {
        _unitOfWork = unitOfWork;
        _teacherRepository = teacherRepository;
        _calendarEntryRepository = calendarEntryRepository;
    }

    public async Task<Result> Handle(AddCalendarEntryCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetByExpression(x => x.Id == request.TeacherId, includes: "CalendarEntries", trackChanges: true);

        var calendarEntry = new CalendarEntry()
        {
            Id = Guid.NewGuid(),
            PupilId = request.PupilId,
            TeacherId = request.TeacherId,
            Day = request.DayOfWeek,
            EndDate = request.EndTime,
            StartDate = request.StartTime
        };

        await _calendarEntryRepository.Add(calendarEntry);
        teacher.CalendarEntries.Add(calendarEntry);


        await _unitOfWork.CommitAsync();

        return Result.Succeed();
    }
}