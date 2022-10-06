namespace Repetito.Domain.Entities
{
    public class Calendar : BaseEntity
    {
        public Guid? TeacherId { get; set; }
        public Guid? PupilId { get; set; }

        public ICollection<CalendarEntry> CalendarEntries { get; set; }
    }



    public class CalendarEntry : BaseEntity
    {
        public Guid CalendarId { get; set; }

        public DayOfWeek Day { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
