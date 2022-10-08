namespace Repetito.Domain.Entities
{
    public class CalendarEntry : BaseEntity
    {
        public Guid? TeacherId { get; set; }
        public Guid? PupilId { get; set; }


        public DayOfWeek Day { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
