using MediatR;
using Repetito.Application.Common.Persistance;
using Repetito.Domain;
using Repetito.Domain.Entities;

namespace Repetito.Application.Organizationing.Commands;

public record AddCalendarEntryCommand : IRequest<Result>
{
    public Guid TeacherId { get; set; }
    public Guid PupilId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
}


internal class AddCalendarEntryCommandHandler : IRequestHandler<AddCalendarEntryCommand, Result>
{
    private readonly IGenericRepository<Calendar> _calendarRepository;
    private readonly IGenericRepository<CalendarEntry> _calendarEntryRepository;
    private readonly IGenericRepository<Teacher> _teacherRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddCalendarEntryCommandHandler(IUnitOfWork unitOfWork, IGenericRepository<Teacher> teacherRepository, IGenericRepository<CalendarEntry> calendarEntryRepository, IGenericRepository<Calendar> calendarRepository)
    {
        _unitOfWork = unitOfWork;
        _teacherRepository = teacherRepository;
        _calendarEntryRepository = calendarEntryRepository;
        _calendarRepository = calendarRepository;
    }

    public async Task<Result> Handle(AddCalendarEntryCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetByExpression(x => x.Id == request.TeacherId, includes: "Calendar", trackChanges: true);

        var newCalendar = teacher.Calendar == null;

        if(newCalendar)
        {
            teacher.Calendar = new Calendar()
            {
                Id = Guid.NewGuid(),
                TeacherId = teacher.Id,
                CalendarEntries = new List<CalendarEntry>(),
                PupilId = request.PupilId
            };
        }

        var calendarEntry = new CalendarEntry()
        {
            Id = Guid.NewGuid(),
            CalendarId = teacher.Calendar.Id,
            Day = request.DayOfWeek,
            EndDate = request.EndTime,
            StartDate = request.StartTime
        };

        await _calendarEntryRepository.Add(calendarEntry);

        if (newCalendar)
            await _calendarRepository.Add(teacher.Calendar);

        teacher.Calendar.CalendarEntries.Add(calendarEntry);


        await _unitOfWork.CommitAsync();

        return Result.Succeed();
    }
}