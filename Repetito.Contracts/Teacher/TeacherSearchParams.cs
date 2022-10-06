using Repetito.Domain.Enums;

namespace Repetito.Contracts.Teacher;

public record TeacherSearchParams
{
    public IEnumerable<City> Citis { get; init; }
    public Sex Sex { get; init; }
    public string Subject { get; init; }
    public int MinAge { get; init; }
    public int MaxAge { get; init; }
    public int Experience { get; init; }
}
