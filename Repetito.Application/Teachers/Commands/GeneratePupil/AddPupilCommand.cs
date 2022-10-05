using MediatR;
using Repetito.Application.Common.Persistance;
using Repetito.Application.Teachers.Models;
using Repetito.Domain;
using Repetito.Domain.Entities;

namespace Repetito.Application.Teachers.Commands.GeneratePupil;

public record AddPupilCommand(
    Guid TeacherId,
    AddNewPupil Pupil
    ): IRequest<Result>;



internal class AddPulilCommandHandler : IRequestHandler<AddPupilCommand, Result>
{
    private readonly IGenericRepository<Teacher> _teachersRepository;

    public AddPulilCommandHandler(IGenericRepository<Teacher> teachersRepository)
    {
        _teachersRepository = teachersRepository;
    }

    public Task<Result> Handle(AddPupilCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}