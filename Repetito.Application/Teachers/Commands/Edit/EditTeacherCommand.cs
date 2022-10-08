using MediatR;
using Repetito.Application.Common.Persistance;
using Repetito.Domain;
using Repetito.Domain.Entities;

namespace Repetito.Application.Teachers.Commands.Edit;

public record EditTeacherCommand : IRequest<Result>
{
    public Guid TeacherId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Subject { get; set; }
    public int? Experience { get; set; }
    public int? Age { get; set; }
}




internal class EditTeacherCommandHandler : IRequestHandler<EditTeacherCommand, Result>
{
    private readonly IGenericRepository<Teacher> _teacherRepository;
    private readonly IUnitOfWork _unitOfWork;
    public EditTeacherCommandHandler(IGenericRepository<Teacher> teacherRepository, IUnitOfWork unitOfWork)
    {
        _teacherRepository = teacherRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(EditTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetById(request.TeacherId);


        teacher.FirstName = request.FirstName ?? teacher.FirstName;
        teacher.LastName = request.LastName ?? teacher.LastName;
        teacher.Subject = request.Subject ?? teacher.Subject;
        teacher.Experience = request.Experience ?? teacher.Experience;
        teacher.Age = request.Age ?? teacher.Age;

        return await _unitOfWork.CommitAsync() ? Result.Succeed() : Result.Fail("Couldn't Save Changes");
    }
}
