namespace Repetito.Contracts.CalendarContracts;

public record AddCalendarEntry
{
    public Guid PupilId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }

}
