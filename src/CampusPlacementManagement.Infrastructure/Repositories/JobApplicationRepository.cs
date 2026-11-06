using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Interfaces.Repositories;
using CampusPlacementManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CampusPlacementManagement.Infrastructure.Repositories;

public class JobApplicationRepository : GenericRepository<JobApplication>, IJobApplicationRepository
{
    public JobApplicationRepository(ApplicationDbContext context) : base(context) { }
    public async Task<bool> HasStudentAppliedAsync(int jobId, int studentId) =>
        await _dbSet.AnyAsync(a => a.JobId == jobId && a.StudentId == studentId);
}
