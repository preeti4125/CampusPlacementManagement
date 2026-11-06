using CampusPlacementManagement.Core.Entities;

namespace CampusPlacementManagement.Core.Interfaces.Repositories;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<bool> HasStudentAppliedAsync(int jobId, int studentId);
}
