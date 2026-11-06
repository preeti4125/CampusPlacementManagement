using CampusPlacementManagement.Application.DTOs.Interviews;
using CampusPlacementManagement.Core.Entities;
namespace CampusPlacementManagement.Application.Interfaces;
public interface IInterviewService
{
    Task<InterviewSchedule> ScheduleAsync(ScheduleInterviewDto dto);
    Task<IReadOnlyList<InterviewSchedule>> GetSchedulesAsync();
}
