using Repetito.Domain.Entities;
using Repetito.Domain.Enums;

namespace Repetito.Contracts.TeacherContracts;

public record TeacherProfile
{
    public TeacherProfile(Teacher teacher)
    {
        FirstName = teacher.FirstName;
        LastName = teacher.LastName;
        Email = teacher.Email;
        Sex = teacher.Sex;
        City = teacher.City;
        Subject = teacher.Subject;
        Rating = teacher.Feedbacks.Average(x => x.Rating);
        Experience = teacher.Experience;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Sex Sex { get; set; }
    public City City { get; set; }
    public string Subject { get; set; }
    public double Rating { get; set; }
    public int Experience { get; set; }
}
