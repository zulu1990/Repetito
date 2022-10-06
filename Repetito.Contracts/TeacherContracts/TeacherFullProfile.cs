using Repetito.Contracts.General;
using Repetito.Domain.Enums;
using Repetito.Domain.Entities;

namespace Repetito.Contracts.TeacherContracts;

public record TeacherFullProfile
{
    public TeacherFullProfile(Teacher teacher)
    {

        Age = teacher.Age;
        City = teacher.City;
        Email = teacher.Email;
        Experience = teacher.Experience;
        FirstName = teacher.FirstName;
        LastName = teacher.LastName;
        Sex = teacher.Sex;
        Subject = teacher.Subject;
        Feedbacks = teacher.Feedbacks.Select(x => new FeedbackDTO { Comment = x.Comment, Rating = x.Rating });
        Pupils = teacher.Pupils.Select(x => new PupilDTO { Age = x.Age, FirstName = x.FirstName, LastName = x.LastName });
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Sex Sex { get; set; }
    public City City { get; set; }
    public string Subject { get; set; }
    public int Experience { get; set; }
    public int Age { get; set; }

    public IEnumerable<PupilDTO> Pupils { get; set; }
    public IEnumerable<FeedbackDTO> Feedbacks { get; set; }

    public double AverageRating => Feedbacks.Average(x => x.Rating);

}