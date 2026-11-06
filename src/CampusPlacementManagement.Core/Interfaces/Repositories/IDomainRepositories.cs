using CampusPlacementManagement.Core.Entities;

namespace CampusPlacementManagement.Core.Interfaces.Repositories;

public interface ICollegeRepository : IGenericRepository<College>
{
    Task<College?> GetByCodeAsync(string collegeCode);
}

public interface ICompanyRepository : IGenericRepository<Company>
{
}

public interface IJobOpeningRepository : IGenericRepository<JobOpening>
{
    Task<IReadOnlyList<JobOpening>> GetActiveJobsWithDetailsAsync();
}

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<Student?> GetByUserIdAsync(string userId);
}

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<bool> HasStudentAppliedAsync(int jobId, int studentId);
}
