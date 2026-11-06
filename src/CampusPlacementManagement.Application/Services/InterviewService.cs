using CampusPlacementManagement.Application.DTOs.Interviews;
using CampusPlacementManagement.Application.Interfaces;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Enums;
using CampusPlacementManagement.Core.Interfaces.Repositories;
namespace CampusPlacementManagement.Application.Services;
public class InterviewService : IInterviewService
{
    private readonly IInterviewRepository _repo;
    private readonly IUnitOfWork _unitOfWork;
    public InterviewService(IInterviewRepository repo, IUnitOfWork unitOfWork) { _repo = repo; _unitOfWork = unitOfWork; }
    public async Task<IReadOnlyList<InterviewSchedule>> GetSchedulesAsync() => await _repo.GetAllAsync();
    public async Task<InterviewSchedule> ScheduleAsync(ScheduleInterviewDto dto)
    {
        var s = new InterviewSchedule { ApplicationId = dto.ApplicationId, RoundId = dto.RoundId, ScheduledAt = dto.ScheduledAt, MeetingLinkOrVenue = dto.MeetingLinkOrVenue, Feedback = dto.Feedback, Status = InterviewStatus.Scheduled };
        await _repo.AddAsync(s);
        await _unitOfWork.CompleteAsync();
        return s;
    }
}
