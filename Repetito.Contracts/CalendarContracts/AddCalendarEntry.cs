using System.ComponentModel.DataAnnotations;

namespace Repetito.Contracts.CalendarContracts;

public record AddCalendarEntry
{
    public Guid PupilId { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
}
