using MediatR;
using Repetito.Application.Common.Persistance;
using Repetito.Domain;
using Repetito.Domain.Entities;

namespace Repetito.Application.Parents.Commands.Rating;

public record FeedbackCommand
(
    Guid TeacherId,
    string Comment,
    int Rating
) : IRequest<Result>;



internal class FeedbackCommandHandler : IRequestHandler<FeedbackCommand, Result>
{
    private readonly IGenericRepository<Teacher> _teacherRepository;
    private readonly IGenericRepository<Feedback> _feedbackRepository;
    private readonly IUnitOfWork _unitOfWork;

    public FeedbackCommandHandler(IGenericRepository<Teacher> teacherRepository, IGenericRepository<Feedback> feedbackRepository, IUnitOfWork unitOfWork)
    {
        _teacherRepository = teacherRepository;
        _feedbackRepository = feedbackRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(FeedbackCommand request, CancellationToken cancellationToken)
    {
        try
        {
            
            var teacher = await _teacherRepository.GetById(request.TeacherId);

            if (teacher == null)
                return Result.Fail("Not Found");

            var feedback = new Feedback
            {
                TeacherId = request.TeacherId,
                Rating = request.Rating,
                Comment = request.Comment,
            };

            await _feedbackRepository.Add(feedback);

            teacher.Feedbacks.Add(feedback);

            await _unitOfWork.CommitAsync();

            return Result.Succeed();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Result.Fail("Cant Proceed");
        }
       
    }
}