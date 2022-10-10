using MediatR;
using Repetito.Application.Common.Persistance;
using Repetito.Domain;
using Repetito.Domain.Entities;

namespace Repetito.Application.Organizationing.Commands;

public record DeleteCalendarEntryCommand(Guid CalendarId) : IRequest<Result>;

internal class DeleteCalendarEntryCommandHandler : IRequestHandler<DeleteCalendarEntryCommand, Result>
{
    private readonly IGenericRepository<CalendarEntry> _calendarRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCalendarEntryCommandHandler(IGenericRepository<CalendarEntry> calendarRepository, IUnitOfWork unitOfWork)
    {
        _calendarRepository = calendarRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCalendarEntryCommand request, CancellationToken cancellationToken)
    {
        var deleteResult = await _calendarRepository.DeleteById(request.CalendarId);
        await _unitOfWork.CommitAsync();
        return deleteResult;

    }
}