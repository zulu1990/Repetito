namespace Repetito.Contracts.CalendarContracts;

public record CalendarEntryDto(
    string StartDate,
    string EndDate,
    Guid? PupilId
);
