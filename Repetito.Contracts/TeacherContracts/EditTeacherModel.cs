namespace Repetito.Contracts.TeacherContracts;

public record EditTeacherModel
(
    string? FirstName,
    string? LastName,
    string? Subject,
    int? Experience,
    int? Age
);
