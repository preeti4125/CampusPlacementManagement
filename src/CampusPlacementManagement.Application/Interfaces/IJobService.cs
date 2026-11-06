using CampusPlacementManagement.Application.DTOs;
using CampusPlacementManagement.Core.Entities;

namespace CampusPlacementManagement.Application.Interfaces;

public interface IJobService
{
    Task<IReadOnlyList<JobOpening>> GetAllJobsAsync();
    Task<JobOpening> CreateJobAsync(CreateJobOpeningDto dto);
    Task<JobApplication> ApplyForJobAsync(ApplyJobDto dto);
}
