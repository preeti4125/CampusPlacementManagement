using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Interfaces.Repositories;
using CampusPlacementManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CampusPlacementManagement.Infrastructure.Repositories;

public class CollegeRepository : GenericRepository<College>, ICollegeRepository
{
    public CollegeRepository(ApplicationDbContext context) : base(context) { }
    public async Task<College?> GetByCodeAsync(string collegeCode) =>
        await _dbSet.FirstOrDefaultAsync(c => c.CollegeCode == collegeCode);
}

public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
{
    public CompanyRepository(ApplicationDbContext context) : base(context) { }
}

public class JobOpeningRepository : GenericRepository<JobOpening>, IJobOpeningRepository
{
    public JobOpeningRepository(ApplicationDbContext context) : base(context) { }
    public async Task<IReadOnlyList<JobOpening>> GetActiveJobsWithDetailsAsync() =>
        await _dbSet.Include(j => j.Company).ToListAsync();
}

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(ApplicationDbContext context) : base(context) { }
    public async Task<Student?> GetByUserIdAsync(string userId) =>
        await _dbSet.Include(s => s.College).FirstOrDefaultAsync(s => s.UserId == userId);
}

public class JobApplicationRepository : GenericRepository<JobApplication>, IJobApplicationRepository
{
    public JobApplicationRepository(ApplicationDbContext context) : base(context) { }
    public async Task<bool> HasStudentAppliedAsync(int jobId, int studentId) =>
        await _dbSet.AnyAsync(a => a.JobId == jobId && a.StudentId == studentId);
}
