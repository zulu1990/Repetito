using MediatR;
using Repetito.Application.Common.Persistance;
using Repetito.Domain;
using Repetito.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repetito.Application.Teachers.Commands.GeneratePupil
{
    public record GeneratePupilForTeacherCommand
    (
        Guid TeacherId
    ): IRequest<Result>;



    internal class GeneratePupilForTeacherCommandHandler : IRequestHandler<GeneratePupilForTeacherCommand, Result>
    {
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<Pupil> _pupilsRepository;

        private readonly IUnitOfWork _unitOfWork;

        public GeneratePupilForTeacherCommandHandler(IGenericRepository<Teacher> teacherRepository, 
            IGenericRepository<Pupil> pupilsRepository,IUnitOfWork unitOfWork)
        {
            _teacherRepository = teacherRepository;
            _pupilsRepository = pupilsRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Result> Handle(GeneratePupilForTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await Task.CompletedTask;

                var rand = new Random();


                var pupil = new Pupil
                {
                    Age = rand.Next(11, 30),
                    FirstName = "Zulu " + rand.Next(5000),
                    LastName = "Zivzi",
                    Id = Guid.NewGuid()
                };

                await _pupilsRepository.Add(pupil);

                var teacher = await _teacherRepository.GetByExpression(x => x.Id == request.TeacherId, includes: "Pupils", trackChanges: true);
                teacher.Pupils.Add(pupil);

                await _unitOfWork.CommitAsync();

            }
            catch (Exception e)
            {

                throw;
            }
            


            return Result.Succeed();
        }
    }
}
